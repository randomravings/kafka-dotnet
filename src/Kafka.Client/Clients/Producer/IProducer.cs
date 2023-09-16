using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Commands;

namespace Kafka.Client.Clients.Producer
{
    public interface IProducer<TKey, TValue> :
        IClient
    {
        /// <summary>
        /// Produce a single record.
        /// </summary>
        /// <param name="produceRecrod"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<ICommand<ProduceResult>> Send(
            ProduceRecord<TKey, TValue> produceRecrod,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Begins a transaction.
        /// If any messages are in flight they will be flushed before transaction is initialized.
        /// To control ensure transaction boundary, all sends should be completed prior to this call.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask BeginTransaction(CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask CommitTransaction(CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask RollbackTransaction(CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask Flush(CancellationToken cancellationToken);
    }
}
