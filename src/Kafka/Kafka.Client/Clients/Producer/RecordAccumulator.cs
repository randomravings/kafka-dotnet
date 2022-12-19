using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Types;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    public sealed class RecordAccumulator<TKey, TValue> :
        IDisposable
    {
        private readonly int _maxInFlightRequests;
        private readonly int _maxRequestSize;
        private readonly TimeSpan _lingerTime;
        private readonly Func<ProduceCallback<TKey, TValue>, int> _sizeEstimator;
        private readonly Action<BatchAccumulatedReason, ImmutableArray<ProduceCallback<TKey, TValue>>> _onBatchesReady;
        private readonly BlockingCollection<ProduceCallback<TKey, TValue>> _queue;
        private readonly Task _dispatcher;
        private readonly CancellationTokenSource _dispatcherCancellation;

        public RecordAccumulator(
            int maxInFlightRequests,
            int maxRequestSize,
            long lingerTimeMs,
            Func<ProduceCallback<TKey, TValue>, int> sizeEstimator,
            Action<BatchAccumulatedReason, ImmutableArray<ProduceCallback<TKey, TValue>>> onBatchesReady
        )
        {
            _maxInFlightRequests = maxInFlightRequests;
            _maxRequestSize = maxRequestSize;
            _lingerTime = TimeSpan.FromMilliseconds(lingerTimeMs);
            _sizeEstimator = sizeEstimator;
            _onBatchesReady = onBatchesReady;
            _queue = new();
            _dispatcherCancellation = new CancellationTokenSource();
            _dispatcher = new Task(Run);
            _dispatcher.Start();
        }

        public Task<ProduceResult<TKey, TValue>> Add(
            ProduceRecord<TKey, TValue> produceRecord,
            Timestamp timestamp,
            Partition partition,
            byte[]? KeyBytes,
            byte[]? ValueBytes,
            CancellationToken cancellationToken
        )
        {
            var taskCompletionSource = new TaskCompletionSource<ProduceResult<TKey, TValue>>();
            _queue.Add(
                new(
                    produceRecord,
                    timestamp,
                    partition,
                    KeyBytes,
                    ValueBytes,
                    taskCompletionSource
                ),
                cancellationToken
            );
            return taskCompletionSource.Task;
        }

        private void Run()
        {
            try
            {
                var collectExitReason = BatchAccumulatedReason.None;
                var overflow = default(ProduceCallback<TKey, TValue>?);
                while (!_dispatcherCancellation.IsCancellationRequested)
                {
                    // Create new batch at add overflow from prior batch if any.
                    var batchBuilder = ImmutableArray.CreateBuilder<ProduceCallback<TKey, TValue>>(_maxInFlightRequests);
                    if (overflow != null)
                        batchBuilder.Add(overflow);
                    // Pack batch and return overflow if any,
                    (collectExitReason, overflow) = Collect(batchBuilder, _dispatcherCancellation.Token);
                    // Flush items.
                    var batch = batchBuilder.ToImmutable();
                    _onBatchesReady(collectExitReason, batch);
                }
            }
            catch (OperationCanceledException) { }
        }

        /// <summary>
        /// Collects items into an existing batch from queue.
        /// If an item would overflow the buffer size then it is returned.
        /// </summary>
        /// <param name="batch">Batch to fill.</param>
        /// <param name="cancellationToken">Cancellation token for the initial dequeue.</param>
        /// <returns></returns>
        private (BatchAccumulatedReason Reason, ProduceCallback<TKey, TValue>? Overflow) Collect(
            ImmutableArray<ProduceCallback<TKey, TValue>>.Builder batchBuilder,
            CancellationToken cancellationToken
        )
        {
            // Batch always allows at least one item.
            if (batchBuilder.Count == 0)
            {
                var item = _queue.Take(cancellationToken);
                batchBuilder.Add(item);
            }

            // Degenerate case, batch size = 1 or no linger time.
            if (_maxInFlightRequests <= 1 && _lingerTime <= TimeSpan.Zero)
                return (BatchAccumulatedReason.MaxInFlightReached, default);

            // Populate remaining batch items for max size > 1.
            var fetchedSize = batchBuilder.Sum(r => _sizeEstimator(r));
            var localCts = new CancellationTokenSource();
            var registration = _dispatcherCancellation.Token.Register(localCts.Cancel);
            localCts.CancelAfter(_lingerTime);
            while (true)
            {
                try
                {
                    var item = _queue.Take(localCts.Token);
                    fetchedSize += _sizeEstimator(item);
                    if (fetchedSize >= _maxRequestSize)
                        return (BatchAccumulatedReason.MaxSizeExceeded, item);
                    batchBuilder.Add(item);
                    if (batchBuilder.Count >= _maxInFlightRequests)
                        return (BatchAccumulatedReason.MaxInFlightReached, default);
                }
                catch (OperationCanceledException)
                {
                    return (BatchAccumulatedReason.MaxLingerMsReached, default);
                }
                finally
                {
                    registration.Unregister();
                }
            }
        }

        public void Dispose()
        {
            _dispatcherCancellation.Cancel();
            _dispatcher.Wait();
            _dispatcher.Dispose();
            _dispatcherCancellation.Dispose();
        }
    }
}
