using Kafka.Client.Model;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client
{
    public interface IConsumerGroups
    {
        /// <summary>
        /// Gets a list of topics in use for a given consumer group.
        /// </summary>
        /// <param name="consumerGroup"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<GetTopicsResult> Get(
            ConsumerGroup consumerGroup,
            GetConsumerGroupsOptions options,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the committed offsets for a topic in consumer group.
        /// The group is specified by 'group.id'.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsCommitted(
            ConsumerGroup consumerGroup,
            TopicName topicName,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the committed offsets for topics in consumer group.
        /// The group is specified by 'group.id'.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsCommitted(
            ConsumerGroup consumerGroup,
            IReadOnlySet<TopicName> topicNames,
            CancellationToken cancellationToken
        );
    }
}
