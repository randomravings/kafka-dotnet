using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Common;
using Kafka.Common.Exceptions;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Kafka.Client.Clients.Consumer
{
    public sealed class ConsumerClient<TKey, TValue> :
        Client<ConsumerConfig>,
        IConsumer<TKey, TValue>
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private readonly CancellationTokenSource _internalCts = new();
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private bool _disposed = false;

        public ConsumerClient(
            ConsumerConfig config,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger<IConsumer<TKey, TValue>> logger
        ) : base(config, logger)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        private async Task HeartBeatLoop(
            IConnection connection,
            SubscriptionMetadata subscriptionMetadata,
            CancellationToken cancellationToken
        )
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.WaitHandle.WaitOne(_config.HeartbeatIntervalMs);
                    if (string.IsNullOrEmpty(subscriptionMetadata.MemberId))
                        continue;
                    var request = new HeartbeatRequest(
                        subscriptionMetadata.GroupId,
                        subscriptionMetadata.GenerationId,
                        subscriptionMetadata.MemberId,
                        subscriptionMetadata.GroupInstanceId
                    );
                    try
                    {
                        var response = await connection.ExecuteRequest(
                            request,
                            HeartbeatRequestSerde.Write,
                            HeartbeatResponseSerde.Read,
                            cancellationToken
                        );
                        if (response.ErrorCodeField != 0)
                        {
                            var error = Errors.Translate(response.ErrorCodeField);
                            _logger.LogWarning("{error}", error);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogCritical("{ex}", ex);
                    }
                }
            }
            catch (OperationCanceledException) { }
        }

        private async Task CommitLoop(
            IConnection connection,
            ConcurrentQueue<TopicPartitionOffset> commitQueue,
            SubscriptionMetadata subscriptionMetadata,
            CancellationToken cancellationToken
        )
        {
            var commitState = new Dictionary<TopicPartition, Offset>();
            while (!cancellationToken.IsCancellationRequested)
            {
                cancellationToken.WaitHandle.WaitOne(_config.AutoCommitIntervalMs);
                var count = commitQueue.Count;
                for (int i = 0; i < count; i++)
                {
                    if (commitQueue.TryDequeue(out var result))
                        commitState[result.TopicPartition] = result.Offset.Value;
                    else
                        break;
                }
                if (commitState.Count == 0)
                    continue;

                var offsetCommitRequestTopic = commitState
                    .GroupBy(g => g.Key.Topic)
                    .Select(t =>
                        new OffsetCommitRequest.OffsetCommitRequestTopic(
                            t.Key.Value ?? "",
                            t.Select(p =>
                                new OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition(
                                    p.Key.Partition,
                                    p.Value,
                                    -1,
                                    Timestamp.Now().TimestampMs,
                                    null
                                )
                            ).ToImmutableArray()
                        )
                    )
                    .ToImmutableArray()
                ;
                var request = new OffsetCommitRequest(
                    subscriptionMetadata.GroupId,
                    subscriptionMetadata.GenerationId,
                    subscriptionMetadata.MemberId,
                    subscriptionMetadata.GroupInstanceId,
                    -1,
                    offsetCommitRequestTopic
                );
                try
                {
                    var response = await connection.ExecuteRequest(
                        request,
                        OffsetCommitRequestSerde.Write,
                        OffsetCommitResponseSerde.Read,
                        cancellationToken
                    );
                    var partitionErrors = response
                        .TopicsField
                        .SelectMany(r => r.PartitionsField)
                        .Where(r => r.ErrorCodeField != 0)
                    ;
                    if (partitionErrors.Any())
                    {
                        foreach (var partition in partitionErrors)
                        {
                            var error = Errors.Translate(partition.ErrorCodeField);
                            _logger.LogError("{error}", error);
                        }
                    }
                    else
                    {
                        commitState.Clear();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("{ex}", ex);
                }
            }
        }

        private static async ValueTask<ImmutableArray<FetchResponse>> Fetch(
            IEnumerable<(IConnection Connection, IEnumerable<TopicPartitionOffset> TopicPartitionOffsets)> assignments,
            CancellationToken cancellationToken
        )
        {
            var tasks = assignments
                .Select(
                    r => r.Connection.ExecuteRequest(
                        CreateFetchRequest(r.TopicPartitionOffsets) with { MaxVersion = 11 },
                        FetchRequestSerde.Write,
                        FetchResponseSerde.Read,
                        cancellationToken
                    )
                )
            ;

            try
            {
                await Task.WhenAll(tasks);
                return tasks
                    .Select(r => r.Result)
                    .ToImmutableArray()
                ;
            }
            catch(AggregateException ex)
            {
                return ImmutableArray<FetchResponse>.Empty;
            }
            catch(OperationCanceledException)
            {
                return ImmutableArray<FetchResponse>.Empty;
            }
        }

        private static FetchRequest CreateFetchRequest(
            IEnumerable<TopicPartitionOffset> topicPartitionOffsets
        )
        {
            var fetchTopics = topicPartitionOffsets
                .GroupBy(g => g.TopicPartition.Topic)
                .Select(t =>
                    new FetchRequest.FetchTopic(
                        t.Key.Value ?? "",
                        Guid.Empty,
                        t.Select(p =>
                            new FetchRequest.FetchTopic.FetchPartition(
                                PartitionField: p.TopicPartition.Partition,
                                CurrentLeaderEpochField: -1,
                                FetchOffsetField: p.Offset,
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

        private static SortedList<TopicPartition, Offset> CreateTopicPartitionOffsets(MetadataResponse metadataResponse)
        {
            var topicPartitionOffsets = new SortedList<TopicPartition, Offset>(TopicPartitionCompare.Instance);
            foreach (var topic in metadataResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = Offset.Unset;
            return topicPartitionOffsets;
        }

        private static ImmutableSortedDictionary<ClusterNodeId, ImmutableArray<TopicPartition>> CreateTopicPartitionMap(MetadataResponse metadataResponse) =>
            metadataResponse.TopicsField.SelectMany(t =>
                    t.PartitionsField.Select(
                        p => (p.LeaderIdField, t.NameField, p.PartitionIndexField)
                    )
                )
                .GroupBy(g => g.LeaderIdField)
                .ToImmutableSortedDictionary(
                    k => new ClusterNodeId(k.Key),
                    v => v.Select(r => new TopicPartition(r.NameField, r.PartitionIndexField))
                        .ToImmutableArray(),
                    ClusterNodeIdCompare.Instance
                )
            ;

        private static void UpdateFromOffsetListResponse(SortedList<TopicPartition, Offset> topicPartitionOffsets, ImmutableArray<ListOffsetsResponse> offsetListResponses)
        {
            foreach (var offsetListResponse in offsetListResponses)
                foreach (var topic in offsetListResponse.TopicsField)
                    foreach (var partition in topic.PartitionsField)
                        topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = partition.OffsetField;
        }

        private static void UpdateFromOffsetFetchResponse(
            SortedList<TopicPartition, Offset> topicPartitionOffsets,
            OffsetFetchResponse offsetFetchResponse
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
                        if (partition.CommittedOffsetField >= 0)
                            topicPartitionOffsets[topicPartition] = partition.CommittedOffsetField;
                    }
                }
            }

            // Check if stored by topic.
            foreach (var topic in offsetFetchResponse.TopicsField)
            {
                foreach (var partition in topic.PartitionsField)
                {
                    var topicPartition = new TopicPartition(topic.NameField, partition.PartitionIndexField);
                    if (partition.CommittedOffsetField >= 0)
                        topicPartitionOffsets[topicPartition] = partition.CommittedOffsetField;
                }
            }
        }

        private static async ValueTask<ImmutableArray<ListOffsetsResponse>> ListOffsets(
            ImmutableSortedDictionary<ClusterNodeId, IConnection> brokerConnections,
            ImmutableSortedDictionary<ClusterNodeId, ImmutableArray<TopicPartition>> topicPartitionLeaders,
            IEnumerable<TopicPartition> topicPartitions,
            Offset defaultOffset,
            CancellationToken cancellationToken
        )
        {
            var filteredTopicPartitionLeaders = topicPartitionLeaders
                .Select(kv =>
                    (kv.Key, Value: kv.Value.Intersect(topicPartitions))
                )
                .Where(r => r.Value.Any())
                .ToImmutableSortedDictionary(
                    k => k.Key,
                    v => v.Value,
                    ClusterNodeIdCompare.Instance
                )
            ;

            if (!filteredTopicPartitionLeaders.Any())
                return ImmutableArray<ListOffsetsResponse>.Empty;

            var tasks =
                topicPartitionLeaders
                .Join(
                    brokerConnections,
                    t => t.Key,
                    c => c.Key,
                    (t, c) => c.Value.ExecuteRequest(
                        CreateListOffsetsReques(
                            t.Value,
                            defaultOffset
                        ),
                        ListOffsetsRequestSerde.Write,
                        ListOffsetsResponseSerde.Read,
                        cancellationToken
                    )
                )
            ;

            await Task.WhenAll(tasks);

            return tasks
                .Select(r => r.Result)
                .ToImmutableArray()
            ;
        }

        private static ListOffsetsRequest CreateListOffsetsReques(
            IEnumerable<TopicPartition> topicPartitions,
            Offset defaultOffset
        )
        {
            var topics = topicPartitions
                .GroupBy(g => g.Topic)
                .Select(t =>
                    new ListOffsetsRequest.ListOffsetsTopic(
                        t.Key.Value ?? "",
                        t.Select(r =>
                            new ListOffsetsRequest.ListOffsetsTopic.ListOffsetsPartition(
                                r.Partition,
                                -1,
                                defaultOffset.Value,
                                1
                            )
                        ).ToImmutableArray()
                    )
                )
                .ToImmutableArray()
            ;
            return new ListOffsetsRequest(
                -1,
                1,
                topics
            );
        }

        private static async ValueTask LeaveGroup(
            IConnection connection,
            SubscriptionMetadata subscriptionMetadata,
            CancellationToken cancellationToken
        )
        {
            var request = CreateLeaveRequest(subscriptionMetadata);
            var response = await connection.ExecuteRequest(
                request,
                LeaveGroupRequestSerde.Write,
                LeaveGroupResponseSerde.Read,
                cancellationToken
            );
            if (response.ErrorCodeField != 0)
            {
                var error = Errors.Translate(response.ErrorCodeField);
                throw new ApiException(error);
            }
        }

        private static async ValueTask<SubscriptionMetadata> JoinGroup(
            IConnection connection,
            SubscriptionMetadata subscriptionMetadata,
            CancellationToken cancellationToken
        )
        {
            var metadata = subscriptionMetadata;
            var request = CreateJoinRequest(metadata);
            var response = await connection.ExecuteRequest(
                request,
                JoinGroupRequestSerde.Write,
                JoinGroupResponseSerde.Read,
                cancellationToken
            );
            if (response.ErrorCodeField == Errors.Known.MEMBER_ID_REQUIRED.Code)
            {
                metadata = metadata with { MemberId = response.MemberIdField };
                request = CreateJoinRequest(metadata);
                response = await connection.ExecuteRequest(
                    request,
                    JoinGroupRequestSerde.Write,
                    JoinGroupResponseSerde.Read,
                    cancellationToken
                );
            }
            if (response.ErrorCodeField != 0)
            {
                var error = Errors.Translate(response.ErrorCodeField);
                throw new ApiException(error);
            }
            return subscriptionMetadata with
            {
                GenerationId = response.GenerationIdField,
                ProtocolType = response.ProtocolTypeField,
                ProtocolName = response.ProtocolNameField,
                Leader = response.LeaderField,
                SkipAssignment = response.SkipAssignmentField,
                MemberId = response.MemberIdField,
                Members = response.MembersField.Select(r =>
                    new MemberMetadata(
                        r.MemberIdField,
                        r.GroupInstanceIdField,
                        r.MetadataField
                    )
                )
                .ToImmutableArray()
            };
        }

        private static async ValueTask<MetadataResponse> TopicMetadata(
            IConnection connection,
            ImmutableArray<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            var metadataRequestTopics = topics
                .Select(r => new MetadataRequest.MetadataRequestTopic(
                    Guid.Empty,
                    r.Value
                ))
                .ToImmutableArray()
            ;
            var request = new MetadataRequest(
                metadataRequestTopics,
                false,
                false,
                false
            );
            return await connection.ExecuteRequest(
                request,
                MetadataRequestSerde.Write,
                MetadataResponseSerde.Read,
                cancellationToken
            );
        }

        private async ValueTask<OffsetFetchResponse> FetchOffsets(
            IConnection connection,
            IEnumerable<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        )
        {
            var topicsToFetch = topicPartitions
                .GroupBy(g => g.Topic)
                .Select(
                    r => new OffsetFetchRequest.OffsetFetchRequestTopic(
                        r.Key.Value ?? "",
                        r.Select(r =>
                            r.Partition.Value
                        )
                        .ToImmutableArray()
                    )
                )
                .ToImmutableArray()
            ;

            var topicsInGroupToFetch =
                new[]
                {
                        new OffsetFetchRequest.OffsetFetchRequestGroup(
                            _config.GroupId ?? "",
                            topicPartitions
                                .GroupBy(g => g.Topic)
                                .Select(r =>
                                    new OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics(
                                        r.Key.Value ?? "",
                                        r.Select(p =>
                                            p.Partition.Value
                                        ).ToImmutableArray()
                                    )
                                ).ToImmutableArray()
                        )
                }
                .ToImmutableArray();

            var offsetFetchRequest = new OffsetFetchRequest(
                _config.GroupId ?? "",
                topicsToFetch,
                topicsInGroupToFetch,
                false
            );
            return await connection.ExecuteRequest(
                offsetFetchRequest,
                OffsetFetchRequestSerde.Write,
                OffsetFetchResponseSerde.Read,
                cancellationToken
            );
        }

        private static async ValueTask<SyncGroupResponse> SyncGroup(
            IConnection connection,
            SubscriptionMetadata subscriptionMetadata,
            CancellationToken cancellationToken
        )
        {
            var assignments = subscriptionMetadata.Members
                .Select(r => new SyncGroupRequest.SyncGroupRequestAssignment(
                    r.MemberId,
                    r.Metadata
                ))
                .ToImmutableArray()
            ;
            var request = new SyncGroupRequest(
                subscriptionMetadata.GroupId,
                subscriptionMetadata.GenerationId,
                subscriptionMetadata.MemberId,
                subscriptionMetadata.GroupInstanceId,
                subscriptionMetadata.ProtocolType,
                subscriptionMetadata.ProtocolName,
                assignments
            );
            return await connection.ExecuteRequest(
                request,
                SyncGroupRequestSerde.Write,
                SyncGroupResponseSerde.Read,
                cancellationToken
            );
        }

        private static JoinGroupRequest CreateJoinRequest(
            SubscriptionMetadata subscriptionMetadata
        )
        {
            return new JoinGroupRequest(
                subscriptionMetadata.GroupId,
                45000,
                300000,
                subscriptionMetadata.MemberId,
                subscriptionMetadata.GroupInstanceId,
                "consumer",
                new[]
                {
                    new JoinGroupRequest.JoinGroupRequestProtocol(
                        "range",
                        ReadOnlyMemory<byte>.Empty
                    )
                }.ToImmutableArray(),
                null
            );
        }

        private static LeaveGroupRequest CreateLeaveRequest(SubscriptionMetadata subscriptionMetadata)
        {
            return new LeaveGroupRequest(
                subscriptionMetadata.GroupId,
                subscriptionMetadata.MemberId,
                ImmutableArray<LeaveGroupRequest.MemberIdentity>.Empty
            );
        }

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionWatermark>>> IConsumer<TKey, TValue>.QueryWatermarks(
            TopicList topics,
            CancellationToken cancellationToken
        )
        {
            var newTopics = topics
                .Names
                .Where(r => !string.IsNullOrEmpty(r.Value))
                .ToImmutableArray()
            ;
            if (!newTopics.Any())
                return ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionWatermark>>.Empty;
            var brokerConnections = await _connectionPool.AquireBrokerConnections(cancellationToken);
            try
            {
                (var coordinatorConnection, var error) = await GetCoordinator(
                    brokerConnections,
                    _config.GroupId ?? "",
                    CoordinatorType.GROUP,
                    cancellationToken
                );
                var metadataResponse = await TopicMetadata(
                    coordinatorConnection,
                    newTopics,
                    cancellationToken
                );
                var topicPartitions = CreateTopicPartitionOffsets(metadataResponse);
                var topicPartitionMap = CreateTopicPartitionMap(metadataResponse);
                var topicPartitionOffsets = CreateTopicPartitionOffsets(metadataResponse);
                var lowListOffsetsResponse = await ConsumerClient<TKey, TValue>.ListOffsets(
                    brokerConnections,
                    topicPartitionMap,
                    topicPartitions.Keys,
                    Offset.Beginning,
                    cancellationToken
                );
                var lowWatermarks = GetTopicPartitionOffsets(lowListOffsetsResponse);

                var highListOffsetsResponse = await ConsumerClient<TKey, TValue>.ListOffsets(
                    brokerConnections,
                    topicPartitionMap,
                    topicPartitions.Keys,
                    Offset.End,
                    cancellationToken
                );
                var highWatermarks = GetTopicPartitionOffsets(highListOffsetsResponse);

                var fetchOffsetsResponse = await FetchOffsets(
                    coordinatorConnection,
                    topicPartitions.Keys,
                    cancellationToken
                );
                var storedOffsets = GetTopicPartitionOffsets(fetchOffsetsResponse);

                var topicWatermarksBuilder = ImmutableSortedDictionary.CreateBuilder<TopicName, ImmutableArray<PartitionWatermark>>(TopicNameCompare.Instance);
                foreach (var topic in topicPartitions.Keys.GroupBy(g => g.Topic))
                {
                    var partitionWatermarksBuilder = ImmutableArray.CreateBuilder<PartitionWatermark>(topic.Count());
                    foreach (var partition in topic)
                    {
                        var low = highWatermarks[topic.Key][partition.Partition];
                        var high = lowWatermarks[topic.Key][partition.Partition];
                        var stored = storedOffsets[topic.Key][partition.Partition];
                        partitionWatermarksBuilder.Add(
                            new(
                                partition.Partition,
                                low,
                                high,
                                stored
                            )
                        );
                    }
                    topicWatermarksBuilder.Add(topic.Key, partitionWatermarksBuilder.ToImmutable());
                }
                return topicWatermarksBuilder.ToImmutable();
            }
            finally
            {
                foreach (var connection in brokerConnections.Values)
                {
                    try
                    {
                        await connection.Close(cancellationToken);
                        connection.Dispose();
                    }
                    catch { }
                }
            }
        }

        private sealed record SubscriptionMetadata(
            string GroupId,
            string? GroupInstanceId,
            int GenerationId,
            string? ProtocolType,
            string? ProtocolName,
            string Leader,
            bool SkipAssignment,
            string MemberId,
            ImmutableArray<MemberMetadata> Members
        )
        {
            public static SubscriptionMetadata Empty { get; } = new(
                "",
                null,
                -1,
                null,
                null,
                "",
                false,
                "",
                ImmutableArray<MemberMetadata>.Empty
            );
        }

        private sealed record MemberMetadata(
            string MemberId,
            string? GroupInstanceId,
            ReadOnlyMemory<byte> Metadata
        );

        private static ImmutableSortedDictionary<TopicName, ImmutableSortedDictionary<Partition, Offset>> GetTopicPartitionOffsets(IEnumerable<ListOffsetsResponse> listOffsetsResponses)
        {
            return listOffsetsResponses
                .SelectMany(r => r.TopicsField)
                .GroupBy(r => r.NameField)
                .ToImmutableSortedDictionary(
                    k => new TopicName(k.Key),
                    v => v
                        .SelectMany(r => r.PartitionsField)
                        .ToImmutableSortedDictionary(
                            k => new Partition(k.PartitionIndexField),
                            v => new Offset(v.OffsetField),
                            PartitionCompare.Instance
                        ),
                    TopicNameCompare.Instance
                )
            ;
        }

        private static ImmutableSortedDictionary<TopicName, ImmutableSortedDictionary<Partition, Offset>> GetTopicPartitionOffsets(OffsetFetchResponse offsetFetchResponse)
        {
            var storedOffsetsBuilder = ImmutableSortedDictionary.CreateBuilder<TopicName, ImmutableSortedDictionary<Partition, Offset>>(TopicNameCompare.Instance);
            var group = offsetFetchResponse.GroupsField.FirstOrDefault();
            if (group != null)
            {
                foreach (var topic in group.TopicsField)
                {
                    var partitionOffsetsBuilder = ImmutableSortedDictionary.CreateBuilder<Partition, Offset>(PartitionCompare.Instance);
                    foreach (var partition in topic.PartitionsField)
                        partitionOffsetsBuilder.Add(new Partition(partition.PartitionIndexField), new Offset(partition.CommittedOffsetField));
                    storedOffsetsBuilder.Add(new TopicName(topic.NameField), partitionOffsetsBuilder.ToImmutable());
                }
            }
            // Check if stored by topic.
            foreach (var topic in offsetFetchResponse.TopicsField)
            {
                var partitionOffsetsBuilder = ImmutableSortedDictionary.CreateBuilder<Partition, Offset>(PartitionCompare.Instance);
                foreach (var partition in topic.PartitionsField)
                    partitionOffsetsBuilder.Add(new Partition(partition.PartitionIndexField), new Offset(partition.CommittedOffsetField));
                storedOffsetsBuilder.Add(new TopicName(topic.NameField), partitionOffsetsBuilder.ToImmutable());
            }
            return storedOffsetsBuilder.ToImmutable();
        }

        private static async ValueTask<ImmutableArray<FetchResponse.FetchableTopicResponse>> FetchUntilCancelled(
            ImmutableSortedDictionary<ClusterNodeId, IConnection> brokerConnections,
            ImmutableSortedDictionary<ClusterNodeId, ImmutableArray<TopicPartition>> topicPartitionLeaders,
            SortedList<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {


                    var connectionAssignments =
                        brokerConnections
                        .Join(
                            topicPartitionLeaders,
                            b => b.Key,
                            t => t.Key,
                            (b, t) => (
                                Connection: b.Value,
                                TopicPartitionOffsets: t.Value
                                    .Join(
                                        topicPartitionOffsets,
                                        p => p,
                                        o => o.Key,
                                        (p, o) => new TopicPartitionOffset(new(p.Topic, p.Partition), o.Value)
                                    )
                            )
                        )
                    ;


                    var responses =
                        await ConsumerClient<TKey, TValue>.Fetch(
                            connectionAssignments,
                            cancellationToken
                        )
                    ;
                    return responses
                        .SelectMany(r =>
                            r.ResponsesField
                        )
                        .ToImmutableArray()
                    ;
                }
                catch (OperationCanceledException) { }
            }
            return ImmutableArray<FetchResponse.FetchableTopicResponse>.Empty;
        }

        async IAsyncEnumerable<ConsumeResult<TKey, TValue>> IConsumer<TKey, TValue>.Read(TopicList topics, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var newTopics = topics
                .Names
                .Where(r => !string.IsNullOrEmpty(r.Value))
                .ToImmutableArray()
            ;
            var subscriptionMetadata = SubscriptionMetadata.Empty with
            {
                GroupId = _config.GroupId ?? "",
                GroupInstanceId = _config.GroupInstanceId,
            };
            if (!newTopics.Any())
                throw new ArgumentException("Must specify at least one topic", nameof(topics));
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            var autoCommitterTask = Task.CompletedTask;
            var hearbeatTask = Task.CompletedTask;
            var brokerConnections = await _connectionPool.AquireBrokerConnections(cancellationToken);
            (var _, var host, var port, var error) = await GetCoordinator(
                brokerConnections.Values.First(),
                _config.GroupId ?? "",
                CoordinatorType.GROUP,
                cancellationToken
            );
            var coordinatorConnection = await _connectionPool.AquireSharedConnection(host, port, cancellationToken);
            try
            {
                var metadataResponse = await TopicMetadata(
                    coordinatorConnection,
                    newTopics,
                    cancellationToken
                );
                var notFoundTopics = metadataResponse.TopicsField.Where(r => r.ErrorCodeField != 0);
                if (notFoundTopics.Any())
                {
                    foreach (var notFoundTopic in notFoundTopics)
                        _logger.LogWarning("Unable to find topic: {TopicName}", notFoundTopic.NameField);
                    throw new Exception("Some topics not available");
                }
                subscriptionMetadata = await ConsumerClient<TKey, TValue>.JoinGroup(
                    coordinatorConnection,
                    subscriptionMetadata,
                    cancellationToken
                );
                var syncResponse = await ConsumerClient<TKey, TValue>.SyncGroup(
                    coordinatorConnection,
                    subscriptionMetadata,
                    cancellationToken
                );
                var topicPartitionMap = CreateTopicPartitionMap(metadataResponse);
                var topicPartitionOffsets = CreateTopicPartitionOffsets(metadataResponse);
                var offsetFetchResponse = await FetchOffsets(
                    coordinatorConnection,
                    topicPartitionOffsets.Keys,
                    cancellationToken
                );
                UpdateFromOffsetFetchResponse(
                    topicPartitionOffsets,
                    offsetFetchResponse
                );
                var unsetTopicPartitions = topicPartitionOffsets
                    .Where(r => r.Value == Offset.Unset)
                    .Select(r => r.Key)
                ;
                if (unsetTopicPartitions.Any())
                {
                    var offsetListResponse = await ConsumerClient<TKey, TValue>.ListOffsets(
                        brokerConnections,
                        topicPartitionMap,
                        unsetTopicPartitions,
                        Offset.Beginning,
                        cancellationToken
                    );
                    UpdateFromOffsetListResponse(
                        topicPartitionOffsets,
                        offsetListResponse
                    );
                }
                var commitQueue = new ConcurrentQueue<TopicPartitionOffset>();
                autoCommitterTask = Task.Run(async () => await CommitLoop(
                        coordinatorConnection,
                        commitQueue,
                        subscriptionMetadata,
                        cancellationToken
                    ),
                    CancellationToken.None
                );
                hearbeatTask = Task.Run(async () => await HeartBeatLoop(
                        coordinatorConnection,
                        subscriptionMetadata,
                        cancellationToken
                    ),
                    CancellationToken.None
                );

                while (!cancellationToken.IsCancellationRequested)
                {
                    var fetchableTopicResponses = await ConsumerClient<TKey, TValue>.FetchUntilCancelled(
                        brokerConnections,
                        topicPartitionMap,
                        topicPartitionOffsets,
                        cancellationToken
                    );
                    foreach (var topic in fetchableTopicResponses)
                    {
                        foreach (var partition in topic.PartitionsField)
                        {
                            var topicPartition = new TopicPartition(topic.TopicField, partition.PartitionIndexField);
                            if (partition.ErrorCodeField != 0)
                                throw new ApiException(Errors.Translate(partition.ErrorCodeField));
                            if (partition.RecordsField == null)
                                continue;
                            foreach (var records in partition.RecordsField)
                            {
                                if (records.IsControlBatch)
                                {
                                    var controlRecord = records.ControlRecord;
                                    topicPartitionOffsets[topicPartition] = records.Offset + 1;
                                    _logger.LogTrace("control record received {version}:{type}", controlRecord.Version, controlRecord.Type);
                                    var newOffset = records.Offset + 1;
                                    topicPartitionOffsets[topicPartition] = newOffset;
                                    commitQueue.Enqueue(new(topicPartition, newOffset));
                                }
                                else
                                {
                                    foreach (var record in records)
                                    {
                                        var offset = records.Offset + record.OffsetDelta;
                                        var timestamp = records.BaseTimestamp + record.TimestampDelta;
                                        var key = _keyDeserializer.Read(record.Key);
                                        var value = _valueDeserializer.Read(record.Value);
                                        var consumeResult = new ConsumeResult<TKey, TValue>(
                                            TopicPartition: topicPartition,
                                            Offset: offset,
                                            LastStableOffset: partition.LastStableOffsetField,
                                            LogStartOffset: partition.LogStartOffsetField,
                                            HighWatermark: partition.HighWatermarkField,
                                            Errors.Known.NONE,
                                            Record: new(
                                                Timestamp: records.Attributes.HasFlag(Attributes.LogAppendTime) ? Timestamp.LogAppend(timestamp) : Timestamp.Created(timestamp),
                                                Headers: record.Headers,
                                                Key: key,
                                                Value: value
                                            )
                                        );
                                        yield return consumeResult;
                                        var newOffset = offset + 1;
                                        topicPartitionOffsets[topicPartition] = newOffset;
                                        commitQueue.Enqueue(new(topicPartition, newOffset));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                try
                {
                    await ConsumerClient<TKey, TValue>.LeaveGroup(
                        coordinatorConnection,
                        subscriptionMetadata,
                        _internalCts.Token
                    );
                }
                catch (Exception ex)
                {
                    _logger.LogError("Exception during leave: {ex}", ex);
                }
                _semaphore.Release();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _internalCts.Dispose();
                    _semaphore.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        protected override async ValueTask OnClose(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            await ValueTask.CompletedTask;
        }
    }
}
