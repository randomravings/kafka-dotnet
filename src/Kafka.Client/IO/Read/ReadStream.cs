using Kafka.Client.Collections;
using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Model.Internal;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Kafka.Client.IO.Read
{
    internal abstract class ReadStream :
        IReadStream,
        IDisposable
    {
        private static readonly TimeSpan WAIT_INDEFINITELY = TimeSpan.FromMilliseconds(-1);

        private readonly List<ReadChannel> _channels = [];
        private readonly List<Task> _channelTasks = [];
        private readonly ConcurrentQueue<FetchResult> _recordQueue = new();
        private readonly ManualResetEventSlim _resetEvent = new(false);
        private readonly Stopwatch _stopwatch = new();
        private CancellationTokenSource _channelCts = new();
        private long _stateAltered = 1;
        private bool _disposed;

        protected readonly SortedSet<TopicPartition> _assignments = new(TopicPartitionCompare.Instance);
        protected readonly ICluster<INodeLink> _cluster;
        protected readonly ConcurrentDictionary<TopicPartition, Offset> _trackedOffsets = new(TopicPartitionCompare.Equality);
        protected readonly SortedSet<TopicPartition> _pausedTopicPartitions = new(TopicPartitionCompare.Instance);
        protected readonly ReadStreamConfig _config;
        protected readonly ILogger _logger;
        protected readonly int _sessionTimeoutMs;
        protected readonly int _maxPollIntervalMs;
        protected readonly IsolationLevel _isolationLevel;
        protected readonly AutoOffsetReset _autoOffsetReset;
        protected readonly SemaphoreSlim _semaphore = new(1, 1);

        protected ReadStream(
            ICluster<INodeLink> connectionManager,
            ReadStreamConfig config,
            ILogger logger
        )
        {
            _cluster = connectionManager;
            _sessionTimeoutMs = config.SessionTimeoutMs;
            _maxPollIntervalMs = config.MaxPollIntervalMs;
            _isolationLevel = config.IsolationLevel;
            _autoOffsetReset = config.AutoOffsetReset;
            _config = config;
            _logger = logger;
        }

        IReadOnlySet<TopicPartition> IReadStream.PausedPartitions =>
            _pausedTopicPartitions
        ;

        IReadOnlySet<TopicPartition> IReadStream.Assignments =>
            _assignments
        ;

        void IReadStream.PausePartitions(
            in IReadOnlyList<TopicPartition> partitions
        )
        {
            foreach (var topicPartition in partitions)
                _pausedTopicPartitions.Add(topicPartition);
        }

        void IReadStream.ResumePartitions(
            in IReadOnlyList<TopicPartition> partitions
        )
        {
            foreach (var topicPartition in partitions)
                _pausedTopicPartitions.Remove(topicPartition);
        }

        void IReadStream.UpdateOffset(
            in TopicPartition topicPartition,
            in Offset offset
         )
        {
            while (_trackedOffsets.TryGetValue(topicPartition, out var oldOffset) && offset > oldOffset)
                if (_trackedOffsets.TryUpdate(topicPartition, offset, oldOffset))
                    break;
        }

        void IReadStream.UpdateOffsets(
            in IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets)
        {
            foreach (var (topicPartition, offset) in topicPartitionOffsets)
                while (_trackedOffsets.TryGetValue(topicPartition, out var oldOffset) && offset > oldOffset)
                    if (_trackedOffsets.TryUpdate(topicPartition, offset, oldOffset))
                        break;
        }

        async Task IReadStream.Close(CancellationToken cancellationToken) =>
            await Closing(cancellationToken).ConfigureAwait(false)
        ;

        /// <inheritdoc/>
        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        async Task<IReadOnlyList<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>> IReadStream.Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        ) =>
            await Read(
                timeout,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<IReadOnlyList<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>> IReadStream.Read(
            CancellationToken cancellationToken
        ) =>
            await Read(
                WAIT_INDEFINITELY,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async Task<IReadOnlyList<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>> Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        )
        {
            while (true)
            {
                // Ensure configurtion before polling queue.
                if (Interlocked.Read(ref _stateAltered) == 1)
                {
                    _logger.InputStreamPreConfigure();
                    await ConfigureInputStream(
                        cancellationToken
                    ).ConfigureAwait(false);
                    _logger.InputStreamPostConfigure();
                }

                // Max poll interval test.
                var elapsed = _stopwatch.ElapsedMilliseconds;
                if (elapsed > _maxPollIntervalMs)
                    throw new TimeoutException($"Max poll time exceeded: {elapsed} ms");

                // Happy path Records have been queued.
                if (_recordQueue.TryDequeue(out var fetchResult))
                {
                    _stopwatch.Reset();
                    fetchResult.Callback.SetResult();
                    return fetchResult.Records;
                }

                // No records queued wait for signal or timeout.
                var signalled = _resetEvent.Wait(
                    timeout,
                    cancellationToken
                );
                _resetEvent.Reset();
                _stopwatch.Reset();

                // Timeout.
                if (!signalled)
                    return ImmutableArray<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>.Empty;
            }
        }

        protected void SignalStateAltered()
        {
            Interlocked.Exchange(ref _stateAltered, 1);
            _resetEvent.Set();
        }

        protected abstract ValueTask Closing(CancellationToken cancellationToken);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _channelCts.Dispose();
                    _semaphore.Dispose();
                    _resetEvent.Dispose();
                }
                _disposed = true;
            }
        }

        protected async ValueTask<INodeLink> GetCoordinator(
            CancellationToken cancellationToken
        )
        {
            var protocol = await _cluster.Controller(
                cancellationToken
            ).ConfigureAwait(false);
            var groupId = _config.GroupId ?? "";
            var request = new FindCoordinatorRequestData(
                groupId,
                (sbyte)CoordinatorType.GROUP,
                [groupId],
                []
            );
            var findCoordinatorResponse = await protocol.FindCoordinator(
            request,
                cancellationToken
            ).ConfigureAwait(false);
            var nodeId = findCoordinatorResponse.NodeIdField;
            if (findCoordinatorResponse.CoordinatorsField.Length > 0)
                nodeId = findCoordinatorResponse.CoordinatorsField[0].NodeIdField;
            return await _cluster.Connection(
                nodeId,
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async Task ConfigureInputStream(
            CancellationToken cancellationToken
        )
        {
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (Interlocked.Read(ref _stateAltered) == 0)
                    return;

                await _channelCts.CancelAsync().ConfigureAwait(false);
                await Task.WhenAll(
                    _channelTasks
                ).ConfigureAwait(false);

                _channelCts.Dispose();
                _channels.Clear();
                _recordQueue.Clear();
                _channelTasks.Clear();
                _trackedOffsets.Clear();

                var coordinator = await _cluster.Controller(
                    cancellationToken
                ).ConfigureAwait(false);

                var topicPartitionOffsets = await GetTopicPartitionOffsets(
                    cancellationToken
                ).ConfigureAwait(false);

                var missingOffsets = topicPartitionOffsets
                    .Where(r => r.Value.Offset == Offset.Unset)
                    .ToImmutableArray()
                ;

                if (_autoOffsetReset == AutoOffsetReset.None && missingOffsets.Length > 0)
                    throw new InvalidOperationException("Unset partitions found with auto.offset.reset=none");

                var assignments = GetTopicPartitionAssignments(
                    topicPartitionOffsets
                );

                _channelCts = new();
                foreach (var (nodeId, assignedTopicPartitionOffsets) in assignments)
                {
                    await CreateChannel(
                        nodeId,
                        assignedTopicPartitionOffsets,
                        cancellationToken
                    ).ConfigureAwait(false);
                }
                _stopwatch.Restart();
                Interlocked.Exchange(ref _stateAltered, 0);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private static IDictionary<NodeId, IDictionary<TopicPartition, Offset>> GetTopicPartitionAssignments(
            IDictionary<TopicPartition, LeaderAndOffset> topicPartitionDetails
        )
        {
            var brokerGrouping = topicPartitionDetails
                .GroupBy(k => k.Value.LeaderId)
            ;
            var topicPartitionAssignments = new Dictionary<NodeId, IDictionary<TopicPartition, Offset>>();
            foreach (var broker in brokerGrouping)
            {
                var topicPartitionOffsets = new Dictionary<TopicPartition, Offset>(TopicPartitionCompare.Equality);
                foreach (var (topicPartition, leaderAndOffset) in broker)
                    topicPartitionOffsets.Add(topicPartition, leaderAndOffset.Offset);
                topicPartitionAssignments.Add(broker.Key, topicPartitionOffsets);
            }
            return topicPartitionAssignments;
        }

        private async Task CreateChannel(
            NodeId nodeId,
            IDictionary<TopicPartition,Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var connection = await _cluster.Connection(
                nodeId,
                cancellationToken
            ).ConfigureAwait(false);

            await EnsureOffsets(
                connection,
                topicPartitionOffsets,
                cancellationToken
            ).ConfigureAwait(false);

            foreach (var (topicPartition, offset) in topicPartitionOffsets)
                _trackedOffsets.AddOrUpdate(
                    topicPartition,
                    k => offset,
                    (k, v) => offset
                );

            var channel = new ReadChannel(
                nodeId,
                _config,
                _logger
            );

            var topicPartitionStates = new ImmutableTopicPartitionMap<TopicPartitionReadState>(
                topicPartitionOffsets
                    .OrderBy(t => t.Key.Topic.TopicName.Value)
                    .ThenBy(p => p.Key.Partition.Value)
                    .Select(r => new KeyValuePair<TopicPartition, TopicPartitionReadState>(
                        r.Key,
                        new TopicPartitionReadState(r.Value))
                    )
                )
            ;

            _channels.Add(channel);
            _channelTasks.Add(channel.Run(
                connection,
                topicPartitionStates,
                _recordQueue,
                _resetEvent,
                _channelCts.Token
            ));
        }

        private static ListOffsetsRequestData CreateListOffsetsRequest(
            in ImmutableArray<KeyValuePair<TopicPartition, long>> topicPartitionTimestamps,
            in IsolationLevel isolationLevel
        )
        {
            if (topicPartitionTimestamps.Length == 0)
                return ListOffsetsRequestData.Empty;
            var listOffsetsTopics = topicPartitionTimestamps
                .GroupBy(g => g.Key.Topic.TopicName)
                .Select(t => new ListOffsetsRequestData.ListOffsetsTopic(
                    t.Key,
                    t.Select(p => new ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition(
                        p.Key.Partition.Value,
                        -1,
                        p.Value,
                        1,
                        []
                    ))
                    .ToImmutableArray(),
                    []
                ))
                .ToImmutableArray()
            ;
            return new ListOffsetsRequestData(
                -1,
                (sbyte)isolationLevel,
                listOffsetsTopics,
                []
            );
        }

        private async Task EnsureOffsets(
            INodeLink connection,
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var timestamp = _autoOffsetReset switch
            {
                AutoOffsetReset.Earliest => Offset.Beginning.Value,
                _ => Offset.End.Value
            };
            var missingOffsets = topicPartitionOffsets
                .Where(r => r.Value < 0)
                .Select(r => new KeyValuePair<TopicPartition, long>(r.Key, timestamp))
                .ToImmutableArray()
            ;
            if (missingOffsets.Length > 0)
            {
                var listOffsetsRequest = CreateListOffsetsRequest(
                    missingOffsets,
                    _isolationLevel
                );
                var listOffsetsResponse = await connection.ListOffsets(
                    listOffsetsRequest,
                    cancellationToken
                ).ConfigureAwait(false);
                UpdateTopicPartitionOffsets(
                    topicPartitionOffsets,
                    listOffsetsResponse
                );
            }
        }

        private static void UpdateTopicPartitionOffsets(
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            ListOffsetsResponseData offsetListResponse
        )
        {
            foreach (var topic in offsetListResponse.TopicsField)
            {
                foreach (var partition in topic.PartitionsField)
                {
                    var topicPartition = new TopicPartition(
                        topic.NameField,
                        partition.PartitionIndexField
                    );
                    topicPartitionOffsets[topicPartition] = partition.OffsetField;
                }
            }
        }

        protected readonly record struct LeaderAndOffset(
            NodeId LeaderId,
            Offset Offset
        );

        protected static async ValueTask<SortedSet<TopicPartition>> GetTopicPartitions(
            INodeLink connection,
            IReadOnlySet<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            var metadataRequest = new MetadataRequestData(
                topics.Select(t => new MetadataRequestData.MetadataRequestTopic(
                    Guid.Empty,
                    t,
                    []
                )).ToImmutableArray(),
                false,
                false,
                false,
                []
            );
            var metadataResponse = await connection.Metadata(
            metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);

            var topicPartitions = new SortedSet<TopicPartition>(TopicPartitionCompare.Instance);
            foreach (var topic in metadataResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    topicPartitions.Add(
                        new TopicPartition(
                            new Topic(
                                topic.TopicIdField,
                                topic.NameField
                            ),
                            new Partition(partition.PartitionIndexField)
                        )
                    );
            return topicPartitions;
        }

        protected static async ValueTask<IDictionary<TopicPartition, LeaderAndOffset>> GetTopicPartitionLeaders(
            INodeLink connection,
            IReadOnlySet<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        )
        {
            var metadataRequest = new MetadataRequestData(
                topicPartitions
                .GroupBy(g => g.Topic.TopicName)
                .Select(t => new MetadataRequestData.MetadataRequestTopic(
                    Guid.Empty,
                    t.Key,
                    []
                )).ToImmutableArray(),
                false,
                false,
                false,
                []
            );
            var metadataResponse = await connection.Metadata(
            metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);

            var topicPartitionLeaders = new Dictionary<TopicPartition, LeaderAndOffset>(TopicPartitionCompare.Equality);
            foreach (var topic in metadataResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    topicPartitionLeaders.Add(
                        new TopicPartition(
                            new Topic(
                                topic.TopicIdField,
                                topic.NameField
                            ),
                            new Partition(
                                partition.PartitionIndexField
                            )
                        ),
                        new LeaderAndOffset(
                            partition.LeaderIdField,
                            Offset.Unset
                        )
                    );
            return topicPartitionLeaders;
        }

        protected async ValueTask<ImmutableArray<TopicName>> CheckTopicList(
            IReadOnlySet<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            var metadataRequest = new MetadataRequestData(
                topics.Select(t => new MetadataRequestData.MetadataRequestTopic(
                    Guid.Empty,
                    t,
                    []
                )).ToImmutableArray(),
                false,
                false,
                false,
                []
            );
            var controller = await _cluster.Controller(
                cancellationToken
            ).ConfigureAwait(false);
            var metadataResponse = await  controller.Metadata(
                metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);

            var clusterTopics = metadataResponse
                .TopicsField
                .Select(r => new TopicName(r.NameField))
                .ToImmutableSortedSet(TopicNameCompare.Instance)
            ;
            return topics
                .Where(r => !clusterTopics.Contains(r))
                .ToImmutableArray()
            ;
        }

        protected bool IsTracked(
            in TopicPartition topicPartition,
            in Offset offset
        ) =>
            _trackedOffsets.TryGetValue(topicPartition, out var trackedOffset) &&
            offset <= trackedOffset
        ;

        protected abstract ValueTask<IDictionary<TopicPartition, LeaderAndOffset>> GetTopicPartitionOffsets(
            CancellationToken cancellationToken
        );
    }
}
