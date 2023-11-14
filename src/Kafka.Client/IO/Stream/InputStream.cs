﻿using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Net;
using Kafka.Common.Collections;
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
        IInputStream
    {
        private static readonly TimeSpan WAIT_INDEFINITELY = TimeSpan.FromMilliseconds(-1);

        private readonly List<ConsumerChannel> _channels = new();
        private readonly List<Task> _channelTasks = new();
        private readonly ConcurrentQueue<FetchResult> _recordQueue = new();
        private readonly ManualResetEventSlim _resetEvent = new(false);
        private readonly Stopwatch _stopwatch = new();
        private CancellationTokenSource _channelCts = new();
        private long _stateAltered = 1;
        private bool _disposed;

        protected readonly SortedSet<TopicPartition> _assignmentList = new(TopicPartitionCompare.Instance);
        protected readonly IConnectionManager<IClientConnection> _connectionManager;
        protected readonly ConcurrentTopicPartitionOffsets _trackedOffsets = new();
        protected readonly ConcurrentTopicPartitionSet _pausedTopicPartitions = new();
        protected readonly InputStreamConfig _config;
        protected readonly ILogger _logger;
        protected readonly int _sessionTimeoutMs;
        protected readonly int _maxPollIntervalMs;
        protected readonly IsolationLevel _isolationLevel;
        protected readonly AutoOffsetReset _autoOffsetReset;
        protected readonly SemaphoreSlim _semaphore = new(1, 1);

        protected InputStream(
            IConnectionManager<IClientConnection> connectionManager,
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
            _pausedTopicPartitions.Copy()
        ;

        void IInputStream.PausePartitions(params TopicPartition[] partitions)
        {
            foreach (var topicPartition in partitions)
                _pausedTopicPartitions.Add(topicPartition);
        }

        void IInputStream.ResumePartitions(params TopicPartition[] partitions)
        {
            foreach (var topicPartition in partitions)
                _pausedTopicPartitions.Remove(topicPartition);
        }

        void IInputStream.UpdateOffsets(TopicPartition topicPartition, Offset offset) =>
            _trackedOffsets.Update(topicPartition, offset)
        ;

        void IInputStream.UpdateOffsets(params TopicPartitionOffset[] topicPartitionOffsets)
        {
            foreach (var (topicPartition, offset) in topicPartitionOffsets)
                _trackedOffsets.Update(topicPartition, offset);
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

        async Task<IReadOnlyList<ConsumerRecord>> IInputStream.Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        ) =>
            await Read(
                timeout,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<IReadOnlyList<ConsumerRecord>> IInputStream.Read(
            CancellationToken cancellationToken
        ) =>
            await Read(
                WAIT_INDEFINITELY,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async Task<IReadOnlyList<ConsumerRecord>> Read(
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
                    return ImmutableArray<ConsumerRecord>.Empty;
            }
        }

        protected void SignalStateAltered()
        {
            Interlocked.Exchange(ref _stateAltered, 1);
            _resetEvent.Set();
        }

        protected abstract ValueTask Closing(CancellationToken cancellationToken);

        protected static async ValueTask<IReadOnlyDictionary<TopicPartition, Offset>> ListOffsets(
            IClientConnection protocol,
            IReadOnlyDictionary<TopicPartition, long> topicPartitions,
            IsolationLevel isolationLevel,
            CancellationToken cancellationToken
        )
        {
            var listOffsetsRequest = CreateListOffsetsRequest(
                topicPartitions,
                isolationLevel
            );
            var listOffsetsResponse = await protocol.ListOffsets(
                listOffsetsRequest,
                cancellationToken
            ).ConfigureAwait(false);
            return listOffsetsResponse
                .TopicsField
                .SelectMany(
                    t => t.PartitionsField.Select(
                        p => new
                        {
                            TopicPartition = new TopicPartition(t.NameField, p.PartitionIndexField),
                            Offset = new Offset(p.OffsetField)
                        }
                    )
                )
                .ToImmutableSortedDictionary(
                    k => k.TopicPartition,
                    v => v.Offset,
                    TopicPartitionCompare.Instance
                )
            ;
        }

        protected static async ValueTask<IReadOnlyDictionary<TopicPartition, Offset>> GetHighWatermarks(
            IClientConnection protocol,
            IReadOnlySet<TopicPartition> topicPartitions,
            IsolationLevel isolationLevel,
            CancellationToken cancellationToken
        ) =>
            await ListOffsets(
                protocol,
                topicPartitions.ToImmutableSortedDictionary(
                    k => k,
                    v => Offset.Beginning.Value,
                    TopicPartitionCompare.Instance
                ),
                isolationLevel,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        protected static async ValueTask<IReadOnlyDictionary<TopicPartition, Offset>> GetLowWatermarks(
            IClientConnection protocol,
            IReadOnlySet<TopicPartition> topicPartitions,
            IsolationLevel isolationLevel,
            CancellationToken cancellationToken
        ) =>
            await ListOffsets(
                protocol,
                topicPartitions.ToImmutableSortedDictionary(
                    k => k,
                    v => Offset.End.Value,
                    TopicPartitionCompare.Instance
                ),
                isolationLevel,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        protected bool IsTracked(
            in TopicPartition topicPartition,
            in Offset offset
        ) =>
            _trackedOffsets.TryGetValue(topicPartition, out var trackedOffset) ||
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
                ImmutableArray.Create(groupId),
                ImmutableArray<TaggedField>.Empty
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

                _channelCts.Cancel();
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
                    await Task.Yield();
                }
                _stopwatch.Restart();
                Interlocked.Exchange(ref _stateAltered, 0);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private static IReadOnlyDictionary<ClusterNodeId, IDictionary<TopicPartition, Offset>> GetTopicPartitionAssignments(
            IReadOnlyDictionary<TopicPartition, LeaderAndOffset> topicPartitionDetails
        )
        {
            var brokerGrouping = topicPartitionDetails
                .GroupBy(k => k.Value.LeaderId)
            ;
            var topicPartitionAssignmentBuilder = ImmutableSortedDictionary
                .CreateBuilder<ClusterNodeId, IDictionary<TopicPartition, Offset>>(
                    ClusterNodeIdCompare.Instance
                )
            ;
            foreach(var broker in brokerGrouping)
            {
                var topicPartitionOffsets = new SortedList<TopicPartition, Offset>(TopicPartitionCompare.Instance);
                foreach (var (topicPartition, leaderAndOffset) in broker)
                    topicPartitionOffsets.Add(topicPartition, leaderAndOffset.Offset);
                topicPartitionAssignmentBuilder.Add(broker.Key, topicPartitionOffsets);
            }
            return topicPartitionAssignmentBuilder.ToImmutable();
        }

        private async Task CreateChannel(
            ClusterNodeId nodeId,
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
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

            foreach(var (topicPartition, offset) in topicPartitionOffsets)
                _trackedOffsets.AddOrUpdate(
                    topicPartition,
                    offset
                );

            var channel = new ConsumerChannel(
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
            IReadOnlyDictionary<TopicPartition, long> topicPartitionTimestamps,
            IsolationLevel isolationLevel
        ) =>
            new(
                -1,
                (sbyte)isolationLevel,
                topicPartitionTimestamps
                    .GroupBy(r => r.Key.Topic)
                    .Select(t => new ListOffsetsRequestData.ListOffsetsTopic(
                        t.Key.TopicName,
                        t.Select(p => new ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition(
                            p.Key.Partition.Value,
                            -1,
                            p.Value,
                            1,
                            ImmutableArray<TaggedField>.Empty
                        )).ToImmutableArray(),
                        ImmutableArray<TaggedField>.Empty
                    )).ToImmutableArray(),
                ImmutableArray<TaggedField>.Empty
            )
        ;

        private async Task EnsureOffsets(
            IClientConnection connection,
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var timestampField = _autoOffsetReset switch
            {
                AutoOffsetReset.Earliest => Offset.Beginning.Value,
                _ => Offset.End.Value
            };
            var missingOffsets = topicPartitionOffsets
                .Where(r => r.Value < 0)
                .Select(r => r.Key)
                .ToImmutableSortedDictionary(
                    k => k,
                    v => timestampField,
                    TopicPartitionCompare.Instance
                )
            ;
            if (missingOffsets.Count > 0)
            {
                var listOffsetsRequest = CreateListOffsetsRequest(
                    missingOffsets
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

        private ListOffsetsRequestData CreateListOffsetsRequest(
            IReadOnlyDictionary<TopicPartition, long> topicPartitionOffsets
        ) =>
            new(
                -1,
                (sbyte)_isolationLevel,
                topicPartitionOffsets
                    .GroupBy(r => r.Key.Topic)
                    .Select(t => new ListOffsetsRequestData.ListOffsetsTopic(
                        t.Key.TopicName,
                        t.Select(p => new ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition(
                            p.Key.Partition.Value,
                            -1,
                            p.Value,
                            1,
                            ImmutableArray<TaggedField>.Empty
                        )).ToImmutableArray(),
                        ImmutableArray<TaggedField>.Empty
                    )).ToImmutableArray(),
                ImmutableArray<TaggedField>.Empty
            )
        ;

        private static void UpdateTopicPartitionOffsets(
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            ListOffsetsResponseData offsetListResponse
        )
        {
            foreach (var topic in offsetListResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = partition.OffsetField;
        }

        protected readonly record struct LeaderAndOffset(
            ClusterNodeId LeaderId,
            Offset Offset
        );

        protected static async ValueTask<IReadOnlySet<TopicPartition>> GetTopicPartitions(
            IClientConnection connection,
            IReadOnlySet<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            var metadataRequest = new MetadataRequestData(
                topics.Select(t => new MetadataRequestData.MetadataRequestTopic(
                    Guid.Empty,
                    t,
                    ImmutableArray<TaggedField>.Empty
                )).ToImmutableArray(),
                false,
                false,
                false,
                ImmutableArray<TaggedField>.Empty
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
            IClientConnection connection,
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
                    ImmutableArray<TaggedField>.Empty
                )).ToImmutableArray(),
                false,
                false,
                false,
                ImmutableArray<TaggedField>.Empty
            );
            var metadataResponse = await connection.Metadata(
            metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);

            var topicPartitionLeaders = new SortedList<TopicPartition, LeaderAndOffset>(TopicPartitionCompare.Instance);
            foreach (var topic in metadataResponse.TopicsField)
            {
                foreach (var partition in topic.PartitionsField)
                {
                    var topicPartition = new TopicPartition(topic.NameField, partition.PartitionIndexField);
                    if(topicPartitions.Contains(topicPartition))
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
                }
            }
            return topicPartitionLeaders;
        }

        protected abstract ValueTask<IReadOnlyDictionary<TopicPartition, LeaderAndOffset>> GetTopicPartitionOffsets(
            CancellationToken cancellationToken
        );
    }
}