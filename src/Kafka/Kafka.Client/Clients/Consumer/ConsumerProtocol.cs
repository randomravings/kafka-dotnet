using Kafka.Client.Messages;
using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal static class ConsumerProtocol
    {
        public static async Task<MetadataResponse> Metadata(
            IConnection connection,
            IEnumerable<TopicName> topicNames,
            CancellationToken cancellationToken
        )
        {
            var request = new MetadataRequest(
                topicNames.Select(r => new MetadataRequest.MetadataRequestTopic(
                        Guid.Empty,
                        r
                    )
                ).ToImmutableArray(),
                true,
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

        public static async Task<HeartbeatResponse> Heartbeat(
            IConnection connection,
            int generationId,
            string memberId,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var request = new HeartbeatRequest(
                config.GroupId ?? "",
                generationId,
                memberId,
                config.GroupInstanceId
            );
            return await connection.ExecuteRequest(
                request,
                HeartbeatRequestSerde.Write,
                HeartbeatResponseSerde.Read,
                cancellationToken
            );
        }

        public static async Task<JoinGroupResponse> JoinGroup(
            IConnection connection,
            string memberId,
            IEnumerable<TopicName> topicNames,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var topicMetadata = Membership.Pack(topicNames);
            var request = new JoinGroupRequest(
                config.GroupId ?? "",
                config.SessionTimeoutMs,
                config.MaxPollIntervalMs,
                memberId,
                config.GroupInstanceId,
                "consumer",
                new[]
                {
                    new JoinGroupRequest.JoinGroupRequestProtocol(
                        "range",
                        topicMetadata
                    ),
                    new JoinGroupRequest.JoinGroupRequestProtocol(
                        "roundrobin",
                        topicMetadata
                    )
                }.ToImmutableArray(),
                null
            );
            return await connection.ExecuteRequest(
                request,
                JoinGroupRequestSerde.Write,
                JoinGroupResponseSerde.Read,
                cancellationToken
            );
        }

        public static async Task<SyncGroupResponse> SyncGroup(
            IConnection connection,
            int generationId,
            string memberId,
            string? protocolName,
            IDictionary<string, byte[]> members,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var syncGroupRequestAssignments = members
                .Select(r => new SyncGroupRequest.SyncGroupRequestAssignment(
                    r.Key,
                    r.Value
                ))
                .ToImmutableArray()
            ;
            var request = new SyncGroupRequest(
                config.GroupId ?? "",
                generationId,
                memberId,
                config.GroupInstanceId,
                "consumer",
                protocolName,
                syncGroupRequestAssignments
            );
            return await connection.ExecuteRequest(
                request,
                SyncGroupRequestSerde.Write,
                SyncGroupResponseSerde.Read,
                cancellationToken
            );
        }

        public static async Task<LeaveGroupResponse> LeaveGroup(
            IConnection connection,
            string memberId,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var request = new LeaveGroupRequest(
                config.GroupId ?? "",
                memberId,
                ImmutableArray<LeaveGroupRequest.MemberIdentity>.Empty
            );
            return await connection.ExecuteRequest(
                request,
                LeaveGroupRequestSerde.Write,
                LeaveGroupResponseSerde.Read,
                cancellationToken
            );
        }

        public static async Task<OffsetFetchResponse> OffsetFetch(
            IConnection connection,
            ConsumerConfig config,
            IEnumerable<TopicPartition> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var topicsToFetch = topicPartitionOffsets
                .GroupBy(g => g.Topic)
                .Select(
                    r => new OffsetFetchRequest.OffsetFetchRequestTopic(
                        r.Key,
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
                        config.GroupId ?? "",
                        topicPartitionOffsets
                            .GroupBy(g => g.Topic)
                            .Select(r =>
                                new OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics(
                                    r.Key,
                                    r.Select(p =>
                                        p.Partition.Value
                                    ).ToImmutableArray()
                                )
                            ).ToImmutableArray()
                    )
                }
                .ToImmutableArray()
            ;
            var request = new OffsetFetchRequest(
                config.GroupId ?? "",
                topicsToFetch,
                topicsInGroupToFetch,
                false
            );
            return await connection.ExecuteRequest(
                request,
                OffsetFetchRequestSerde.Write,
                OffsetFetchResponseSerde.Read,
                cancellationToken
            );
        }

        public static async Task<ListOffsetsResponse> ListOffsets(
            IConnection connection,
            ImmutableSortedSet<TopicPartition> topicPartitions,
            IsolationLevel isolationLevel,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        )
        {
            var request = new ListOffsetsRequest(
                -1,
                (sbyte)isolationLevel,
                topicPartitions
                    .GroupBy(g => g.Topic)
                    .Select(t =>
                    new ListOffsetsRequest.ListOffsetsTopic(
                        t.Key,
                        t.Select(p =>
                            new ListOffsetsRequest.ListOffsetsTopic.ListOffsetsPartition(
                                p.Partition,
                                -1,
                                timestamp.ToUnixTimeMilliseconds(),
                                1
                            )
                        )
                        .ToImmutableArray()
                    )
                )
                .ToImmutableArray()
            );
            return await connection
                .ExecuteRequest(
                    request,
                    ListOffsetsRequestSerde.Write,
                    ListOffsetsResponseSerde.Read,
                    cancellationToken
                )
            ;
        }

        public static async Task<OffsetCommitResponse> CommitOffsets(
            IConnection connection,
            int generationId,
            string memberId,
            IEnumerable<TopicPartitionOffset> topicPartitionOffsets,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var offsetCommitRequestTopic = topicPartitionOffsets
                .GroupBy(g => g.TopicPartition.Topic)
                .Select(t =>
                    new OffsetCommitRequest.OffsetCommitRequestTopic(
                        t.Key.Value ?? "",
                        t.Select(p =>
                            new OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition(
                                p.TopicPartition.Partition,
                                p.Offset,
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
                config.GroupId ?? "",
                generationId,
                memberId,
                config.GroupInstanceId,
                -1,
                offsetCommitRequestTopic
            );
            return await connection.ExecuteRequest(
                request,
                OffsetCommitRequestSerde.Write,
                OffsetCommitResponseSerde.Read,
                cancellationToken
            );
        }

        public static async Task<OffsetCommitResponse> CommitOffset(
            IConnection connection,
            int generationId,
            string memberId,
            TopicPartitionOffset topicPartitionOffset,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var offsetCommitRequestTopic = new[] {
                new OffsetCommitRequest.OffsetCommitRequestTopic(
                    topicPartitionOffset.TopicPartition.Topic,
                    new[]{
                        new OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition(
                            topicPartitionOffset.TopicPartition.Partition,
                            topicPartitionOffset.Offset,
                            -1,
                            Timestamp.Now().TimestampMs,
                            null
                        )
                    }.ToImmutableArray()
                )
            }.ToImmutableArray();
            var request = new OffsetCommitRequest(
                config.GroupId ?? "",
                generationId,
                memberId,
                config.GroupInstanceId,
                -1,
                offsetCommitRequestTopic
            );
            return await connection.ExecuteRequest(
                request,
                OffsetCommitRequestSerde.Write,
                OffsetCommitResponseSerde.Read,
                cancellationToken
            );
        }

        internal static async Task<FindCoordinatorResponse> FindCoordinator(
            IConnection connection,
            ConsumerConfig config,
            ILogger logger,
            CancellationToken cancellationToken
        )
        {
            var groupId = config.GroupId ?? "";
            var request = new FindCoordinatorRequest(
                groupId,
                (sbyte)CoordinatorType.GROUP,
                new[] { groupId }.ToImmutableArray()
            );
            return await RetryHandler.Run(
                connection,
                request,
                FindCoordinatorRequestSerde.Write,
                FindCoordinatorResponseSerde.Read,
                config.Retries,
                config.RetryBackoffMs,
                r => r.ErrorCodeField,
                (l, e) => l.LogError("{error}", e),
                logger,
                cancellationToken
            );
        }

        internal static async Task<FetchResponse> Fetch(
            IConnection connection,
            IEnumerable<KeyValuePair<TopicPartition, Offset>> topicPartitionOffsets,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var fetchTopics = topicPartitionOffsets
                .GroupBy(g => g.Key.Topic)
                .Select(t =>
                    new FetchRequest.FetchTopic(
                        t.Key,
                        Guid.Empty,
                        t.Select(tp =>
                            new FetchRequest.FetchTopic.FetchPartition(
                                PartitionField: tp.Key.Partition,
                                CurrentLeaderEpochField: -1,
                                FetchOffsetField: tp.Value,
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
            var request = new FetchRequest(
                ClusterIdField: null,
                ReplicaIdField: -1,
                MaxWaitMsField: config.FetchMaxWaitMs,
                MinBytesField: config.FetchMinBytes,
                MaxBytesField: config.FetchMaxBytes,
                IsolationLevelField: (sbyte)config.IsolationLevel,
                SessionIdField: -1,
                SessionEpochField: -1,
                TopicsField: fetchTopics,
                ForgottenTopicsDataField: ImmutableArray<FetchRequest.ForgottenTopic>.Empty,
                RackIdField: config.ClientRack
            ) with
            {
                MaxVersion = 11
            };
            return await connection.ExecuteRequest(
                request,
                FetchRequestSerde.Write,
                FetchResponseSerde.Read,
                cancellationToken
            );
        }
    }
}
