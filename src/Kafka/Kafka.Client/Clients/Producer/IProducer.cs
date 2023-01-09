using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Records;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    public interface IProducer<TKey, TValue> :
        IClient
    {
        /// <summary>
        /// Produce a single record.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProduceResult<TKey, TValue>> Send(
            TopicName topic,
            TKey key,
            TValue value,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Produce a single record.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timestamp"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProduceResult<TKey, TValue>> Send(
            TopicName topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Produce a single record.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="recordHeaders"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProduceResult<TKey, TValue>> Send(
            TopicName topic,
            TKey key,
            TValue value,
            ImmutableArray<RecordHeader> recordHeaders,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Produce a single record.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timestamp"></param>
        /// <param name="recordHeaders"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProduceResult<TKey, TValue>> Send(
            TopicName topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            ImmutableArray<RecordHeader> recordHeaders,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Produce a single record.
        /// </summary>
        /// <param name="produceRecrod"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProduceResult<TKey, TValue>> Send(
            ProduceRecord<TKey, TValue> produceRecrod,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Produce a batch of records using a given chunk size which can be used to
        /// achieve higher throughput while preserving ordering within partitions for
        /// the provided list of records.
        /// <para>
        /// The throughput is constrained by the settings:
        /// <list type="bullet">
        ///   <item>max.in.flight.requests.per.connection</item>
        ///   <item>max.request.size</item>
        ///   <item>linger.ms</item>
        /// </list>
        /// All settings contribute to more records being sent per batch.
        /// </para>
        /// </summary>
        /// <param name="produceRecords">List of records.</param>
        /// <param name="chunkSize">Chunk size in number of records per send.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IAsyncEnumerable<ImmutableArray<ProduceResult<TKey, TValue>>> Send(
            IEnumerable<ProduceRecord<TKey, TValue>> produceRecords,
            int chunkSize,
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
    }
}
