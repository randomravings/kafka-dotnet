using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Messages;
using Kafka.Common;
using Kafka.Common.Encoding;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Kafka.Client.Clients.Producer
{
    public sealed class Producer<TKey, TValue> :
        Client<ProducerConfig>,
        IProducer<TKey, TValue>
    {
        private readonly int _maxInFlightRequests;
        private readonly int _maxRequestSize;
        private readonly TimeSpan _lingerTime;
        private readonly ISerializer<TKey> _keySerializer;
        private readonly ISerializer<TValue> _valueSerializer;
        private readonly IPartitioner _partitioner;
        private readonly BlockingCollection<ProduceCallback<TKey, TValue>> _collectQueue = new();
        private readonly BlockingCollection<ImmutableDictionary<TopicPartition, ImmutableArray<ProduceCallback<TKey, TValue>>>> _dispatchQueue = new();
        private readonly Task _recordsBuilderTask;
        private readonly Task _recordsAccumulatorTask;
        private readonly CancellationTokenSource _internalCts = new();

        public Producer(
            ISerializer<TKey> keySerializer,
            ISerializer<TValue> valueSerializer,
            IPartitioner partitioner,
            ProducerConfig config,
            ILogger<IProducer<TKey, TValue>> logger
        ) : base(config, logger)
        {
            _maxInFlightRequests = config.MaxInFlightRequestsPerConnection;
            _maxRequestSize = config.MaxRequestSize;
            _lingerTime = TimeSpan.FromMilliseconds(config.LingerMs);

            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
            _partitioner = partitioner;
            _recordsBuilderTask = Task.Run(() => RunDispatch(_internalCts.Token));
            _recordsAccumulatorTask = Task.Run(() => RunCollector(_internalCts.Token));
        }

        public async IAsyncEnumerable<ImmutableArray<ProduceResult<TKey, TValue>>> Send(
            IEnumerable<ProduceRecord<TKey, TValue>> produceRecords,
            int chunkSize,
            [EnumeratorCancellation] CancellationToken cancellationToken
        )
        {
            if (chunkSize < 1)
                throw new ArgumentOutOfRangeException(nameof(chunkSize), "Chunk size must be one or greater");
            var count = 0;
            var chunk = new ProduceCallback<TKey, TValue>[chunkSize];
            foreach (var produceRecord in produceRecords)
            {
                var keyBytes = _keySerializer.Write(produceRecord.Key);
                var valueBytes = _valueSerializer.Write(produceRecord.Value);

                var partition = produceRecord.Partition;
                if (partition == Partition.Unassigned)
                    partition = await _partitioner.Select(_cluster, produceRecord.Topic, keyBytes);

                var timestamp = produceRecord.Timestamp;
                if (timestamp == Timestamp.None)
                    timestamp = Timestamp.Now();

                var taskCompletionSource = new TaskCompletionSource<ProduceResult<TKey, TValue>>();
                var produceCallback = new ProduceCallback<TKey, TValue>(
                        produceRecord,
                        timestamp,
                        partition,
                        keyBytes,
                        valueBytes,
                        taskCompletionSource
                    )
                ;
                chunk[count++] = produceCallback;
                if (count >= chunkSize)
                {
                    yield return await SendChunk(
                        chunk,
                        count,
                        cancellationToken
                    );
                    count = 0;
                }
            }
            yield return await SendChunk(
                chunk,
                count,
                cancellationToken
            );
        }

        private async Task<ImmutableArray<ProduceResult<TKey, TValue>>> SendChunk(
            ProduceCallback<TKey, TValue>[] chunk,
            int length,
            CancellationToken cancellationToken
        )
        {
            if (length <= 0)
                return ImmutableArray<ProduceResult<TKey, TValue>>.Empty;
            for (int i = 0; i < length; i++)
                _collectQueue.Add(chunk[i], cancellationToken);
            var tasks = chunk
                .Take(length)
                .Select(r => r.TaskCompletionSource.Task)
            ;
            await Task.WhenAll(tasks);
            return tasks
                .Select(r => r.Result)
                .ToImmutableArray()
            ;

        }

        public async Task<ProduceResult<TKey, TValue>> Send(
            ProduceRecord<TKey, TValue> produceRecord,
            CancellationToken cancellationToken
        )
        {
            var keyBytes = _keySerializer.Write(produceRecord.Key);
            var valueBytes = _valueSerializer.Write(produceRecord.Value);

            var partition = produceRecord.Partition;
            if (partition == Partition.Unassigned)
                partition = await _partitioner.Select(_cluster, produceRecord.Topic, keyBytes);

            var timestamp = produceRecord.Timestamp;
            if (timestamp == Timestamp.None)
                timestamp = Timestamp.Now();

            var taskCompletionSource = new TaskCompletionSource<ProduceResult<TKey, TValue>>();
            _collectQueue.Add(
                new(
                    produceRecord,
                    timestamp,
                    partition,
                    keyBytes,
                    valueBytes,
                    taskCompletionSource
                ),
                cancellationToken
            );
            return await taskCompletionSource.Task;
        }

        private void HandleRecordBatch(
            ImmutableArray<ProduceCallback<TKey, TValue>> batch
        )
        {
            var batchPerPartition = batch
                .GroupBy(
                    g => new TopicPartition(g.Record.Topic, g.Partition)
                )
                .ToImmutableDictionary(
                    k => k.Key,
                    v => v.ToImmutableArray()
                )
            ;
            _dispatchQueue.Add(batchPerPartition, CancellationToken.None);
        }

        private async Task HandleRecordSend(
            TopicPartition topicPartition,
            ImmutableArray<IRecords> records,
            ImmutableArray<ProduceCallback<TKey, TValue>> produceCallbacks,
            CancellationToken cancellationToken
        )
        {
            var request = new ProduceRequest(
                null,
                -1,
                30000,
                new[]
                {
                    new ProduceRequest.TopicProduceData(
                        topicPartition.Topic.Value ?? "",
                        new[]
                        {
                            new ProduceRequest.TopicProduceData.PartitionProduceData(
                                topicPartition.Partition,
                                records
                            )
                        }.ToImmutableArray()
                    )
                }.ToImmutableArray()
            );

            var respose = await HandleRequest(
                request,
                ProduceRequestSerde.Write,
                ProduceResponseSerde.Read,
                cancellationToken
            );

            for (int i = 0; i < respose.ResponsesField.Length; i++)
            {
                var topicResponse = respose.ResponsesField[i];
                var topicName = new TopicName(topicResponse.NameField);
                for (int j = 0; j < topicResponse.PartitionResponsesField.Length; j++)
                {
                    var partitionResponse = topicResponse.PartitionResponsesField[j];
                    var partition = new Partition(partitionResponse.IndexField);
                    var offset = new Offset(partitionResponse.BaseOffsetField);
                    var topicPartitionOffset = new TopicPartitionOffset(topicName, new(partition, offset));
                    var timestamp = Timestamp.LogAppend(partitionResponse.LogAppendTimeMsField);
                    var error = Errors.Known.NONE;
                    if (partitionResponse.ErrorCodeField != error.Code)
                        error = Errors.Translate(partitionResponse.ErrorCodeField);
                    var recordErrors = ImmutableArray<ProduceRecordError>.Empty;
                    if (partitionResponse.RecordErrorsField.Length > 0)
                    {
                        var recordErrorsBuilder = ImmutableArray.CreateBuilder<ProduceRecordError>(partitionResponse.RecordErrorsField.Length);
                        foreach (var recordError in partitionResponse.RecordErrorsField)
                            recordErrorsBuilder.Add(new(recordError.BatchIndexField, recordError.BatchIndexErrorMessageField ?? ""));
                    }
                    var produceCallback = produceCallbacks[j];
                    produceCallback.TaskCompletionSource.SetResult(
                        new ProduceResult<TKey, TValue>(
                            topicPartitionOffset,
                            timestamp,
                            produceCallback.Record.Headers,
                            produceCallback.Record.Key,
                            produceCallback.Record.Value,
                            error,
                            recordErrors
                        )
                    );
                }
            }
        }

        public void RunCollector(CancellationToken cancellationToken)
        {
            try
            {
                var collectExitReason = BatchAccumulatedReason.None;
                var overflow = default(ProduceCallback<TKey, TValue>?);
                while (!cancellationToken.IsCancellationRequested)
                {
                    // Create new batch at add overflow from prior batch if any.
                    var batchBuilder = ImmutableArray.CreateBuilder<ProduceCallback<TKey, TValue>>(_config.MaxInFlightRequestsPerConnection);
                    if (overflow != null)
                        batchBuilder.Add(overflow);
                    // Pack batch and return overflow if any,
                    (collectExitReason, overflow) = Collect(batchBuilder, cancellationToken);
                    // Flush items.
                    var batch = batchBuilder.ToImmutable();
                    HandleRecordBatch(batch);
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
                var item = _collectQueue.Take(cancellationToken);
                batchBuilder.Add(item);
            }

            // Degenerate case, batch size = 1 or no linger time.
            if (_maxInFlightRequests <= 1 && _lingerTime <= TimeSpan.Zero)
                return (BatchAccumulatedReason.MaxInFlightReached, default);

            // Populate remaining batch items for max size > 1.
            var fetchedSize = batchBuilder.Sum(r => EstimateRecordSize(r));
            using var localCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            localCts.CancelAfter(_lingerTime);
            while (true)
            {
                try
                {
                    var item = _collectQueue.Take(localCts.Token);
                    fetchedSize += EstimateRecordSize(item);
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
            }
        }

        public void RunDispatch(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var dispatchItem = _dispatchQueue.Take(cancellationToken);
                    var index = 0;
                    var tasks = new Task[dispatchItem.Count];
                    foreach (var item in dispatchItem)
                    {
                        var minTimestamp = item.Value.Min(r => r.Timestamp.TimestampMs);
                        var maxTimestamp = item.Value.Max(r => r.Timestamp.TimestampMs);
                        var recordArrayBuilder = ImmutableArray.CreateBuilder<IRecord>();
                        var batchSize = 0;
                        int offsetDelta = 0;
                        foreach (var callback in item.Value)
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
                        var recordBatchesBuilder = ImmutableArray.CreateBuilder<IRecords>(1);
                        recordBatchesBuilder.Add(batch);
                        tasks[index++] = HandleRecordSend(
                            item.Key,
                            recordBatchesBuilder.ToImmutableArray(),
                            item.Value,
                            cancellationToken
                        );
                    }
                    Task.WaitAll(tasks, cancellationToken);
                }
            }
            catch (OperationCanceledException) { }
        }

        /// <summary>
        /// Used to estimate record size.
        /// This is a conservative estimate and the actual size is likely to be lower due to the zigzag encoded integer values.
        /// Timestamp delta and offset delta are not known at this time.
        /// </summary>
        /// <param name="produceCallback"></param>
        /// <returns></returns>
        private static int EstimateRecordSize(ProduceCallback<TKey, TValue> produceCallback) =>
            (produceCallback.KeyBytes?.Length ?? 0) +
            (produceCallback.KeyBytes?.Length ?? 0) +
            ComputeHeadersSize(produceCallback.Record.Headers) +
            40 // Add some overhead to accout for overhead varint stuff.
        ;

        /// <summary>
        /// Used to compute the precise record size in bytes.
        /// </summary>
        /// <param name="timestampDelta"></param>
        /// <param name="offsetDelta"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        private static int ComputeRecordSize(
            long timestampDelta,
            int offsetDelta,
            ReadOnlyMemory<byte>? key,
            ReadOnlyMemory<byte>? value,
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

        /// <summary>
        /// Used to compute the precise Record header size in bytes.
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
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

        protected override async ValueTask OnClose(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            Task.WaitAll(new[] { _recordsAccumulatorTask, _recordsBuilderTask }, cancellationToken);
            await ValueTask.CompletedTask;
        }
    }
}
