using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Encoding;
using Kafka.Common.Records;
using Kafka.Common.Types;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    public sealed class RecordsBuilder<TKey, TValue> :
        IDisposable
    {
        private readonly Func<TopicPartition, IRecords, ImmutableArray<ProduceCallback<TKey, TValue>>, CancellationToken, Task> _dispatchAction;
        private readonly BlockingCollection<ImmutableDictionary<TopicPartition, ImmutableArray<ProduceCallback<TKey, TValue>>>> _queue = new();
        private readonly Task _dispatcher;
        private readonly CancellationTokenSource _dispatcherCancellation;

        public RecordsBuilder(
            Func<TopicPartition, IRecords, ImmutableArray<ProduceCallback<TKey, TValue>>, CancellationToken, Task> dispatchAction
        )
        {
            _dispatchAction = dispatchAction;
            _dispatcherCancellation = new CancellationTokenSource();
            _dispatcher = new Task(Run);
            _dispatcher.Start();
        }

        public void Add(
            ImmutableDictionary<TopicPartition, ImmutableArray<ProduceCallback<TKey, TValue>>> dispatchItem,
            CancellationToken cancellationToken
        )
        {
            _queue.Add(dispatchItem, cancellationToken);
        }

        private void Run()
        {
            try
            {
                while (!_dispatcherCancellation.IsCancellationRequested)
                {
                    var dispatchItem = _queue.Take(_dispatcherCancellation.Token);
                    var index = 0;
                    var tasks = new Task[dispatchItem.Count];
                    foreach (var item in dispatchItem)
                    {
                        var minTimestamp = item.Value.Min(r => r.Timestamp.TimestampMs);
                        var maxTimestamp = item.Value.Max(r => r.Timestamp.TimestampMs);
                        var recordArrayBuilder = ImmutableArray.CreateBuilder<IRecord>();
                        var batchSize = 0;
                        int offsetDelta = 0;
                        foreach(var callback in item.Value)
                        {
                            var timestampDelta = maxTimestamp - callback.Timestamp.TimestampMs;
                            var recordSize = ComputeRecordSize(
                                timestampDelta,
                                offsetDelta,
                                callback.KeyBytes,
                                callback.ValueBytes,
                                callback.Record.Headers
                            );
                            var record = new Record(
                                Length: recordSize,
                                Attributes: Attributes.None,
                                TimestampDelta: timestampDelta,
                                OffsetDelta: offsetDelta,
                                Key: callback.KeyBytes,
                                Value: callback.ValueBytes,
                                Headers: callback.Record.Headers
                            );
                            recordArrayBuilder.Add(record);
                            batchSize += recordSize;
                            offsetDelta++;
                        }
                        var records = recordArrayBuilder.ToImmutable();
                        batchSize += Encoder.SizeOfInt32(batchSize);
                        var batch = new RecordBatch(
                            BaseOffset: 0,
                            BatchLength: batchSize, // Header size adjustment deferred to encoder.
                            PartitionLeaderEpoch: 0,
                            Magic: 2,
                            Crc: 0,                 // Crc computation deferred to encoder.
                            Attributes.None,
                            LastOffsetDelta: 0,
                            BaseTimestamp: minTimestamp,
                            MaxTimestamp: maxTimestamp,
                            ProducerId: -1,
                            ProducerEpoch: -1,
                            BaseSequence: -1,
                            records
                        );
                        tasks[index++] = _dispatchAction(
                            item.Key,
                            batch,
                            item.Value,
                            _dispatcherCancellation.Token
                        );
                    }
                    Task.WaitAll(tasks);
                }
            }
            catch (OperationCanceledException) { }
        }

        public void Dispose()
        {
            _dispatcherCancellation.Cancel();
            _dispatcher.Wait();
            _dispatcher.Dispose();
            _dispatcherCancellation.Dispose();
        }

        private static int ComputeRecordSize(
            long timestampDelta,
            int offsetDelta,
            byte[]? key,
            byte[]? value,
            ImmutableArray<RecordHeader> headers
        ) =>
            Encoder.SizeOfInt64(timestampDelta) +
            Encoder.SizeOfInt32(offsetDelta) +
            1 + // Attributes
            Encoder.SizeOfInt32(key?.Length ?? 0) +
            (key?.Length ?? 0) +
            Encoder.SizeOfInt32(value?.Length ?? 0) +
            (value?.Length ?? 0) +
            ComputeHeadersSize(headers)
        ;

        private static int ComputeHeadersSize(
            ImmutableArray<RecordHeader> headers
        ) =>
            Encoder.SizeOfInt32(headers.Length) +
            headers.Sum(
                r =>
                    Encoder.SizeOfInt32(r.Key.Length) +
                    r.Key.Length +
                    Encoder.SizeOfInt32(r.Value.Length) +
                    r.Value.Length
            )
        ;
    }
}
