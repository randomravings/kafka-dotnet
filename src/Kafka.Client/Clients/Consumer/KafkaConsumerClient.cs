using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class KafkaConsumerClient<TKey, TValue> :
        KafkaClient<IConsumer<TKey, TValue>, ConsumerConfig>,
        IConsumer<TKey, TValue>
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private readonly CancellationTokenSource _internalCts = new();
        private IConsumerProtocol? _protocol;
        private bool _disposed;

        public KafkaConsumerClient(
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ConsumerConfig config,
            ILogger<IConsumer<TKey, TValue>> logger
        ) : base(config, logger)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _internalCts.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        protected override ValueTask OnClose(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            return ValueTask.CompletedTask;
        }

        async ValueTask<ImmutableArray<TopicInfo>> IConsumer<TKey, TValue>.ListTopics(CancellationToken cancellationToken)
        {
            var protocol = await GetProtocol(cancellationToken).ConfigureAwait(false);
            var request = new MetadataRequestData(
                ImmutableArray<MetadataRequestData.MetadataRequestTopic>.Empty,
                false,
                false,
                false,
                ImmutableArray<TaggedField>.Empty
            );
            var response = await protocol.Metadata(
                request,
                cancellationToken
            ).ConfigureAwait(false);
            var topicNames = response
                .TopicsField
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
                .OrderBy(r => r.Name)
                .ThenBy(r => r.Id)
                .ToImmutableArray()
            ;
            return topicNames;
        }

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsStart(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsStart(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsStart(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsStart(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsEnd(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsEnd(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsEnd(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsEnd(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsForTimestamp(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsForTimestamp(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsForTimestamp(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsForTimestamp(
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

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsCommitted(
            TopicName topicName,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                ToReadOnlySet(topicName),
                ImmutableSortedSet<TopicPartition>.Empty,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsCommitted(
            IReadOnlySet<TopicName> topicNames,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                topicNames,
                ImmutableSortedSet<TopicPartition>.Empty,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IStreamReaderApplication<TKey, TValue>> IConsumer<TKey, TValue>.CreateInstance(
            TopicName topicName,
            CancellationToken cancellationToken
        )
        {
            var coordinatorProtocol = await GetCoordinator(cancellationToken).ConfigureAwait(false);
            return new StreamReaderApplication<TKey, TValue>(
                coordinatorProtocol,
                ImmutableSortedSet.Create(TopicNameCompare.Instance, topicName),
                _keyDeserializer,
                _valueDeserializer,
                Config,
                Logger
            );
        }

        async ValueTask<IStreamReaderApplication<TKey, TValue>> IConsumer<TKey, TValue>.CreateInstance(
            IReadOnlySet<TopicName> topicNames,
            CancellationToken cancellationToken
        )
        {
            if (!topicNames.Any())
                throw new ArgumentException("Must specify at least one topic", nameof(topicNames));
            var coordinatorProtocol = await GetCoordinator(cancellationToken).ConfigureAwait(false);
            return new StreamReaderApplication<TKey, TValue>(
                coordinatorProtocol,
                topicNames.ToImmutableSortedSet(TopicNameCompare.Instance),
                _keyDeserializer,
                _valueDeserializer,
                Config,
                Logger
            );
        }

        private async ValueTask<IConsumerProtocol> GetCoordinator(
            CancellationToken cancellationToken
        )
        {
            var controllerProtocol = await CreateControllerConsumerProtocol(cancellationToken).ConfigureAwait(false);
            var groupId = Config.GroupId ?? "";
            var request = new FindCoordinatorRequestData(
                groupId,
                (sbyte)CoordinatorType.GROUP,
                ImmutableArray.Create(groupId),
                ImmutableArray<TaggedField>.Empty
            );
            var findCoordinatorResponse = await controllerProtocol.FindCoordinator(
            request,
                cancellationToken
            ).ConfigureAwait(false);
            var host = findCoordinatorResponse.HostField;
            var port = findCoordinatorResponse.PortField;
            if (findCoordinatorResponse.CoordinatorsField.Length > 0)
            {
                host = findCoordinatorResponse.CoordinatorsField[0].HostField;
                port = findCoordinatorResponse.CoordinatorsField[0].PortField;
            }
            var connection = new SaslPlaintextTransport(host, port);
            return new ConsumerProtocol(connection, Config, Logger);
        }

        IStreamReaderAssigned<TKey, TValue> IConsumer<TKey, TValue>.Assign(
            TopicPartition topicPartition
        )
        {
            throw new NotImplementedException();
        }

        IStreamReaderAssigned<TKey, TValue> IConsumer<TKey, TValue>.Assign(
            IReadOnlySet<TopicPartition> topicPartitions
        )
        {
            throw new NotImplementedException();
        }

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> ListTopicPartitionOffsets(
            IReadOnlySet<TopicName> topicNames,
            IReadOnlySet<TopicPartition> filter,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        )
        {
            var protocol = await GetProtocol(cancellationToken).ConfigureAwait(false);
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
            IReadOnlySet<TopicName> topicNames,
            IReadOnlySet<TopicPartition> filter,
            CancellationToken cancellationToken
        )
        {
            var protocol = await GetProtocol(cancellationToken).ConfigureAwait(false);
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
                Config.GroupId ?? "",
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
                    Config.GroupId ?? "",
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

        private async ValueTask<IConsumerProtocol> GetProtocol(
                CancellationToken cancellationToken
            ) =>
                _protocol ??= await CreateControllerConsumerProtocol(cancellationToken).ConfigureAwait(false)
            ;

        private async ValueTask<IConsumerProtocol> CreateControllerConsumerProtocol(
            CancellationToken cancellationToken
        ) =>
            await GetControllerProtocol<IConsumerProtocol>(
                (connection, config, logger) => new ConsumerProtocol(connection, config, logger),
                cancellationToken
            ).ConfigureAwait(false)
        ;

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
    }
}
