using Kafka.Client.Config;
using Kafka.Client.IO;
using Kafka.Client.IO.Stream;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Net;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client
{
    internal sealed class KafkaClient :
        IClient,
        ITopics,
        IConsumerGroups
    {
        private readonly ClientConfig _config;
        private readonly ILogger<IClient> _logger;
        private readonly IConnectionManager<IClientConnection> _connections;

        public KafkaClient(
            ClientConfig config,
            ILogger<IClient> logger
        )
        {
            _config = config;
            _logger = logger;
            _connections = new ConnectionManager(_config, _logger);
        }

        ITopics IClient.Topics => this;
        IConsumerGroups IClient.ConsumerGroups => this;

        async ValueTask IClient.Close(
            CancellationToken cancellationToken
        )
        {
            await _connections.CloseAll(
                cancellationToken
            ).ConfigureAwait(false);
            await Task.Yield();
        }

        IInputStreamBuilder IClient.CreateInputStream(InputStreamConfig config) =>
            new InputStreamBuilder(
                _connections,
                config,
                _logger
            )
        ;

        IInputStreamBuilder IClient.CreateInputStream(Action<InputStreamConfig> configure)
        {
            var config = new InputStreamConfig();
            configure(config);
            return new InputStreamBuilder(
                _connections,
                config,
                _logger
            );
        }

        IOutputStreamBuilder IClient.CreateOuputStream(OutputStreamConfig config) =>
            new OutputStreamBuilder(
                _connections,
                config,
                _logger
            )
        ;

        IOutputStreamBuilder IClient.CreateOuputStream(Action<OutputStreamConfig> configure)
        {
            var config = new OutputStreamConfig();
            configure(config);
            return new OutputStreamBuilder(
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
                                r.Value.ToImmutableArray(),
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
                _config.RequestTimeoutMs,
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
                        ImmutableArray<TaggedField>.Empty
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
                _config.RequestTimeoutMs,
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

        async ValueTask<DescribeTopicsResult> ITopics.Describe(
            TopicName topic,
            DescribeTopicOptions options,
            CancellationToken cancellationToken
        ) =>
            await DescribeTopics(
                ImmutableArray.Create(topic),
                options,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<DescribeTopicsResult> ITopics.Describe(
            IReadOnlyList<TopicName> topics,
            DescribeTopicOptions options,
            CancellationToken cancellationToken
        ) =>
            await DescribeTopics(
                topics,
                options,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<DescribeTopicsResult> DescribeTopics(
            IReadOnlyList<TopicName> topics,
            DescribeTopicOptions options,
            CancellationToken cancellationToken
        )
        {
            var protocol = await _connections.Controller(
                cancellationToken
            ).ConfigureAwait(false);

            var metadataRequestTopics = topics
                .Select(
                    r => new MetadataRequestData.MetadataRequestTopic(
                        Guid.Empty,
                        r,
                        ImmutableArray<TaggedField>.Empty
                    )
                )
                .ToImmutableArray()
            ;
            var request = new MetadataRequestData(
                metadataRequestTopics,
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

        async ValueTask<ListTopicsResult> ITopics.List(
            ListTopicsOptions options,
            CancellationToken cancellationToken
        )
        {
            var protocol = await _connections.Controller(cancellationToken)
                .ConfigureAwait(false)
            ;

            var request = new MetadataRequestData(
                null,
                false,
                false,
                false,
                ImmutableArray<TaggedField>.Empty
            );
            var response = await protocol.Metadata(
                request,
                cancellationToken
            ).ConfigureAwait(false);

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

        ValueTask<ListTopicsResult> IConsumerGroups.List(
            ConsumerGroup consumerGroup,
            ListTopicsOptions options,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumerGroups.OffsetsCommitted(
            ConsumerGroup consumerGroup,
            TopicName topicName,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                consumerGroup,
                ToReadOnlySet(topicName),
                ImmutableSortedSet<TopicPartition>.Empty,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumerGroups.OffsetsCommitted(
            ConsumerGroup consumerGroup,
            IReadOnlySet<TopicName> topicNames,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                consumerGroup,
                topicNames,
                ImmutableSortedSet<TopicPartition>.Empty,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> ListTopicPartitionOffsets(
            IReadOnlySet<TopicName> topicNames,
            IReadOnlySet<TopicPartition> filter,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        )
        {
            var protocol = await _connections.Controller(
                cancellationToken
            ).ConfigureAwait(false);
            var metadataRequest = new MetadataRequestData(
                topicNames.Select(t =>
                    new MetadataRequestData.MetadataRequestTopic(
                        Guid.Empty,
                        t,
                        ImmutableArray<TaggedField>.Empty
                    )
                )
                .ToImmutableArray(),
                false,
                false,
                false,
                ImmutableArray<TaggedField>.Empty
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
                                ImmutableArray<TaggedField>.Empty
                            )
                        )
                        .ToImmutableArray(),
                        ImmutableArray<TaggedField>.Empty
                    )
                )
                .ToImmutableArray(),
                ImmutableArray<TaggedField>.Empty
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
            ConsumerGroup consumerGroup,
            IReadOnlySet<TopicName> topicNames,
            IReadOnlySet<TopicPartition> filter,
            CancellationToken cancellationToken
        )
        {
            var protocol = await _connections.Controller(
                cancellationToken
            ).ConfigureAwait(false);
            var metadataRequest = new MetadataRequestData(
                topicNames.Select(t =>
                    new MetadataRequestData.MetadataRequestTopic(
                        Guid.Empty,
                        t,
                        ImmutableArray<TaggedField>.Empty
                    )
                )
                .ToImmutableArray(),
                false,
                false,
                false,
                ImmutableArray<TaggedField>.Empty
            );
            var metadataResponse = await protocol.Metadata(
                metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);
            var offsetFetchRequest = new OffsetFetchRequestData(
                consumerGroup,
                metadataResponse.TopicsField.Select(t => new OffsetFetchRequestData.OffsetFetchRequestTopic(
                    t.NameField ?? "",
                    t.PartitionsField
                        .Where(p => !filter.Any() || filter.Contains(new TopicPartition(t.NameField, p.PartitionIndexField)))
                        .Select(p =>
                            p.PartitionIndexField
                        )
                        .ToImmutableArray(),
                        ImmutableArray<TaggedField>.Empty
                    )
                )
                .ToImmutableArray(),
                ImmutableArray.Create(new OffsetFetchRequestData.OffsetFetchRequestGroup(
                    consumerGroup,
                    metadataResponse.TopicsField.Select(t => new OffsetFetchRequestData.OffsetFetchRequestGroup.OffsetFetchRequestTopics(
                        t.NameField ?? "",
                        t.PartitionsField
                            .Where(p => !filter.Any() || filter.Contains(new TopicPartition(t.NameField, p.PartitionIndexField)))
                            .Select(p =>
                                p.PartitionIndexField
                            )
                            .ToImmutableArray(),
                            ImmutableArray<TaggedField>.Empty
                        )
                    )
                    .ToImmutableArray(),
                    ImmutableArray<TaggedField>.Empty
                )),
                false,
                ImmutableArray<TaggedField>.Empty
            );
            var offsetFetchResponse = await protocol.OffsetFetch(
                offsetFetchRequest,
                cancellationToken
            ).ConfigureAwait(false);

            var builder = ImmutableSortedDictionary.CreateBuilder<TopicName, ImmutableArray<PartitionOffset>>(TopicNameCompare.Instance);
            foreach (var group in offsetFetchResponse.GroupsField)
                foreach (var topic in group.TopicsField)
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

        private static IReadOnlySet<TopicName> ToNameReadonlySet(TopicPartition topicPartition) =>
            ToReadOnlySet(topicPartition.Topic.TopicName)
        ;

        private static IReadOnlySet<TopicName> ToNameReadonlySet(IReadOnlySet<TopicPartition> topicPartitions) =>
            ToReadOnlySet(topicPartitions.Select(r => r.Topic.TopicName))
        ;

        private static IReadOnlySet<TopicName> ToReadOnlySet(TopicName topic) =>
            ImmutableSortedSet.Create(TopicNameCompare.Instance, topic)
        ;

        private static IReadOnlySet<TopicName> ToReadOnlySet(IEnumerable<TopicName> topicNames) =>
            topicNames
            .ToImmutableSortedSet(TopicNameCompare.Instance)
        ;

        void IDisposable.Dispose()
        {
            _connections.Dispose();
        }
    }
}
