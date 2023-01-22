using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
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
            using var connection = await _connectionPool.AquireControllerConnection(cancellationToken);
            var response = await ConsumerProtocol.RequestMetadata(
                connection,
                Enumerable.Empty<TopicName>(),
                cancellationToken
            );
            var topics = response
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
            return topics;
        }

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsStart(
            TopicNames topics,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topics.List.Distinct(),
                ImmutableSortedSet<TopicPartition>.Empty,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsStart(
            IEnumerable<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topicPartitions.Select(r => r.Topic).Distinct(),
                topicPartitions.ToImmutableSortedSet(TopicPartitionCompare.Instance),
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsEnd(
            TopicNames topics,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topics.List.Distinct(),
                ImmutableSortedSet<TopicPartition>.Empty,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsEnd(
            IEnumerable<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topicPartitions.Select(r => r.Topic).Distinct(),
                topicPartitions.ToImmutableSortedSet(TopicPartitionCompare.Instance),
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value),
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsForTimestamp(
            TopicNames topics,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topics.List.Distinct(),
                ImmutableSortedSet<TopicPartition>.Empty,
                timestamp,
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsForTimestamp(
            IEnumerable<TopicPartition> topicPartitions,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await ListTopicPartitionOffsets(
                topicPartitions.Select(r => r.Topic).Distinct(),
                topicPartitions.ToImmutableSortedSet(TopicPartitionCompare.Instance),
                timestamp,
                cancellationToken
            )
        ;

        async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> IConsumer<TKey, TValue>.GetOffsetsCommitted(
            TopicNames topics,
            CancellationToken cancellationToken
        ) =>
            await FetchTopicPartitionOffsets(
                topics.List,
                cancellationToken
            )
        ;

        async ValueTask<IInputStreamAutoCommit<TKey, TValue>> IConsumer<TKey, TValue>.CreateAutoCommitStream(
            TopicNames topics,
            CancellationToken cancellationToken
        )
        {
            if (!topics.List.Any())
                throw new ArgumentException("Must specify at least one topic", nameof(topics));
            var brokerConnections = await _connectionPool.AquireBrokerConnections(cancellationToken);
            return await CreateGroupedStream(
                brokerConnections,
                topics.List,
                cancellationToken
            );
        }

        async ValueTask<IInputStreamManualCommit<TKey, TValue>> IConsumer<TKey, TValue>.CreateManualCommitStream(
            TopicNames topics,
            CancellationToken cancellationToken
        )
        {
            if (!topics.List.Any())
                throw new ArgumentException("Must specify at least one topic", nameof(topics));
            var brokerConnections = await _connectionPool.AquireBrokerConnections(cancellationToken);
            return await CreateGroupedStream(
                brokerConnections,
                topics.List,
                cancellationToken
            );
        }

        async ValueTask<IInputStreamSeekable<TKey, TValue>> IConsumer<TKey, TValue>.CreateSeekableStream(
            TopicPartitions topics,
            CancellationToken cancellationToken
        )
        {
            if (!topics.List.Any())
                throw new ArgumentException("Must specify at least one topic", nameof(topics));
            var brokerConnections = await _connectionPool.AquireBrokerConnections(cancellationToken);
            var coordinatorConnection = brokerConnections.Values.ElementAt(Random.Shared.Next(0, brokerConnections.Count - 1));
            var metadataResponse = await ConsumerProtocol.RequestMetadata(
                coordinatorConnection,
                topics.List.Select(r => r.Topic).Distinct(),
                cancellationToken
            );
            var topicPartitionOffsets = CreateTopicPartitionOffsets(
                metadataResponse,
                Offset.Unset
            );
            var nodeAssignments = CreateNodeAssignments(
                brokerConnections,
                metadataResponse
            );
            var listOffsetsResponse = await ConsumerProtocol.RequestListOffsets(
                nodeAssignments,
                topicPartitionOffsets.Keys.ToImmutableSortedSet(),
                _config.IsolationLevel,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            );
            UpdateTopicPartitionOffsets(
                topicPartitionOffsets,
                listOffsetsResponse
            );
            return new InputStreamAssigned<TKey, TValue>(
                nodeAssignments,
                topicPartitionOffsets,
                _keyDeserializer,
                _valueDeserializer,
                _config,
                _logger
            );
        }

        private async ValueTask<InputStreamGrouped<TKey, TValue>> CreateGroupedStream(
            ImmutableSortedDictionary<ClusterNodeId, IConnection> brokerConnections,
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            (_, var host, var port, _) = await GetCoordinator(
                brokerConnections.Values.First(),
                _config.GroupId ?? "",
                CoordinatorType.GROUP,
                cancellationToken
            );
            var coordinatorConnection = await _connectionPool.AquireConnection(host, port, cancellationToken);
            var metadataResponse = await ConsumerProtocol.RequestMetadata(
                coordinatorConnection,
                topics,
                cancellationToken
            );
            var topicPartitionOffsets = CreateTopicPartitionOffsets(
                metadataResponse,
                Offset.Unset
            );
            var nodeAssignments = CreateNodeAssignments(
                brokerConnections,
                metadataResponse
            );
            var offsetFetchResponse = await ConsumerProtocol.RequestOffsetFetch(
                coordinatorConnection,
                _config,
                topicPartitionOffsets.Keys,
                cancellationToken
            );
            UpdateTopicPartitionOffsets(
                topicPartitionOffsets,
                offsetFetchResponse
            );
            var unsetTopicPartitions = topicPartitionOffsets
                .Where(r => r.Value < 0)
                .Select(r => r.Key)
                .ToImmutableSortedSet(TopicPartitionCompare.Instance)
            ;
            var listOffsetsResponse = await ConsumerProtocol.RequestListOffsets(
                nodeAssignments,
                unsetTopicPartitions,
                _config.IsolationLevel,
                DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value),
                cancellationToken
            );
            UpdateTopicPartitionOffsets(
                topicPartitionOffsets,
                listOffsetsResponse
            );
            return new InputStreamGrouped<TKey, TValue>(
                coordinatorConnection,
                nodeAssignments,
                topicPartitionOffsets,
                _keyDeserializer,
                _valueDeserializer,
                _config,
                _logger
            );
        }

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> ListTopicPartitionOffsets(
            IEnumerable<TopicName> topics,
            ImmutableSortedSet<TopicPartition> filter,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        )
        {
            if (!topics.Any())
                return ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>.Empty;
            var brokerConnections = await _connectionPool.AquireBrokerConnections(cancellationToken);
            try
            {
                var filteredTopics = topics.ToImmutableArray();
                if (filter.Any())
                    filteredTopics = topics.Except(filter.Select(r => r.Topic).Distinct()).ToImmutableArray();
                var someConnection = brokerConnections.Values.ElementAt(Random.Shared.Next(0, brokerConnections.Count - 1));
                brokerConnections = await _connectionPool.AquireBrokerConnections(cancellationToken);
                var metadataResponse = await ConsumerProtocol.RequestMetadata(
                    someConnection,
                    topics,
                    cancellationToken
                );
                var topicPartitionOffsets = CreateTopicPartitionOffsets(
                    metadataResponse,
                    Offset.Unset
                );
                var nodeAssignments = CreateNodeAssignments(
                    brokerConnections,
                    metadataResponse
                );
                var unsetTopicPartitions = topicPartitionOffsets
                    .Where(r => r.Value < 0)
                    .Select(r => r.Key)
                    .ToImmutableSortedSet(TopicPartitionCompare.Instance)
                ;
                var listOffsetsResponse = await ConsumerProtocol.RequestListOffsets(
                    nodeAssignments,
                    unsetTopicPartitions,
                    _config.IsolationLevel,
                    timestamp,
                    cancellationToken
                );
                return listOffsetsResponse
                    .SelectMany(r => r.TopicsField)
                    .GroupBy(g => g.NameField)
                    .ToImmutableSortedDictionary(
                        k => new TopicName(k.Key),
                        v => v.SelectMany(t => t.PartitionsField
                                .Select(p => new PartitionOffset(p.PartitionIndexField, p.OffsetField))
                            )
                            .ToImmutableArray(),
                        TopicNameCompare.Instance
                    )
                ;
            }
            finally
            {
                foreach (var connection in brokerConnections.Values)
                {
                    try
                    {
                        await connection.Close(cancellationToken);
                        connection.Dispose();
                    }
                    catch { }
                }
            }
        }

        private async ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> FetchTopicPartitionOffsets(
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            if (!topics.Any())
                throw new ArgumentException("Must specify at least one topic", nameof(topics));
            var brokerConnections = ImmutableSortedDictionary<ClusterNodeId, IConnection>.Empty;
            try
            {
                brokerConnections = await _connectionPool.AquireBrokerConnections(cancellationToken);
                (var clusterNodeId, _, _, var error) = await GetCoordinator(
                    brokerConnections.Values.First(),
                    _config.GroupId ?? "",
                    CoordinatorType.GROUP,
                    cancellationToken
                );
                var coordinatorConnection = brokerConnections[clusterNodeId];
                var metadataResponse = await ConsumerProtocol.RequestMetadata(
                    coordinatorConnection,
                    topics,
                    cancellationToken
                );
                var topicPartitionOffsets = CreateTopicPartitionOffsets(
                    metadataResponse,
                    Offset.Unset
                );
                var nodeAssignments = CreateNodeAssignments(
                    brokerConnections,
                    metadataResponse
                );
                var offsetFetchResponse = await ConsumerProtocol.RequestOffsetFetch(
                    coordinatorConnection,
                    _config,
                    topicPartitionOffsets.Keys,
                    cancellationToken
                );
                return offsetFetchResponse
                    .TopicsField
                    .ToImmutableSortedDictionary(
                        k => new TopicName(k.NameField),
                        v => v.PartitionsField
                                .Select(v => new PartitionOffset(v.PartitionIndexField, v.CommittedOffsetField))
                                .ToImmutableArray(),
                        TopicNameCompare.Instance
                    )
                ;
            }
            finally
            {
                foreach (var connection in brokerConnections.Values)
                {
                    try
                    {
                        await connection.Close(cancellationToken);
                        connection.Dispose();
                    }
                    catch { }
                }
            }
        }

        private static ImmutableArray<NodeAssignment> CreateNodeAssignments(
            ImmutableSortedDictionary<ClusterNodeId, IConnection> connections,
            MetadataResponse metadataResponse
        )
        {
            var topicPartitionsByLeader = metadataResponse
                .TopicsField
                .SelectMany(t => t.PartitionsField
                    .Select(p => new
                    {
                        ClusterNodeId = new ClusterNodeId(p.LeaderIdField),
                        TopicPartition = new TopicPartition(t.NameField, p.PartitionIndexField)
                    })
                )
                .ToLookup(l => l.ClusterNodeId)
            ;
            return topicPartitionsByLeader
                .Select(r =>
                    new NodeAssignment(
                        r.Key,
                        connections[r.Key],
                        r.Select(r => r.TopicPartition)
                            .ToImmutableSortedSet(TopicPartitionCompare.Instance),
                        r.GroupBy(g => g.TopicPartition.Topic)
                            .ToImmutableSortedDictionary(
                                k => k.Key,
                                v => v.Select(t => t.TopicPartition).ToImmutableArray(),
                                TopicNameCompare.Instance
                            )
                    )
                )
                .ToImmutableArray()
            ;
        }

        private static SortedList<TopicPartition, Offset> CreateTopicPartitionOffsets(
            MetadataResponse metadataResponse,
            Offset defaultOffset
        )
        {
            var topicPartitionOffsets = new SortedList<TopicPartition, Offset>(TopicPartitionCompare.Instance);
            foreach (var topic in metadataResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    topicPartitionOffsets.Add(new(topic.NameField, partition.PartitionIndexField), defaultOffset);
            return topicPartitionOffsets;
        }

        private static void UpdateTopicPartitionOffsets(
            SortedList<TopicPartition, Offset> topicPartitionOffsets,
            OffsetFetchResponse offsetFetchResponse
        )
        {
            // Check if stored by group. This assumes one and only one group.
            var group = offsetFetchResponse.GroupsField.FirstOrDefault();
            if (group != null)
                foreach (var topic in group.TopicsField)
                    foreach (var partition in topic.PartitionsField)
                        topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = partition.CommittedOffsetField;
            // Check if stored by topic.
            foreach (var topic in offsetFetchResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = partition.CommittedOffsetField;
        }

        private static void UpdateTopicPartitionOffsets(
            SortedList<TopicPartition, Offset> topicPartitionOffsets,
            ImmutableArray<ListOffsetsResponse> offsetListResponses
        )
        {
            foreach (var offsetListResponse in offsetListResponses)
                foreach (var topic in offsetListResponse.TopicsField)
                    foreach (var partition in topic.PartitionsField)
                        topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = partition.OffsetField;
        }
    }
}
