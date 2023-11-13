using Kafka.Client.Model;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client
{
    public interface ITopics
    {
        ValueTask<GetTopicsResult> Get(
            GetTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<GetTopicsResult> Get(
            TopicName topics,
            GetTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<GetTopicsResult> Get(
            IReadOnlyList<TopicName> topics,
            GetTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<CreateTopicsResult> Create(
            CreateTopicDefinition topic,
            CreateTopicOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<CreateTopicsResult> Create(
            IReadOnlyList<CreateTopicDefinition> topics,
            CreateTopicOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<DeleteTopicsResult> Delete(
            TopicName topic,
            CancellationToken cancellationToken
        );

        ValueTask<DeleteTopicsResult> Delete(
            IReadOnlyList<TopicName> topics,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the start offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsStart(
            TopicName topicName,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the start offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsStart(
            IReadOnlySet<TopicName> topicNames,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the start offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsStart(
            TopicPartition topicPartitions,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the start offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsStart(
            IReadOnlySet<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the end offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsEnd(
            TopicName topicName,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the end offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsEnd(
            IReadOnlySet<TopicName> topicNames,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the end offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsEnd(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the end offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsEnd(
            IReadOnlySet<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsForTimestamp(
            TopicName topicName,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsForTimestamp(
            IReadOnlySet<TopicName> topicNames,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsForTimestamp(
            TopicPartition topicPartition,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> OffsetsForTimestamp(
            IReadOnlySet<TopicPartition> topicPartitions,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        );
    }
}
