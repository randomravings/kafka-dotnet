using Kafka.Client.Model;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client
{
    public interface IGroups
    {
        /// <summary>
        /// Gets a list of topics in use for a given consumer group.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyList<GroupDescription>> List(
            ListGroupsOptions options,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets a list of topics in use for a given consumer group.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyList<DescribeGroupResult>> Describe(
            IEnumerable<ConsumerGroup> groups,
            DescribeGroupOptions options,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets a list of topics in use for a given consumer group.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyList<DeleteGroupResult>> Delete(
            IEnumerable<ConsumerGroup> groups,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the committed offsets for all topics in consumer group.
        /// The group is specified by 'group.id'.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="topic"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<ConsumerGroup, IReadOnlyList<TopicPartitionOffset>>> OffsetsCommitted(
            IEnumerable<ConsumerGroup> group,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the committed offsets for topics in consumer group.
        /// The group is specified by 'group.id'.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<ConsumerGroup, IReadOnlyList<TopicPartitionOffset>>> OffsetsCommitted(
            IEnumerable<ConsumerGroup> group,
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        );
    }
}
