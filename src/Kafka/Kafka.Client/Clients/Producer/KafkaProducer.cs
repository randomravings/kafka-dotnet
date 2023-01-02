using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Messages;
using Kafka.Common;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
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
        private readonly BlockingCollection<IProducerCommand> _commandQueue = new();
        private readonly BlockingCollection<IProducerCommand> _executeQueue = new();
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
            var chunk = new ProduceCommand<TKey, TValue>[chunkSize];
            foreach (var produceRecord in produceRecords)
            {
                var produceCallback = await CreateProduceCommand(produceRecord);
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
            ProduceCommand<TKey, TValue>[] chunk,
            int length,
            CancellationToken cancellationToken
        )
        {
            if (length <= 0)
                return ImmutableArray<ProduceResult<TKey, TValue>>.Empty;
            for (int i = 0; i < length; i++)
                _commandQueue.Add(chunk[i], cancellationToken);
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
            var produceCallback = await CreateProduceCommand(produceRecord);
            _commandQueue.Add(produceCallback, cancellationToken);
            return await produceCallback.TaskCompletionSource.Task;
        }

        private async ValueTask<ProduceCommand<TKey, TValue>> CreateProduceCommand(
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
            return new ProduceCommand<TKey, TValue>(
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
                var overflow = default(ProduceCommand<TKey, TValue>?);
                while (!cancellationToken.IsCancellationRequested)
                {
                    // Create new batch at add overflow from prior batch if any.
                    var batchBuilder = ImmutableArray.CreateBuilder<ProduceCommand<TKey, TValue>>(maxInFlightRequestsPerConnection);
                    if (overflow != null)
                        batchBuilder.Add(overflow);
                    // Pack batch and return overflow if any,
                    (collectExitReason, overflow) = Collect(
                        _commandQueue,
                        _executeQueue,
                        batchBuilder,
                        maxInFlightRequestsPerConnection,
                        maxrequestSize,
                        lingerTime,
                        cancellationToken
                    );
                    // Flush items.
                    var batch = batchBuilder.ToImmutable();
                    _executeQueue.Add(new ProduceCommandBatch<TKey, TValue>(batch), CancellationToken.None);
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
        private static (BatchAccumulatedReason Reason, ProduceCommand<TKey, TValue>? Overflow) Collect(
            BlockingCollection<IProducerCommand> commandQueue,
            BlockingCollection<IProducerCommand> dispatchQueue,
            ImmutableArray<ProduceCommand<TKey, TValue>>.Builder batchBuilder,
            int maxInFlightRequestsPerConnection,
            int maxRequestSize,
            TimeSpan lingerTime,
            CancellationToken cancellationToken
        )
        {
            // Batch always allows at least one item.
            while (batchBuilder.Count == 0)
            {
                var produceCommand = HandleCommandQueue(
                    commandQueue,
                    dispatchQueue,
                    cancellationToken
                );
                batchBuilder.Add(produceCommand);
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
                    var produceCommand = HandleCommandQueue(
                        commandQueue,
                        dispatchQueue,
                        localCts.Token
                    );
                    fetchedSize += EstimateRecordSize(produceCommand);
                    if (fetchedSize >= maxRequestSize)
                        return (BatchAccumulatedReason.MaxSizeExceeded, produceCommand);
                    batchBuilder.Add(produceCommand);
                    if (batchBuilder.Count >= maxInFlightRequestsPerConnection)
                        return (BatchAccumulatedReason.MaxInFlightReached, default);
                }
                catch (OperationCanceledException)
                {
                    return (BatchAccumulatedReason.MaxLingerMsReached, default);
                }
            }
        }

        private static ProduceCommand<TKey, TValue> HandleCommandQueue(
            BlockingCollection<IProducerCommand> commandQueue,
            BlockingCollection<IProducerCommand> dispatchQueue,
            CancellationToken cancellationToken
        )
        {
            ProduceCommand<TKey, TValue>? produceCommand = null;
            while (produceCommand == null)
            {
                var producerCommand = commandQueue.Take(cancellationToken);
                switch (producerCommand)
                {
                    case ProduceCommand<TKey, TValue> p:
                        return p;
                    default:
                        dispatchQueue.Add(producerCommand, cancellationToken);
                        break;
                }
            }
            return produceCommand;
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
            var baseSequence = 0;
            var sequencer = new Func<int, int>(i => baseSequence);
            var transactionalId = _config.TransactionalId;
            var transactionTimeoutMs = -1;

            if (!string.IsNullOrEmpty(_config.TransactionalId))
            {
                enableIdempotence = true;
                transactionTimeoutMs = _config.TransactionTimeoutMs;
            }

            try
            {
                if (enableIdempotence)
                {
                    var request = new InitProducerIdRequest(
                        transactionalId,
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
                    sequencer = i => { var v = baseSequence; Interlocked.Add(ref baseSequence, i); return v; };
                }

                var transaction = NoTransaction.Instance;
                while (!cancellationToken.IsCancellationRequested)
                {
                    var dispatchCommand = _executeQueue.Take(cancellationToken);
                    switch (dispatchCommand)
                    {
                        case ProduceCommandBatch<TKey, TValue> pb:
                            _logger.LogTrace("Record Builder dequeued {count} records", pb.ProduceCommands.Length);
                            var topicPartitions = KafkaProducer<TKey, TValue>.CreateTopicPartitionTree(pb.ProduceCommands);
                            if (transaction is ActiveTransaction activeTransaction)
                            {
                                var newTopicPartitions = transaction.AddTopicPartitions(topicPartitions.Keys);
                                if (newTopicPartitions.Any())
                                {
                                    var addPartitionsToTxnTopic = newTopicPartitions
                                        .GroupBy(g => g.Topic.Value ?? "")
                                        .Select(r => new AddPartitionsToTxnRequest.AddPartitionsToTxnTopic(
                                                r.Key,
                                                r.Select(r => r.Partition.Value).ToImmutableArray()
                                            )
                                        )
                                        .ToImmutableArray()
                                    ;
                                    var addPartitionsToTxnRequest = new AddPartitionsToTxnRequest(
                                        activeTransaction.TransactionId,
                                        producerId,
                                        producerEpoch,
                                        addPartitionsToTxnTopic
                                    );
                                    var addPartitionsToTxnResponse = await HandleRequest(
                                        addPartitionsToTxnRequest,
                                        AddPartitionsToTxnRequestSerde.Write,
                                        AddPartitionsToTxnResponseSerde.Read,
                                        cancellationToken
                                    );
                                    foreach (var topicParitionResponse in addPartitionsToTxnResponse.ResultsField)
                                        foreach (var paritionResponse in topicParitionResponse.ResultsField)
                                            if (paritionResponse.ErrorCodeField != 0)
                                                _logger.LogWarning("Topic: {topic} - Error: {error}", topicParitionResponse.NameField, Errors.Translate(paritionResponse.ErrorCodeField).ToString());
                                }
                            }
                            var tasks = CreateTopicPartitionSends(
                                transaction,
                                topicPartitions,
                                acks,
                                requestTimeoutMs,
                                producerId,
                                producerEpoch,
                                transactionalId,
                                sequencer,
                                cancellationToken
                            );
                            await Task.WhenAll(tasks);
                            break;
                        case BeginTransactionCommand bt:
                            if (transaction is ActiveTransaction)
                            {
                                bt.TaskCompletionSource.SetException(new InvalidOperationException("Active transaction in progress"));
                                break;
                            }
                            if (string.IsNullOrEmpty(transactionalId))
                            {
                                bt.TaskCompletionSource.SetException(new InvalidOperationException("transaction.id is not initialized"));
                                break;
                            }
                            transaction = new ActiveTransaction(transactionalId, _commandQueue);
                            bt.TaskCompletionSource.SetResult(transaction);
                            break;
                        case CommitTransactionCommand ct:
                            if (transaction is NoTransaction)
                            {
                                ct.TaskCompletionSource.SetException(new InvalidOperationException("No active transaction"));
                                break;
                            }
                            var commitRequest = new EndTxnRequest(
                                ct.TransactionId,
                                producerId,
                                producerEpoch,
                                true
                            );
                            var commitResponse = await HandleRequest(
                                commitRequest,
                                EndTxnRequestSerde.Write,
                                EndTxnResponseSerde.Read,
                                cancellationToken
                            );
                            if (commitResponse.ErrorCodeField != 0)
                            {
                                var error = Errors.Translate(commitResponse.ErrorCodeField);
                                ct.TaskCompletionSource.SetException(new ApiException(error));
                            }
                            else
                            {
                                ct.TaskCompletionSource.SetResult(transaction);
                                transaction = NoTransaction.Instance;
                            }
                            break;
                        case RollbackTransactionCommand rt:
                            if (transaction is NoTransaction)
                            {
                                rt.TaskCompletionSource.SetException(new InvalidOperationException("No active transaction"));
                                break;
                            }
                            var rollbackRequest = new EndTxnRequest(
                                rt.TransactionId,
                                producerId,
                                producerEpoch,
                                false
                            );
                            var rollbackResponse = await HandleRequest(
                                rollbackRequest,
                                EndTxnRequestSerde.Write,
                                EndTxnResponseSerde.Read,
                                cancellationToken
                            );
                            if (rollbackResponse.ErrorCodeField != 0)
                            {
                                var error = Errors.Translate(rollbackResponse.ErrorCodeField);
                                rt.TaskCompletionSource.SetException(new ApiException(error));
                            }
                            else
                            {
                                rt.TaskCompletionSource.SetResult(transaction);
                                transaction = NoTransaction.Instance;
                            }
                            break;
                        default:
                            throw new NotSupportedException($"Unsupported Command: {dispatchCommand}");
                    }
                }
            }
            catch (OperationCanceledException) { }
        }

        private static ImmutableSortedDictionary<TopicPartition, ImmutableArray<ProduceCommand<TKey, TValue>>> CreateTopicPartitionTree(
            ImmutableArray<ProduceCommand<TKey, TValue>> dispatchItems
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
            Transaction transaction,
            ImmutableSortedDictionary<TopicPartition, ImmutableArray<ProduceCommand<TKey, TValue>>> topicPartitions,
            short acks,
            int requestTimeoutMs,
            long producerId,
            short producerEpoch,
            string? transactionId,
            Func<int, int> sequencer,
            CancellationToken cancellationToken
        )
        {
            var tasks = ImmutableArray.CreateBuilder<Task>(topicPartitions.Count);
            foreach (var topicPartition in topicPartitions)
            {
                var batchSize = 0;
                var attributes = Attributes.None | transaction.TxnAttributes;
                var minTimestamp = long.MaxValue;
                var maxTimestamp = long.MinValue;
                foreach (var x in topicPartition.Value)
                {
                    minTimestamp = Math.Min(minTimestamp, x.Timestamp.TimestampMs);
                    maxTimestamp = Math.Max(maxTimestamp, x.Timestamp.TimestampMs);
                }
                (var sizeDelta, var recordList) = BuildRecordArray(topicPartition.Value, minTimestamp);
                batchSize += sizeDelta;
                var records = new RecordBatch(
                    BaseOffset: 0,
                    BatchLength: batchSize,
                    PartitionLeaderEpoch: 0,
                    Magic: 2,
                    Crc: 0, // Crc computation deferred to encoder.
                    attributes,
                    LastOffsetDelta: recordList.Length - 1,
                    BaseTimestamp: minTimestamp,
                    MaxTimestamp: maxTimestamp,
                    ProducerId: producerId,
                    ProducerEpoch: producerEpoch,
                    BaseSequence: sequencer(recordList.Length),
                    recordList
                );
                var recordBatchesBuilder = ImmutableArray.CreateBuilder<IRecords>(1);
                recordBatchesBuilder.Add(records);
                tasks.Add(
                    HandleRecordSend(
                        transaction,
                        topicPartition.Key,
                        recordBatchesBuilder.ToImmutableArray(),
                        topicPartition.Value,
                        acks,
                        requestTimeoutMs,
                        transactionId,
                        cancellationToken
                    )
                );
            }
            return tasks.ToImmutable();
        }

        //private static ImmutableArray<Task> CreateTopicPartitionSends()

        private static (int SizeDelta, ImmutableArray<IRecord> Records) BuildRecordArray(ImmutableArray<ProduceCommand<TKey, TValue>> value, long minTimestampMs)
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
            Transaction transaction,
            TopicPartition topicPartition,
            ImmutableArray<IRecords> records,
            ImmutableArray<ProduceCommand<TKey, TValue>> produceCallbacks,
            short acks,
            int requestTimeOutMs,
            string? transactionId,
            CancellationToken cancellationToken
        )
        {
            var request = new ProduceRequest(
                transactionId,
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
                request with { MaxVersion = 7 },
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
                        transaction.InrementBaseSequence(topicPartition, produceCallbacks.Length);
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
        private static int EstimateRecordSize(ProduceCommand<TKey, TValue> produceCallback) =>
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

        protected override async ValueTask OnClose(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            await Task.WhenAll(_recordsAccumulatorTask, _recordsBuilderTask);
        }

        Task<ITransaction> IProducer<TKey, TValue>.BeginTransaction(CancellationToken cancellationToken)
        {
            var beginTransactionCommand = new BeginTransactionCommand(new TaskCompletionSource<ITransaction>());
            _commandQueue.Add(beginTransactionCommand, cancellationToken);
            return beginTransactionCommand.TaskCompletionSource.Task;
        }

        private abstract class Transaction :
            ITransaction
        {
            protected Transaction(string transactionId)
            {
                TransactionId = transactionId;
            }
            public string TransactionId { get; init; }
            public abstract TxnState TxnState { get; }
            internal abstract Attributes TxnAttributes { get; }
            public abstract Task Commit(CancellationToken cancellationToken);
            public abstract Task Rollback(CancellationToken cancellationToken);
            internal abstract long GetBaseSequence(TopicPartition topicPartition);
            internal abstract void InrementBaseSequence(TopicPartition topicPartition, long count);
            internal abstract IEnumerable<TopicPartition> AddTopicPartitions(IEnumerable<TopicPartition> topicPartitions);
        }

        private sealed class ActiveTransaction :
            Transaction
        {
            private readonly TxnState _txnState = TxnState.Active;
            private readonly object _guard = new();
            private readonly Dictionary<TopicPartition, long> _topicPartitionsBaseSequence = new();
            private readonly BlockingCollection<IProducerCommand> _commandQueue;
            public ActiveTransaction(string transactionId, BlockingCollection<IProducerCommand> commandQueue)
                : base(transactionId)
            {
                _commandQueue = commandQueue;
            }

            public override TxnState TxnState => throw new NotImplementedException();
            internal override Attributes TxnAttributes => Attributes.IsTransactional;
            public override Task Commit(CancellationToken cancellationToken)
            {
                lock (_guard)
                {
                    if (_txnState != TxnState.Active)
                        throw new InvalidOperationException($"Invalid Transaction state: {_txnState}");
                    var command = new CommitTransactionCommand(TransactionId, new TaskCompletionSource<ITransaction>());
                    _commandQueue.Add(command, cancellationToken);
                    return command.TaskCompletionSource.Task;
                }
            }
            public override Task Rollback(CancellationToken cancellationToken)
            {
                lock (_guard)
                {
                    if (_txnState != TxnState.Active)
                        throw new InvalidOperationException($"Invalid Transaction state: {_txnState}");
                    var command = new RollbackTransactionCommand(TransactionId, new TaskCompletionSource<ITransaction>());
                    _commandQueue.Add(command, cancellationToken);
                    return command.TaskCompletionSource.Task;
                }
            }
            internal override IEnumerable<TopicPartition> AddTopicPartitions(IEnumerable<TopicPartition> topicPartitions)
            {
                var newTopicPartitions = new List<TopicPartition>();
                foreach (var topicPartition in topicPartitions)
                {
                    if (!_topicPartitionsBaseSequence.ContainsKey(topicPartition))
                    {
                        _topicPartitionsBaseSequence.Add(topicPartition, Offset.Zero);
                        newTopicPartitions.Add(topicPartition);
                    }
                }
                return newTopicPartitions;
            }

            internal override long GetBaseSequence(TopicPartition topicPartition) =>
                _topicPartitionsBaseSequence[topicPartition]
            ;

            internal override void InrementBaseSequence(TopicPartition topicPartition, long count) =>
                _topicPartitionsBaseSequence[topicPartition] += count
            ;
        }

        private sealed class NoTransaction :
            Transaction
        {
            public static Transaction Instance { get; } = new NoTransaction();

            public override TxnState TxnState => TxnState.None;
            internal override Attributes TxnAttributes => Attributes.None;
            private NoTransaction()
                : base("") { }
            public override Task Commit(CancellationToken cancellationToken) =>
                Task.CompletedTask
            ;
            public override Task Rollback(CancellationToken cancellationToken) =>
                Task.CompletedTask
            ;
            internal override IEnumerable<TopicPartition> AddTopicPartitions(IEnumerable<TopicPartition> topicPartitions) =>
                Enumerable.Empty<TopicPartition>()
            ;

            internal override long GetBaseSequence(TopicPartition topicPartition) =>
                0
            ;

            internal override void InrementBaseSequence(TopicPartition topicPartition, long count) { }
        }
    }
}