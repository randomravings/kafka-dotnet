namespace Kafka.Client.IO.Write
{
    internal sealed class Transaction :
        ITransaction
    {
        private readonly Func<bool, CancellationToken, Task> _endTransactionDelegate;
        private bool _active;
        public Transaction(
            Func<bool, CancellationToken, Task> endTransactionDelegate
        )
        {
            _endTransactionDelegate = endTransactionDelegate;
            _active = true;
        }
        async ValueTask ITransaction.Commit(CancellationToken cancellationToken)
        {
            if (_active)
                await _endTransactionDelegate(true, cancellationToken).ConfigureAwait(false);
            else
                throw new InvalidOperationException();
            _active = false;
        }
        async ValueTask ITransaction.Rollback(CancellationToken cancellationToken)
        {
            if (_active)
                await _endTransactionDelegate(false, cancellationToken).ConfigureAwait(false);
            else
                throw new InvalidOperationException();
            _active = false;
        }
        public void Dispose()
        {
            if (_active)
            {
                using var cts = new CancellationTokenSource();
                cts.CancelAfter(5000);
                try
                {
                    _endTransactionDelegate(false, cts.Token).Wait(CancellationToken.None);
                }
                catch (OperationCanceledException) { }
            }
        }
    }
}
