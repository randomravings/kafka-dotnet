using Kafka.Client.Collections;
using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Kafka.Client.IO.Stream
{
    internal abstract class InputStream :
        IInputStream,
        IDisposable
    {
        private static readonly TimeSpan WAIT_INDEFINITELY = TimeSpan.FromMilliseconds(-1);

        private readonly List<InputChannel> _channels = [];
        private readonly List<Task> _channelTasks = [];
        private readonly ConcurrentQueue<FetchResult> _recordQueue = new();
        private readonly ManualResetEventSlim _resetEvent = new(false);
        private readonly Stopwatch _stopwatch = new();
        private CancellationTokenSource _channelCts = new();
        private long _stateAltered = 1;
        private bool _disposed;

        protected readonly TopicPartitionSet _assignmentList = [];
        protected readonly ICluster<IClientConnection> _connectionManager;
        protected readonly TopicPartitionMap<Offset> _trackedOffsets = [];
        protected readonly TopicPartitionSet _pausedTopicPartitions = [];
        protected readonly InputStreamConfig _config;
        protected readonly ILogger _logger;
        protected readonly int _sessionTimeoutMs;
        protected readonly int _maxPollIntervalMs;
        protected readonly IsolationLevel _isolationLevel;
        protected readonly AutoOffsetReset _autoOffsetReset;
        protected readonly SemaphoreSlim _semaphore = new(1, 1);

        protected InputStream(
            ICluster<IClientConnection> connectionManager,
            InputStreamConfig config,
            ILogger logger
        )
        {
            _connectionManager = connectionManager;
            _sessionTimeoutMs = config.SessionTimeoutMs;
            _maxPollIntervalMs = config.MaxPollIntervalMs;
            _isolationLevel = config.IsolationLevel;
            _autoOffsetReset = config.AutoOffsetReset;
            _config = config;
            _logger = logger;
        }

        IStreamReaderBuilder IInputStream.CreateReader() =>
            new StreamReaderBuilder(
                this
            )
        ;

        IReadOnlySet<TopicPartition> IInputStream.TopicPartitions()
        {
            throw new NotImplementedException();
        }

        IReadOnlySet<TopicPartition> IInputStream.PausedPartitions() =>
            _pausedTopicPartitions.CopyItems().ToImmutableSortedSet(TopicPartitionCompare.Instance)
        ;

        void IInputStream.PausePartitions(
            in IReadOnlyList<TopicPartition> partitions
        )
        {
            foreach (var topicPartition in partitions)
                _pausedTopicPartitions.Add(topicPartition);
        }

        void IInputStream.ResumePartitions(
            in IReadOnlyList<TopicPartition> partitions
        )
        {
            foreach (var topicPartition in partitions)
                _pausedTopicPartitions.Remove(topicPartition, out _);
        }

        void IInputStream.UpdateOffsets(
            in TopicPartition topicPartition,
            in Offset offset
         ) =>
            _trackedOffsets.Set(topicPartition, offset)
        ;

        void IInputStream.UpdateOffsets(
            in IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets)
        {
            foreach (var (topicPartition, offset) in topicPartitionOffsets)
                _trackedOffsets.Set(topicPartition, offset);
        }

        async Task IInputStream.Close(CancellationToken cancellationToken) =>
            await Closing(cancellationToken).ConfigureAwait(false)
        ;

        /// <inheritdoc/>
        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        async Task<IReadOnlyList<InputRecord>> IInputStream.Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        ) =>
            await Read(
                timeout,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<IReadOnlyList<InputRecord>> IInputStream.Read(
            CancellationToken cancellationToken
        ) =>
            await Read(
                WAIT_INDEFINITELY,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async Task<IReadOnlyList<InputRecord>> Read(
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
                    return ImmutableArray<InputRecord>.Empty;
            }
        }

        protected void SignalStateAltered()
        {
            Interlocked.Exchange(ref _stateAltered, 1);
            _resetEvent.Set();
        }

        protected abstract ValueTask Closing(CancellationToken cancellationToken);

        protected bool IsTracked(
            in TopicPartition topicPartition,
            in Offset offset
        ) =>
            _trackedOffsets.Get(topicPartition, out var trackedOffset) ||
            offset <= trackedOffset
        ;

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

        protected async ValueTask<IClientConnection> GetCoordinator(
            CancellationToken cancellationToken
        )
        {
            var protocol = await _connectionManager.Controller(
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
            return await _connectionManager.Connection(
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

                var coordinator = await _connectionManager.Controller(
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

        private static ClusterNodeDictionary<TopicPartitionMap<Offset>> GetTopicPartitionAssignments(
            TopicPartitionMap<LeaderAndOffset> topicPartitionDetails
        )
        {
            var items = topicPartitionDetails.CopyItems();
            var brokerGrouping = items
                .GroupBy(k => k.Value.LeaderId)
            ;
            var topicPartitionAssignments = new ClusterNodeDictionary<TopicPartitionMap<Offset>>();
            foreach (var broker in brokerGrouping)
            {
                var topicPartitionOffsets = new TopicPartitionMap<Offset>();
                foreach (var (topicPartition, leaderAndOffset) in broker)
                    topicPartitionOffsets.Add(topicPartition, leaderAndOffset.Offset);
                topicPartitionAssignments.Add(broker.Key, topicPartitionOffsets);
            }
            return topicPartitionAssignments;
        }

        private async Task CreateChannel(
            ClusterNodeId nodeId,
            TopicPartitionMap<Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var connection = await _connectionManager.Connection(
                nodeId,
                cancellationToken
            ).ConfigureAwait(false);

            await EnsureOffsets(
                connection,
                topicPartitionOffsets,
                cancellationToken
            ).ConfigureAwait(false);

            foreach (var (topicPartition, offset) in topicPartitionOffsets)
                _trackedOffsets.Upsert(
                    topicPartition,
                    offset
                );

            var channel = new InputChannel(
                _config,
                _logger
            );
            _channels.Add(channel);
            _channelTasks.Add(channel.Run(
                connection,
                topicPartitionOffsets,
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
            var listOffsetsTopicsBuilder = ImmutableArray.CreateBuilder<ListOffsetsRequestData.ListOffsetsTopic>();
            var listOffsetsPartitionsBuilder = ImmutableArray.CreateBuilder<ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition>();
            var index = 0;
            var length = topicPartitionTimestamps.Length;
            var currentTopic = topicPartitionTimestamps[0].Key.Topic;
            while (index < length)
            {
                (var (topic, partition), var timestamp) = topicPartitionTimestamps[index];
                var listOffsetsPartition = new ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition(
                    partition,
                    -1,
                    timestamp,
                    1,
                    []
                );
                listOffsetsPartitionsBuilder.Add(listOffsetsPartition);
                index++;
                if (currentTopic != topic || index == length)
                {
                    var partitions = listOffsetsPartitionsBuilder.DrainToImmutable();
                    var fetchTopic = new ListOffsetsRequestData.ListOffsetsTopic(
                        currentTopic.TopicName,
                        partitions,
                        []
                    );
                    listOffsetsTopicsBuilder.Add(fetchTopic);
                    currentTopic = topic;
                }
            }
            var listOffsetsTopics = listOffsetsTopicsBuilder.ToImmutable();
            return new ListOffsetsRequestData(
                -1,
                (sbyte)isolationLevel,
                listOffsetsTopics,
                []
            );
        }

        private async Task EnsureOffsets(
            IClientConnection connection,
            TopicPartitionMap<Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var timestamp = _autoOffsetReset switch
            {
                AutoOffsetReset.Earliest => Offset.Beginning.Value,
                _ => Offset.End.Value
            };
            var items = topicPartitionOffsets.CopyItems();
            var missingOffsets = items
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
            TopicPartitionMap<Offset> topicPartitionOffsets,
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
                    topicPartitionOffsets.Set(topicPartition, partition.OffsetField);
                }
            }
        }

        protected readonly record struct LeaderAndOffset(
            ClusterNodeId LeaderId,
            Offset Offset
        );

        protected static async ValueTask<TopicPartitionSet> GetTopicPartitions(
            IClientConnection connection,
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

            var topicPartitions = new TopicPartitionSet();
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

        protected static async ValueTask<TopicPartitionMap<LeaderAndOffset>> GetTopicPartitionLeaders(
            IClientConnection connection,
            TopicPartitionSet topicPartitions,
            CancellationToken cancellationToken
        )
        {
            var items = topicPartitions.CopyItems();
            var metadataRequest = new MetadataRequestData(
                items
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

            var topicPartitionLeaders = new TopicPartitionMap<LeaderAndOffset>();
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

        protected abstract ValueTask<TopicPartitionMap<LeaderAndOffset>> GetTopicPartitionOffsets(
            CancellationToken cancellationToken
        );
    }
}
