using Kafka.Client.Clients.Producer.Model;

namespace Kafka.Client.Clients.Producer
{
    public interface ITransaction
    {
        /// <summary>
        /// Transaciton Id from config.
        /// </summary>
        string TransactionId { get; }
        /// <summary>
        /// Current transaction state.
        /// </summary>
        TxnState TxnState { get; }
        /// <summary>
        /// Flushes the inflight records and issues a commit command.
        /// To control ensure transaction boundary, all sends should be completed prior to this call.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Commit(CancellationToken cancellationToken);
        /// <summary>
        /// flushes the inflight records and issues a abort command.
        /// To control ensure transaction boundary, all sends should be completed prior to this call.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Rollback(CancellationToken cancellationToken);
    }
}
