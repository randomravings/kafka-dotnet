using Kafka.Client.Clients.Admin.Model;
using Kafka.Client.Messages;
using Kafka.Common.Exceptions;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
using System.Collections.Immutable;
using static Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic;

namespace Kafka.Client.Clients.Admin
{
    public sealed class AdminClient :
        Client<AdminClientConfig>,
        IAdminClient
    {
        public AdminClient(AdminClientConfig config)
            : base(config) { }

        async ValueTask<ApiVersionsResult> IAdminClient.GetApiVersions(
            ApiVersionsOptions options,
            CancellationToken cancellationToken
        )
        {
            await EnsureConnection(cancellationToken);
            return new(
                _apiVersions
                .ToImmutableSortedDictionary(
                    k => new Api(k.Key),
                    v => v.Value
                )
            );
        }

        async ValueTask<ListTopicsResult> IAdminClient.ListTopics(
            ListTopicsOptions options,
            CancellationToken cancellationToken
        )
        {
            var request = new MetadataRequest(
                (options.ApiVersion == 0 ? null : ImmutableArray<MetadataRequest.MetadataRequestTopic>.Empty),
                options.IncludeInternal,
                false,
                false
            );
            var response = await HandleRequest(
                request,
                (s, v, r) => MetadataRequestSerde.Write(s, v, r),
                (ref ReadOnlyMemory<byte> s, short v) => MetadataResponseSerde.Read(ref s, v),
                options.ApiVersion,
                cancellationToken
            );
            var topics = response
                .TopicsField
                .Where(r => options.IncludeInternal || r.IsInternalField == false)
                .Select(r => new TopicListing(new(r.TopicIdField, r.NameField), r.IsInternalField))
                .ToImmutableSortedSet(
                    TopicListingCompare.Instance
                )
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
                        t.NumPartitions ?? -1,
                        t.ReplicationFactor ?? -1,
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
            var response = await HandleRequest(
                request,
                (s, v, r) => CreateTopicsRequestSerde.Write(s, v, r),
                (ref ReadOnlyMemory<byte> s, short v) => CreateTopicsResponseSerde.Read(ref s, v),
                options.ApiVersion,
                cancellationToken
            );
            var createdTopics = response
                .TopicsField
                .Where(r => r.ErrorCodeField == 0)
                .Select(
                    r => new CreateTopicsResult.CreatedTopicResult(
                        new(r.TopicIdField, r.NameField),
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
                .ToImmutableSortedDictionary(
                    k => k.Topic,
                    v => v
                )
            ;
            var errorTopics = response
                .TopicsField
                .Where(r => r.ErrorCodeField != 0)
                .ToImmutableSortedDictionary(
                    k => new Topic(k.TopicIdField, k.NameField),
                    v => new ApiException(
                        (ErrorCode)v.ErrorCodeField,
                        v.ErrorMessageField
                    )
                )
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
            var response = await HandleRequest(
                request,
                (s, v, r) => DeleteTopicsRequestSerde.Write(s, v, r),
                (ref ReadOnlyMemory<byte> s, short v) => DeleteTopicsResponseSerde.Read(ref s, v),
                options.ApiVersion,
                cancellationToken
            );
            var deletedTopics = response
                .ResponsesField
                .Where(r => r.ErrorCodeField == 0)
                .Select(
                    r => new Topic(r.TopicIdField, r.NameField)
                )
                .ToImmutableArray()
            ;
            var errorTopics = response
                .ResponsesField
                .Where(r => r.ErrorCodeField != 0)
                .ToImmutableSortedDictionary(
                    k => new Topic(k.TopicIdField, k.NameField),
                    v => new ApiException(
                        (ErrorCode)v.ErrorCodeField,
                        v.ErrorMessageField
                    )
                )
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
            var response = await HandleRequest(
                request,
                (s, v, r) => MetadataRequestSerde.Write(s, v, r),
                (ref ReadOnlyMemory<byte> s, short v) => MetadataResponseSerde.Read(ref s, v),
                options.ApiVersion,
                cancellationToken
            );
            return new(
                response.TopicsField.Select(
                    t => new DescribeTopicsResult.DescribeTopicResult(
                        t.TopicIdField,
                        t.NameField,
                        t.IsInternalField,
                        t.TopicAuthorizedOperationsField,
                        (ErrorCode)t.ErrorCodeField,
                        t.PartitionsField.Select(
                            p => new DescribeTopicsResult.DescribeTopicResult.TopicPartitionDescription(
                                p.PartitionIndexField,
                                p.LeaderIdField,
                                p.LeaderEpochField,
                                (ErrorCode)p.ErrorCodeField,
                                p.ReplicaNodesField,
                                p.IsrNodesField,
                                p.OfflineReplicasField
                            )
                        ).ToImmutableArray()
                    )
                )
                .ToImmutableSortedDictionary(
                    k => new Topic(k.TopicId, k.Name),
                    v => v,
                    TopicCompare.Instance
                )
            );
        }
    }
}
