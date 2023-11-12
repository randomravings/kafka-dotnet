using Kafka.Client.Model;
using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IOutputStream :
        IDisposable
    {
        internal ValueTask<ProducerTopicMetadata> MetadataForTopic(
            TopicName topicName,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        IStreamWriterBuilder CreateWriter(
            TopicName topic
        );

        /// <summary>
        /// Produce a single record.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TaskCompletionSource<ProduceResult>> Write(
            ProduceRecord record,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Begins a transaction.
        /// If any messages are in flight they will be flushed before transaction is initialized.
        /// To control ensure transaction boundary, all sends should be completed prior to this call.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ITransaction> BeginTransaction(CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Flush(CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Close(CancellationToken cancellationToken);
    }
}
