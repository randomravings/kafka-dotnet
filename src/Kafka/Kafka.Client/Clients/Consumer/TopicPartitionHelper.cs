using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Messages;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal static class TopicPartitionHelper
    {
        internal static async Task<ImmutableArray<NodeAssignment>> CreateNodeAssignments(
            Cluster cluster,
            IConnectionPool connectionPool,
            MetadataResponse metadataResponse,
            ImmutableSortedSet<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
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
                .Join(
                    topicPartitions,
                    ok => ok.TopicPartition,
                    ik => ik,
                    (o, i) => o
                    
                )
                .ToLookup(l => l.ClusterNodeId)
            ;

            var builder = ImmutableArray.CreateBuilder<NodeAssignment>();
            foreach (var topicPartition in topicPartitionsByLeader)
            {
                var node = cluster.Nodes[topicPartition.Key];
                var connection = await connectionPool.AquireConnection(node.Host, node.Port, cancellationToken);
                var nodeAssignment = new NodeAssignment(
                        topicPartition.Key,
                        connection,
                        topicPartition.Select(r => r.TopicPartition)
                            .ToImmutableSortedSet(TopicPartitionCompare.Instance),
                        topicPartition.GroupBy(g => g.TopicPartition.Topic)
                            .ToImmutableSortedDictionary(
                                k => k.Key,
                                v => v.Select(t => t.TopicPartition).ToImmutableArray(),
                                TopicNameCompare.Instance
                            )
                    )
                ;
                builder.Add(nodeAssignment);
            }
            return builder.ToImmutable();
        }

        internal static SortedList<TopicPartition, Offset> CreateTopicPartitionOffsets(
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

        internal static ImmutableSortedSet<TopicPartition> GetTopicPartitions(
            MetadataResponse metadataResponse
        )
        {
            var builder = ImmutableSortedSet.CreateBuilder(TopicPartitionCompare.Instance);
            foreach (var topic in metadataResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    builder.Add(new(topic.NameField, partition.PartitionIndexField));
            return builder.ToImmutable();
        }

        internal static void UpdateTopicPartitionOffsets(
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
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

        internal static void UpdateTopicPartitionOffsets(
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            IEnumerable<ListOffsetsResponse> offsetListResponses
        )
        {
            foreach (var offsetListResponse in offsetListResponses)
                UpdateTopicPartitionOffsets(topicPartitionOffsets, offsetListResponse);
        }

        internal static void UpdateTopicPartitionOffsets(
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            ListOffsetsResponse offsetListResponse
        )
        {
            foreach (var topic in offsetListResponse.TopicsField)
                foreach (var partition in topic.PartitionsField)
                    topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = partition.OffsetField;
        }
    }
}
