using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Types;
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
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsStart(TopicNames topics, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the start offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsStart(IEnumerable<TopicPartition> topicPartitions, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the end offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsEnd(TopicNames topics, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the end offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsEnd(IEnumerable<TopicPartition> topicPartitions, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsForTimestamp(TopicNames topics, DateTimeOffset timestamp, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsForTimestamp(IEnumerable<TopicPartition> topicPartitions, DateTimeOffset timestamp, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the committed offsets for topics in consumer group, if any.
        /// The group is specified by 'group.id'.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsCommitted(TopicNames topics, CancellationToken cancellationToken);

        /// <summary>
        /// Subscribes to consumer group specified by 'group.id' and returns a auto commit stream.
        /// Auto commit interval is specified by 'auto.commit.interval.ms'.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">If 'enable.auto.commit=false'.</exception>
        ValueTask<IInputStreamAutoCommit<TKey, TValue>> CreateAutoCommitStream(TopicNames topics, CancellationToken cancellationToken);

        /// <summary>
        /// Subscribes to consumer group specified by 'group.id' and returns a manual commit stream.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">If 'enable.auto.commit=true'.</exception>
        ValueTask<IInputStreamManualCommit<TKey, TValue>> CreateManualCommitStream(TopicNames topics, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a seekable stream on selected topic partitions.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IInputStreamSeekable<TKey, TValue>> CreateSeekableStream(TopicPartitions topics, CancellationToken cancellationToken);
    }
}
