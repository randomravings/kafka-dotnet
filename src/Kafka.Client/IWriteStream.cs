using Kafka.Client.Model;
using Kafka.Client.Model.Internal;
using Kafka.Common.Model;

namespace Kafka.Client
{
    public interface IWriteStream
    {
        internal Task<TopicMetadata> MetadataForTopic(
            TopicName topicName,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        IWriterBuilder CreateWriter();

        /// <summary>
        /// Write a single record.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<WriteResult> Write(
            WriteRecord record,
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
