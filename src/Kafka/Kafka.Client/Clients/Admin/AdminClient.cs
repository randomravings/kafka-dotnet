using Kafka.Client.Clients.Admin.Model;
using Kafka.Client.Messages;
using Kafka.Common.Exceptions;
using Kafka.Common.Types;
using System.Collections.Immutable;
using static Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic;
using Version = Kafka.Common.Types.Version;

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
            var request = new ApiVersionsRequest(
                ".Net Client",
                "1.0.0"
            );
            var response = await HandleRequest(
                Api.ApiVersions,
                request,
                (s, v, r) => ApiVersionsRequestSerde.Write(s, v, r),
                (s, v) => ApiVersionsResponseSerde.Read(s, v),
                options.ApiVersion,
                cancellationToken
            );
            return new(
                response
                .ApiKeysField
                .ToImmutableSortedDictionary(
                    k => new Api(k.ApiKeyField),
                    v => new ApiVersion(
                        new Api(v.ApiKeyField),
                        new Version(
                            v.MinVersionField,
                            v.MaxVersionField
                        )
                    )
                )
            );
        }

        async ValueTask<ListTopicsResult> IAdminClient.ListTopics(
            ListTopicsOptions options,
            CancellationToken cancellationToken
        )
        {
            var request = new MetadataRequest(
                null,
                options.IncludeInternal,
                options.IncludeClusterAuthorizedOperations,
                options.IncludeTopicAuthorizedOperations
            );
            var response = await HandleRequest(
                Api.Metadata,
                request,
                (s, v, r) => MetadataRequestSerde.Write(s, v, r),
                (s, v) => MetadataResponseSerde.Read(s, v),
                options.ApiVersion,
                cancellationToken
            );
            var topics = response
                .TopicsField
                .Where(r => options.IncludeInternal || r.IsInternalField == false)
                .Select(r => new TopicListing(new(r.TopicIdField, r.NameField), r.IsInternalField))
                .ToImmutableSortedDictionary(
                    k => k.Topic,
                    v => v
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
                Api.CreateTopics,
                request,
                (s, v, r) => CreateTopicsRequestSerde.Write(s, v, r),
                (s, v) => CreateTopicsResponseSerde.Read(s, v),
                options.ApiVersion,
                cancellationToken
            );
            var createdTopics = response
                .TopicsField
                .Where(r => r.ErrorCodeField == 0)
                .Select(
                    r => new CreateTopicsResult.CreateTopicResult(
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
                        $"Error Code: {v.ErrorCodeField} - Message: {v.ErrorMessageField}"
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
            var request = new DeleteTopicsRequest(
                options.TopicsField.Select(
                    r => new DeleteTopicsRequest.DeleteTopicState(
                        r.NameField,
                        r.TopicIdField
                    )
                ).ToImmutableArray(),
                options.TopicNamesField,
                options.TimeoutMs
            );
            var response = await HandleRequest(
                Api.DeleteTopics,
                request,
                (s, v, r) => DeleteTopicsRequestSerde.Write(s, v, r),
                (s, v) => DeleteTopicsResponseSerde.Read(s, v),
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
                        $"Error Code: {v.ErrorCodeField} - Message: {v.ErrorMessageField}"
                    )
                )
            ;
            return new(
                deletedTopics,
                errorTopics
            );
        }
    }
}
