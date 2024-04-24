using Kafka.Client.Config;
using Kafka.Client.Read;
using Kafka.Client.Write;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Model.Internal;
using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client
{
    internal sealed class KafkaClient(
        ImmutableArray<BootstrapServer> bootstrapServers,
        KafkaClientConfig config,
        ILogger<IKafkaClient> logger
    ) :
        IKafkaClient
    {
        private readonly Net.Cluster _connections =
            new(
                bootstrapServers,
                config,
                logger
            )
        ;
        private readonly KafkaClientConfig _config = config;
        private readonly ILogger<IKafkaClient> _logger = logger;

        async Task IKafkaClient.Close(
            CancellationToken cancellationToken
        )
        {
            await _connections.CloseAll(
                cancellationToken
            ).ConfigureAwait(false);
        }

        IReadStreamBuilder IKafkaClient.CreateReadStream() =>
            new ReadStreamBuilder(
                _connections,
                _config.ReadStream,
                _logger
            )
        ;

        IReadStreamBuilder IKafkaClient.CreateReadStream(Action<ReadStreamConfig> configure)
        {
            var config = new ReadStreamConfig();
            configure(config);
            return new ReadStreamBuilder(
                _connections,
                config,
                _logger
            );
        }

        IWriteStreamBuilder IKafkaClient.CreateWriteStream() =>
            new WriteStreamBuilder(
                _connections,
                _config.WriteStream,
                _logger
            )
        ;

        IWriteStreamBuilder IKafkaClient.CreateWriteStream(Action<WriteStreamConfig> configure)
        {
            var config = new WriteStreamConfig();
            configure(config);
            return new WriteStreamBuilder(
                _connections,
                config,
                _logger
            );
        }

        async ValueTask<CreateTopicsResult> IKafkaClient.CreateTopic(
            CreateTopicDefinition topic,
            CreateTopicOptions options,
            CancellationToken cancellationToken
        ) =>
            await CreateTopics(
                ImmutableArray.Create(topic),
                options,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<CreateTopicsResult> IKafkaClient.CreateTopics(
            IEnumerable<CreateTopicDefinition> topics,
            CreateTopicOptions options,
            CancellationToken cancellationToken
        ) =>
            await CreateTopics(
                topics,
                options,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<CreateTopicsResult> CreateTopics(
            IEnumerable<CreateTopicDefinition> topics,
            CreateTopicOptions options,
            CancellationToken cancellationToken
        )
        {
            var protocol = await _connections.Controller(cancellationToken)
                .ConfigureAwait(false)
            ;
            var request = new CreateTopicsRequestData(
                topics.Select(t =>
                    new CreateTopicsRequestData.CreatableTopic(
                        t.Name,
                        t.NumPartitions,
                        t.ReplicationFactor,
                        t.ReplicasAssignments.Select(r =>
                            new CreateTopicsRequestData.CreatableTopic.CreatableReplicaAssignment(
                                r.Key,
                                r.Value.Select(r => r.Value).ToImmutableArray(),
                                []
                            )
                        ).ToImmutableArray(),
                        t.Configs.Select(c =>
                            new CreateTopicsRequestData.CreatableTopic.CreateableTopicConfig(
                                c.Key,
                                c.Value,
                                []
                            )
                        ).ToImmutableArray(),
                        []
                    )
                ).ToImmutableArray(),
                _config.Client.RequestTimeoutMs,
                options.ValidateOnly,
                []
            );
            var response = await protocol.CreateTopics(
                request,
                cancellationToken
            ).ConfigureAwait(false);
            var createdTopics = response
                .TopicsField
                .Select(
                    r => new CreateTopicResult(
                        r.TopicIdField,
                        r.NameField,
                        r.NumPartitionsField,
                        r.ReplicationFactorField,
                        r.ConfigsField.IsDefaultOrEmpty ?
                            ImmutableSortedDictionary<string, string?>.Empty :
                            r.ConfigsField.ToImmutableSortedDictionary(
                                k => k.NameField,
                                v => v.ValueField
                            ),
                        r.ErrorCodeField == 0 ?
                            ApiError.None :
                            ApiErrors.Translate(r.ErrorCodeField)
                    )
                )
                .ToImmutableArray()
            ;
            return new CreateTopicsResult(
                createdTopics
            );
        }

        async ValueTask<DeleteTopicsResult> IKafkaClient.DeleteTopic(
            TopicName topic,
            CancellationToken cancellationToken
        ) =>
            await DeleteTopics(
                ImmutableArray.Create(topic),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<DeleteTopicsResult> IKafkaClient.DeleteTopics(
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        ) =>
            await DeleteTopics(
                topics,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<DeleteTopicsResult> DeleteTopics(
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            var protocol = await _connections.Controller(cancellationToken)
                .ConfigureAwait(false)
            ;
            var topicNames = topics
                .Select(r => r.Value ?? "")
                .ToImmutableArray()
            ;
            var deleteTopicStates = topicNames
                .Select(
                    r => new DeleteTopicsRequestData.DeleteTopicState(
                        r,
                        Guid.Empty,
                        []
                    )
                )
                .ToImmutableArray()
            ;
            var request = new DeleteTopicsRequestData(
                deleteTopicStates,
                topicNames,
                _config.Client.RequestTimeoutMs,
                []
            );
            var response = await protocol.DeleteTopics(
                request,
                cancellationToken
            ).ConfigureAwait(false);
            var deletedTopics = response
                .ResponsesField
                .Select(
                    r => new DeleteTopicResult(
                        r.TopicIdField,
                        r.NameField,
                        r.ErrorCodeField == 0 ?
                            ApiError.None :
                            ApiErrors.Translate(r.ErrorCodeField)
                    )
                )
                .ToImmutableArray()
            ;
            return new(
                deletedTopics
            );
        }

        async ValueTask<IReadOnlyList<TopicDescription>> IKafkaClient.ListTopics(
            TopicName topic,
            ListTopicsOptions options,
            CancellationToken cancellationToken
        ) =>
            await List(
                [topic],
                options,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyList<TopicDescription>> IKafkaClient.ListTopics(
            IEnumerable<TopicName> topics,
            ListTopicsOptions options,
            CancellationToken cancellationToken
        ) =>
            await List(
                topics,
                options,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyList<TopicDescription>> IKafkaClient.ListTopics(
            ListTopicsOptions options,
            CancellationToken cancellationToken
        ) =>
            await List(
                ImmutableSortedSet<TopicName>.Empty,
                options,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<IReadOnlyList<TopicDescription>> List(
            IEnumerable<TopicName> topics,
            ListTopicsOptions options,
            CancellationToken cancellationToken
        )
        {
            var protocol = await _connections.Controller(cancellationToken)
                .ConfigureAwait(false)
            ;

            var metadataTopicsReques = topics
                .Select(t => new MetadataRequestData.MetadataRequestTopic(
                    Guid.Empty,
                    t.Value,
                    []
                ))
                .ToImmutableArray();
            ;

            var request = new MetadataRequestData(
                metadataTopicsReques.Length == 0 ? default : metadataTopicsReques,
                false,
                false,
                options.IncludeTopicAuthorizedOperations,
                []
            );
            var response = await protocol.Metadata(
                request,
                cancellationToken
            ).ConfigureAwait(false);

            return response
                .TopicsField
                .Where(t => options.IncludeInternal || t.IsInternalField == false)
                .Select(t => new TopicDescription(
                    t.TopicIdField,
                    t.NameField,
                    t.IsInternalField,
                    t.PartitionsField
                        .Select(p => new PartitionDescription(
                            p.PartitionIndexField,
                            p.LeaderIdField,
                            p.LeaderEpochField,
                            p.ReplicaNodesField
                                .Select(i => new NodeId(i))
                                .ToImmutableArray(),
                            p.IsrNodesField
                                .Select(i => new NodeId(i))
                                .ToImmutableArray(),
                            p.OfflineReplicasField
                                .Select(i => new NodeId(i))
                                .ToImmutableArray(),
                            p.ErrorCodeField == 0 ?
                                ApiError.None :
                                ApiErrors.Translate(p.ErrorCodeField)
                        ))
                        .ToImmutableArray(),
                    AclOperations(t.TopicAuthorizedOperationsField),
                    t.ErrorCodeField == 0 ?
                        ApiError.None :
                        ApiErrors.Translate(t.ErrorCodeField)
                ))
                .OrderBy(t => t.TopicName, TopicNameCompare.Instance)
                .ThenBy(t => t.TopicId)
                .ToImmutableArray()
            ;
        }

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsStart(
            TopicName topic,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToReadOnlySet(topic),
                [],
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsStart(
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToReadOnlySet(topics),
                [],
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsStart(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadOnlySet(topicPartition),
                ToReadOnlySet(topicPartition),
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsStart(
            IEnumerable<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadOnlySet(topicPartitions),
                ToReadOnlySet(topicPartitions),
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsEnd(
            TopicName topicName,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToReadOnlySet(topicName),
                [],
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsEnd(
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToReadOnlySet(topics),
                [],
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsEnd(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadOnlySet(topicPartition),
                [topicPartition],
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsEnd(
            IEnumerable<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadOnlySet(topicPartitions),
                ToReadOnlySet(topicPartitions),
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsForTimestamp(
            TopicName topicName,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToReadOnlySet(topicName),
                [],
                timestamp,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsForTimestamp(
            IEnumerable<TopicName> topics,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToReadOnlySet(topics),
                [],
                timestamp,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsForTimestamp(
            TopicPartition topicPartition,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadOnlySet(topicPartition),
                ToReadOnlySet(topicPartition),
                timestamp,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IKafkaClient.GetOffsetsForTimestamp(
            IEnumerable<TopicPartition> topicPartitions,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadOnlySet(topicPartitions),
                ToReadOnlySet(topicPartitions),
                timestamp,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyList<GroupDescription>> IKafkaClient.ListGroups(
            ListGroupsOptions options,
            CancellationToken cancellationToken
        )
        {
            var responses = await ListGroups(
                options,
                cancellationToken
            ).ConfigureAwait(false);
            var resultsBuilder = ImmutableArray.CreateBuilder<GroupDescription>();
            foreach (var (nodeId, listGroupsResponse) in responses)
            {
                foreach (var group in listGroupsResponse.GroupsField)
                    resultsBuilder.Add(new GroupDescription(
                        group.GroupIdField,
                        group.ProtocolTypeField,
                        group.GroupStateField,
                        nodeId
                    ));
            }
            return resultsBuilder.ToImmutable();
        }

        private async ValueTask<KeyValuePair<NodeId, ListGroupsResponseData>[]> ListGroups(
            ListGroupsOptions options,
            CancellationToken cancellationToken
        )
        {
            var connection = await _connections.Controller(
                cancellationToken
            ).ConfigureAwait(false);
            var metadata = await connection.Metadata(
                cancellationToken
            ).ConfigureAwait(false);

            var states = options.States.Select(r => r.ToString()).ToImmutableArray();
            var types = options.Types.Select(r => r.ToString()).ToImmutableArray();
            var request = new ListGroupsRequestData(
                states,
                types,
                []
            );

            var listTasks = metadata
                .BrokersField
                .Select(r => Task.Run(async () =>
                {
                    var brokerConnection = await _connections.Connection(
                        r.NodeIdField,
                        cancellationToken
                    ).ConfigureAwait(false);
                    var result = await brokerConnection.ListGroups(
                        request,
                        cancellationToken
                    ).ConfigureAwait(false);
                    return new KeyValuePair<NodeId, ListGroupsResponseData>(r.NodeIdField, result);
                }, CancellationToken.None))
                .ToImmutableArray()
            ;
            return await Task.WhenAll(
                listTasks
            ).ConfigureAwait(false);
        }

        async ValueTask<IReadOnlyList<DescribeGroupResult>> IKafkaClient.DescribeGroups(
            IEnumerable<ConsumerGroup> groups,
            DescribeGroupOptions options,
            CancellationToken cancellationToken
        )
        {
            var groupsByCoordinators = await FindCoordinators(
                groups,
                cancellationToken
            ).ConfigureAwait(false);

            var describeTasks = groupsByCoordinators
                .Select(r => Task.Run(async () =>
                {
                    var brokerConnection = await _connections.Connection(
                        r.Key,
                        cancellationToken
                    ).ConfigureAwait(false);
                    var request = new DescribeGroupsRequestData(
                        r.Value,
                        options.IncludeAuthorizedOperations,
                        []
                    );
                    var result = await brokerConnection.DescribeGroups(
                        request,
                        cancellationToken
                    ).ConfigureAwait(false);
                    return new KeyValuePair<NodeId, DescribeGroupsResponseData>(r.Key, result);
                }, CancellationToken.None))
                .ToImmutableArray()
            ;
            var responses = await Task.WhenAll(
                describeTasks
            ).ConfigureAwait(false);

            var resultsBuilder = ImmutableArray.CreateBuilder<DescribeGroupResult>();
            foreach (var (nodeId, response) in responses)
            {
                foreach (var result in response.GroupsField)
                {
                    resultsBuilder.Add(new DescribeGroupResult(
                        result.GroupIdField,
                        result.GroupStateField,
                        result.ProtocolTypeField,
                        result.ProtocolDataField,
                        nodeId,
                        result.MembersField
                            .Select(r => new DescribeGroupMemberResult(
                                r.MemberIdField,
                                r.GroupInstanceIdField,
                                r.ClientIdField,
                                r.ClientHostField,
                                result.ProtocolTypeField == "consumer" ? Membership.UnpackProtocolMetadata(r.MemberMetadataField) : ProtocolMetadata.Empty,
                                result.ProtocolTypeField == "consumer" ? Membership.UnpackTopicPartitions(r.MemberAssignmentField) : ImmutableSortedSet<TopicPartition>.Empty
                            )).ToImmutableArray(),
                        AclOperations(result.AuthorizedOperationsField),
                        result.ErrorCodeField == 0 ?
                            ApiError.None :
                            ApiErrors.Translate(result.ErrorCodeField)
                    ));
                }
            }
            return resultsBuilder.ToImmutable();
        }

        async ValueTask<IReadOnlyList<DeleteGroupResult>> IKafkaClient.DeleteGroups(
            IEnumerable<ConsumerGroup> groups,
            CancellationToken cancellationToken
        )
        {
            var groupsByCoordinators = await FindCoordinators(
                groups,
                cancellationToken
            ).ConfigureAwait(false);

            var deleteTasks = groupsByCoordinators
                .Select(r => Task.Run(async () =>
                {
                    var brokerConnection = await _connections.Connection(
                        r.Key,
                        cancellationToken
                    ).ConfigureAwait(false);
                    var request = new DeleteGroupsRequestData(
                        r.Value,
                        []
                    );
                    var result = await brokerConnection.DeleteGroups(
                        request,
                        cancellationToken
                    ).ConfigureAwait(false);
                    return new KeyValuePair<NodeId, DeleteGroupsResponseData>(r.Key, result);
                }, CancellationToken.None))
                .ToImmutableArray()
            ;
            var responses = await Task.WhenAll(
                deleteTasks
            ).ConfigureAwait(false);

            var resultsBuilder = ImmutableArray.CreateBuilder<DeleteGroupResult>();
            foreach (var (nodeId, response) in responses)
            {
                foreach (var result in response.ResultsField)
                {
                    resultsBuilder.Add(new DeleteGroupResult(
                        result.GroupIdField,
                        result.ErrorCodeField == 0 ?
                            ApiError.None :
                            ApiErrors.Translate(result.ErrorCodeField)
                    ));
                }
            }
            return resultsBuilder.ToImmutable();
        }

        async ValueTask<IReadOnlyDictionary<ConsumerGroup, IReadOnlyList<TopicPartitionOffset>>> IKafkaClient.GetOffsetsCommitted(
            IEnumerable<ConsumerGroup> group,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                ToReadOnlySet(group),
                [],
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<ConsumerGroup, IReadOnlyList<TopicPartitionOffset>>> IKafkaClient.GetOffsetsCommitted(
            IEnumerable<ConsumerGroup> group,
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                ToReadOnlySet(group),
                ToReadOnlySet(topics),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyList<AclResource>> IKafkaClient.DescribeAcls(
            DescribeAclOptions options,
            CancellationToken cancellationToken
        )
        {
            var request = new DescribeAclsRequestData(
                (sbyte)options.ResourceType,
                options.ResourceNameFilter,
                (sbyte)options.PatternType,
                options.PrincipalFilter,
                options.HostFilter,
                (sbyte)options.Operation,
                (sbyte)options.PermissionType,
                []
            );
            var connection = await _connections.Controller(
                cancellationToken
            ).ConfigureAwait(false);

            var result = await connection.DescribeAcls(
                request,
                cancellationToken
            ).ConfigureAwait(false);

            return result
                .ResourcesField
                .Select(r => new AclResource(
                    (ResourceType)r.ResourceTypeField,
                    r.ResourceNameField,
                    (PatternType)r.PatternTypeField,
                    r.AclsField.Select(a => new Acl(
                        a.PrincipalField,
                        a.HostField,
                        (AclOperation)a.OperationField,
                        (AclPermissionType)a.PermissionTypeField
                    ))
                    .ToImmutableArray()
                ))
                .ToImmutableArray()
            ;
        }

        ValueTask<IReadOnlyList<CreateAclResult>> IKafkaClient.CreateAcls(
            CreateAclOptions options,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        ValueTask<IReadOnlyList<DeleteAclResult>> IKafkaClient.DeleteAcls(
            DeleteAclOptions options,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> ListTopicPartitionOffsets(
            ImmutableSortedSet<TopicName> topics,
            ImmutableSortedSet<TopicPartition> filter,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        )
        {
            var protocol = await _connections.Controller(
                cancellationToken
            ).ConfigureAwait(false);
            var metadataRequest = new MetadataRequestData(
                topics.Select(t =>
                    new MetadataRequestData.MetadataRequestTopic(
                        Guid.Empty,
                        t,
                        []
                    )
                )
                .ToImmutableArray(),
                false,
                false,
                false,
                []
            );
            var metadataResponse = await protocol.Metadata(
                metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);
            var listOffsetsRequest = new ListOffsetsRequestData(
                -1,
                (sbyte)IsolationLevel.ReadCommitted,
                metadataResponse
                    .TopicsField
                    .Select(t => new ListOffsetsRequestData.ListOffsetsTopic(
                        t.NameField ?? "",
                        t.PartitionsField
                            .Where(p => !filter.IsEmpty || filter.Contains(new TopicPartition(t.NameField, p.PartitionIndexField)))
                            .Select(p => new ListOffsetsRequestData.ListOffsetsTopic.ListOffsetsPartition(
                                p.PartitionIndexField,
                                p.LeaderEpochField,
                                timestamp.ToUnixTimeMilliseconds(),
                                1,
                                []
                            )
                        )
                        .ToImmutableArray(),
                        []
                    )
                )
                .ToImmutableArray(),
                []
            );
            var listOffsetsResponse = await protocol.ListOffsets(
                listOffsetsRequest,
                cancellationToken
            ).ConfigureAwait(false);
            return listOffsetsResponse
                .TopicsField
                .ToImmutableSortedDictionary(
                    k => new TopicName(k.NameField),
                    v => v.PartitionsField
                        .Select(p => new PartitionOffset(p.PartitionIndexField, p.OffsetField))
                        .ToImmutableArray(),
                    TopicNameCompare.Instance
                )
            ;
        }

        private async ValueTask<IReadOnlyDictionary<ConsumerGroup, IReadOnlyList<TopicPartitionOffset>>> FetchTopicPartitionOffsets(
            ImmutableSortedSet<ConsumerGroup> groups,
            ImmutableSortedSet<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            var groupsToFetch = groups;
            var topicsToFetch = default(ImmutableArray<OffsetFetchRequestData.OffsetFetchRequestGroup.OffsetFetchRequestTopics>);

            if (groups.Count == 0)
            {
                var responses = await ListGroups(
                    ListGroupsOptions.Empty,
                    cancellationToken
                ).ConfigureAwait(false);
                groupsToFetch = responses
                    .SelectMany(r => r.Value.GroupsField
                        .Select(g => new ConsumerGroup(g.GroupIdField))
                    )
                    .ToImmutableSortedSet(ConsumerGroupCompare.Instance)
                ;
            }

            if (topics.Count > 0)
            {
                var controller = await _connections.Controller(
                    cancellationToken
                ).ConfigureAwait(false);


                var metadataRequest = new MetadataRequestData(
                    topics.Select(t =>
                        new MetadataRequestData.MetadataRequestTopic(
                            Guid.Empty,
                            t,
                            []
                        )
                    )
                    .ToImmutableArray(),
                    false,
                    false,
                    false,
                    []
                );

                var metadataResponse = await controller.Metadata(
                    metadataRequest,
                    cancellationToken
                ).ConfigureAwait(false);

                topicsToFetch = metadataResponse
                    .TopicsField
                    .Select(t => new OffsetFetchRequestData.OffsetFetchRequestGroup.OffsetFetchRequestTopics(
                        t.NameField ?? "",
                        t.PartitionsField
                            .Select(p =>
                                p.PartitionIndexField
                            )
                            .ToImmutableArray(),
                            []
                        )
                    )
                    .ToImmutableArray()
                ;
            }


            var coordinators = await FindCoordinators(
                groupsToFetch,
                cancellationToken
            ).ConfigureAwait(false);

            var offsetFetchTasks = coordinators
                .Select(r => Task.Run(async () =>
                {
                    var connection = await _connections.Connection(
                        r.Key,
                        cancellationToken
                    ).ConfigureAwait(false);

                    var offsetFetchRequest = new OffsetFetchRequestData(
                        "",
                        default,
                        r.Value.Select(g =>
                            new OffsetFetchRequestData.OffsetFetchRequestGroup(
                                g,
                                null,
                                -1,
                                topicsToFetch,
                                []
                            )
                        ).ToImmutableArray(),
                        false,
                        []
                    );
                    return await connection.OffsetFetch(
                        offsetFetchRequest,
                        cancellationToken
                    ).ConfigureAwait(false);
                }))
                .ToImmutableArray()
            ;

            var results = await Task.WhenAll(
                offsetFetchTasks
            ).ConfigureAwait(false);

            var builder = ImmutableSortedDictionary.CreateBuilder<ConsumerGroup, IReadOnlyList<TopicPartitionOffset>>(ConsumerGroupCompare.Instance);
            foreach (var result in results)
            {
                foreach (var offsetFetchResponseGroup in result.GroupsField)
                {
                    var groupId = new ConsumerGroup(offsetFetchResponseGroup.GroupIdField);
                    var topicPartitions = offsetFetchResponseGroup
                        .TopicsField
                        .SelectMany(t => t.PartitionsField
                            .Select(p => new TopicPartitionOffset(new(t.NameField, p.PartitionIndexField), p.CommittedOffsetField))
                        )
                        .ToImmutableArray()
                    ;
                    builder.Add(groupId, topicPartitions);
                }
            }
            return builder.ToImmutable();
        }

        private async ValueTask<ImmutableSortedDictionary<int, ImmutableArray<string>>> FindCoordinators(
            IEnumerable<ConsumerGroup> groups,
            CancellationToken cancellationToken
        )
        {
            var connection = await _connections.Controller(
                cancellationToken
            ).ConfigureAwait(false);

            var coordinators = await connection.FindCoordinator(
                new(
                    "",
                    (sbyte)CoordinatorType.Group,
                    groups.Select(r => r.Value).ToImmutableArray(),
                    []
                ),
                cancellationToken
            ).ConfigureAwait(false);

            return coordinators
                .CoordinatorsField
                .GroupBy(g => g.NodeIdField)
                .ToImmutableSortedDictionary(
                    k => k.Key,
                    v => v.Select(r => r.KeyField).ToImmutableArray()
                )
            ;
        }

        private static ImmutableSortedSet<TopicName> ToNameReadOnlySet(TopicPartition topicPartition) =>
            ToReadOnlySet(topicPartition.Topic.TopicName)
        ;

        private static ImmutableSortedSet<TopicName> ToNameReadOnlySet(IEnumerable<TopicPartition> topicPartitions) =>
            ToReadOnlySet(topicPartitions.Select(r => r.Topic.TopicName))
        ;

        private static ImmutableSortedSet<TopicName> ToReadOnlySet(TopicName topic) =>
            ImmutableSortedSet.Create(TopicNameCompare.Instance, topic)
        ;

        private static ImmutableSortedSet<TopicName> ToReadOnlySet(IEnumerable<TopicName> topicNames) =>
            topicNames
            .ToImmutableSortedSet(TopicNameCompare.Instance)
        ;

        private static ImmutableSortedSet<TopicPartition> ToReadOnlySet(IEnumerable<TopicPartition> topicPartitions) =>
            topicPartitions
            .ToImmutableSortedSet(TopicPartitionCompare.Instance)
        ;

        private static ImmutableSortedSet<TopicPartition> ToReadOnlySet(TopicPartition topicPartition) =>
            ImmutableSortedSet.Create(TopicPartitionCompare.Instance, topicPartition)
        ;

        private static ImmutableSortedSet<ConsumerGroup> ToReadOnlySet(IEnumerable<ConsumerGroup> consumerGroups) =>
            consumerGroups.ToImmutableSortedSet(ConsumerGroupCompare.Instance)
        ;

        private static AclOperation AclOperations(int mask)
        {
            if (mask == int.MinValue)
                return AclOperation.NotSpecified;
            var flags = (AclOperation)mask;
            return flags & ~(AclOperation.Any | AclOperation.All | AclOperation.NotSpecified);
        }

        void IDisposable.Dispose()
        {
            _connections.Dispose();
        }
    }
}
