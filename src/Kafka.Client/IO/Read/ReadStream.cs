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
using System.Net.Http.Headers;

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
                (sbyte)CoordinatorType.Group,
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

                var coordinator = await _cluster.Controller(
                    cancellationToken
                ).ConfigureAwait(false);

                await UpdateTrackedOffsets(
                    _trackedOffsets,
                    cancellationToken
                ).ConfigureAwait(false);

                var missingOffsets = _trackedOffsets
                    .Where(r => r.Value == Offset.Unset)
                    .ToImmutableArray()
                ;

                if (_autoOffsetReset == AutoOffsetReset.None && missingOffsets.Length > 0)
                    throw new InvalidOperationException("Unset partitions found with auto.offset.reset=none");

                var assignments = await GetTopicPartitionAssignments(
                    _trackedOffsets,
                    cancellationToken
                ).ConfigureAwait(false);

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

        private async Task<Dictionary<NodeId, IDictionary<TopicPartition, Offset>>> GetTopicPartitionAssignments(
            IDictionary<TopicPartition, Offset> topicPartitions,
            CancellationToken cancellationToken
        )
        {
            var controller = await _cluster.Controller(
                cancellationToken
            ).ConfigureAwait(false);

            var metadataRequest = new MetadataRequestData(
                topicPartitions.Select(r => new MetadataRequestData.MetadataRequestTopic(
                    r.Key.Topic.TopicId,
                    r.Key.Topic.TopicName,
                    []
                ))
                .ToImmutableArray(),
                false,
                false,
                false,
                []
            );

            var metadataResponse = await controller.Metadata(
                metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);

            var topicPartitionAssignments = new Dictionary<NodeId, IDictionary<TopicPartition, Offset>>();
            foreach (var topic in metadataResponse.TopicsField)
            {
                foreach (var partition in topic.PartitionsField)
                {
                    var topicPartition = new TopicPartition(new Topic(topic.TopicIdField, topic.NameField), partition.PartitionIndexField);
                    if (!topicPartitions.TryGetValue(topicPartition, out var offset))
                        continue;
                    if (!topicPartitionAssignments.TryGetValue(partition.LeaderIdField, out var topicPartitionAssignment))
                    {
                        topicPartitionAssignment = new Dictionary<TopicPartition, Offset>(TopicPartitionCompare.Equality);
                        topicPartitionAssignments.Add(partition.LeaderIdField, topicPartitionAssignment);
                    }
                    topicPartitionAssignment.Add(topicPartition, offset);
                }
            }
            return topicPartitionAssignments;
        }

        private async Task CreateChannel(
            NodeId nodeId,
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
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
            var missingOffsets = topicPartitionOffsets
                .Where(r => r.Value < 0)
                .Select(r => new KeyValuePair<TopicPartition, long>(
                    r.Key,
                    TimestampFromOffset(
                        r.Value,
                        _autoOffsetReset
                    )
                ))
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

        private static long TimestampFromOffset(
            in Offset offset,
            in AutoOffsetReset autoOffsetReset
        )
        {
            if (offset == Offset.Beginning || offset == Offset.End)
                return offset;
            return autoOffsetReset switch
            {
                AutoOffsetReset.Earliest => Offset.Beginning.Value,
                _ => Offset.End.Value
            };
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
            IReadOnlySet<Topic> topics,
            CancellationToken cancellationToken
        )
        {
            var metadataRequest = new MetadataRequestData(
                topics.Select(t => new MetadataRequestData.MetadataRequestTopic(
                    t.TopicId,
                    t.TopicName,
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

        protected async ValueTask<ImmutableArray<Topic>> CheckTopicList(
            IEnumerable<Topic> topics,
            CancellationToken cancellationToken
        )
        {
            var topicSet = topics.ToImmutableSortedSet(TopicCompare.Instance);
            var metadataRequest = new MetadataRequestData(
                topicSet.Select(t => new MetadataRequestData.MetadataRequestTopic(
                    t.TopicId,
                    t.TopicName,
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
            var metadataResponse = await controller.Metadata(
                metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);

            var clusterTopics = metadataResponse
                .TopicsField
                .Select(r => new Topic(r.TopicIdField, r.NameField))
                .ToImmutableSortedSet(TopicCompare.Instance)
            ;
            return topicSet
                .Where(r => !clusterTopics.Contains(r))
                .ToImmutableArray()
            ;
        }

        protected async ValueTask<ImmutableArray<TopicPartitionOffset>> CheckTopicPartitionOffsetList(
            IEnumerable<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var topicPartitionOffsetArray = topicPartitionOffsets
                .ToImmutableSortedDictionary(
                    k => k.TopicPartition,
                    v => v.Offset,
                    TopicPartitionCompare.Instance
                )
            ;
            var missingOrBadTopicPartitionOffsets = ImmutableArray.CreateBuilder<TopicPartitionOffset>();
            var metadataRequest = new MetadataRequestData(
                topicPartitionOffsetArray
                .GroupBy(g => g.Key.Topic, TopicCompare.Equality)
                .Select(t => new MetadataRequestData.MetadataRequestTopic(
                    t.Key.TopicId,
                    t.Key.TopicName,
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
            var metadataResponse = await controller.Metadata(
                metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);

            var clusterTopics = metadataResponse
                .TopicsField
                .SelectMany(t => t.PartitionsField
                    .Select(p => new TopicPartition(
                        new Topic(
                            t.TopicIdField,
                            t.NameField
                        ),
                        new Partition(p.PartitionIndexField)
                    ))
                )
                .ToImmutableSortedSet(TopicPartitionCompare.Instance)
            ;
            var missingTopicPartitions = topicPartitionOffsetArray
                .Where(r => !clusterTopics.Contains(r.Key))
                .ToImmutableArray()
            ;
            foreach (var (topicPartition, offset) in topicPartitionOffsetArray)
                if (!clusterTopics.Contains(topicPartition))
                    missingOrBadTopicPartitionOffsets.Add(new(topicPartition, offset));

            if (missingOrBadTopicPartitionOffsets.Count > 0)
                return missingOrBadTopicPartitionOffsets.ToImmutable();

            var assignments = await GetTopicPartitionAssignments(
                topicPartitionOffsetArray,
                cancellationToken
            ).ConfigureAwait(false);

            var tasks = assignments.Select(r => Task.Run(async () =>
            {
                var connection = await _cluster.Connection(
                    r.Key,
                    cancellationToken
                ).ConfigureAwait(false);
                var listOffsetsLow = r
                    .Value
                    .GroupBy(g => g.Key.Topic, TopicCompare.Equality)
                    .Select(t => new ListOffsetsRequestData.ListOffsetsTopic(
                        t.Key.TopicName,
                        t.Select(p => new ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition(
                            p.Key.Partition,
                            -1,
                            -1,
                            1,
                            []
                        )).ToImmutableArray(),
                        []
                    ))
                    .ToImmutableArray()
                ;

                var listOffsetLowRequest = new ListOffsetsRequestData(
                    -1,
                    (sbyte)_isolationLevel,
                    listOffsetsLow,
                    []
                );

                var listOffsetLowReponse = await connection.ListOffsets(
                    listOffsetLowRequest,
                    cancellationToken
                ).ConfigureAwait(false);

                var listOffsetsHigh = r
                    .Value
                    .GroupBy(g => g.Key.Topic, TopicCompare.Equality)
                    .Select(t => new ListOffsetsRequestData.ListOffsetsTopic(
                        t.Key.TopicName,
                        t.Select(p => new ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition(
                            p.Key.Partition,
                            -1,
                            -2,
                            1,
                            []
                        )).ToImmutableArray(),
                        []
                    ))
                    .ToImmutableArray()
                ;

                var listOffsetHighRequest = new ListOffsetsRequestData(
                    -1,
                    (sbyte)_isolationLevel,
                    listOffsetsHigh,
                    []
                );

                var listOffsetHighReponse = await connection.ListOffsets(
                    listOffsetHighRequest,
                    cancellationToken
                ).ConfigureAwait(false);

                var builder = ImmutableArray.CreateBuilder<KeyValuePair<TopicPartition, (Offset Low, Offset High)>>();
                for (int i = 0; i < listOffsetLowReponse.TopicsField.Length; i++)
                {
                    var topicLow = listOffsetLowReponse.TopicsField[i];
                    var topicHigh = listOffsetHighReponse.TopicsField[i];
                    var topic = new Topic(Guid.Empty, topicLow.NameField);
                    for (int j = 0; j < topicLow.PartitionsField.Length; j++)
                    {
                        var low = topicLow.PartitionsField[j];
                        var high = topicHigh.PartitionsField[j];
                        var topicPartition = new TopicPartition(topic, low.PartitionIndexField);
                        builder.Add(new KeyValuePair<TopicPartition, (Offset Low, Offset High)>(
                            topicPartition, (low.OffsetField, high.OffsetField)
                        ));
                    }
                }
                return builder.ToImmutable();
            }));
            var lists = await Task.WhenAll(tasks).ConfigureAwait(false);
            var watermarks = lists
                .SelectMany(r => r)
                .OrderBy(r => r.Key, TopicPartitionCompare.Instance)
                .ToImmutableArray()
            ;

            for (int i = 0; i < topicPartitionOffsetArray.Count; i++)
            {
                var (topicPartition, (low, high)) = watermarks[i];
                topicPartitionOffsetArray.TryGetKey(topicPartition, out topicPartition);
                var offset = topicPartitionOffsetArray[topicPartition];
                if (offset == Offset.Unset || offset == Offset.Beginning || offset == Offset.End)
                    continue;
                if (offset < low || offset > high + 1)
                    missingOrBadTopicPartitionOffsets.Add(new(topicPartition, offset));
            }
            return missingOrBadTopicPartitionOffsets.ToImmutable();
        }

        protected bool IsTracked(
            in TopicPartition topicPartition,
            in Offset offset
        ) =>
            _trackedOffsets.TryGetValue(topicPartition, out var trackedOffset) &&
            offset <= trackedOffset
        ;

        protected abstract ValueTask UpdateTrackedOffsets(
            ConcurrentDictionary<TopicPartition, Offset> trackedOffsets,
            CancellationToken cancellationToken
        );
    }
}
