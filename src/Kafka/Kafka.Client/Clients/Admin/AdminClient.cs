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
            : base(config)
        {

        }

        async ValueTask<ApiVersionsResult> IAdminClient.GetApiVersions(
            ApiVersionsOptions apiVersionsOptions,
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
                null,
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
            ListTopicsOptions listTopicOption,
            CancellationToken cancellationToken
        )
        {
            var request = new MetadataRequest(
                ImmutableArray<MetadataRequest.MetadataRequestTopic>.Empty,
                false,
                true,
                true
            );
            var response = await HandleRequest(
                Api.Metadata,
                request,
                (s, v, r) => MetadataRequestSerde.Write(s, v, r),
                (s, v) => MetadataResponseSerde.Read(s, v),
                null,
                cancellationToken
            );
            var topics = response
                .TopicsField
                .Where(r => listTopicOption.IncludeInternal || r.IsInternalField == false)
                .ToImmutableSortedDictionary(
                    k => new Topic(k.NameField ?? ""),
                    v => new TopicListing(
                        v.NameField ?? "",
                        v.IsInternalField,
                        v.TopicIdField
                    )
                )
            ;
            return new(topics);
        }

        async ValueTask<CreateTopicsResult> IAdminClient.CreateTopic(
            CreateTopicsOptions createTopicOptions,
            CancellationToken cancellationToken
        )
        {
            var request = new CreateTopicsRequest(
                createTopicOptions.Topics.Select(t =>
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
                createTopicOptions.TimeoutMs,
                createTopicOptions.ValidateOnly
            );
            var response = await HandleRequest(
                Api.CreateTopics,
                request,
                (s, v, r) => CreateTopicsRequestSerde.Write(s, v, r),
                (s, v) => CreateTopicsResponseSerde.Read(s, v),
                null,
                cancellationToken
            );
            var createdTopics = response
                .TopicsField
                .Where(r => r.ErrorCodeField == 0)
                .ToImmutableSortedDictionary(
                    k => new Topic(k.NameField ?? ""),
                    v => new CreateTopicsResult.CreateTopicResult(
                        v.TopicIdField,
                        v.NumPartitionsField,
                        v.ReplicationFactorField,
                        v.ConfigsField.HasValue ?
                            v.ConfigsField.Value.ToImmutableSortedDictionary(
                                k => k.NameField,
                                v => v.ValueField
                            ) :
                            ImmutableSortedDictionary<string, string?>.Empty
                    )
                )
            ;
            var errorTopics = response
                .TopicsField
                .Where(r => r.ErrorCodeField != 0)
                .ToImmutableSortedDictionary(
                    k => new Topic(k.NameField ?? ""),
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
    }
}
