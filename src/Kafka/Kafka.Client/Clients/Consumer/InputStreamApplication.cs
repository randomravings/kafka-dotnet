using Kafka.Client.Clients.Consumer.Logging;
using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Threading.Channels;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class InputStreamApplication<TKey, TValue> :
        IInputStreamApplication<TKey, TValue>
    {
        private const string PROTOCOL_TYPE = "consumer";
        private static readonly ImmutableArray<string> PROTOCOLS =
            ImmutableArray.Create("range", "roundrobin")
        ;

        private readonly IReadOnlySet<TopicName> _topics;
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private readonly ConsumerConfig _config;
        private readonly ILogger<IConsumer<TKey, TValue>> _logger;
        private readonly IConsumerProtocol _coordinatorProtocol;
        private readonly string _groupId;
        private readonly int _sessionTimeoutMs;
        private readonly int _maxPollIntervalMs;
        private readonly string? _groupInstanceId;
        private readonly AutoOffsetReset _autoOffsetReset;
        private readonly int _autoCommitIntervalMs;
        private readonly IList<IConsumerChannel> _consumerChannels = new List<IConsumerChannel>();
        private readonly ConcurrentDictionary<TopicPartition, Offset> _trackedOffsets = new();

        private MemberInfo _memberInfo = MemberInfo.Empty;
        private BlockingCollection<FetchResultEnumerator> _fetchResultEnumerators = new();
        private FetchResultEnumerator _enumerator = FetchResultEnumerator.Empty;
        private CancellationTokenSource _internalCTS = new();
        private Task _heartbeat = Task.CompletedTask;
        private Task _committer = Task.CompletedTask;
        private long _joined;

        public InputStreamApplication(
            IConsumerProtocol coordinatorProtocol,
            IReadOnlySet<TopicName> topics,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ConsumerConfig config,
            ILogger<IConsumer<TKey, TValue>> logger
        )
        {
            _coordinatorProtocol = coordinatorProtocol;
            _topics = topics;
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            _groupId = config.GroupId ?? "";
            _sessionTimeoutMs = config.SessionTimeoutMs;
            _maxPollIntervalMs = config.MaxPollIntervalMs;
            _groupInstanceId = config.GroupInstanceId;
            _autoOffsetReset = config.AutoOffsetReset;
            _autoCommitIntervalMs = config.AutoCommitIntervalMs;
            _config = config;
            _logger = logger;
        }

        async Task<ConsumerRecord<TKey, TValue>> IConsumerInstance<TKey, TValue>.Fetch(CancellationToken cancellationToken)
        {
            await CheckMembership(cancellationToken).ConfigureAwait(false);
            var record = NextRecord(cancellationToken);
            AddOffsetToCommit(record.TopicPartition, record.Offset);
            return record;
        }

        private async Task CheckMembership(CancellationToken cancellationToken)
        {
            if (Interlocked.Read(ref _joined) == 0)
            {
                await CleanUp(cancellationToken).ConfigureAwait(false);
                var nodeAssignments = await JoinGroup(cancellationToken).ConfigureAwait(false);
                _internalCTS = new();
                _heartbeat = Task.Run(async () => await HeartbeatLoop(_internalCTS.Token).ConfigureAwait(false), CancellationToken.None);
                _committer = Task.Run(async () => await CommitLoop(_internalCTS.Token).ConfigureAwait(false), CancellationToken.None);
                _fetchResultEnumerators = new();
                foreach ((var nodeId, var assignment) in nodeAssignments)
                {
                    foreach (var topicPartitionOffset in assignment.TopicPartitionOffsets)
                        _trackedOffsets[topicPartitionOffset.Key] = topicPartitionOffset.Value;
                    var channel = CreateChannel(assignment);
                    _consumerChannels.Add(channel);
                }
                foreach (var channel in _consumerChannels)
                    await channel.Start(cancellationToken).ConfigureAwait(false);
                _enumerator = FetchResultEnumerator.Empty;
                Interlocked.Exchange(ref _joined, 1);
            }
        }

        private IConsumerChannel CreateChannel(NodeAssignment assignment)
        {
            var connection = new TcpConnection(assignment.Host, assignment.Port);
            var protocol = new ConsumerProtocol(connection, _config, _logger);
            return new ConsumerChannel(assignment.NodeId, protocol, assignment.TopicPartitionOffsets, _fetchResultEnumerators, _config, _logger);
        }

        private async Task CleanUp(CancellationToken cancellationToken)
        {
            if (!_internalCTS.IsCancellationRequested)
                _internalCTS.Cancel();
            var closeTasks = _consumerChannels.Select(r => r.Stop(cancellationToken));
            await Task.WhenAll(closeTasks).ConfigureAwait(false);
            _consumerChannels.Clear();
            await _committer.ConfigureAwait(false);
            await _heartbeat.ConfigureAwait(false);
            _trackedOffsets.Clear();
        }

        private ConsumerRecord<TKey, TValue> NextRecord(CancellationToken cancellationToken)
        {
            while (!_enumerator.MoveNext())
            {
                _enumerator.Dispose();
                _enumerator = _fetchResultEnumerators.Take(cancellationToken);
            }
            return _enumerator.ReadRecord(_keyDeserializer, _valueDeserializer);
        }

        private void AddOffsetToCommit(TopicPartition topicPartition, Offset offset) =>
            _trackedOffsets[topicPartition] = offset + 1
        ;

        async Task IConsumerInstance<TKey, TValue>.Close(CancellationToken cancellationToken)
        {
            await CleanUp(cancellationToken).ConfigureAwait(false);
            var leaveGroupRequest = new LeaveGroupRequest(
                _groupId,
                _memberInfo.MemberId,
                ImmutableArray.Create(new LeaveGroupRequest.MemberIdentity(
                    _memberInfo.MemberId,
                    _groupId,
                    "Closing",
                    ImmutableArray<TaggedField>.Empty
                )),
                ImmutableArray<TaggedField>.Empty
            );
            _ = await _coordinatorProtocol.LeaveGroup(leaveGroupRequest, cancellationToken).ConfigureAwait(false);
        }

        ValueTask IInputStreamApplication<TKey, TValue>.Commit(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        ValueTask IInputStreamApplication<TKey, TValue>.Commit(TopicPartitionOffset topicPartitionOffset, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        ValueTask<ImmutableArray<TopicPartitionOffset>> IInputStreamApplication<TKey, TValue>.Commit(ImmutableSortedDictionary<TopicPartition, Offset> topicPartitionOffsets, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        private async Task<ImmutableSortedDictionary<ClusterNodeId, NodeAssignment>> JoinGroup(
            CancellationToken cancellationToken
        )
        {
            (var memberId, var generationId) = _memberInfo;
            var metadataRequest = new MetadataRequest(
                _topics.Select(t => new MetadataRequest.MetadataRequestTopic(
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
            var joinGroupRequest = new JoinGroupRequest(
                _groupId,
                _sessionTimeoutMs,
                _maxPollIntervalMs,
                memberId,
                _groupInstanceId,
                PROTOCOL_TYPE,
                PROTOCOLS.Select(r =>
                    new JoinGroupRequest.JoinGroupRequestProtocol(
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
                .Select(r => new SyncGroupRequest.SyncGroupRequestAssignment(
                    r.Key,
                    r.Value,
                    ImmutableArray<TaggedField>.Empty
                ))
                .ToImmutableArray()
            ;
            var syncGroupRequest = new SyncGroupRequest(
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

            var topicPartitionOffsets = topicPartitions.ToDictionary(k => k, v => Offset.Unset, TopicPartitionByNameCompare.Equality);

            var topicsToFetch = topicPartitionOffsets
                .Keys
                .GroupBy(g => g.Topic)
                .Select(
                    r => new OffsetFetchRequest.OffsetFetchRequestTopic(
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
                    new OffsetFetchRequest.OffsetFetchRequestGroup(
                        _groupId,
                        topicPartitionOffsets
                            .Keys
                            .GroupBy(g => g.Topic)
                            .Select(r =>
                                new OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics(
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
            var offsetFetchRequest = new OffsetFetchRequest(
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
            TopicPartitionHelper.UpdateTopicPartitionOffsets(
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
                    nodeTopicPartitionOffsets.Add(topicPartition, topicPartitionOffsets[topicPartition]);
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
                    await Task.Delay(_config.HeartbeatIntervalMs, cancellationToken).ConfigureAwait(false);
                    var heartbeatRequest = new HeartbeatRequest(
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
                            break;
                        }
                    }
                }
                catch (OperationCanceledException) { }
            }
            ConsumerLog.HeartbeatExit(_logger);
        }

        private async Task CommitLoop(
            CancellationToken cancellationToken
        )
        {
            var commitedOffsets = new SortedList<TopicPartition, Offset>(TopicPartitionCompare.Instance);
            foreach (var topicPartitionOffset in _trackedOffsets)
                commitedOffsets.Add(topicPartitionOffset.Key, topicPartitionOffset.Value);
            while (!cancellationToken.IsCancellationRequested)
            {
                cancellationToken.WaitHandle.WaitOne(_autoCommitIntervalMs);
                await DoCommit(
                    commitedOffsets,
                    cancellationToken
                ).ConfigureAwait(false);
            }
            // Try committing lingering offsets if any.
            using var lts = new CancellationTokenSource(5000);
            await DoCommit(
                commitedOffsets,
                lts.Token
            ).ConfigureAwait(false);
            _logger.LogInformation("Commit loop exited");
        }

        private async Task DoCommit(
            IEnumerable<KeyValuePair<TopicPartition, Offset>> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            if (!topicPartitionOffsets.Any())
                return;
            var orderedEnumerator = topicPartitionOffsets.Order().GetEnumerator();
            var offsetCommitRequestTopicsBuilder = ImmutableArray.CreateBuilder<OffsetCommitRequest.OffsetCommitRequestTopic>();
            var offsetCommitRequestPartitionsBuilder = ImmutableArray.CreateBuilder<OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition>();
            orderedEnumerator.MoveNext();
            var topicPartitionOffset = orderedEnumerator.Current;
            while (true)
            {
                var currentOffset = _trackedOffsets[topicPartitionOffset.Key];
                if (currentOffset < topicPartitionOffset.Value)
                {
                    var offsetCommitRequestPartition = new OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition(
                        topicPartitionOffset.Key.Partition,
                        topicPartitionOffset.Value,
                        -1,
                        Timestamp.Now().TimestampMs,
                        null,
                        ImmutableArray<TaggedField>.Empty
                    );
                    offsetCommitRequestPartitionsBuilder.Add(offsetCommitRequestPartition);
                }
                if (!orderedEnumerator.MoveNext())
                    break;
                if (topicPartitionOffset.Key.Topic != orderedEnumerator.Current.Key.Topic)
                {
                    if (offsetCommitRequestPartitionsBuilder.Count == 0)
                        continue;
                    var offsetCommitRequestPartitions = offsetCommitRequestPartitionsBuilder.ToImmutable();
                    var offsetCommitRequestTopic = new OffsetCommitRequest.OffsetCommitRequestTopic(
                        topicPartitionOffset.Key.Topic.TopicName,
                        offsetCommitRequestPartitions,
                        ImmutableArray<TaggedField>.Empty
                    );
                    offsetCommitRequestTopicsBuilder.Add(offsetCommitRequestTopic);
                    offsetCommitRequestPartitionsBuilder = ImmutableArray.CreateBuilder<OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition>();
                }
                topicPartitionOffset = orderedEnumerator.Current;
            }
            if (offsetCommitRequestPartitionsBuilder.Count == 0)
                return;

            var offsetCommitRequestTopics = offsetCommitRequestTopicsBuilder.ToImmutable();

            try
            {
                var offsetCommitRequest = new OffsetCommitRequest(
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
        }

        public void Dispose()
        {
            _fetchResultEnumerators.Dispose();
            _internalCTS.Dispose();
            _enumerator.Dispose();
        }
    }
}
