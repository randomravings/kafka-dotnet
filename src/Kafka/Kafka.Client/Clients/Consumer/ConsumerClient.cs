using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class ConsumerClient<TKey, TValue> :
        Client<IConsumer<TKey, TValue>, ConsumerConfig>,
        IConsumer<TKey, TValue>
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private readonly CancellationTokenSource _internalCts = new();
        private bool _disposed = false;

        public ConsumerClient(
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

        protected override async ValueTask OnClose(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            await ValueTask.CompletedTask;
        }

        async ValueTask<ImmutableArray<TopicInfo>> IConsumer<TKey, TValue>.ListTopics(CancellationToken cancellationToken)
        {
            using var connection = await _connectionPool.AquireConnection(cancellationToken);
            var response = await ConsumerProtocol.Metadata(
                connection,
                Enumerable.Empty<TopicName>(),
                cancellationToken
            );
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
            )
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
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsStart(
            TopicPartition topicPartitions,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartitions),
                ImmutableSortedSet<TopicPartition>.Empty,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsStart(
            IReadOnlySet<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartitions),
                topicPartitions.ToImmutableSortedSet(TopicPartitionCompare.Instance),
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            )
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
            )
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
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsEnd(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartition),
                ImmutableSortedSet<TopicPartition>.Empty,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsEnd(
            IReadOnlySet<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartitions),
                topicPartitions.ToImmutableSortedSet(TopicPartitionCompare.Instance),
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            )
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
            )
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
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsForTimestamp(
            TopicPartition topicPartition,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToNameReadonlySet(topicPartition),
                ImmutableSortedSet<TopicPartition>.Empty,
                timestamp,
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsForTimestamp(
            IReadOnlySet<TopicPartition> topicPartitions,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topicPartitions.Select(r => r.Topic).Distinct().ToImmutableSortedSet(),
                topicPartitions.ToImmutableSortedSet(TopicPartitionCompare.Instance),
                timestamp,
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsCommitted(
            TopicName topicName,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                ToReadOnlySet(topicName),
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsCommitted(
            IReadOnlySet<TopicName> topicNames,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                topicNames,
                cancellationToken
            )
        ;

        IInputStream<TKey, TValue> IConsumer<TKey, TValue>.JoinGroup(
            TopicName topicName
        )
        {
            return new InputStreamApplication<TKey, TValue>(
                ToReadOnlySet(topicName),
                _keyDeserializer,
                _valueDeserializer,
                _connectionPool,
                _config,
                _logger
            );
        }

        IInputStream<TKey, TValue> IConsumer<TKey, TValue>.JoinGroup(
            IReadOnlySet<TopicName> topicNames
        )
        {
            if (!topicNames.Any())
                throw new ArgumentException("Must specify at least one topic", nameof(topicNames));
            return new InputStreamApplication<TKey, TValue>(
                topicNames.ToImmutableSortedSet(TopicNameCompare.Instance),
                _keyDeserializer,
                _valueDeserializer,
                _connectionPool,
                _config,
                _logger
            );
        }

        IInputStreamAssigned<TKey, TValue> IConsumer<TKey, TValue>.Assign(
            TopicPartition topicPartition
        )
        {
            throw new NotImplementedException();
        }

        IInputStreamAssigned<TKey, TValue> IConsumer<TKey, TValue>.Assign(
            IReadOnlySet<TopicPartition> topicPartitions
        )
        {
            throw new NotImplementedException();
        }

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> ListTopicPartitionOffsets(
            TopicName topicName,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                ToReadOnlySet(topicName),
                ImmutableSortedSet<TopicPartition>.Empty,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            )
        ;

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> ListTopicPartitionOffsets(
            IReadOnlySet<TopicName> topicNames,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topicNames,
                ImmutableSortedSet<TopicPartition>.Empty,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            )
        ;

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> ListTopicPartitionOffsets(
            IReadOnlySet<TopicName> topicNames,
            IReadOnlySet<TopicPartition> filter,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        )
        {
            return ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>.Empty;
        }

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> FetchTopicPartitionOffsets(
            IEnumerable<TopicName> topicNames,
            CancellationToken cancellationToken
        )
        {
            return ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>.Empty;
        }

        private static IReadOnlySet<TopicName> ToNameReadonlySet(TopicPartition topicPartition) =>
            ToReadOnlySet(topicPartition.Topic)
        ;

        private static IReadOnlySet<TopicName> ToNameReadonlySet(IReadOnlySet<TopicPartition> topicPartitions) =>
            ToReadOnlySet(topicPartitions.Select(r => r.Topic))
        ;

        private static IReadOnlySet<TopicName> ToReadOnlySet(TopicName topicName) =>
            ToReadOnlySet(new[] { topicName })
        ;

        private static IReadOnlySet<TopicName> ToReadOnlySet(IEnumerable<TopicName> topicNames) =>
            topicNames
            .ToImmutableSortedSet(TopicNameCompare.Instance)
        ;
    }
}
