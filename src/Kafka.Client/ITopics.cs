using Kafka.Client.Model;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client
{
    public interface ITopics
    {
        ValueTask<IReadOnlyList<TopicDescription>> List(
            ListTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<IReadOnlyList<TopicDescription>> List(
            TopicName topics,
            ListTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<IReadOnlyList<TopicDescription>> List(
            IEnumerable<TopicName> topics,
            ListTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<CreateTopicsResult> Create(
            CreateTopicDefinition topic,
            CreateTopicOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<CreateTopicsResult> Create(
            IEnumerable<CreateTopicDefinition> topics,
            CreateTopicOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<DeleteTopicsResult> Delete(
            TopicName topic,
            CancellationToken cancellationToken
        );

        ValueTask<DeleteTopicsResult> Delete(
            IEnumerable<TopicName> topics,
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
            IEnumerable<TopicName> topicNames,
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
            IEnumerable<TopicPartition> topicPartitions,
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
            IEnumerable<TopicName> topicNames,
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
            IEnumerable<TopicPartition> topicPartitions,
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
            IEnumerable<TopicName> topicNames,
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
            IEnumerable<TopicPartition> topicPartitions,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        );
    }
}
