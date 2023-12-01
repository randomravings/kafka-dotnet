using Kafka.Client.Model;
using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IInputStream
    {
        IStreamReaderBuilder CreateReader();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IReadOnlyList<InputRecord>> Read(
            CancellationToken cancellationToken
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IReadOnlyList<InputRecord>> Read(
            TimeSpan timeSpan,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Gets all Topic Partitions in the current stream.
        /// </summary>
        /// <returns></returns>
        IReadOnlySet<TopicPartition> TopicPartitions();

        /// <summary>
        /// Gets a list of suspended partitions.
        /// </summary>
        /// <returns></returns>
        IReadOnlySet<TopicPartition> PausedPartitions();

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
        /// Closes the consumer instance and frees up resources.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Close(
            CancellationToken cancellationToken
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicPartition"></param>
        /// <param name="offset"></param>
        void UpdateOffsets(
            in TopicPartition topicPartition,
            in Offset offset
        );

        /// <summary>
        /// Stores the topic poartition offsets.
        /// </summary>
        /// <param name="topicPartitionOffsets"></param>
        void UpdateOffsets(
            in IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets
        );
    }
}
