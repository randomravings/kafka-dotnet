using Kafka.Client.Clients.Admin.Model;
using Kafka.Client.Messages;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin
{
    internal sealed class KafkaAdminClient :
        KafkaClient<IAdminClient, AdminClientConfig>,
        IAdminClient
    {
        private IAdminProtocol? _protocol;
        public KafkaAdminClient(
            AdminClientConfig config,
            ILogger<IAdminClient> logger
        )
            : base(config, logger) { }

        private async ValueTask<IAdminProtocol> GetProtocol(
            CancellationToken cancellationToken
        ) =>
            _protocol ??= await GetControllerProtocol<IAdminProtocol>(
                (connection, config, logger) => new AdminProtocol(connection, config, logger),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<ListTopicsResult> IAdminClient.ListTopics(
            ListTopicsOptions options,
            CancellationToken cancellationToken
        )
        {
            var protocol = await GetProtocol(cancellationToken).ConfigureAwait(false);

            var request = new MetadataRequestData(
                null,
                false,
                false,
                false,
                ImmutableArray<TaggedField>.Empty
            );
            var response = await protocol.Metadata(cancellationToken).ConfigureAwait(false);

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
            var protocol = await GetProtocol(cancellationToken).ConfigureAwait(false);
            var request = new CreateTopicsRequestData(
                options.Topics.Select(t =>
                    new CreateTopicsRequestData.CreatableTopic(
                        t.Name,
                        t.NumPartitions,
                        t.ReplicationFactor,
                        t.ReplicasAssignments.Select(r =>
                            new CreateTopicsRequestData.CreatableTopic.CreatableReplicaAssignment(
                                r.Key,
                                r.Value,
                                ImmutableArray<TaggedField>.Empty
                            )
                        ).ToImmutableArray(),
                        t.Configs.Select(c =>
                            new CreateTopicsRequestData.CreatableTopic.CreateableTopicConfig(
                                c.Key,
                                c.Value,
                                ImmutableArray<TaggedField>.Empty
                            )
                        ).ToImmutableArray(),
                        ImmutableArray<TaggedField>.Empty
                    )
                ).ToImmutableArray(),
                options.TimeoutMs,
                options.ValidateOnly,
                ImmutableArray<TaggedField>.Empty
            );
            var response = await protocol.CreateTopics(
                request,
                cancellationToken
            ).ConfigureAwait(false);
            var createdTopics = response
                .TopicsField
                .Where(r => r.ErrorCodeField == 0)
                .Select(
                    r => new CreateTopicResult(
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
                    r => new CreateTopicError(
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
            var protocol = await GetProtocol(cancellationToken).ConfigureAwait(false);
            var deleteTopicStateByIds = options.TopicIds.Select(
                    r => new DeleteTopicsRequestData.DeleteTopicState(
                        null,
                        r,
                        ImmutableArray<TaggedField>.Empty
                    )
                );
            var deleteTopicStateByNames = options.TopicNames.Select(
                    r => new DeleteTopicsRequestData.DeleteTopicState(
                        r,
                        Guid.Empty,
                        ImmutableArray<TaggedField>.Empty
                    )
                );
            var request = new DeleteTopicsRequestData(
                Enumerable.Concat(
                    deleteTopicStateByIds,
                    deleteTopicStateByNames
                ).ToImmutableArray(),
                options.TopicNames,
                options.TimeoutMs,
                ImmutableArray<TaggedField>.Empty
            );
            var response = await protocol.DeleteTopics(
                request,
                cancellationToken
            ).ConfigureAwait(false);
            var deletedTopics = response
                .ResponsesField
                .Where(r => r.ErrorCodeField == 0)
                .Select(
                    r => new DeleteTopicResult(
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
                    r => new DeleteTopicError(
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
            var protocol = await GetProtocol(cancellationToken).ConfigureAwait(false);
            var topicIds = options.TopicIds.Select(
                    r => new MetadataRequestData.MetadataRequestTopic(
                        r,
                        null,
                        ImmutableArray<TaggedField>.Empty
                    )
                );
            var topicNames = options.TopicNames.Select(
                    r => new MetadataRequestData.MetadataRequestTopic(
                        Guid.Empty,
                        r,
                        ImmutableArray<TaggedField>.Empty
                    )
                );
            var topics = Enumerable.Concat(
                    topicIds,
                    topicNames
                ).ToImmutableArray()
            ;
            var request = new MetadataRequestData(
                topics,
                false,
                false,
                true,
                ImmutableArray<TaggedField>.Empty
            );
            var response = await protocol.Metadata(
                request,
                cancellationToken
            ).ConfigureAwait(false);
            return new(
                response.TopicsField.Select(
                    t => new DescribeTopicResult(
                        t.TopicIdField,
                        t.NameField,
                        t.IsInternalField,
                        t.TopicAuthorizedOperationsField,
                        Errors.Translate(t.ErrorCodeField),
                        t.PartitionsField.Select(
                            p => new TopicPartitionDescription(
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
                .ToImmutableArray()
            );
        }

        protected override ValueTask OnClose(CancellationToken cancellationToken) =>
            ValueTask.CompletedTask
        ;
    }
}
