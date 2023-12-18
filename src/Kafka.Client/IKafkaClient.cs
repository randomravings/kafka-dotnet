using Kafka.Client.Config;
using Kafka.Client.IO;
using Kafka.Client.Model;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client
{
    /// <summary>
    /// 
    /// </summary>
    public interface IKafkaClient :
        IDisposable
    {
        ValueTask<IReadOnlyList<TopicDescription>> ListTopics(
            ListTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<IReadOnlyList<TopicDescription>> ListTopics(
            TopicName topics,
            ListTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<IReadOnlyList<TopicDescription>> ListTopics(
            IEnumerable<TopicName> topics,
            ListTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<CreateTopicsResult> CreateTopic(
            CreateTopicDefinition topic,
            CreateTopicOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<CreateTopicsResult> CreateTopics(
            IEnumerable<CreateTopicDefinition> topics,
            CreateTopicOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<DeleteTopicsResult> DeleteTopic(
            TopicName topic,
            CancellationToken cancellationToken
        );

        ValueTask<DeleteTopicsResult> DeleteTopics(
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the start offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsStart(
            TopicName topicName,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the start offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsStart(
            IEnumerable<TopicName> topicNames,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the start offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsStart(
            TopicPartition topicPartitions,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the start offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsStart(
            IEnumerable<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the end offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsEnd(
            TopicName topicName,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the end offsets for topics.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsEnd(
            IEnumerable<TopicName> topicNames,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the end offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsEnd(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the end offsets for topic partitions.
        /// </summary>
        /// <param name="topicPartitions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsEnd(
            IEnumerable<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets the earliest offsets for topics equal or greater than the specified timestamp.
        /// </summary>
        /// <param name="topics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsForTimestamp(
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
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsForTimestamp(
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
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsForTimestamp(
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
        ValueTask<IReadOnlyDictionary<TopicName, ImmutableArray<PartitionOffset>>> GetOffsetsForTimestamp(
            IEnumerable<TopicPartition> topicPartitions,
            DateTimeOffset timestamp,
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
        ValueTask<IReadOnlyDictionary<ConsumerGroup, IReadOnlyList<TopicPartitionOffset>>> GetOffsetsCommitted(
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
        ValueTask<IReadOnlyDictionary<ConsumerGroup, IReadOnlyList<TopicPartitionOffset>>> GetOffsetsCommitted(
            IEnumerable<ConsumerGroup> group,
            IEnumerable<TopicName> topics,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets a list of topics in use for a given consumer group.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyList<GroupDescription>> ListGroups(
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
        ValueTask<IReadOnlyList<DescribeGroupResult>> DescribeGroups(
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
        ValueTask<IReadOnlyList<DeleteGroupResult>> DeleteGroups(
            IEnumerable<ConsumerGroup> groups,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets a list of acls.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyList<AclResource>> DescribeAcls(
            DescribeAclOptions options,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Creates new acls.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyList<CreateAclResult>> CreateAcls(
            CreateAclOptions options,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Deletes existing acls.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyList<DeleteAclResult>> DeleteAcls(
            DeleteAclOptions options,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Creates a new input stream to cluster for writing records.
        /// </summary>
        /// <returns></returns>
        IReadStreamBuilder CreateReadStream();

        /// <summary>
        /// Creates a new input stream to cluster for writing records.
        /// </summary>
        /// <returns></returns>
        IReadStreamBuilder CreateReadStream(
            Action<ReadStreamConfig> configure
        );

        /// <summary>
        /// Creates a new output stream from cluster for reading records.
        /// </summary>
        /// <returns></returns>
        IWriteStreamBuilder CreateWriteStream();

        /// <summary>
        /// Creates a new output stream from cluster for reading records.
        /// </summary>
        /// <returns></returns>
        IWriteStreamBuilder CreateWriteStream(
            Action<WriteStreamConfig> configure
        );

        /// <summary>
        /// Perform graceful shut down of client and free up resources.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Close(CancellationToken cancellationToken);
    }
}
