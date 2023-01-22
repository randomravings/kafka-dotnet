using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Common;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Threading;

namespace Kafka.Client.Clients.Consumer
{
    internal abstract class InputStream<TKey, TValue> :
        IInputStream<TKey, TValue>
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        protected readonly ImmutableArray<NodeAssignment> _nodeAssignment;
        protected readonly ConsumerConfig _config;
        protected readonly ILogger<IConsumer<TKey, TValue>> _logger;
        protected readonly SemaphoreSlim _semaphore = new(1, 1);
        protected readonly ConcurrentDictionary<TopicPartition, Offset> _topicPartitionOffsets;
        protected readonly ConcurrentQueue<ConsumeResult> _queue = new();

        protected InputStream(
            ImmutableArray<NodeAssignment> nodeAssignments,
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ConsumerConfig config,
            ILogger<IConsumer<TKey, TValue>> logger
        )
        {
            _nodeAssignment = nodeAssignments;
            _topicPartitionOffsets = new(topicPartitionOffsets);
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            _config = config;
            _logger = logger;
        }

        async IAsyncEnumerator<ConsumeResult<TKey, TValue>> IAsyncEnumerable<ConsumeResult<TKey, TValue>>.GetAsyncEnumerator(
            CancellationToken cancellationToken
        )
        {
            await _semaphore.WaitAsync(cancellationToken);
            var heartbeat = Task.CompletedTask;
            var committer = Task.CompletedTask;
            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            try
            {
                await OnStart(linkedCts.Token);
                heartbeat = CreateHeartbeat(linkedCts.Token);
                committer = CreateAutoCommit(linkedCts.Token);
            }
            catch (Exception ex)
            {
                _logger.LogError("On Start up: {ex}", ex);
                linkedCts.Cancel();
            }

            while (!linkedCts.IsCancellationRequested)
            {
                if (_queue.TryDequeue(out var result))
                {
                    SetNextOffset(result.TopicPartition, result.Offset + 1);
                    if (result is ConsumeResult<TKey, TValue> consumeResult)
                        yield return consumeResult;
                }
                else
                {
                    try
                    {
                        var fetchResponses = await FetchFromNodes(linkedCts.Token);
                        foreach (var fetchedResponse in fetchResponses)
                            foreach (var item in EnumerateFetchResponse(fetchedResponse))
                                _queue.Enqueue(item);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("{ex}", ex);
                        linkedCts.Cancel();
                    }
                }

            }
            await HandleShupDown(
                heartbeat,
                committer
            );
            _semaphore.Release();
        }

        private async ValueTask HandleShupDown(
            Task heartbeat,
            Task committer
        )
        {
            var cts = new CancellationTokenSource(5000);
            await OnStop(cts.Token);
            await Task.WhenAll(committer, heartbeat);
        }

        private async ValueTask<ImmutableArray<FetchResponse>> FetchFromNodes(
            CancellationToken cancellationToken
        )
        {
            var fetchTasks = Array.Empty<Task<FetchResponse>>();
            try
            {
                fetchTasks = _nodeAssignment.Select(r =>
                    Fetch(r, cancellationToken)
                ).ToArray();
                await Task.WhenAll(fetchTasks);
                return fetchTasks.Select(r => r.Result).ToImmutableArray();
            }
            catch (OperationCanceledException)
            {
                return ImmutableArray<FetchResponse>.Empty;
            }
            catch (Exception)
            {
                foreach (var task in fetchTasks)
                {
                    if (task.IsFaulted)
                        _logger.LogError("{ex}", task.Exception);
                }
                return fetchTasks.Where(r => !r.IsFaulted).Select(r => r.Result).ToImmutableArray();
            }
        }


        protected virtual void SetNextOffset(TopicPartition topicPartition, Offset offset) =>
            _topicPartitionOffsets.AddOrUpdate(topicPartition, offset, (tp, o) => offset)
        ;

        protected virtual Task CreateHeartbeat(CancellationToken cancellationToken) =>
            Task.CompletedTask
        ;

        protected virtual Task CreateAutoCommit(CancellationToken cancellationToken) =>
            Task.CompletedTask
        ;

        protected virtual ValueTask OnStart(CancellationToken cancellationToken) => ValueTask.CompletedTask;
        protected virtual ValueTask OnStop(CancellationToken cancellationToken) => ValueTask.CompletedTask;

