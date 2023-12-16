using Kafka.Client.Config;
using Kafka.Client.IO;
using Kafka.Client.IO.Read;
using Kafka.Client.IO.Write;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Model.Internal;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Reflection;
using System.Runtime.Serialization;
using static Kafka.Client.Messages.FindCoordinatorResponseData;

namespace Kafka.Client
{
    internal sealed class KafkaClient(
        ImmutableArray<BootstrapServer> bootstrapServers,
        KafkaClientConfig config,
        ILogger<IKafkaClient> logger
    ) :
        IKafkaClient,
        ITopics,
        IGroups
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

        ITopics IKafkaClient.Topics => this;
        IGroups IKafkaClient.Groups => this;

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

        async ValueTask<CreateTopicsResult> ITopics.Create(
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

        async ValueTask<CreateTopicsResult> ITopics.Create(
            IReadOnlyList<CreateTopicDefinition> topics,
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
            IReadOnlyList<CreateTopicDefinition> topics,
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
                                v => (string?)v.ValueField
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

        async ValueTask<DeleteTopicsResult> ITopics.Delete(
            TopicName topic,
            CancellationToken cancellationToken
        ) =>
            await DeleteTopics(
                ImmutableArray.Create(topic),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<DeleteTopicsResult> ITopics.Delete(
            IReadOnlyList<TopicName> topics,
            CancellationToken cancellationToken
        ) =>
            await DeleteTopics(
                topics,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<DeleteTopicsResult> DeleteTopics(
            IReadOnlyList<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            var protocol = await _connections.Controller(cancellationToken)
                .ConfigureAwait(false)
            ;
            var deleteTopicStates = topics
                .Select(
                    r => new DeleteTopicsRequestData.DeleteTopicState(
                        r,
                        Guid.Empty,
                        []
                    )
                )
                .ToImmutableArray()
            ;
            var topicNames = topics
                .Select(r => r.Value ?? "")
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

        async ValueTask<ListTopicsResult> ITopics.List(
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

        async ValueTask<ListTopicsResult> ITopics.List(
            IReadOnlyList<TopicName> topics,
            ListTopicsOptions options,
            CancellationToken cancellationToken
        ) =>
            await List(
                topics,
                options,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<ListTopicsResult> ITopics.List(
            ListTopicsOptions options,
            CancellationToken cancellationToken
        ) =>
            await List(
                ImmutableSortedSet<TopicName>.Empty,
                options,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<ListTopicsResult> List(
            IReadOnlyList<TopicName> topics,
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

            var topicDescriptions = response
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
                    options.IncludeTopicAuthorizedOperations ?
                        t.TopicAuthorizedOperationsField :
                        0,
                    t.ErrorCodeField == 0 ?
                        ApiError.None :
                        ApiErrors.Translate(t.ErrorCodeField)
                ))
                .OrderBy(t => t.TopicName, TopicNameCompare.Instance)
                .ThenBy(t => t.TopicId)
                .ToImmutableArray()
            ;
            return new(topicDescriptions);
        }

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsStart(
            TopicName topicName,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToReadOnlySet(topicName),
                ImmutableSortedSet<TopicPartition>.Empty,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsStart(
            IReadOnlySet<TopicName> topicNames,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topicNames,
                ImmutableSortedSet<TopicPartition>.Empty,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsStart(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartition),
                ImmutableSortedSet.Create(topicPartition),
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsStart(
            IReadOnlySet<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartitions),
                topicPartitions,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsEnd(
            TopicName topicName,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToReadOnlySet(topicName),
                ImmutableSortedSet<TopicPartition>.Empty,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsEnd(
            IReadOnlySet<TopicName> topicNames,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topicNames,
                ImmutableSortedSet<TopicPartition>.Empty,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsEnd(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartition),
                ImmutableSortedSet.Create(topicPartition),
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsEnd(
            IReadOnlySet<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartitions),
                topicPartitions,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsForTimestamp(
            TopicName topicName,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToReadOnlySet(topicName),
                ImmutableSortedSet<TopicPartition>.Empty,
                timestamp,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsForTimestamp(
            IReadOnlySet<TopicName> topicNames,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topicNames,
                ImmutableSortedSet<TopicPartition>.Empty,
                timestamp,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsForTimestamp(
            TopicPartition topicPartition,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartition),
                ImmutableSortedSet.Create(topicPartition),
                timestamp,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> ITopics.OffsetsForTimestamp(
            IReadOnlySet<TopicPartition> topicPartitions,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartitions),
                topicPartitions,
                timestamp,
                cancellationToken
            ).ConfigureAwait(false)
        ;



        async ValueTask<IReadOnlyList<GroupDescription>> IGroups.List(
            ListGroupsOptions options,
            CancellationToken cancellationToken
        )
        {
            var states = options.States.Select(r => r.ToString()).ToImmutableArray();
            var request = new ListGroupsRequestData(
                states,
                []
            );

            var connection = await _connections.Controller(
                cancellationToken
            ).ConfigureAwait(false);
            var metadata = await connection.Metadata(
                cancellationToken
            ).ConfigureAwait(false);

            var resultsBuilder = ImmutableArray.CreateBuilder<GroupDescription>();
            foreach (var broker in metadata.BrokersField)
            {
                var brokerConnection = await _connections.Connection(
                    broker.NodeIdField,
                    cancellationToken
                ).ConfigureAwait(false);
                var response = await brokerConnection.ListGroups(
                    request,
                    cancellationToken
                ).ConfigureAwait(false);
                foreach (var result in response.GroupsField)
                {
                    resultsBuilder.Add(new GroupDescription(
                        result.GroupIdField,
                        result.ProtocolTypeField,
                        result.GroupStateField
                    ));
                }
            }
            return resultsBuilder.ToImmutable();
        }

        async ValueTask<IReadOnlyList<DeleteGroupResult>> IGroups.Delete(
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
                    (sbyte)CoordinatorType.GROUP,
                    groups.Select(r => r.Value).ToImmutableArray(),
                    []
                ),
                cancellationToken
            ).ConfigureAwait(false);

            var groupsByCoordinators = coordinators
                .CoordinatorsField
                .GroupBy(g => g.NodeIdField)
                .Select(r => new KeyValuePair<NodeId, ImmutableArray<string>>(
                    new NodeId(r.Key),
                    r.Select(r => r.KeyField).ToImmutableArray()
                )).ToImmutableArray()
            ;

            var resultsBuilder = ImmutableArray.CreateBuilder<DeleteGroupResult>();
            foreach(var groupsByCoordinator in groupsByCoordinators)
            {
                var request = new DeleteGroupsRequestData(
                    groupsByCoordinator.Value,
                    []
                );
                var coordinator = await _connections.Connection(
                    groupsByCoordinator.Key,
                    cancellationToken
                ).ConfigureAwait(false);
                var response = await coordinator.DeleteGroups(
                    request,
                    cancellationToken
                ).ConfigureAwait(false);
                foreach(var result in response.ResultsField)
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

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IGroups.OffsetsCommitted(
            ConsumerGroup group,
            TopicName topic,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                group,
                ToReadOnlySet(topic),
                [],
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IGroups.OffsetsCommitted(
            ConsumerGroup group,
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                group,
                topics,
                [],
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> ListTopicPartitionOffsets(
            IReadOnlySet<TopicName> topics,
            IReadOnlySet<TopicPartition> filter,
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
                            .Where(p => !filter.Any() || filter.Contains(new TopicPartition(t.NameField, p.PartitionIndexField)))
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

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> FetchTopicPartitionOffsets(
            ConsumerGroup group,
            IEnumerable<TopicName> topics,
            ImmutableSortedSet<TopicPartition> filter,
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
            var offsetFetchRequest = new OffsetFetchRequestData(
                group,
                metadataResponse.TopicsField.Select(t => new OffsetFetchRequestData.OffsetFetchRequestTopic(
                    t.NameField ?? "",
                    t.PartitionsField
                        .Where(p => !filter.IsEmpty || filter.Contains(new TopicPartition(t.NameField, p.PartitionIndexField)))
                        .Select(p =>
                            p.PartitionIndexField
                        )
                        .ToImmutableArray(),
                        []
                    )
                )
                .ToImmutableArray(),
                [
                    new OffsetFetchRequestData.OffsetFetchRequestGroup(
                            group,
                            null,
                            -1,
                            metadataResponse.TopicsField.Select(t => new OffsetFetchRequestData.OffsetFetchRequestGroup.OffsetFetchRequestTopics(
                                t.NameField ?? "",
                                t.PartitionsField
                                    .Where(p => !filter.IsEmpty || filter.Contains(new TopicPartition(t.NameField, p.PartitionIndexField)))
                                    .Select(p =>
                                        p.PartitionIndexField
                                    )
                                    .ToImmutableArray(),
                                    []
                                )
                            )
                            .ToImmutableArray(),
                            []
                        ),
                ],
                false,
                []
            );
            var offsetFetchResponse = await protocol.OffsetFetch(
                offsetFetchRequest,
                cancellationToken
            ).ConfigureAwait(false);

            var builder = ImmutableSortedDictionary.CreateBuilder<TopicName, ImmutableArray<PartitionOffset>>(TopicNameCompare.Instance);
            foreach (var offsetFetchResponseGroup in offsetFetchResponse.GroupsField)
                foreach (var topic in offsetFetchResponseGroup.TopicsField)
                    foreach (var partition in topic.PartitionsField)
                        builder.TryAdd(
                            new TopicName(topic.NameField),
                            topic.PartitionsField
                                .Select(r => new PartitionOffset(r.PartitionIndexField, r.CommittedOffsetField))
                                .ToImmutableArray()
                       );

            // Check if stored by topic.
            foreach (var topic in offsetFetchResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    builder.TryAdd(
                        new TopicName(topic.NameField),
                        topic.PartitionsField
                            .Select(r => new PartitionOffset(r.PartitionIndexField, r.CommittedOffsetField))
                            .ToImmutableArray()
                    );

            return builder.ToImmutable();
        }

        private static ImmutableSortedSet<TopicName> ToNameReadonlySet(TopicPartition topicPartition) =>
            ToReadOnlySet(topicPartition.Topic.TopicName)
        ;

        private static ImmutableSortedSet<TopicName> ToNameReadonlySet(IReadOnlySet<TopicPartition> topicPartitions) =>
            ToReadOnlySet(topicPartitions.Select(r => r.Topic.TopicName))
        ;

        private static ImmutableSortedSet<TopicName> ToReadOnlySet(TopicName topic) =>
            ImmutableSortedSet.Create(TopicNameCompare.Instance, topic)
        ;

        private static ImmutableSortedSet<TopicName> ToReadOnlySet(IEnumerable<TopicName> topicNames) =>
            topicNames
            .ToImmutableSortedSet(TopicNameCompare.Instance)
        ;

        void IDisposable.Dispose()
        {
            _connections.Dispose();
        }
    }
}
