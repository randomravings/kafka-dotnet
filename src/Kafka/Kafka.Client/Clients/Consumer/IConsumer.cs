using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public interface IConsumer<TKey, TValue> :
        IClient
    {
        /// <summary>
        /// Lists available topics.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableArray<TopicInfo>> ListTopics(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the start offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsStart(TopicName topicName, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the start offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsStart(IReadOnlySet<TopicName> topicNames, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the start offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsStart(TopicPartition topicPartitions, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the start offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsStart(IReadOnlySet<TopicPartition> topicPartitions, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the end offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsEnd(TopicName topicName, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the end offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsEnd(IReadOnlySet<TopicName> topicNames, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the end offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsEnd(TopicPartition topicPartition, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the end offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsEnd(IReadOnlySet<TopicPartition> topicPartitions, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsForTimestamp(TopicName topicName, DateTimeOffset timestamp, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsForTimestamp(IReadOnlySet<TopicName> topicNames, DateTimeOffset timestamp, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsForTimestamp(TopicPartition topicPartition, DateTimeOffset timestamp, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsForTimestamp(IReadOnlySet<TopicPartition> topicPartitions, DateTimeOffset timestamp, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the committed offsets for topics in consumer group, if any.
        /// The group is specified by 'group.id'.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsCommitted(TopicName topicName, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the committed offsets for topics in consumer group, if any.
        /// The group is specified by 'group.id'.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsCommitted(IReadOnlySet<TopicName> topicNames, CancellationToken cancellationToken);

        /// <summary>
        /// Subscribes to consumer group specified by 'group.id' and returns an application stream.
        /// If Auto commit interval 'auto.commit.interval.ms' is > 0 then the stream will automatically
        /// the consumed offsets.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IInputStreamApplication<TKey, TValue>> CreateInstance(TopicName topicName, CancellationToken cancellationToken);

        /// <summary>
        /// Subscribes to consumer group specified by 'group.id' and returns an application stream.
        /// If Auto commit interval 'auto.commit.interval.ms' is > 0 then the stream will automatically
        /// the consumed offsets.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IInputStreamApplication<TKey, TValue>> CreateInstance(IReadOnlySet<TopicName> topicNames, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a seekable stream on selected topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <returns></returns>
        IInputStreamAssigned<TKey, TValue> Assign(TopicPartition topicPartition);

        /// <summary>
        /// Creates a seekable stream on selected topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <returns></returns>
        IInputStreamAssigned<TKey, TValue> Assign(IReadOnlySet<TopicPartition> topicPartitions);
    }
}
