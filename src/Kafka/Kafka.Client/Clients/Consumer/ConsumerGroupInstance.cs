using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class ConsumerGroupInstance :
        IConsumerGroupInstance
    {
        private readonly IConnection _coordinatorConnection;
        private readonly ConsumerConfig _config;
        private readonly ILogger _logger;
        private long _state = (long)CoordinatorState.None;
        private readonly CancellationTokenSource _localCts = new();

        private Task _heartbeat = Task.CompletedTask;
        private Task _committer = Task.CompletedTask;

        private readonly string _memberId = "";
        private readonly int _generationId = 0;

        private readonly ImmutableArray<NodeAssignment> _nodeAssignments;
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private readonly IDictionary<TopicPartition, Offset> _topicPartitionOffsets;

        public ConsumerGroupInstance(
            string memberId,
            int generationId,
            IConnection coordinatorConnection,
            ImmutableArray<NodeAssignment> nodeAssignments,
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            ConsumerConfig config,
            ILogger logger
        )
        {
            _memberId = memberId;
            _generationId = generationId;
            _coordinatorConnection = coordinatorConnection;
            _nodeAssignments = nodeAssignments;
            _topicPartitionOffsets = topicPartitionOffsets;
            _config = config;
            _logger = logger;
            _state = (long)CoordinatorState.Created;
        }

        IDictionary<TopicPartition, Offset> IConsumerGroupInstance.ReadOffsets => _topicPartitionOffsets;

        CoordinatorState IConsumerGroupInstance.State => (CoordinatorState)Interlocked.Read(ref _state);

        ImmutableArray<NodeAssignment> IConsumerGroupInstance.NodeAssignments => _nodeAssignments;

        CancellationToken IConsumerGroupInstance.CancellationToken => _localCts.Token;

        private async Task HeartbeatLoop(
            IConnection coordinatorConnection,
            CancellationToken cancellationToken
        )
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(_config.HeartbeatIntervalMs, cancellationToken);
                    var response = await ConsumerProtocol.Heartbeat(
                        coordinatorConnection,
                        _generationId,
                        _memberId,
                        _config,
                        cancellationToken
                    );
                    if (response.ErrorCodeField != 0)
                    {
                        var error = Errors.Translate(response.ErrorCodeField);
                        _logger.LogWarning("Heartbeat: {error}", error);

                        if (error.Code == Errors.Known.REBALANCE_IN_PROGRESS.Code)
                            SetState(CoordinatorState.Rebalancing);
                        _localCts.Cancel();
                    }
                }
                catch (OperationCanceledException) { }
                catch (Exception ex)
                {
                    _logger.LogCritical("{ex}", ex);
                }
            }
            _logger.LogInformation("Heartbeat loop exited");
        }

        private void SetState(CoordinatorState reason) =>
            Interlocked.Exchange(ref _state, (long)reason)
        ;

        private readonly ManualResetEventSlim _manualResetEventSlim = new();

        private async Task CommitLoop(
            IConnection coordinatorConnection,
            CancellationToken cancellationToken
        )
        {
            var commitedOffsets = new SortedList<TopicPartition, Offset>(TopicPartitionCompare.Instance);
            foreach (var topicPartitionOffset in _topicPartitionOffsets)
                commitedOffsets.Add(topicPartitionOffset.Key, topicPartitionOffset.Value);
            while (!cancellationToken.IsCancellationRequested)
            {
                _manualResetEventSlim.Wait(_config.AutoCommitIntervalMs, cancellationToken);
                await DoCommit(
                    coordinatorConnection,
                    commitedOffsets,
                    cancellationToken
                );
            }
            // Try committing lingering offsets if any.
            using var lts = new CancellationTokenSource(5000);
            await DoCommit(
                coordinatorConnection,
                commitedOffsets,
                lts.Token
            );
            _logger.LogInformation("Commit loop exited");
        }

        private async Task<IEnumerable<TopicPartitionOffset>> DoCommit(
            IConnection coordinatorConnection,
            IDictionary<TopicPartition, Offset> comittedOffsets,
            CancellationToken cancellationToken
        )
        {
            var offsets = new List<TopicPartitionOffset>(comittedOffsets.Count);
            foreach (var topicPartitionOffset in comittedOffsets)
            {
                var currentOffset = _topicPartitionOffsets[topicPartitionOffset.Key];
                if (currentOffset.Value > topicPartitionOffset.Value)
                    offsets.Add(new(topicPartitionOffset.Key, currentOffset));
            }
            if (offsets.Count == 0)
                return Enumerable.Empty<TopicPartitionOffset>();
            try
            {
                var response = await ConsumerProtocol.CommitOffsets(
                    coordinatorConnection,
                    _generationId,
                    _memberId,
                    offsets,
                    _config,
                    cancellationToken
                );
                var anyErrors = response
                    .TopicsField
                    .SelectMany(r => r.PartitionsField)
                    .Where(r => r.ErrorCodeField != 0)
                    .Any()
                ;
                // Happy path.
                if (!anyErrors)
                    return offsets;

                // Tedious path.
                foreach (var topic in response.TopicsField)
                {
                    foreach (var partition in topic.PartitionsField)
                    {
                        var topicPartition = new TopicPartition(topic.NameField, partition.PartitionIndexField);
                        if (partition.ErrorCodeField != 0)
                        {
                            var error = Errors.Translate(partition.ErrorCodeField);
                            _logger.LogError("Commit {topic}:{partition}:{error}", topic.NameField, partition.PartitionIndexField, error);
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogTrace("Commit was cancelled");
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Commit exception: {ex}", ex);
            }
            return Enumerable.Empty<TopicPartitionOffset>();
        }

        private async Task EnsureStopped()
        {
            if (!_localCts.IsCancellationRequested)
                _localCts.Cancel();
            await Task.WhenAll(_heartbeat, _committer);
        }

        void IConsumerGroupInstance.AddOffset(TopicPartition topicPartition, Offset offset) =>
            _topicPartitionOffsets[topicPartition] = offset
        ;

        Task<CommitResult> IConsumerGroupInstance.Commit()
        {
            _manualResetEventSlim.Set();
            return Task.FromResult(new CommitResult());
        }

        Task<CommitResult> IConsumerGroupInstance.Commit(TopicPartition topicPartition, Offset offset)
        {
            throw new NotImplementedException();
        }

        async Task IConsumerGroupInstance.Close(CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                await EnsureStopped();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        async Task IConsumerGroupInstance.Start(CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                var state = (CoordinatorState)_state;
                switch (state)
                {
                    case CoordinatorState.Created:
                        _heartbeat = Task.Run(() => HeartbeatLoop(_coordinatorConnection, _localCts.Token), CancellationToken.None);
                        _committer = Task.Run(() => CommitLoop(_coordinatorConnection, _localCts.Token), CancellationToken.None);
                        _state = (long)CoordinatorState.Consuming;
                        break;
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
