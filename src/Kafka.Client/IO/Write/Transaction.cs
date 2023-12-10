namespace Kafka.Client.IO.Write
{
    internal sealed class Transaction(
        Func<bool, CancellationToken, Task> endTransactionDelegate
    ) :
        ITransaction
    {
        private readonly Func<bool, CancellationToken, Task> _endTransactionDelegate = endTransactionDelegate;
        private int _completed;

        async Task ITransaction.Commit(CancellationToken cancellationToken)
        {
            if (Interlocked.CompareExchange(ref _completed, 1, 0) != 0)
                throw new InvalidOperationException("Transaction has been completed");
            await _endTransactionDelegate(
                true,
                cancellationToken
            ).ConfigureAwait(false);
        }
        async Task ITransaction.Rollback(CancellationToken cancellationToken)
        {
            if (Interlocked.CompareExchange(ref _completed, 1, 0) != 0)
                throw new InvalidOperationException("Transaction has been completed");
            await _endTransactionDelegate(
                false,
                cancellationToken
            ).ConfigureAwait(false);
        }
        public void Dispose()
        {
            if (Interlocked.CompareExchange(ref _completed, 1, 0) != 0)
                return;
            using var cts = new CancellationTokenSource();
            cts.CancelAfter(5000);
            _endTransactionDelegate(
                false,
                cts.Token
            ).Wait(cts.Token);
        }
    }
}
