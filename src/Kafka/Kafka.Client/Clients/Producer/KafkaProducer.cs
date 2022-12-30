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
    internal sealed class KafkaProducer<TKey, TValue> :
        Client<ProducerConfig>,
        IProducer<TKey, TValue>
    {
        private readonly ISerializer<TKey> _keySerializer;
        private readonly ISerializer<TValue> _valueSerializer;
        private readonly IPartitioner _partitioner;
        private readonly BlockingCollection<ProduceCallback<TKey, TValue>> _collectQueue = new();
        private readonly BlockingCollection<ImmutableArray<ProduceCallback<TKey, TValue>>> _dispatchQueue = new();
        private readonly Task _recordsBuilderTask;
        private readonly Task _recordsAccumulatorTask;
        private readonly CancellationTokenSource _internalCts = new();

        public KafkaProducer(
            ISerializer<TKey> keySerializer,
            ISerializer<TValue> valueSerializer,
            IPartitioner partitioner,
            ProducerConfig config,
            ILogger<IProducer<TKey, TValue>> logger
        ) : base(config, logger)
        {
            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
            _partitioner = partitioner;
            _recordsBuilderTask = Task.Run(async () => await RunDispatch(_internalCts.Token));
            _recordsAccumulatorTask = Task.Run(() => RunCollector(_internalCts.Token));
        }

        private static short ParseAcks(
            ProducerConfig producerConfig,
            ILogger logger
        )
        {
            if (producerConfig.Acks == "all")
                return -1;
            if (short.TryParse(producerConfig.Acks, out var acks) && acks >= 0)
                return acks;
            logger.LogWarning("Unknown value 'acks={value}, defaulting to 'acks=all'", producerConfig.Acks);
            return -1;
        }

        async Task<ProduceResult<TKey, TValue>> IProducer<TKey, TValue>.Send(
            TopicName topic,
            TKey key,
            TValue value,
            CancellationToken cancellationToken
        ) =>
            await SendRecord(
                new ProduceRecord<TKey, TValue>(
                    topic,
                    Partition.Unassigned,
                    Timestamp.None,
                    key,
                    value,
                    ImmutableArray<RecordHeader>.Empty
                ),
                cancellationToken
            )
        ;

        async Task<ProduceResult<TKey, TValue>> IProducer<TKey, TValue>.Send(
            TopicName topic,
            TKey key,
            TValue value,
            ImmutableArray<RecordHeader> recordHeaders,
            CancellationToken cancellationToken
        ) =>
            await SendRecord(
                new ProduceRecord<TKey, TValue>(
                    topic,
                    Partition.Unassigned,
                    Timestamp.None,
                    key,
                    value,
                    recordHeaders
                ),
                cancellationToken
            )
        ;

        async Task<ProduceResult<TKey, TValue>> IProducer<TKey, TValue>.Send(
            TopicName topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            CancellationToken cancellationToken
        ) =>
            await SendRecord(
                new ProduceRecord<TKey, TValue>(
                    topic,
                    Partition.Unassigned,
                    timestamp,
                    key,
                    value,
                    ImmutableArray<RecordHeader>.Empty
                ),
                cancellationToken
            )
        ;

        async Task<ProduceResult<TKey, TValue>> IProducer<TKey, TValue>.Send(
            TopicName topic,
            TKey key,
            TValue value,
            Timestamp timestamp,
            ImmutableArray<RecordHeader> recordHeaders,
            CancellationToken cancellationToken
        ) =>
            await SendRecord(
                new ProduceRecord<TKey, TValue>(
                    topic,
                    Partition.Unassigned,
                    timestamp,
                    key,
                    value,
                    recordHeaders
                ),
                cancellationToken
            )
        ;

        async Task<ProduceResult<TKey, TValue>> IProducer<TKey, TValue>.Send(
            ProduceRecord<TKey, TValue> produceRecord,
            CancellationToken cancellationToken
        ) =>
            await SendRecord(
                produceRecord,
                cancellationToken
            )
        ;

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
                var produceCallback = await CreateCallback(produceRecord);
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

        private async Task<ProduceResult<TKey, TValue>> SendRecord(
            ProduceRecord<TKey, TValue> produceRecord,
            CancellationToken cancellationToken
        )
        {
            var produceCallback = await CreateCallback(produceRecord);
            _collectQueue.Add(produceCallback, cancellationToken);
            return await produceCallback.TaskCompletionSource.Task;
        }

        private async ValueTask<ProduceCallback<TKey, TValue>> CreateCallback(
            ProduceRecord<TKey, TValue> produceRecord
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
            return new ProduceCallback<TKey, TValue>(
                    produceRecord.Topic,
                    partition,
                    timestamp,
                    keyBytes,
                    valueBytes,
                    produceRecord.Headers,
                    taskCompletionSource
                )
            ;
        }

        private void RunCollector(
            CancellationToken cancellationToken
        )
        {
            var maxInFlightRequestsPerConnection = _config.MaxInFlightRequestsPerConnection;
            var maxrequestSize = _config.MaxRequestSize;
            var lingerTime = TimeSpan.FromMilliseconds(_config.LingerMs);
            try
            {
                var collectExitReason = BatchAccumulatedReason.None;
                var overflow = default(ProduceCallback<TKey, TValue>?);
                while (!cancellationToken.IsCancellationRequested)
                {
                    // Create new batch at add overflow from prior batch if any.
                    var batchBuilder = ImmutableArray.CreateBuilder<ProduceCallback<TKey, TValue>>(maxInFlightRequestsPerConnection);
                    if (overflow != null)
                        batchBuilder.Add(overflow);
                    // Pack batch and return overflow if any,
                    (collectExitReason, overflow) = Collect(
                        _collectQueue,
                        batchBuilder,
                        maxInFlightRequestsPerConnection,
                        maxrequestSize,
                        lingerTime,
                        cancellationToken
                    );
                    // Flush items.
                    var batch = batchBuilder.ToImmutable();
                    _dispatchQueue.Add(batch, CancellationToken.None);
                    _logger.LogTrace("Collect triggered reason: {reason}, count: {count}", collectExitReason, batch.Length);
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
        private static (BatchAccumulatedReason Reason, ProduceCallback<TKey, TValue>? Overflow) Collect(
            BlockingCollection<ProduceCallback<TKey, TValue>> collectQueue,
            ImmutableArray<ProduceCallback<TKey, TValue>>.Builder batchBuilder,
            int maxInFlightRequestsPerConnection,
            int maxRequestSize,
            TimeSpan lingerTime,
            CancellationToken cancellationToken
        )
        {
            // Batch always allows at least one item.
            if (batchBuilder.Count == 0)
            {
                var item = collectQueue.Take(cancellationToken);
                batchBuilder.Add(item);
            }

            // Degenerate case, batch size = 1 or no linger time.
            if (maxInFlightRequestsPerConnection <= 1 && lingerTime <= TimeSpan.Zero)
                return (BatchAccumulatedReason.MaxInFlightReached, default);

            // Populate remaining batch items for max size > 1.
            var fetchedSize = batchBuilder.Sum(r => EstimateRecordSize(r));
            using var localCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            localCts.CancelAfter(lingerTime);
            while (true)
            {
                try
                {
                    var item = collectQueue.Take(localCts.Token);
                    fetchedSize += EstimateRecordSize(item);
                    if (fetchedSize >= maxRequestSize)
                        return (BatchAccumulatedReason.MaxSizeExceeded, item);
                    batchBuilder.Add(item);
                    if (batchBuilder.Count >= maxInFlightRequestsPerConnection)
                        return (BatchAccumulatedReason.MaxInFlightReached, default);
                }
                catch (OperationCanceledException)
                {
                    return (BatchAccumulatedReason.MaxLingerMsReached, default);
                }
            }
        }

        public async Task RunDispatch(
            CancellationToken cancellationToken
        )
        {
            var acks = ParseAcks(_config, _logger);
            var requestTimeoutMs = _config.RequestTimeoutMs;
            var enableIdempotence = _config.EnableIdempotence;
            var producerId = -1L;
            var producerEpoch = (short)-1;
            var baseSequence = -1;
            var sequencer = () => baseSequence;
            var transactionId = _config.TransactionalId;
            var transactionTimeoutMs = string.IsNullOrEmpty(transactionId) ? -1 : _config.TransactionTimeoutMs;

            try
            {
                if (enableIdempotence || !string.IsNullOrEmpty(transactionId))
                {
                    var request = new InitProducerIdRequest(
                        transactionId,
                        transactionTimeoutMs,
                        producerId,
                        producerEpoch
                    );
                    var response = await HandleRequest(
                        request,
                        InitProducerIdRequestSerde.Write,
                        InitProducerIdResponseSerde.Read,
                        cancellationToken
                    );
                    producerId = response.ProducerIdField;
                    producerEpoch = response.ProducerEpochField;
                    sequencer = () => Interlocked.Increment(ref baseSequence);
                }

                while (!cancellationToken.IsCancellationRequested)
                {
                    var dispatchItems = _dispatchQueue.Take(cancellationToken);
                    _logger.LogTrace("Record Builder dequeued {count} records", dispatchItems.Length);
                    var topicPartitions = CreateTopicPartitionTree(dispatchItems);
                    var tasks = CreateTopicPartitionSends(
                        topicPartitions,
                        acks,
                        requestTimeoutMs,
                        producerId,
                        producerEpoch,
                        sequencer,
                        cancellationToken
                    );
                    await Task.WhenAll(tasks);
                }
            }
            catch (OperationCanceledException) { }
        }

        private ImmutableSortedDictionary<TopicPartition, ImmutableArray<ProduceCallback<TKey, TValue>>> CreateTopicPartitionTree(
            ImmutableArray<ProduceCallback<TKey, TValue>> dispatchItems
        ) =>
            dispatchItems
                .Select((r, i) => new { Sequence = i, Callback = r })
                .GroupBy(
                    g => new TopicPartition(g.Callback.Topic, g.Callback.Partition)
                )
                .ToImmutableSortedDictionary(
                    k => k.Key,
                    v => v.Select(r => r.Callback)
                        .ToImmutableArray()
                )
            ;

        private ImmutableArray<Task> CreateTopicPartitionSends(
            ImmutableSortedDictionary<TopicPartition, ImmutableArray<ProduceCallback<TKey, TValue>>> topicPartitions,
            short acks,
            int requestTimeoutMs,
            long producerId,
            short producerEpoch,
            Func<int> sequencer,
            CancellationToken cancellationToken
        )
        {
            var tasks = ImmutableArray.CreateBuilder<Task>(topicPartitions.Count);
            foreach (var topicPartition in topicPartitions)
            {
                var batchSize = 0;
                var minTimestamp = long.MaxValue;
                var maxTimestamp = long.MinValue;
                foreach (var x in topicPartition.Value)
                {
                    minTimestamp = Math.Min(minTimestamp, x.Timestamp.TimestampMs);
                    maxTimestamp = Math.Max(maxTimestamp, x.Timestamp.TimestampMs);
                }
                (var sizeDelta, var recordList) = BuildRecordArray(topicPartition.Value, minTimestamp);
                var records = new RecordBatch(
                    BaseOffset: 0,
                    BatchLength: batchSize,
                    PartitionLeaderEpoch: 0,
                    Magic: 2,
                    Crc: 0, // Crc computation deferred to encoder.
                    Attributes.None,
                    LastOffsetDelta: recordList.Length - 1,
                    BaseTimestamp: minTimestamp,
                    MaxTimestamp: maxTimestamp,
                    ProducerId: producerId,
                    ProducerEpoch: producerEpoch,
                    BaseSequence: sequencer(),
                    recordList
                );
                var recordBatchesBuilder = ImmutableArray.CreateBuilder<IRecords>(1);
                recordBatchesBuilder.Add(records);
                tasks.Add(
                    HandleRecordSend(
                        topicPartition.Key,
                        recordBatchesBuilder.ToImmutableArray(),
                        topicPartition.Value,
                        acks,
                        requestTimeoutMs,
                        cancellationToken
                    )
                );
            }
            return tasks.ToImmutable();
        }

        //private static ImmutableArray<Task> CreateTopicPartitionSends()

        private static (int SizeDelta, ImmutableArray<IRecord> Records) BuildRecordArray(ImmutableArray<ProduceCallback<TKey, TValue>> value, long minTimestampMs)
        {
            var sizeDelta = 0;
            var recordArrayBuilder = ImmutableArray.CreateBuilder<IRecord>();
            for (int i = 0; i < value.Length; i++)
            {
                var callback = value[i];
                var timestampDelta = callback.Timestamp.TimestampMs - minTimestampMs;
                var record = CreateRecord(
                    timestampDelta,
                    i,
                    callback.Key,
                    callback.Value,
                    callback.Headers
                );
                recordArrayBuilder.Add(record);
                sizeDelta += record.SizeInBytes;
                sizeDelta += Encoder.SizeOfInt32(record.SizeInBytes);
            }
            return (sizeDelta, recordArrayBuilder.ToImmutable());
        }

        private static IRecord CreateRecord(
            long timestampDelta,
            int offsetDelta,
            ReadOnlyMemory<byte>? key,
            ReadOnlyMemory<byte>? value,
            ImmutableArray<RecordHeader> headers
        )
        {
            var recordSize = ComputeRecordSize(
                timestampDelta,
                offsetDelta,
                key,
                value,
                headers
            );
            return new Record(
                Length: recordSize,
                Attributes: Attributes.None,
                TimestampDelta: timestampDelta,
                OffsetDelta: offsetDelta,
                Key: key,
                Value: value,
                Headers: headers
            );
        }

        private async Task HandleRecordSend(
            TopicPartition topicPartition,
            ImmutableArray<IRecords> records,
            ImmutableArray<ProduceCallback<TKey, TValue>> produceCallbacks,
            short acks,
            int requestTimeOutMs,
            CancellationToken cancellationToken
        )
        {
            var request = new ProduceRequest(
                null,
                acks,
                requestTimeOutMs,
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
                    var offset = partitionResponse.BaseOffsetField;
                    var timestamp = Timestamp.LogAppend(partitionResponse.LogAppendTimeMsField);
                    var error = Errors.Known.NONE;
                    if (partitionResponse.ErrorCodeField == 0)
                    {
                        foreach (var produceCallback in produceCallbacks)
                        {
                            var topicPartitionOffset = new TopicPartitionOffset(topicName, new(partition, offset++));
                            produceCallback.TaskCompletionSource.SetResult(
                                new ProduceResult<TKey, TValue>(
                                    topicPartitionOffset,
                                    timestamp,
                                    error,
                                    ""
                                )
                            );
                        }
                        continue;
                    }

                    error = Errors.Translate(partitionResponse.ErrorCodeField);
                    var recordErrors = partitionResponse
                        .RecordErrorsField
                        .ToImmutableSortedDictionary(
                            k => k.BatchIndexField,
                            v => v.BatchIndexErrorMessageField ?? ""
                        )
                    ;
                    for (int k = 0; k < records.Length; k++)
                    {
                        var recordBatch = records[k];
                        for (int l = 0; l < recordBatch.Count; l++)
                        {
                            var index = k * l + l;
                            var topicPartitionOffset = new TopicPartitionOffset(topicName, new(partition, offset++));
                            if (!recordErrors.TryGetValue(index, out var recordError))
                                recordError = "";
                            var produceCallback = produceCallbacks[index];
                            produceCallback.TaskCompletionSource.SetResult(
                                new ProduceResult<TKey, TValue>(
                                    topicPartitionOffset,
                                    timestamp,
                                    error,
                                    recordError
                                )
                            );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Used to estimate record size.
        /// This is a conservative estimate and the actual size is likely to be lower due to the zigzag encoded integer values.
        /// Timestamp delta and offset delta are not known at this time.
        /// </summary>
        /// <param name="produceCallback"></param>
        /// <returns></returns>
        private static int EstimateRecordSize(ProduceCallback<TKey, TValue> produceCallback) =>
            (produceCallback.Key?.Length ?? 0) +
            (produceCallback.Key?.Length ?? 0) +
            ComputeHeadersSize(produceCallback.Headers) +
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
