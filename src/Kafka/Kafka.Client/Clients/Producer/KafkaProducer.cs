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
using System.Linq;
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
                var produceCallback = CreateProduceCommand(produceRecord);
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
            var produceCallback = CreateProduceCommand(produceRecord);
            _commandQueue.Add(produceCallback, cancellationToken);
            return await produceCallback.TaskCompletionSource.Task;
        }

        private ProduceCommand<TKey, TValue> CreateProduceCommand(
            ProduceRecord<TKey, TValue> produceRecord
        )
        {
            var keyBytes = _keySerializer.Write(produceRecord.Key);
            var valueBytes = _valueSerializer.Write(produceRecord.Value);
            var partition = produceRecord.Partition;
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
                var carryOver = default(ProduceCommand<TKey, TValue>);
                while (!cancellationToken.IsCancellationRequested)
                {
                    // Pack batch and return overflow if any,
                    (var collectExitReason, var batch, carryOver, var controlCommand) = Collect(
                        _commandQueue,
                        carryOver,
                        maxInFlightRequestsPerConnection,
                        maxrequestSize,
                        lingerTime,
                        cancellationToken
                    );
                    _logger.LogTrace("Collect reason: {reason}, count: {count}, carryOver: {carryOver}, controlCommand: {controlCommand}", collectExitReason, batch.Length, carryOver != null, controlCommand?.GetType().Name ?? "(none)");
                    if (batch.Length > 0)
                        _executeQueue.Add(new ProduceCommandBatch<TKey, TValue>(batch), CancellationToken.None);
                    if (controlCommand != null)
                        _executeQueue.Add(controlCommand, CancellationToken.None);
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
        private static BatchCollectResult<TKey, TValue> Collect(
            BlockingCollection<IProducerCommand> commandQueue,
            ProduceCommand<TKey, TValue>? carryOver,
            int maxInFlightRequestsPerConnection,
            int maxRequestSize,
            TimeSpan lingerTime,
            CancellationToken cancellationToken
        )
        {
            var batchBuilder = ImmutableArray.CreateBuilder<ProduceCommand<TKey, TValue>>(maxInFlightRequestsPerConnection);
            var fetchedSize = 0;
            if (carryOver != null)
            {
                batchBuilder.Add(carryOver);
                if (maxInFlightRequestsPerConnection == 1)
                    return new(BatchCollectReason.MaxInFlightReached, batchBuilder.ToImmutable(), default, default);
                fetchedSize += EstimateRecordSize(carryOver);
            }
            var command = commandQueue.Take(cancellationToken);
            using var localCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            localCts.CancelAfter(lingerTime);
            do
            {
                try
                {
                    switch (command)
                    {
                        case ProduceCommand<TKey, TValue> produceCommand:
                            if (batchBuilder.Count >= maxInFlightRequestsPerConnection)
                                return new(BatchCollectReason.MaxInFlightReached, batchBuilder.ToImmutable(), produceCommand, default);
                            fetchedSize += EstimateRecordSize(produceCommand);
                            if (fetchedSize >= maxRequestSize)
                                return new(BatchCollectReason.MaxSizeExceeded, batchBuilder.ToImmutable(), produceCommand, default);
                            batchBuilder.Add(produceCommand);
                            break;
                        default:
                            return new(BatchCollectReason.ControlCommandIssued, batchBuilder.ToImmutable(), default, command);
                    }
                    command = commandQueue.Take(localCts.Token);
                }
                catch (OperationCanceledException) { }
            }
            while (!localCts.IsCancellationRequested);
            return new(BatchCollectReason.MaxLingerMsReached, batchBuilder.ToImmutable(), default, default);
        }

        private sealed class TopicState
        {
            public TopicState(
                string topicName,
                long lastRefreshedMs,
                PartitionState[] partitionStates
            )
            {
                TopicName = topicName;
                LastRefreshedMs = lastRefreshedMs;
                PartitionStates = partitionStates;
            }
            public string TopicName { get; init; }
            public long LastRefreshedMs { get; init; }
            public PartitionState[] PartitionStates { get; init; }
            public ClusterNodeId PartitionLeader { get; private set; }
            public static TopicState FromTopicMetadata(MetadataResponse.MetadataResponseTopic topic)
            {
                string topicName = topic.NameField ?? "";
                long lastRefeshedMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                var partitionStates = topic
                    .PartitionsField
                    .Select(p =>
                        PartitionState.FromPartitionMetadata(p)
                    )
                    .ToArray()
                ;
                return new(topicName, lastRefeshedMs, partitionStates);
            }
        }

        private sealed class PartitionState
        {
            private int _baseSequence = -1;
            private PartitionState() { }
            public int PartitionIndex { get; init; }
            public int PartitionLeader { get; init; }
            public int NextBaseSequence() =>
                Interlocked.Increment(ref _baseSequence)
            ;
            public static PartitionState FromPartitionMetadata(MetadataResponse.MetadataResponseTopic.MetadataResponsePartition partition)
            {
                int partitionIndex = partition.PartitionIndexField;
                var partitionLeader = partition.LeaderIdField;
                return new PartitionState
                {
                    PartitionIndex = partitionIndex,
                    PartitionLeader = partitionLeader,
                };
            }
        }

        public async Task RunDispatch(
            CancellationToken cancellationToken
        )
        {
            var topicStates = new SortedList<TopicName, TopicState>(TopicNameCompare.Instance);


            var acks = ParseAcks(_config, _logger);
            var requestTimeoutMs = _config.RequestTimeoutMs;
            var enableIdempotence = _config.EnableIdempotence;
            var producerId = -1L;
            var producerEpoch = (short)-1;
            var partitionSequences = new SortedList<TopicPartition, int>(TopicPartitionCompare.Instance);
            var sequencer = new Func<TopicPartition, IDictionary<TopicPartition, int>, int>((t, p) => 0);
            var transactionalId = _config.TransactionalId;
            var transactionTimeoutMs = -1;

            if (!string.IsNullOrEmpty(_config.TransactionalId))
            {
                enableIdempotence = true;
                transactionTimeoutMs = _config.TransactionTimeoutMs;
            }

            try
            {
                var brokerConnections = await _connectionPool.AquireBrokerConnections(cancellationToken);
                var controllerConnection = brokerConnections.Values.First();
                if (!string.IsNullOrEmpty(transactionalId))
                {
                    var findCoordinatorRequest = new FindCoordinatorRequest(
                        transactionalId,
                        (sbyte)CoordinatorType.TRANSACTION,
                        new[] { transactionalId }.ToImmutableArray()
                    );
                    var findCoordinatorResponse = await controllerConnection.ExecuteRequest(
                        findCoordinatorRequest,
                        FindCoordinatorRequestSerde.Write,
                        FindCoordinatorResponseSerde.Read,
                        cancellationToken
                    );
                    var host = findCoordinatorResponse.HostField;
                    var port = findCoordinatorResponse.PortField;
                    if (string.IsNullOrEmpty(host))
                    {
                        host = findCoordinatorResponse.CoordinatorsField[0].HostField;
                        port = findCoordinatorResponse.CoordinatorsField[0].PortField;
                    }
                    controllerConnection = await _connectionPool.AquireConnection(host, port, cancellationToken);
                }
                if (enableIdempotence)
                {
                    var initProducerIdRequest = new InitProducerIdRequest(
                        transactionalId,
                        transactionTimeoutMs,
                        producerId,
                        producerEpoch
                    );
                    var initProducerIdResponse = await controllerConnection.ExecuteRequest(
                        initProducerIdRequest,
                        InitProducerIdRequestSerde.Write,
                        InitProducerIdResponseSerde.Read,
                        cancellationToken
                    );
                    producerId = initProducerIdResponse.ProducerIdField;
                    producerEpoch = initProducerIdResponse.ProducerEpochField;
                    sequencer = (t, p) =>
                    {
                        if (!p.TryGetValue(t, out var s))
                        {
                            p.Add(t, 0);
                            return 0;
                        }
                        else
                        {
                            s++;
                            p[t] = s;
                            return s;
                        }
                    };
                }
                var transaction = NoTransaction.Instance;
                while (!cancellationToken.IsCancellationRequested)
                {
                    var dispatchCommand = _executeQueue.Take(cancellationToken);
                    switch (dispatchCommand)
                    {
                        case ProduceCommandBatch<TKey, TValue> produceCommandBatch:
                            _logger.LogTrace("Record Builder dequeued {count} records", produceCommandBatch.ProduceCommands.Length);
                            await UpdateTopicState(
                                topicStates,
                                produceCommandBatch,
                                controllerConnection,
                                cancellationToken
                            );
                            var groupedProduceCommands = new Dictionary<TopicPartition, IList<ProduceCommand<TKey, TValue>>>();
                            foreach (var produceCommand in produceCommandBatch.ProduceCommands)
                                await AddProduceCommand(
                                    groupedProduceCommands,
                                    topicStates,
                                    _partitioner,
                                    produceCommand,
                                    cancellationToken
                                );

                            if (transaction is ActiveTransaction activeTransaction)
                                await UpdateTransactions(
                                    activeTransaction,
                                    producerId,
                                    producerEpoch,
                                    groupedProduceCommands.Keys,
                                    controllerConnection,
                                    _logger,
                                    cancellationToken
                                );
                            var tasks = CreateTopicPartitionSends(
                                brokerConnections,
                                topicStates,
                                groupedProduceCommands,
                                transaction,
                                acks,
                                requestTimeoutMs,
                                producerId,
                                producerEpoch,
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
                            var commitResponse = await controllerConnection.ExecuteRequest(
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
                            var rollbackResponse = await controllerConnection.ExecuteRequest(
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

        private static async ValueTask AddProduceCommand(
            IDictionary<TopicPartition, IList<ProduceCommand<TKey, TValue>>> topicPartitionList,
            IDictionary<TopicName, TopicState> topicStates,
            IPartitioner partitioner,
            ProduceCommand<TKey, TValue> produceCommand,
            CancellationToken cancellationToken
        )
        {
            var partition = produceCommand.Partition;
            if (partition == Partition.Unassigned)
                partition = await partitioner.Select(produceCommand.Topic, topicStates[produceCommand.Topic].PartitionStates.Length, produceCommand.Key, cancellationToken);
            var topicPartition = new TopicPartition(produceCommand.Topic, partition);
            if (!topicPartitionList.TryGetValue(topicPartition, out var commands))
            {
                commands = new List<ProduceCommand<TKey, TValue>>();
                topicPartitionList.Add(topicPartition, commands);
            }
            commands.Add(produceCommand);
        }

        private static async ValueTask UpdateTopicState(
            SortedList<TopicName, TopicState> topicStates,
            ProduceCommandBatch<TKey, TValue> produceCommandBatch,
            IConnection connection,
            CancellationToken cancellationToken
        )
        {
            var newTopics = produceCommandBatch
                .ProduceCommands
                .Select(r => r.Topic)
                .Distinct()
                .Except(topicStates.Keys)
            ;
            if (newTopics.Any())
            {
                var metadataRequest = new MetadataRequest(
                    newTopics.Select(r =>
                            new MetadataRequest.MetadataRequestTopic(Guid.Empty, r)
                    ).ToImmutableArray(),
                    false,
                    false,
                    false
                );
                var metadataResponse = await connection.ExecuteRequest(
                    metadataRequest,
                    MetadataRequestSerde.Write,
                    MetadataResponseSerde.Read,
                    cancellationToken
                );
                foreach (var topic in metadataResponse.TopicsField)
                    topicStates.Add(topic.NameField, TopicState.FromTopicMetadata(topic));
            }
        }

        private static async ValueTask UpdateTransactions(
            ITransaction transaction,
            long producerId,
            short producerEpoch,
            IEnumerable<TopicPartition> topicPartitions,
            IConnection connection,
            ILogger logger,
            CancellationToken cancellationToken
        )
        {
            if (transaction is ActiveTransaction activeTransaction)
            {
                var newTopicPartitions = activeTransaction.AddTopicPartitions(topicPartitions);
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
                    var addPartitionsToTxnResponse = await connection.ExecuteRequest(
                        addPartitionsToTxnRequest,
                        AddPartitionsToTxnRequestSerde.Write,
                        AddPartitionsToTxnResponseSerde.Read,
                        cancellationToken
                    );
                    foreach (var topicParitionResponse in addPartitionsToTxnResponse.ResultsField)
                        foreach (var paritionResponse in topicParitionResponse.ResultsField)
                            if (paritionResponse.ErrorCodeField != 0)
                                logger.LogWarning("Topic: {topic} - Error: {error}", topicParitionResponse.NameField, Errors.Translate(paritionResponse.ErrorCodeField).ToString());
                }
            }
        }

        private static ImmutableArray<Task> CreateTopicPartitionSends(
            ImmutableSortedDictionary<ClusterNodeId, IConnection> connections,
            IDictionary<TopicName, TopicState> topicStates,
            IDictionary<TopicPartition, IList<ProduceCommand<TKey, TValue>>> groupedProduceCommand,
            Transaction transaction,
            short acks,
            int requestTimeoutMs,
            long producerId,
            short producerEpoch,
            CancellationToken cancellationToken
        )
        {
            var tasks = ImmutableArray.CreateBuilder<Task>(groupedProduceCommand.Count);
            foreach (var topicPartition in groupedProduceCommand)
            {
                var partitionState = topicStates[topicPartition.Key.Topic].PartitionStates[topicPartition.Key.Partition];
                var batchSize = 0;
                var attributes = Attributes.None;
                var minTimestamp = long.MaxValue;
                var maxTimestamp = long.MinValue;
                if (transaction.TxnState == TxnState.Active)
                    attributes |= Attributes.IsTransactional;
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
                    BaseSequence: partitionState.NextBaseSequence(),
                    recordList
                );
                var recordBatchesBuilder = ImmutableArray.CreateBuilder<IRecords>(1);
                recordBatchesBuilder.Add(records);
                var connection = connections[partitionState.PartitionLeader];
                tasks.Add(
                    HandleRecordSend(
                        connection,
                        transaction,
                        topicPartition.Key,
                        recordBatchesBuilder.ToImmutableArray(),
                        topicPartition.Value,
                        acks,
                        requestTimeoutMs,
                        transaction.TransactionId,
                        cancellationToken
                    )
                );
            }
            return tasks.ToImmutable();
        }

        //private static ImmutableArray<Task> CreateTopicPartitionSends()

        private static (int SizeDelta, ImmutableArray<IRecord> Records) BuildRecordArray(IEnumerable<ProduceCommand<TKey, TValue>> produceCommands, long minTimestampMs)
        {
            var offsetDelta = 0;
            var sizeDelta = 0;
            var recordArrayBuilder = ImmutableArray.CreateBuilder<IRecord>();
            foreach (var produceCommand in produceCommands)
            {
                var callback = produceCommand;
                var timestampDelta = callback.Timestamp.TimestampMs - minTimestampMs;
                var record = CreateRecord(
                    timestampDelta,
                    offsetDelta++,
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

        private static async Task HandleRecordSend(
            IConnection connection,
            Transaction transaction,
            TopicPartition topicPartition,
            ImmutableArray<IRecords> records,
            IList<ProduceCommand<TKey, TValue>> produceCallbacks,
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
            var respose = await connection.ExecuteRequest(
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
                            var topicPartitionOffset = new TopicPartitionOffset(new(topicName, partition), offset++);
                            produceCallback.TaskCompletionSource.SetResult(
                                new ProduceResult<TKey, TValue>(
                                    topicPartitionOffset,
                                    timestamp,
                                    error,
                                    ""
                                )
                            );
                        }
                        transaction.InrementBaseSequence(topicPartition, produceCallbacks.Count);
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
                            var topicPartitionOffset = new TopicPartitionOffset(new(topicName, partition), offset++);
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

            public override TxnState TxnState => _txnState;
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