        private Task<FetchResponse> Fetch(
            NodeAssignment nodeAssignment,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var requests = CreateFetchRequest(
                    nodeAssignment.TopicPartitionsLookup,
                    _topicPartitionOffsets
                ) with
                {
                    MaxVersion = 11
                };
                return nodeAssignment.Connection.ExecuteRequest(
                    requests,
                    FetchRequestSerde.Write,
                    FetchResponseSerde.Read,
                    cancellationToken
                );
            }
            catch (OperationCanceledException) { }
            return Task.FromResult(FetchResponse.Empty);
        }

        private static FetchRequest CreateFetchRequest(
            ImmutableSortedDictionary<TopicName, ImmutableArray<TopicPartition>> topicPartitions,
            ConcurrentDictionary<TopicPartition, Offset> topicPartitionOffsets
        )
        {
            var fetchTopics = topicPartitions
                .Select(t =>
                    new FetchRequest.FetchTopic(
                        t.Key,
                        Guid.Empty,
                        t.Value.Select(tp =>
                            new FetchRequest.FetchTopic.FetchPartition(
                                PartitionField: tp.Partition,
                                CurrentLeaderEpochField: -1,
                                FetchOffsetField: topicPartitionOffsets[tp],
                                LastFetchedEpochField: -1,
                                LogStartOffsetField: -1,
                                PartitionMaxBytesField: 1048576
                            )
                        )
                        .ToImmutableArray()
                    )
                )
                .ToImmutableArray()
            ;

            return new FetchRequest(
                ClusterIdField: null,
                ReplicaIdField: -1,
                MaxWaitMsField: 500,
                MinBytesField: 1,
                MaxBytesField: 52428800,
                IsolationLevelField: 1,
                SessionIdField: -1,
                SessionEpochField: -1,
                TopicsField: fetchTopics,
                ForgottenTopicsDataField: ImmutableArray<FetchRequest.ForgottenTopic>.Empty,
                RackIdField: ""
            );
        }

        private IEnumerable<ConsumeResult> EnumerateFetchResponse(
            FetchResponse fetchResponse
        )
        {
            foreach (var response in fetchResponse.ResponsesField)
                foreach (var consumeResult in EnumerateTopic(response))
                    yield return consumeResult;

        }

        private IEnumerable<ConsumeResult> EnumerateTopic(
            FetchResponse.FetchableTopicResponse topic
        )
        {
            foreach (var partition in topic.PartitionsField)
                if (partition.ErrorCodeField == 0)
                    foreach (var consumeResult in EnumeratePartition(topic.TopicField, partition))
                        yield return consumeResult;
                else
                    _logger.LogError("{error}", Errors.Translate(partition.ErrorCodeField));
        }

        private IEnumerable<ConsumeResult> EnumeratePartition(
            string topicName,
            FetchResponse.FetchableTopicResponse.PartitionData partition
        )
        {
            if (partition.RecordsField == null)
                yield break;
            var topicPartition = new TopicPartition(topicName, partition.PartitionIndexField);
            foreach (var records in partition.RecordsField)
            {
                var offset = records.Offset;
                var lastStableOffset = partition.LastStableOffsetField;
                var logStartOffset = partition.LogStartOffsetField;
                var highWatermark = partition.HighWatermarkField;
                if (records.IsControlBatch)
                {
                    var controlRecord = records.ControlRecord;
                    yield return new ControlResult(
                        topicPartition,
                        offset,
                        lastStableOffset,
                        logStartOffset,
                        highWatermark,
                        Errors.Known.NONE,
                        new Models.ControlRecord(
                            controlRecord.Type,
                            controlRecord.Version
                        )
                    );
                    continue;
                }
                foreach (var record in records)
                {
                    var consumeResult = default(ConsumeResult<TKey, TValue>);
                    offset += record.OffsetDelta;
                    var timestamp = records.BaseTimestamp + record.TimestampDelta;
                    var key = _keyDeserializer.Read(record.Key);
                    var value = _valueDeserializer.Read(record.Value);
                    consumeResult = new ConsumeResult<TKey, TValue>(
                        TopicPartition: topicPartition,
                        Offset: offset,
                        LastStableOffset: lastStableOffset,
                        LogStartOffset: logStartOffset,
                        HighWatermark: highWatermark,
                        Errors.Known.NONE,
                        Record: new(
                            Timestamp: records.Attributes.HasFlag(Attributes.LogAppendTime) ? Timestamp.LogAppend(timestamp) : Timestamp.Created(timestamp),
                            Headers: record.Headers,
                            Key: key,
                            Value: value
                        )
                    );
                    yield return consumeResult;
                }
            }
        }
    }
}
