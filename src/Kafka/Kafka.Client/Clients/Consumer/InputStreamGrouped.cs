using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common;
using Kafka.Common.Exceptions;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class InputStreamGrouped<TKey, TValue> :
        InputStream<TKey, TValue>,
        IInputStreamAutoCommit<TKey, TValue>,
        IInputStreamManualCommit<TKey, TValue>
    {
        private readonly BlockingCollection<TopicPartitionOffset> _consumedRecords = new();
        private readonly IConnection _coordinatorConnection;
        private string _memberId = "";
        private int _generationId = 0;
        public InputStreamGrouped(
            IConnection coordinatorConnection,
            ImmutableArray<NodeAssignment> nodeAssignments,
            SortedList<TopicPartition, Offset> topicPartitionOffsets,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ConsumerConfig config,
            ILogger<IConsumer<TKey, TValue>> logger
        ) : base(
            nodeAssignments,
            topicPartitionOffsets,
            keyDeserializer,
            valueDeserializer,
            config,
            logger
        )
        {
            _coordinatorConnection = coordinatorConnection;
        }

        async ValueTask IInputStreamAutoCommit<TKey, TValue>.Commit(
            CancellationToken cancellationToken
        )
        {
            _consumedRecords.Add(new(new(TopicName.Empty, Partition.Unassigned), Offset.Unset), cancellationToken);
            await ValueTask.CompletedTask;
        }

        async ValueTask<CommitResult> IInputStreamManualCommit<TKey, TValue>.Commit(
            ConsumeResult<TKey, TValue> consumeResult,
            CancellationToken cancellationToken
        )
        {
            var topicPartitionOffset = new TopicPartitionOffset(
                consumeResult.TopicPartition,
                consumeResult.Offset
            );
            await ConsumerProtocol.RequestCommitOffset(
                _coordinatorConnection,
                _generationId,
                _memberId,
                _config,
                topicPartitionOffset,
                cancellationToken
            );
            return new();
        }

        async ValueTask<CommitResult> IInputStreamManualCommit<TKey, TValue>.Commit(
            TopicPartition topicPartition,
            Offset offset,
            CancellationToken cancellationToken
        )
        {
            var topicPartitionOffset = new TopicPartitionOffset(
                topicPartition,
                offset
            );
            await ConsumerProtocol.RequestCommitOffset(
                _coordinatorConnection,
                _generationId,
                _memberId,
                _config,
                topicPartitionOffset,
                cancellationToken
            );
            return new();
        }

        async ValueTask<CommitResult> IInputStreamManualCommit<TKey, TValue>.Commit(
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var topicPartitionOffsetList = _topicPartitionOffsets
                .Select(r => new TopicPartitionOffset(r.Key, r.Value))
            ;
            await ConsumerProtocol.RequestCommitOffsets(
                _coordinatorConnection,
                _generationId,
                _memberId,
                _config,
                topicPartitionOffsetList,
                cancellationToken
            );
            return new();
        }

        protected override void SetNextOffset(TopicPartition topicPartition, Offset offset)
        {
            base.SetNextOffset(topicPartition, offset);
            _consumedRecords.Add(new(topicPartition, offset));
        }

        protected override Task CreateHeartbeat(CancellationToken cancellationToken) =>
            Task.Run(async () => 
                await HeartBeatLoop(cancellationToken),
                CancellationToken.None
            )
        ;

        protected override Task CreateAutoCommit(CancellationToken cancellationToken) =>
            _config.EnableAutoCommit switch
            {
                true => Task.Run(async () =>
                    await CommitLoop(cancellationToken),
                    CancellationToken.None
                ),
                _ => Task.CompletedTask
            }
        ;

        protected override async ValueTask OnStart(CancellationToken cancellationToken)
        {
            var topicNames = _topicPartitionOffsets.Select(r => r.Key.Topic).Distinct();
            var response = await ConsumerProtocol.RequestJoinGroup(
                _coordinatorConnection,
                _memberId,
                topicNames,
                _config,
                cancellationToken
            );
            _generationId = response.GenerationIdField;
            _memberId = response.MemberIdField;
            if (response.ErrorCodeField == Errors.Known.MEMBER_ID_REQUIRED.Code)
            {
                response = await ConsumerProtocol.RequestJoinGroup(
                    _coordinatorConnection,
                    _memberId,
                    topicNames,
                    _config,
                    cancellationToken
                );
                _generationId = response.GenerationIdField;
                _memberId = response.MemberIdField;
            }
            if (response.ErrorCodeField != 0)
            {
                var error = Errors.Translate(response.ErrorCodeField);
                throw new ApiException(error);
            }

            var syncResponse = await ConsumerProtocol.RequestSyncGroup(
                _coordinatorConnection,
                _generationId,
                _memberId,
                response.ProtocolNameField,
                _topicPartitionOffsets.Keys,
                _config,
                cancellationToken
            );
        }

        protected override async ValueTask OnStop(CancellationToken cancellationToken)
        {
            try
            {
                var response = await ConsumerProtocol.RequestLeaveGroup(
                    _coordinatorConnection,
                    _memberId,
                    _config,
                    cancellationToken
                );
                if (response.ErrorCodeField != 0)
                {
                    var error = Errors.Translate(response.ErrorCodeField);
                    _logger.LogError("Error during leave group {err}", error);
                }
                else
                {
                    _logger.LogInformation("Left group sucessfully");
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception during leave group {err}", ex);
            }
        }

        private async Task HeartBeatLoop(
            CancellationToken cancellationToken
        )
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                cancellationToken.WaitHandle.WaitOne(_config.HeartbeatIntervalMs);
                try
                {
                    var response = await ConsumerProtocol.RequestHeartbeat(
                        _coordinatorConnection,
                        _memberId,
                        _generationId,
                        _config,
                        cancellationToken
                    );
                    if (response.ErrorCodeField != 0)
                    {
                        var error = Errors.Translate(response.ErrorCodeField);
                        _logger.LogWarning("{error}", error);
                    }
                }
                catch (OperationCanceledException) { }
                catch (Exception ex)
                {
                    _logger.LogCritical("{ex}", ex);
                }
            }
        }

        private async Task CommitLoop(
            CancellationToken cancellationToken
        )
        {
            var commitState = new SortedList<TopicPartition, TopicPartitionOffset>(TopicPartitionCompare.Instance);
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    using var lts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                    if (_config.EnableAutoCommit)
                        lts.CancelAfter(_config.AutoCommitIntervalMs);
                    while (!lts.IsCancellationRequested)
                    {
                        var topicPartitionOffset = _consumedRecords.Take(lts.Token);
                        if (topicPartitionOffset.Offset == Offset.Unset)
                            break;
                        commitState[topicPartitionOffset.TopicPartition] = topicPartitionOffset;
                    }
                }
                catch (OperationCanceledException) { }

                // Noting to commit.
                if (commitState.Count == 0)
                    continue;

                // If cancelled try for 5 seconds to commit.
                var commitToken = cancellationToken;
                if (commitToken.IsCancellationRequested)
                    commitToken = new CancellationTokenSource(5000).Token;

                try
                {
                    var response = await ConsumerProtocol.RequestCommitOffsets(
                        _coordinatorConnection,
                        _generationId,
                        _memberId,
                        _config,
                        commitState.Values,
                        commitToken
                    );
                    var anyErrors = response
                        .TopicsField
                        .SelectMany(r => r.PartitionsField)
                        .Where(r => r.ErrorCodeField != 0)
                        .Any()
                    ;
                    if (!anyErrors)
                    {
                        commitState.Clear();
                        continue;
                    }
                    foreach (var topic in response.TopicsField)
                    {
                        foreach (var partition in topic.PartitionsField)
                        {
                            var topicPartition = new TopicPartition(topic.NameField, partition.PartitionIndexField);
                            if (partition.ErrorCodeField == 0)
                            {
                                commitState.Remove(topicPartition);
                            }
                            else
                            {
                                var error = Errors.Translate(partition.ErrorCodeField);
                                _logger.LogError("{error}", error);
                            }
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    _logger.LogWarning("Commit was interrupted");
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Commit Loop exception: {ex}", ex);
                }
            }
            _logger.LogWarning("Commit loop exited");
        }
    }
}
