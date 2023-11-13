using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Net;
using Kafka.Common.Collections;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Net;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Stream
{
    internal sealed class ApplicationInputStream :
        InputStream,
        IApplicationInputStream
    {
        private const string PROTOCOL_TYPE = "consumer";
        private static readonly ImmutableArray<string> PROTOCOLS =
            ImmutableArray.Create("range", "roundrobin")
        ;

        private readonly string _groupId;
        private readonly string? _groupInstanceId;
        private readonly bool _enableAutoCommit;
        private readonly int _autoCommitIntervalMs;
        private readonly IReadOnlySet<TopicName> _topics;
        private readonly ConcurrentTopicPartitionOffsets _commitedOffsets = new();

        private MemberInfo _memberInfo = MemberInfo.Empty;
        private Task _heartbeat = Task.CompletedTask;
        private Task _committer = Task.CompletedTask;
        private readonly SemaphoreSlim _commitSync = new(1, 1);
        private readonly ManualResetEventSlim _joinGroupSync = new(false);
        private CancellationTokenSource _heartbeatCts = new();
        private CancellationTokenSource _commitCts = new();

        public ApplicationInputStream(
            IConnectionManager<IClientConnection> connectionManager,
            IReadOnlySet<TopicName> topics,
            InputStreamConfig config,
            ILogger logger
        ) : base(connectionManager, config, logger)
        {
            _topics = topics;
            _groupId = config.GroupId ?? "";
            _groupInstanceId = config.GroupInstanceId;
            _autoCommitIntervalMs = config.AutoCommitIntervalMs;
            _enableAutoCommit = config.EnableAutoCommit;
        }

        async ValueTask IApplicationInputStream.Commit(
            CancellationToken cancellationToken
        ) =>
            await CommitDelta(
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask IApplicationInputStream.Commit(
            TopicPartitionOffset topicPartitionOffset,
            CancellationToken cancellationToken
        )
        {
            await _commitSync.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var offsetsToCommit = GetOffsetToCommit();
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

        async ValueTask IApplicationInputStream.Commit(
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
                    if (!IsTracked(topicPartition, offset))
                        break;
                    if (IsCommited(topicPartition, offset))
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

        private static void AssertTopicList(
            IReadOnlySet<TopicName> topics,
            IReadOnlySet<TopicPartition> topicPartitions
        )
        {
            var missingTopics = topics
                .Where(t => !topicPartitions.Any(r =>
                    string.Equals(
                        r.Topic.TopicName.Value,
                        t.Value,
                        StringComparison.OrdinalIgnoreCase
                    )
                ))
                .Select(t => t.Value)
                .ToImmutableSortedSet()
            ;
            if (missingTopics.Count > 0)
            {
                var list = string.Join(',', missingTopics);
                throw new InvalidOperationException($"Topic(s) not found: '{list}'");
            }
        }


        protected override async ValueTask<IReadOnlyDictionary<TopicPartition, LeaderAndOffset>> GetTopicPartitionOffsets(
            CancellationToken cancellationToken
        )
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

            _joinGroupSync.Wait(cancellationToken);

            var offsetFetchRequest = CreateOffsetFetchRequest(
                _memberInfo,
                _assignmentList
            );

            var coordinator = await GetCoordinator(cancellationToken).ConfigureAwait(false);
            var topicPartitions = await GetTopicPartitionLeaders(
                coordinator,
                _assignmentList,
                cancellationToken
            ).ConfigureAwait(false);
            RemoveUnassignedTopicPartitions(
                topicPartitions,
                _assignmentList
            );
            var offsetFetchResponse = await coordinator.OffsetFetch(
                offsetFetchRequest,
                cancellationToken
            ).ConfigureAwait(false);
            UpdateTopicPartitionOffsets(
                topicPartitions,
                offsetFetchResponse
            );
            return topicPartitions.AsReadOnly();
        }

        private async Task Setup(CancellationToken cancellationToken)
        {
            await JoinGroup(
                cancellationToken
            ).ConfigureAwait(false);
            _logger.ConsumerGroupJoin(
                _groupId,
                _memberInfo.MemberId,
                _memberInfo.GenerationId,
                _groupInstanceId,
                _assignmentList.Select(r => $"{r.Topic.TopicName.Value}:{r.Partition.Value}")
            );
            _commitCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            if (_enableAutoCommit)
                _committer = Task.Run(async () => await AutoCommitLoop(_commitCts.Token).ConfigureAwait(false), CancellationToken.None);
            await Task.Yield();
        }

        protected override async ValueTask Closing(CancellationToken cancellationToken)
        {
            _heartbeatCts.Cancel();
            await _heartbeat.ConfigureAwait(false);
            await TearDown().ConfigureAwait(false);
            await Task.Yield();
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
            var coordinator = await GetCoordinator(cancellationToken).ConfigureAwait(false);
            var leaveGroupResponse = await coordinator
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

        private async ValueTask TearDown()
        {
            if (!_commitCts.IsCancellationRequested)
                _commitCts.Cancel();
            await _committer.ConfigureAwait(false);
            _trackedOffsets.Clear();
            _commitedOffsets.Clear();
            _commitCts.Dispose();
            await Task.Yield();
        }

        private async Task JoinGroup(
            CancellationToken cancellationToken
        )
        {
            var coordinator = await GetCoordinator(cancellationToken).ConfigureAwait(false);
            var topicPartitions = await GetTopicPartitions(
                coordinator,
                _topics,
                cancellationToken
            ).ConfigureAwait(false);
            await Task.Yield();

            var joinGroupRequest = CreateJoinGroupRequest(
                _topics,
                _memberInfo.MemberId
            );
            var joinGroupResponse = await coordinator.JoinGroup(
                joinGroupRequest,
                cancellationToken
            ).ConfigureAwait(false);
            await Task.Yield();

            if (joinGroupResponse.ErrorCodeField == Errors.Known.MEMBER_ID_REQUIRED.Code)
            {
                joinGroupRequest = joinGroupRequest with
                {
                    MemberIdField = joinGroupResponse.MemberIdField,
                    ReasonField = "retry due to missing member id"
                };
                joinGroupResponse = await coordinator.JoinGroup(
                    joinGroupRequest,
                    cancellationToken
                ).ConfigureAwait(false);
                await Task.Yield();
            }
            if (joinGroupResponse.ErrorCodeField != 0)
            {
                var error = Errors.Translate(joinGroupResponse.ErrorCodeField);
                throw new ApiException(error);
            }
            _memberInfo = new MemberInfo(
                joinGroupResponse.MemberIdField,
                joinGroupResponse.GenerationIdField
            );

            var syncGroupRequest = CreateSyncGroupRequest(
                joinGroupResponse,
                topicPartitions
            );
            var syncGroupResponse = await coordinator.SyncGroup(
                syncGroupRequest,
                cancellationToken
            ).ConfigureAwait(false);
            await Task.Yield();

            if (syncGroupResponse.ErrorCodeField != 0)
            {
                var error = Errors.Translate(syncGroupResponse.ErrorCodeField);
                throw new ApiException(error);
            }
            var synchedTopicPartitions = Membership.UnpackTopicPartitions(
                syncGroupResponse.AssignmentField
            );
            _assignmentList.Clear();
            foreach (var topicPartition in synchedTopicPartitions)
                _assignmentList.Add(topicPartition);
            _joinGroupSync.Set();
        }

        private JoinGroupRequestData CreateJoinGroupRequest(
            IReadOnlySet<TopicName> topics,
            string memberId
        )
        {
            var topicMetadata = Membership.PackProtocolMetadata(
                3,
                topics,
                Array.Empty<byte>()
            );
            return new(
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
        }

        private SyncGroupRequestData CreateSyncGroupRequest(
            JoinGroupResponseData joinGroupResponse,
            IReadOnlySet<TopicPartition> topicPartitions
        )
        {
            var memberId = joinGroupResponse.MemberIdField;
            var generationId = joinGroupResponse.GenerationIdField;
            var assignments = new Dictionary<string, List<TopicPartition>>();
            // Am I the leader?
            if (joinGroupResponse.MemberIdField == joinGroupResponse.LeaderField)
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
                    v => Membership.PackTopicPartitions(
                        v.Value.ToImmutableSortedSet(TopicPartitionCompare.Instance)
                    )
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
            return new(
                _groupId,
                joinGroupResponse.GenerationIdField,
                joinGroupResponse.MemberIdField,
                _groupInstanceId,
                PROTOCOL_TYPE,
                joinGroupResponse.ProtocolNameField,
                syncGroupRequestAssignments,
                ImmutableArray<TaggedField>.Empty
            );
        }

        private OffsetFetchRequestData CreateOffsetFetchRequest(
            MemberInfo member,
            IReadOnlySet<TopicPartition> topicPartitions
        )
        {
            var topicsToFetch = topicPartitions
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
                        member.MemberId,
                        member.GenerationId,
                        topicPartitions
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
            return new(
                _groupId,
                topicsToFetch,
                topicsInGroupToFetch,
                false,
                ImmutableArray<TaggedField>.Empty
            );
        }

        private async Task HeartbeatLoop(
            CancellationToken cancellationToken
        )
        {
            _logger.HeartbeatLoopStart();
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    if(!_joinGroupSync.IsSet)
                    {
                        _logger.HeartbeatLoopPreJoin();
                        _joinGroupSync.Reset();
                        SignalStateAltered();
                        await TearDown().ConfigureAwait(false);
                        await Setup(cancellationToken).ConfigureAwait(false);
                        _joinGroupSync.Wait(cancellationToken);
                        _logger.HeartbeatLoopPostJoin();
                    }

                    await Task.Delay(_config.HeartbeatIntervalMs, cancellationToken).ConfigureAwait(false);
                    await Task.Yield();
                    var heartbeatRequest = new HeartbeatRequestData(
                        _groupId,
                        _memberInfo.GenerationId,
                        _memberInfo.MemberId,
                        _groupInstanceId,
                        ImmutableArray<TaggedField>.Empty
                    );
                    var coordinator = await GetCoordinator(cancellationToken).ConfigureAwait(false);
                    var heartbeatResponse = await coordinator.Heartbeat(
                        heartbeatRequest,
                        cancellationToken
                    ).ConfigureAwait(false);
                    await Task.Yield();
                    if (heartbeatResponse.ErrorCodeField != 0)
                    {
                        var error = Errors.Translate(heartbeatResponse.ErrorCodeField);
                        _logger.HeartBeatError(error);

                        if (error.Code == Errors.Known.REBALANCE_IN_PROGRESS.Code)
                            _joinGroupSync.Reset();
                    }
                }
                catch (OperationCanceledException) { }
            }
            _logger.HeartbeatLoopStop();
        }

        private async Task AutoCommitLoop(
            CancellationToken cancellationToken
        )
        {
            _logger.CommitLoopStart();
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
            _logger.CommitLoopStop();
        }

        private async Task CommitDelta(
            CancellationToken cancellationToken
        )
        {
            await _commitSync.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var offsetsToCommit = GetOffsetToCommit();
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
            IReadOnlyDictionary<TopicPartition, Offset> topicPartitionOffsets,
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
                var coordinator = await GetCoordinator(cancellationToken).ConfigureAwait(false);
                var response = await coordinator.OffsetCommit(
                    offsetCommitRequest,
                    cancellationToken
                ).ConfigureAwait(false);
                await Task.Yield();
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
                            _logger.CommitLoopTopicPartitionError(topic.NameField, partition.PartitionIndexField, error);
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.CommitLoopInterrupted();
            }
        }

        private bool IsCommited(
            in TopicPartition topicPartition,
            in Offset offset
        ) =>
            _commitedOffsets.TryGetValue(topicPartition, out var commitedOffset) &&
            offset <= commitedOffset
        ;

        private static void RemoveUnassignedTopicPartitions(
            IDictionary<TopicPartition, LeaderAndOffset> topicPartitionOffsets,
            IReadOnlySet<TopicPartition> topicPartitions
        )
        {
            var topicPartitionsToRemove = topicPartitionOffsets
                .Select(r => r.Key)
                .Where(k => !topicPartitions.Contains(k))
                .ToImmutableArray()
            ;
            foreach (var topicPartition in topicPartitionsToRemove)
                topicPartitionOffsets.Remove(topicPartition);
        }

        private static void UpdateTopicPartitionOffsets(
            IDictionary<TopicPartition, LeaderAndOffset> topicPartitionOffsets,
            OffsetFetchResponseData offsetFetchResponse
        )
        {
            // Check if stored by group. This assumes one and only one group.
            var group = offsetFetchResponse.GroupsField.FirstOrDefault();
            if (group != null)
            {
                foreach (var topic in group.TopicsField)
                {
                    foreach (var partition in topic.PartitionsField)
                    {
                        var topicPartition = new TopicPartition(topic.NameField, partition.PartitionIndexField);
                        var leaderAndOffset = topicPartitionOffsets[topicPartition];
                        topicPartitionOffsets[topicPartition] = leaderAndOffset with { Offset = partition.CommittedOffsetField };
                    }
                }
            }

            // Check if stored by topic.
            foreach (var topic in offsetFetchResponse.TopicsField)
            {
                foreach (var partition in topic.PartitionsField)
                {
                    var topicPartition = new TopicPartition(topic.NameField, partition.PartitionIndexField);
                    var leaderAndOffset = topicPartitionOffsets[topicPartition];
                    topicPartitionOffsets[topicPartition] = leaderAndOffset with { Offset = partition.CommittedOffsetField };
                }
            }
        }

        public IReadOnlyDictionary<TopicPartition, Offset> GetOffsetToCommit()
        {
            var builder = ImmutableSortedDictionary.CreateBuilder<TopicPartition, Offset>(TopicPartitionCompare.Instance);
            foreach ((var topicPartition, var offset) in _trackedOffsets)
                if (!_commitedOffsets.TryGetValue(topicPartition, out var otherOffset) || offset > otherOffset)
                    builder.Add(topicPartition, offset);
            return builder.ToImmutable();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _commitSync.Dispose();
                _commitSync.Dispose();
                _joinGroupSync.Dispose();
                _heartbeatCts.Dispose();
                _commitCts.Dispose();
            }
        }
    }
}
