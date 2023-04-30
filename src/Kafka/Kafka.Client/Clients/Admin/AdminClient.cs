using Kafka.Client.Clients.Admin.Model;
using Kafka.Client.Messages;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using static Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic;

namespace Kafka.Client.Clients.Admin
{
    public sealed class AdminClient :
        Client<IAdminClient, AdminClientConfig>,
        IAdminClient
    {
        public AdminClient(
            AdminClientConfig config,
            ILogger<IAdminClient> logger
        )
            : base(config, logger) { }

        async ValueTask<ListTopicsResult> IAdminClient.ListTopics(
            ListTopicsOptions options,
            CancellationToken cancellationToken
        )
        {
            var request = new MetadataRequest(
                null,
                false,
                false,
                false
            );
            using var connection = await GetController(cancellationToken);
            var response = await connection.ExecuteRequest(
                request,
                MetadataRequestSerde.Write,
                MetadataResponseSerde.Read,
                cancellationToken
            );

            var topics = response
                .TopicsField
                    .Where(r => options.IncludeInternal || r.IsInternalField == false)
                    .Select(r => new TopicInfo(
                        r.TopicIdField,
                        r.NameField,
                        r.IsInternalField,
                        r.PartitionsField
                            .Select(p => new TopicInfo.PartitionInfo(
                                p.PartitionIndexField,
                                p.LeaderIdField,
                                p.IsrNodesField
                                    .Select(i => new ClusterNodeId(i))
                                    .ToImmutableArray()
                            ))
                            .ToImmutableArray()
                        ))
                    .OrderBy(r => r.Name, TopicNameCompare.Instance)
                    .ThenBy(r => r.Id)
                    .ToImmutableArray()
                ;
            return new(topics);
        }

        async ValueTask<CreateTopicsResult> IAdminClient.CreateTopics(
            CreateTopicsOptions options,
            CancellationToken cancellationToken
        )
        {
            var request = new CreateTopicsRequest(
                options.Topics.Select(t =>
                    new CreateTopicsRequest.CreatableTopic(
                        t.Name,
                        t.NumPartitions,
                        t.ReplicationFactor,
                        t.ReplicasAssignments.Select(r =>
                            new CreatableReplicaAssignment(
                                r.Key,
                                r.Value
                            )
                        ).ToImmutableArray(),
                        t.Configs.Select(c =>
                            new CreateableTopicConfig(
                                c.Key,
                                c.Value
                            )
                        ).ToImmutableArray()
                    )
                ).ToImmutableArray(),
                options.TimeoutMs,
                options.ValidateOnly
            );
            using var connection = await GetController(cancellationToken);
            var response = await connection.ExecuteRequest(
                request,
                CreateTopicsRequestSerde.Write,
                CreateTopicsResponseSerde.Read,
                cancellationToken
            );
            var createdTopics = response
                .TopicsField
                .Where(r => r.ErrorCodeField == 0)
                .Select(
                    r => new CreateTopicsResult.CreateTopicResult(
                        r.TopicIdField,
                        r.NameField,
                        r.NumPartitionsField,
                        r.ReplicationFactorField,
                        r.ConfigsField.HasValue ?
                            r.ConfigsField.Value.ToImmutableSortedDictionary(
                                k => k.NameField,
                                v => v.ValueField
                            ) :
                            ImmutableSortedDictionary<string, string?>.Empty
                    )
                )
                .ToImmutableArray()
            ;
            var errorTopics = response
                .TopicsField
                .Where(r => r.ErrorCodeField != 0)
                .Select(
                    r => new CreateTopicsResult.CreateTopicError(
                        r.NameField,
                        Errors.Translate(r.ErrorCodeField)
                    )
                )
                .ToImmutableArray()
            ;
            return new CreateTopicsResult(
                createdTopics,
                errorTopics
            );
        }

        async ValueTask<DeleteTopicsResult> IAdminClient.DeleteTopics(
            DeleteTopicsOptions options,
            CancellationToken cancellationToken
        )
        {
            var deleteTopicStateByIds = options.TopicIds.Select(
                    r => new DeleteTopicsRequest.DeleteTopicState(
                        null,
                        r
                    )
                );
            var deleteTopicStateByNames = options.TopicNames.Select(
                    r => new DeleteTopicsRequest.DeleteTopicState(
                        r,
                        Guid.Empty
                    )
                );
            var request = new DeleteTopicsRequest(
                Enumerable.Concat(
                    deleteTopicStateByIds,
                    deleteTopicStateByNames
                ).ToImmutableArray(),
                options.TopicNames,
                options.TimeoutMs
            );
            using var connection = await GetController(cancellationToken);
            var response = await connection.ExecuteRequest(
                request,
                DeleteTopicsRequestSerde.Write,
                DeleteTopicsResponseSerde.Read,
                cancellationToken
            );
            var deletedTopics = response
                .ResponsesField
                .Where(r => r.ErrorCodeField == 0)
                .Select(
                    r => new DeleteTopicsResult.DeleteTopicResult(
                        r.TopicIdField,
                        r.NameField
                    )
                )
                .ToImmutableArray()
            ;
            var errorTopics = response
                .ResponsesField
                .Where(r => r.ErrorCodeField != 0)
                .Select(
                    r => new DeleteTopicsResult.DeleteTopicError(
                        r.NameField,
                        Errors.Translate(r.ErrorCodeField)
                    )
                )
                .ToImmutableArray()
            ;
            return new(
                deletedTopics,
                errorTopics
            );
        }

        async ValueTask<DescribeTopicsResult> IAdminClient.DescribeTopics(
            DescribeTopicsOptions options,
            CancellationToken cancellationToken
        )
        {
            var topicIds = options.TopicIds.Select(
                    r => new MetadataRequest.MetadataRequestTopic(
                        r,
                        null
                    )
                );
            var topicNames = options.TopicNames.Select(
                    r => new MetadataRequest.MetadataRequestTopic(
                        Guid.Empty,
                        r
                    )
                );
            var topics = Enumerable.Concat(
                    topicIds,
                    topicNames
                ).ToImmutableArray()
            ;
            var request = new MetadataRequest(
                topics,
                false,
                false,
                true
            );
            using var connection = await GetController(cancellationToken);
            var response = await connection.ExecuteRequest(
                request,
                MetadataRequestSerde.Write,
                MetadataResponseSerde.Read,
                cancellationToken
            );
            return new(
                response.TopicsField.Select(
                    t => new DescribeTopicsResult.DescribeTopicResult(
                        t.TopicIdField,
                        t.NameField,
                        t.IsInternalField,
                        t.TopicAuthorizedOperationsField,
                        Errors.Translate(t.ErrorCodeField),
                        t.PartitionsField.Select(
                            p => new DescribeTopicsResult.DescribeTopicResult.TopicPartitionDescription(
                                p.PartitionIndexField,
                                p.LeaderIdField,
                                p.LeaderEpochField,
                                Errors.Translate(p.ErrorCodeField),
                                p.ReplicaNodesField,
                                p.IsrNodesField,
                                p.OfflineReplicasField
                            )
                        ).ToImmutableArray()
                    )
                )
                .ToImmutableSortedDictionary(
                    k => new TopicName(k.Name),
                    v => v,
                    TopicNameCompare.Instance
                )
            );
        }

        private async ValueTask<IConnection> GetController(CancellationToken cancellationToken)
        {
            var connection = await _connectionPool.AquireSharedConnection(cancellationToken);
            var cluster = await connection.GetClusterInfo(cancellationToken);
            if (cluster.Controller.Id == connection.NodeId)
                return connection;
            await connection.Close(cancellationToken);
            return await _connectionPool.AquireSharedConnection(cluster.Controller.Host, cluster.Controller.Port, cancellationToken);
        }

        protected override async ValueTask OnClose(CancellationToken cancellationToken) =>
            await ValueTask.CompletedTask
        ;
    }
}
