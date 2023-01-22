using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Common.Encoding;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal static class ConsumerProtocol
    {
        public static async ValueTask<MetadataResponse> RequestMetadata(
            IConnection connection,
            IEnumerable<TopicName> topicNames,
            CancellationToken cancellationToken
        )
        {
            var request = CreateMetadataRequest(
                topicNames
            );
            return await connection.ExecuteRequest(
                request,
                MetadataRequestSerde.Write,
                MetadataResponseSerde.Read,
                cancellationToken
            );
        }

        public static async ValueTask<HeartbeatResponse> RequestHeartbeat(
            IConnection connection,
            string memberId,
            int generationId,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var request = CreateHeartbeatRequest(
                memberId,
                generationId,
                config
            );
            return await connection.ExecuteRequest(
                request,
                HeartbeatRequestSerde.Write,
                HeartbeatResponseSerde.Read,
                cancellationToken
            );
        }

        public static async ValueTask<JoinGroupResponse> RequestJoinGroup(
            IConnection connection,
            string memberId,
            IEnumerable<TopicName> topicNames,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var request = CreateJoinGroupRequest(memberId, topicNames, config);
            return await connection.ExecuteRequest(
                request,
                JoinGroupRequestSerde.Write,
                JoinGroupResponseSerde.Read,
                cancellationToken
            );
        }

        public static async ValueTask<SyncGroupResponse> RequestSyncGroup(
            IConnection connection,
            int generationId,
            string memberId,
            string? protocolName,
            IEnumerable<TopicPartition> topicPartitions,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var request = CreateSyncGroupRequest(
                generationId,
                memberId,
                protocolName,
                topicPartitions,
                config
            );
            return await connection.ExecuteRequest(
                request,
                SyncGroupRequestSerde.Write,
                SyncGroupResponseSerde.Read,
                cancellationToken
            );
        }

        public static async ValueTask<LeaveGroupResponse> RequestLeaveGroup(
            IConnection connection,
            string memberId,
            ConsumerConfig config,
            CancellationToken cancellationToken
        )
        {
            var request = CreateLeaveRequest(
                memberId,
                config
            );
            return await connection.ExecuteRequest(
                request,
                LeaveGroupRequestSerde.Write,
                LeaveGroupResponseSerde.Read,
                cancellationToken
            );
        }

        public static async ValueTask<OffsetFetchResponse> RequestOffsetFetch(
            IConnection connection,
            ConsumerConfig config,
            IEnumerable<TopicPartition> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var request = CreateOffsetFetchRequest(
                config,
                topicPartitionOffsets
            );
            return await connection.ExecuteRequest(
                request,
                OffsetFetchRequestSerde.Write,
                OffsetFetchResponseSerde.Read,
                cancellationToken
            );
        }

        public static async ValueTask<ImmutableArray<ListOffsetsResponse>> RequestListOffsets(
            ImmutableArray<NodeAssignment> nodeAssignments,
            ImmutableSortedSet<TopicPartition> topicPartitions,
            IsolationLevel isolationLevel,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        )
        {
            var nodeCount = nodeAssignments.Length;
            var tasks = new Task<ListOffsetsResponse>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                var topicPartitionsToList = nodeAssignments[i]
                    .TopicPartitions
                    .Intersect(topicPartitions)
                ;
                var tpoCount = topicPartitionsToList.Count;
                if (tpoCount == 0)
                {
                    tasks[i] = Task.FromResult(ListOffsetsResponse.Empty);
                    continue;
                }

                var request = CreateListOffsetsRequest(
                    topicPartitionsToList,
                    isolationLevel,
                    timestamp
                );
                tasks[i] = nodeAssignments[i]
                    .Connection
                    .ExecuteRequest(
                        request,
                        ListOffsetsRequestSerde.Write,
                        ListOffsetsResponseSerde.Read,
                        cancellationToken
                    )
                ;
            }

            await Task.WhenAll(tasks);

            return tasks
                .Select(r => r.Result)
                .ToImmutableArray()
            ;
        }

        public static async ValueTask<OffsetCommitResponse> RequestCommitOffsets(
            IConnection connection,
            int generationId,
            string memberId,
            ConsumerConfig config,
            IEnumerable<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            var request = CreateCommitRequest(
                generationId,
                memberId,
                config,
                topicPartitionOffsets
            );
            return await connection.ExecuteRequest(
                request,
                OffsetCommitRequestSerde.Write,
                OffsetCommitResponseSerde.Read,
                cancellationToken
            );
        }

        public static async ValueTask<OffsetCommitResponse> RequestCommitOffset(
            IConnection connection,
            int generationId,
            string memberId,
            ConsumerConfig config,
            TopicPartitionOffset topicPartitionOffset,
            CancellationToken cancellationToken
        )
        {
            var request = CreateCommitRequest(
                generationId,
                memberId,
                config,
                topicPartitionOffset
            );
            return await connection.ExecuteRequest(
                request,
                OffsetCommitRequestSerde.Write,
                OffsetCommitResponseSerde.Read,
                cancellationToken
            );
        }

        private static MetadataRequest CreateMetadataRequest(
            IEnumerable<TopicName> topicNames
        ) => new(
                topicNames.Select(r => new MetadataRequest.MetadataRequestTopic(
                        Guid.Empty,
                        r
                    )
                ).ToImmutableArray(),
                true,
                false,
                false
            )
        ;

        private static HeartbeatRequest CreateHeartbeatRequest(
            string memberId,
            int generationId,
            ConsumerConfig config
        ) => new(
                config.GroupId ?? "",
                generationId,
                memberId,
                config.GroupInstanceId
            )
        ;

        private static JoinGroupRequest CreateJoinGroupRequest(
            string memberId,
            IEnumerable<TopicName> topicNames,
            ConsumerConfig config
        )
        {
            var metadataSize = 
                2 + // version
                4 + // count
                topicNames.Sum(r => 2 + r.Value?.Length ?? 0) + // topic names including size
                8 // no idea what this is ...
            ;
            var topicMetadata = new byte[metadataSize];
            var offset = 0;
            offset = Encoder.WriteInt16(topicMetadata, offset, 1);
            offset = Encoder.WriteInt32(topicMetadata, offset, topicNames.Count());
            foreach (var topic in topicNames)
                offset = Encoder.WriteString(topicMetadata, offset, topic);

            return new JoinGroupRequest(
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
        }

        private static SyncGroupRequest CreateSyncGroupRequest(
            int generationId,
            string memberId,
            string? protocolName,
            IEnumerable<TopicPartition> topicPartitions,
            ConsumerConfig config
        )
        {
            var topics = topicPartitions.Select(r => $"{r.Topic.Value}").Distinct();
            var topicNameBytes = topics.Sum(r => r.Length);
            var groupedTopics = topicPartitions
                .GroupBy(r => r.Topic.Value ?? "")
            ;
            var size =
                4 + // some magic
                2 + // number of assignments
                (topics.Count() * 2) + // topic name length
                topicNameBytes + // total bytes for topic names
                (topics.Count() * 4) + // partition counts
                (topicPartitions.Count() * 4) // partition indices
            ;

            var synbGroupRequestAssignmentsBuilder = ImmutableArray.CreateBuilder<SyncGroupRequest.SyncGroupRequestAssignment>();
            var bytes = new byte[size];
            var offset = 4; // skipping magic
            offset = Encoder.WriteInt16(bytes, offset, (short)topics.Count());
            foreach (var groupedTopic in groupedTopics)
            {
                offset = Encoder.WriteString(bytes, offset, groupedTopic.Key);
                offset = Encoder.WriteInt32(bytes, offset, groupedTopic.Count());
                foreach (var partition in groupedTopic.OrderBy(r => r.Partition.Value))
                    offset = Encoder.WriteInt32(bytes, offset, partition.Partition.Value);
            }
            synbGroupRequestAssignmentsBuilder.Add(new SyncGroupRequest.SyncGroupRequestAssignment(
                memberId,
                bytes
            ));
            return new SyncGroupRequest(
                config.GroupId ?? "",
                generationId,
                memberId,
                config.GroupInstanceId,
                "consumer",
                protocolName,
                synbGroupRequestAssignmentsBuilder.ToImmutable()
            );
        }

        private static LeaveGroupRequest CreateLeaveRequest(
            string memberId,
            ConsumerConfig config
        )
        {
            return new LeaveGroupRequest(
                config.GroupId ?? "",
                memberId,
                ImmutableArray<LeaveGroupRequest.MemberIdentity>.Empty
            );
        }

        private static OffsetFetchRequest CreateOffsetFetchRequest(
            ConsumerConfig config,
            IEnumerable<TopicPartition> topicPartitionOffsets
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

            return new OffsetFetchRequest(
                config.GroupId ?? "",
                topicsToFetch,
                topicsInGroupToFetch,
                false
            );
        }

        public static ListOffsetsRequest CreateListOffsetsRequest(
            IEnumerable<TopicPartition> topicPartitions,
            IsolationLevel isolationLevel,
            DateTimeOffset timestamp
        ) => new(
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
            )
        ;

        private static OffsetCommitRequest CreateCommitRequest(
            int generationId,
            string memberId,
            ConsumerConfig config,
            IEnumerable<TopicPartitionOffset> topicPartitionOffsets
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
            return new OffsetCommitRequest(
                config.GroupId ?? "",
                generationId,
                memberId,
                config.GroupInstanceId,
                -1,
                offsetCommitRequestTopic
            );
        }

        private static OffsetCommitRequest CreateCommitRequest(
            int generationId,
            string memberId,
            ConsumerConfig config,
            TopicPartitionOffset topicPartitionOffset
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
            return new OffsetCommitRequest(
                config.GroupId ?? "",
                generationId,
                memberId,
                config.GroupInstanceId,
                -1,
                offsetCommitRequestTopic
            );
        }
    }
}
