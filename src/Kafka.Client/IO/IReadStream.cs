using Kafka.Client.Model;
using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IReadStream
    {
        /// <summary>
        /// Gets a list of suspended partitions.
        /// </summary>
        /// <returns></returns>
        IReadOnlySet<TopicPartition> PausedPartitions { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IReadOnlyList<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>> Read(
            CancellationToken cancellationToken
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IReadOnlyList<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>> Read(
            TimeSpan timeSpan,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Suspends one or more topic partition from the fetch requests.
        /// </summary>
        /// <param name="partitions"></param>
        void PausePartitions(
            in IReadOnlyList<TopicPartition> partitions
        );

        /// <summary>
        /// Reinstates one or more topic partition to be included in fetch requests.
        /// </summary>
        /// <param name="partitions"></param>
        void ResumePartitions(
            in IReadOnlyList<TopicPartition> partitions
        );

        /// <summary>
        /// Closes the read stream instance and frees up resources.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Close(
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Marks a topic partition offset as read.
        /// </summary>
        /// <param name="topicPartition"></param>
        /// <param name="offset"></param>
        void UpdateOffset(
            in TopicPartition topicPartition,
            in Offset offset
        );

        /// <summary>
        /// Marks a set of topic partition offset as read.
        /// </summary>
        /// <param name="topicPartitionOffsets"></param>
        void UpdateOffsets(
            in IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets
        );
    }
}
