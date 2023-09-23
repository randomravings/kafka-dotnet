using Kafka.Client.Clients.Consumer.Logging;
using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Common.Collections;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Protocol;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class StreamReaderApplication<TKey, TValue> :
        StreamReader<TKey, TValue>,
        IStreamReaderApplication<TKey, TValue>
    {
        private const string PROTOCOL_TYPE = "consumer";
        private static readonly ImmutableArray<string> PROTOCOLS =
            ImmutableArray.Create("range", "roundrobin")
        ;

        private readonly IReadOnlySet<TopicName> _topics;
        private readonly IConsumerProtocol _coordinatorProtocol;
        private readonly string _groupId;
        private readonly string? _groupInstanceId;
        private readonly AutoOffsetReset _autoOffsetReset;
        private readonly bool _enableAutoCommit;
        private readonly int _autoCommitIntervalMs;
        private readonly ConcurrentTopicPartitionOffsets _commitedOffsets = new();

        private MemberInfo _memberInfo = MemberInfo.Empty;
        private Task _heartbeat = Task.CompletedTask;
        private Task _committer = Task.CompletedTask;
        private long _joined;
        private readonly SemaphoreSlim _commitSync = new(1, 1);
        private readonly ManualResetEventSlim _joinGroupSync = new(false);
        private CancellationTokenSource _heartbeatCts = new();
        private CancellationTokenSource _dataCts = new();

        public StreamReaderApplication(
            IConsumerProtocol coordinatorProtocol,
            IReadOnlySet<TopicName> topics,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ConsumerConfig config,
            ILogger<IConsumer<TKey, TValue>> logger
        ) : base(keyDeserializer, valueDeserializer, config, logger)
        {
            _coordinatorProtocol = coordinatorProtocol;
            _topics = topics;
            _groupId = config.GroupId ?? "";
            _groupInstanceId = config.GroupInstanceId;
            _autoOffsetReset = config.AutoOffsetReset;
            _autoCommitIntervalMs = config.AutoCommitIntervalMs;
            _enableAutoCommit = config.EnableAutoCommit;
        }

        async ValueTask IStreamReaderApplication<TKey, TValue>.Commit(
            CancellationToken cancellationToken
        ) =>
            await CommitDelta(cancellationToken).ConfigureAwait(false)
        ;

        async ValueTask IStreamReaderApplication<TKey, TValue>.Commit(
            TopicPartitionOffset topicPartitionOffset,
            CancellationToken cancellationToken
        )
        {
            await _commitSync.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                (var topicPartition, var offset) = topicPartitionOffset;
                if (!IsTracked(_trackedOffsets, topicPartition, offset))
                    return;
                if (IsCommited(_commitedOffsets, topicPartition, offset))
                    return;
                var offsetToCommit = new Dictionary<TopicPartition, Offset>()
                {
                    { topicPartitionOffset.TopicPartition, topicPartitionOffset.Offset }
                };
                await CommitOffsets(offsetToCommit, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _commitSync.Release();
            }
        }

        async ValueTask IStreamReaderApplication<TKey, TValue>.Commit(
            IEnumerable<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            await _commitSync.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var offsetToCommit = new Dictionary<TopicPartition, Offset>();
                foreach ((var topicPartition, var offset) in topicPartitionOffsets)
                {
                    if (!IsTracked(_trackedOffsets, topicPartition, offset))
                        break;
                    if (IsCommited(_commitedOffsets, topicPartition, offset))
                        break;
                    offsetToCommit[topicPartition] = offset;
                }
                if (offsetToCommit.Count > 0)
                    await CommitOffsets(offsetToCommit, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _commitSync.Release();
            }
        }

        protected override async ValueTask PrepareFetch(CancellationToken cancellationToken)
        {
            if (_heartbeat.IsCompleted)
            {
                _heartbeatCts = new CancellationTokenSource();
                _heartbeat = Task.Run(
                    async () => await HeartbeatLoop(_heartbeatCts.Token).ConfigureAwait(false),
                    CancellationToken.None
                );
                await Task.Yield();
            }

            if (!_joinGroupSync.IsSet)
                _joinGroupSync.Wait(cancellationToken);
        }

        private async Task Setup(CancellationToken cancellationToken)
        {
            var nodeAssignments = await JoinGroup(cancellationToken).ConfigureAwait(false);
            _logger.ConsumerGroupJoin(
                _groupId,
                _memberInfo.MemberId,
                _memberInfo.GenerationId,
                _groupInstanceId,
                nodeAssignments.Values.SelectMany(r => r.TopicPartitionOffsets.Keys.Select(k => $"{k.Topic.TopicName.Value}:{k.Partition.Value}"))
            );
            _dataCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            if (_enableAutoCommit)
                _committer = Task.Run(async () => await AutoCommitLoop(_dataCts.Token).ConfigureAwait(false), CancellationToken.None);
            ResetFetchResults();
            foreach ((var nodeId, var assignment) in nodeAssignments)
            {
                foreach (var topicPartitionOffset in assignment.TopicPartitionOffsets)
                    _trackedOffsets[topicPartitionOffset.Key] = topicPartitionOffset.Value;
                var channel = CreateChannel(assignment);
                _consumerChannels.Add(channel);
            }
            var startTasks = _consumerChannels.Select(c => c.Start(_dataCts.Token));
            await Task.WhenAll(startTasks).ConfigureAwait(false);
            await Task.Yield();
        }

        protected override async ValueTask Closing(CancellationToken cancellationToken)
        {
            await TearDown(cancellationToken).ConfigureAwait(false);
            _heartbeatCts.Cancel();
            await _heartbeat.ConfigureAwait(false);
            var leaveGroupRequest = new LeaveGroupRequestData(
                _groupId,
                _memberInfo.MemberId,
                ImmutableArray.Create(new LeaveGroupRequestData.MemberIdentity(
                    _memberInfo.MemberId,
                    _groupInstanceId,
                    "Closing",
                    ImmutableArray<TaggedField>.Empty
                )),
                ImmutableArray<TaggedField>.Empty
            );
            var leaveGroupResponse = await _coordinatorProtocol
                .LeaveGroup(leaveGroupRequest, cancellationToken)
                .ConfigureAwait(false)
            ;
            if (leaveGroupResponse.ErrorCodeField == 0)
            {
                _logger.ConsumerGroupLeave(_groupId);
            }
            else
            {
                var error = Errors.Translate(leaveGroupResponse.ErrorCodeField);
                _logger.ConsumerGroupLeaveError(_groupId, error);
            }
        }

        private async ValueTask TearDown(CancellationToken cancellationToken)
        {
            if (!_dataCts.IsCancellationRequested)
                _dataCts.Cancel();
            var closeTasks = _consumerChannels.Select(r => r.Stop(cancellationToken)).ToArray();
            await Task.WhenAll(closeTasks).ConfigureAwait(false);
            await _committer.ConfigureAwait(false);
            _consumerChannels.Clear();
            _trackedOffsets.Clear();
            _commitedOffsets.Clear();
            _dataCts.Dispose();
        }

        private async Task<ImmutableSortedDictionary<ClusterNodeId, NodeAssignment>> JoinGroup(
            CancellationToken cancellationToken
        )
        {
            (var memberId, var generationId) = _memberInfo;
            var metadataRequest = new MetadataRequestData(
                _topics.Select(t => new MetadataRequestData.MetadataRequestTopic(
                    Guid.Empty,
                    t,
                    ImmutableArray<TaggedField>.Empty
                )).ToImmutableArray(),
                false,
                false,
                false,
                ImmutableArray<TaggedField>.Empty
            );
            var metadataResponse = await _coordinatorProtocol.Metadata(
                metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);
            var nodeAssignments = TopicPartitionHelper.GetAssignments(
                metadataResponse
            );
            var topicPartitions = nodeAssignments
                .SelectMany(r => r.Value)
                .OrderBy(r => r.Topic, TopicCompare.Instance)
                .ThenBy(r => r.Partition, PartitionCompare.Instance)
                .ToImmutableArray()
            ;
            var topicMetadata = Membership.Pack(_topics.ToImmutableSortedSet(TopicNameCompare.Instance));
            var joinGroupRequest = new JoinGroupRequestData(
                _groupId,
                _sessionTimeoutMs,
                _maxPollIntervalMs,
                memberId,
                _groupInstanceId,
                PROTOCOL_TYPE,
                PROTOCOLS.Select(r =>
                    new JoinGroupRequestData.JoinGroupRequestProtocol(
                        r,
                        topicMetadata,
                        ImmutableArray<TaggedField>.Empty
                    )
                ).ToImmutableArray(),
                null,
                ImmutableArray<TaggedField>.Empty
            );
            var joinGroupResponse = await _coordinatorProtocol.JoinGroup(
                joinGroupRequest,
                cancellationToken
            ).ConfigureAwait(false);
            if (joinGroupResponse.ErrorCodeField == Errors.Known.MEMBER_ID_REQUIRED.Code)
            {
                joinGroupRequest = joinGroupRequest with
                {
                    MemberIdField = joinGroupResponse.MemberIdField
                };
                joinGroupResponse = await _coordinatorProtocol.JoinGroup(
                    joinGroupRequest,
                    cancellationToken
                ).ConfigureAwait(false);
            }
            if (joinGroupResponse.ErrorCodeField != 0)
            {
                var error = Errors.Translate(joinGroupResponse.ErrorCodeField);
                throw new ApiException(error);
            }
            memberId = joinGroupResponse.MemberIdField;
            generationId = joinGroupResponse.GenerationIdField;

            _memberInfo = new MemberInfo(
                memberId,
                generationId
            );

            var assignments = new Dictionary<string, List<TopicPartition>>();
            // Am I the leader?
            if (memberId == joinGroupResponse.LeaderField)
            {
                assignments = joinGroupResponse.MembersField.ToDictionary(k => k.MemberIdField, v => new List<TopicPartition>());
                var keys = assignments.Keys.ToArray();
                var i = 0;
                foreach (var topicPartition in topicPartitions)
                {
                    assignments[keys[i]].Add(topicPartition);
                    i = (i + 1) % keys.Length;
                }
            }

            var packedAssignments = assignments
                .ToDictionary(
                    k => k.Key,
                    v => Membership.Pack(v.Value.ToImmutableSortedSet(TopicPartitionCompare.Instance))
                )
            ;

            var syncGroupRequestAssignments = packedAssignments
                .Select(r => new SyncGroupRequestData.SyncGroupRequestAssignment(
                    r.Key,
                    r.Value,
                    ImmutableArray<TaggedField>.Empty
                ))
                .ToImmutableArray()
            ;
            var syncGroupRequest = new SyncGroupRequestData(
                _groupId,
                generationId,
                memberId,
                _groupInstanceId,
                PROTOCOL_TYPE,
                joinGroupResponse.ProtocolNameField,
                syncGroupRequestAssignments,
                ImmutableArray<TaggedField>.Empty
            );
            var syncGroupResponse = await _coordinatorProtocol.SyncGroup(
                syncGroupRequest,
                cancellationToken
            ).ConfigureAwait(false);
            if (syncGroupResponse.ErrorCodeField != 0)
            {
                var error = Errors.Translate(syncGroupResponse.ErrorCodeField);
                throw new ApiException(error);
            }

            var synchedTopicPartitions = Membership.Unpack(
                syncGroupResponse.AssignmentField.ToArray()
            );

            var topicPartitionOffsets = synchedTopicPartitions.ToImmutableSortedDictionary(
                k => k,
                v => Offset.Unset,
                TopicPartitionCompare.Instance
            );

            var topicsToFetch = topicPartitionOffsets
                .Keys
                .GroupBy(g => g.Topic)
                .Select(
                    r => new OffsetFetchRequestData.OffsetFetchRequestTopic(
                        r.Key.TopicName,
                        r.Select(r =>
                            r.Partition.Value
                        )
                        .ToImmutableArray(),
                        ImmutableArray<TaggedField>.Empty
                    )
                )
                .ToImmutableArray()
            ;
            var topicsInGroupToFetch =
                ImmutableArray.Create(
                    new OffsetFetchRequestData.OffsetFetchRequestGroup(
                        _groupId,
                        topicPartitionOffsets
                            .Keys
                            .GroupBy(g => g.Topic)
                            .Select(r =>
                                new OffsetFetchRequestData.OffsetFetchRequestGroup.OffsetFetchRequestTopics(
                                    r.Key.TopicName,
                                    r.Select(p =>
                                        p.Partition.Value
                                    ).ToImmutableArray(),
                                    ImmutableArray<TaggedField>.Empty
                                )
                            ).ToImmutableArray(),
                        ImmutableArray<TaggedField>.Empty
                    )
                )
            ;
            var offsetFetchRequest = new OffsetFetchRequestData(
                _groupId,
                topicsToFetch,
                topicsInGroupToFetch,
                false,
                ImmutableArray<TaggedField>.Empty
            );
            var offsetFetchResponse = await _coordinatorProtocol.OffsetFetch(
                offsetFetchRequest,
                cancellationToken
            ).ConfigureAwait(false);
            topicPartitionOffsets = TopicPartitionHelper.UpdateTopicPartitionOffsets(
                topicPartitionOffsets,
                offsetFetchResponse
            );

            if (_autoOffsetReset == AutoOffsetReset.None && topicPartitionOffsets.Values.Any(r => r.Value == Offset.Unset))
                throw new InvalidOperationException("Unset partitions found with auto.offset.reset=none");

            var nodeTopicPartitions = ImmutableSortedDictionary.CreateBuilder<ClusterNodeId, NodeAssignment>(ClusterNodeIdCompare.Instance);
            foreach ((var nodeId, var assignment) in nodeAssignments)
            {
                var nodeTopicPartitionOffsets = ImmutableSortedDictionary.CreateBuilder<TopicPartition, Offset>(TopicPartitionCompare.Instance);
                foreach (var topicPartition in assignment)
                    if (topicPartitionOffsets.TryGetValue(topicPartition, out var offset))
                        nodeTopicPartitionOffsets.Add(topicPartition, offset);
                if (!nodeTopicPartitionOffsets.Any())
                    continue;
                var node = metadataResponse.BrokersField.First(r => r.NodeIdField == nodeId);
                nodeTopicPartitions.Add(nodeId, new NodeAssignment(nodeId, node.HostField, node.PortField, nodeTopicPartitionOffsets.ToImmutable()));
            }

            return nodeTopicPartitions.ToImmutable();
        }


        private async Task HeartbeatLoop(
            CancellationToken cancellationToken
        )
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    if (Interlocked.Read(ref _joined) == 0)
                    {
                        await TearDown(cancellationToken).ConfigureAwait(false);
                        await Setup(cancellationToken).ConfigureAwait(false);
                        Interlocked.Exchange(ref _joined, 1);
                        _joinGroupSync.Set();
                    }


                    await Task.Delay(_config.HeartbeatIntervalMs, cancellationToken).ConfigureAwait(false);
                    var heartbeatRequest = new HeartbeatRequestData(
                        _groupId,
                        _memberInfo.GenerationId,
                        _memberInfo.MemberId,
                        _groupInstanceId,
                        ImmutableArray<TaggedField>.Empty
                    );
                    var heartbeatResponse = await _coordinatorProtocol.Heartbeat(
                        heartbeatRequest,
                        cancellationToken
                    ).ConfigureAwait(false);
                    if (heartbeatResponse.ErrorCodeField != 0)
                    {
                        var error = Errors.Translate(heartbeatResponse.ErrorCodeField);
                        ConsumerLog.HeartBeatError(_logger, error);

                        if (error.Code == Errors.Known.REBALANCE_IN_PROGRESS.Code)
                        {
                            Interlocked.Exchange(ref _joined, 0);
                            _joinGroupSync.Reset();
                        }
                    }
                }
                catch (OperationCanceledException) { }
            }
            ConsumerLog.HeartbeatLoopStop(_logger);
        }

        private async Task AutoCommitLoop(
            CancellationToken cancellationToken
        )
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    cancellationToken.WaitHandle.WaitOne(_autoCommitIntervalMs);
                    await CommitDelta(cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    using var lts = new CancellationTokenSource(5000);
                    await CommitDelta(lts.Token).ConfigureAwait(false);
                }

            }
            ConsumerLog.CommitLoopStop(_logger);
        }

        private async Task CommitDelta(
            CancellationToken cancellationToken
        )
        {
            await _commitSync.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var offsetsToCommit = _trackedOffsets.OffsetDiff(_commitedOffsets);
                if (offsetsToCommit.Count == 0)
                    return;
                await CommitOffsets(
                    offsetsToCommit,
                    cancellationToken
                ).ConfigureAwait(false);
            }
            finally
            {
                _commitSync.Release();
            }
        }

        private async Task CommitOffsets(
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var grouping = topicPartitionOffsets
                .GroupBy(t => t.Key.Topic)
                .ToArray()
            ;

            var offsetCommitRequestTopicsBuilder = ImmutableArray.CreateBuilder<OffsetCommitRequestData.OffsetCommitRequestTopic>();
            foreach (var topic in grouping)
            {
                var offsetCommitRequestPartitionsBuilder = ImmutableArray.CreateBuilder<OffsetCommitRequestData.OffsetCommitRequestTopic.OffsetCommitRequestPartition>();
                foreach (var partition in topic)
                {
                    var offsetCommitRequestPartition = new OffsetCommitRequestData.OffsetCommitRequestTopic.OffsetCommitRequestPartition(
                        partition.Key.Partition,
                        partition.Value,
                        -1,
                        Timestamp.Now().TimestampMs,
                        null,
                        ImmutableArray<TaggedField>.Empty
                    );
                    offsetCommitRequestPartitionsBuilder.Add(offsetCommitRequestPartition);
                }
                var offsetCommitRequestPartitions = offsetCommitRequestPartitionsBuilder.ToImmutable();
                var offsetCommitRequestTopic = new OffsetCommitRequestData.OffsetCommitRequestTopic(
                    topic.Key.TopicName,
                    offsetCommitRequestPartitions,
                    ImmutableArray<TaggedField>.Empty
                );
                offsetCommitRequestTopicsBuilder.Add(offsetCommitRequestTopic);
            }
            var offsetCommitRequestTopics = offsetCommitRequestTopicsBuilder.ToImmutable();

            try
            {
                var offsetCommitRequest = new OffsetCommitRequestData(
                    _groupId,
                    _memberInfo.GenerationId,
                    _memberInfo.MemberId,
                    _groupInstanceId,
                    -1,
                    offsetCommitRequestTopics,
                    ImmutableArray<TaggedField>.Empty
                );
                var response = await _coordinatorProtocol.OffsetCommit(
                    offsetCommitRequest,
                    cancellationToken
                ).ConfigureAwait(false);
                var anyErrors = response
                    .TopicsField
                    .SelectMany(r => r.PartitionsField)
                    .Where(r => r.ErrorCodeField != 0)
                    .Any()
                ;
                // Happy path.
                if (!anyErrors)
                    return;

                // Tedious path.
                foreach (var topic in response.TopicsField)
                {
                    foreach (var partition in topic.PartitionsField)
                    {
                        var topicPartition = new TopicPartition(topic.NameField, partition.PartitionIndexField);
                        if (partition.ErrorCodeField == 0)
                        {
                            _commitedOffsets[topicPartition] = topicPartitionOffsets[topicPartition];
                        }
                        else
                        {
                            var error = Errors.Translate(partition.ErrorCodeField);
                            ConsumerLog.CommitLoopTopicPartitionError(_logger, topic.NameField, partition.PartitionIndexField, error);
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                ConsumerLog.CommitLoopInterrupted(_logger);
            }
        }

        private static bool IsTracked(
            ConcurrentTopicPartitionOffsets trackedOffsets,
            in TopicPartition topicPartition,
            in Offset offset
        ) =>
            trackedOffsets.TryGetValue(topicPartition, out var trackedOffset) ||
            offset <= trackedOffset
        ;

        private static bool IsCommited(
            ConcurrentTopicPartitionOffsets commitedOffsets,
            in TopicPartition topicPartition,
            in Offset offset
        ) =>
            commitedOffsets.TryGetValue(topicPartition, out var commitedOffset) &&
            offset <= commitedOffset
        ;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _commitSync.Dispose();
                _commitSync.Dispose();
                _joinGroupSync.Dispose();
                _heartbeatCts.Dispose();
                _dataCts.Dispose();
            }
        }
    }
}
