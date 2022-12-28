using Kafka.Client.Clients.Producer.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    public interface IProducer<TKey, TValue> :
        IClient
    {
        /// <summary>
        /// Produce a single record.
        /// If called from a single thread ordering is guaranteed.
        /// If called in parallel then ordering is not guaranteed.
        /// </summary>
        /// <param name="produceRecrod"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProduceResult<TKey, TValue>> Send(
            ProduceRecord<TKey, TValue> produceRecrod,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Produce a batch of records using a given chunk size.
        /// Ordering is preserved.
        /// Chunks are handled one by one and and match by index.
        /// In case of presend failures an entire chunk fails.
        /// </summary>
        /// <param name="produceRecords"></param>
        /// <param name="chunkSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IAsyncEnumerable<ImmutableArray<ProduceResult<TKey, TValue>>> Send(
            IEnumerable<ProduceRecord<TKey, TValue>> produceRecords,
            int chunkSize,
            CancellationToken cancellationToken
        );
    }
}
