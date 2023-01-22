using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Clients.Producer.Model.Internal;
using Kafka.Client.Messages;
using Kafka.Common;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Protocol;
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
    internal sealed class ProducerClient<TKey, TValue> :
        Client<IProducer<TKey, TValue>, ProducerConfig>,
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

        public ProducerClient(
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

        Task<ITransaction> IProducer<TKey, TValue>.BeginTransaction(CancellationToken cancellationToken)
        {
            var beginTransactionCommand = new BeginTransactionCommand(new TaskCompletionSource<ITransaction>());
            _commandQueue.Add(beginTransactionCommand, cancellationToken);
            return beginTransactionCommand.TaskCompletionSource.Task;
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

        public async Task RunDispatch(
            CancellationToken cancellationToken
        )
        {
            try
            {
                var runtime = await InitRuntime(
                    _config,
                    _logger,
                    cancellationToken
                );
                while (!cancellationToken.IsCancellationRequested)
                {
                    var command = _executeQueue.Take(cancellationToken);
                    await HandleCommand(
                        command,
                        runtime,
                        cancellationToken
                    );
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                _logger.LogCritical("{ex}", ex);
            }
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

        private static TopicState CreateTopicState(MetadataResponse.MetadataResponseTopic topic)
        {
            string topicName = topic.NameField ?? "";
            long lastRefeshedMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var partitionStates = topic
                .PartitionsField
                .OrderBy(p => p.PartitionIndexField)
                .Select(p =>
                    CreatePartitionState(p)
                )
                .ToArray()
            ;
            return new(topicName, lastRefeshedMs, partitionStates);
        }

        private static PartitionState CreatePartitionState(MetadataResponse.MetadataResponseTopic.MetadataResponsePartition partition)
        {
            int partitionIndex = partition.PartitionIndexField;
            var partitionLeader = partition.LeaderIdField;
            return new PartitionState(
                partitionIndex,
                partitionLeader,
                0
            );
        }

        private static async ValueTask<(long ProducerId, short ProducerEpoch)> GetProducerInstance(
            IConnection connection,
            string transactionalId,
            int transactionTimeoutMs,
            long producerId,
            short producerEpoch,
            CancellationToken cancellationToken
        )
        {
            var initProducerIdRequest = new InitProducerIdRequest(
                transactionalId,
                transactionTimeoutMs,
                producerId,
                producerEpoch
            );
            var initProducerIdResponse = await connection.ExecuteRequest(
                initProducerIdRequest,
                InitProducerIdRequestSerde.Write,
                InitProducerIdResponseSerde.Read,
                cancellationToken
            );
            return (
                initProducerIdResponse.ProducerIdField,
                initProducerIdResponse.ProducerEpochField
            );
        }

        /// <summary>
        /// Terminates commands that target unavailable topics and returns remaining valid ones, possibly empty.
        /// </summary>
        /// <param name="produceCommandBatch"></param>
        /// <param name="errorTopics"></param>
        /// <returns></returns>
        private static ProduceCommandBatch<TKey, TValue> TerminateErrorCommands(
            ProduceCommandBatch<TKey, TValue> produceCommandBatch,
            ImmutableSortedDictionary<TopicName, Error> errorTopics
        )
        {
            var newProduceCommands = ImmutableArray.CreateBuilder<ProduceCommand<TKey, TValue>>();
            foreach (var produceCommand in produceCommandBatch.ProduceCommands)
                if (errorTopics.TryGetValue(produceCommand.Topic, out var error))
                    produceCommand.TaskCompletionSource.SetResult(
                        new ProduceResult<TKey, TValue>(
                            new TopicPartitionOffset(new TopicPartition(produceCommand.Topic, Partition.Unassigned), Offset.Unset),
                            produceCommand.Timestamp,
                            error,
                            ""
                        )
                    );
                else
                    newProduceCommands.Add(produceCommand);
            return new(newProduceCommands.ToImmutable());
        }

        private sealed class RuntimeConfigurations
        {
            public RuntimeConfigurations(
                short acks,
                int requestTimeoutMs,
                long producerId,
                short producerEpoch,
                string transactionalId,
                int transactionTimeoutMs,
                bool enableIdempotence,
                SortedList<TopicName, TopicState> topicStates,
                Transaction transaction,
                ImmutableSortedDictionary<ClusterNodeId, IConnection> brokerConnections,
                IConnection controllerConnection
            )
            {
                Acks = acks;
                RequestTimeoutMs = requestTimeoutMs;
                ProducerId = producerId;
                ProducerEpoch = producerEpoch;
                TransactionalId = transactionalId;
                TransactionTimeoutMs = transactionTimeoutMs;
                EnableIdempotence = enableIdempotence;
                BrokerConnections = brokerConnections;
                ControllerConnection = controllerConnection;
                TopicStates = topicStates;
                Transaction = transaction;
                BrokerConnections = brokerConnections;
                ControllerConnection = controllerConnection;
            }
            public short Acks { get; set; }
            public int RequestTimeoutMs { get; set; }
            public long ProducerId { get; set; }
            public short ProducerEpoch { get; set; }
            public string TransactionalId { get; set; }
            public int TransactionTimeoutMs { get; set; }
            public bool EnableIdempotence { get; set; }
            public SortedList<TopicName, TopicState> TopicStates { get; set; }
            public Transaction Transaction { get; set; }
            public ImmutableSortedDictionary<ClusterNodeId, IConnection> BrokerConnections { get; set; }
            public IConnection ControllerConnection { get; set; }
        }

        private async ValueTask<RuntimeConfigurations> InitRuntime(
            ProducerConfig producerConfig,
            ILogger logger,
            CancellationToken cancellationToken
        )
        {
            var acks = ParseAcks(producerConfig, logger);
            var requestTimeoutMs = producerConfig.RequestTimeoutMs;
            var producerId = -1L;
            var producerEpoch = (short)-1;
            var transactionalId = producerConfig.TransactionalId ?? "";
            var transactionTimeoutMs = producerConfig.TransactionTimeoutMs;
            var enableIdempotence = producerConfig.EnableIdempotence || transactionalId != "";

            var brokerConnections = await _connectionPool.AquireBrokerConnections(cancellationToken);
            var controllerConnection = brokerConnections.Values.First();

            if (transactionalId != "")
                (controllerConnection, _) = await GetCoordinator(
                    brokerConnections,
                    transactionalId,
                    CoordinatorType.TRANSACTION,
                    cancellationToken
                );

            if (enableIdempotence)
                (producerId, producerEpoch) = await GetProducerInstance(
                    controllerConnection,
                    transactionalId,
                    transactionTimeoutMs,
                    producerId,
                    producerEpoch,
                    cancellationToken
                );

            return new RuntimeConfigurations(
                acks,
                requestTimeoutMs,
                producerId,
                producerEpoch,
                transactionalId,
                transactionTimeoutMs,
                enableIdempotence,
                new SortedList<TopicName, TopicState>(TopicNameCompare.Instance),
                NoTransaction.Instance,
                brokerConnections,
                controllerConnection
            );
        }

        private async ValueTask HandleCommand(
            IProducerCommand command,
            RuntimeConfigurations runtime,
            CancellationToken cancellationToken
        )
        {
            switch (command)
            {
                case ProduceCommandBatch<TKey, TValue> produceCommandBatch:
                    _logger.LogTrace("Record Builder dequeued {count} records", produceCommandBatch.ProduceCommands.Length);
                    await HandleProduceCommandBatch(
                        produceCommandBatch,
                        runtime,
                        cancellationToken
                    );
                    break;
                case BeginTransactionCommand beginTransactionCommand:
                    HandleBeginTransaction(
                        beginTransactionCommand,
                        runtime,
                        _commandQueue
                    );
                    break;
                case CommitTransactionCommand commitTransactionCommand:
                    await HandleCommitTransaction(
                        commitTransactionCommand,
                        runtime,
                        cancellationToken
                    );
                    break;
                case RollbackTransactionCommand rollbackTransactionCommand:
                    await HandleRollbackTransaction(
                        rollbackTransactionCommand,
                        runtime,
                        cancellationToken
                    );
                    break;
                default:
                    throw new NotSupportedException($"Unsupported Command: {command}");
            }
        }

        private async ValueTask HandleProduceCommandBatch(
            ProduceCommandBatch<TKey, TValue> produceCommandBatch,
            RuntimeConfigurations runtime,
            CancellationToken cancellationToken
        )
        {
            var errorTopics = await CheckTopicState(
                runtime.TopicStates,
                produceCommandBatch,
                runtime.ControllerConnection,
                cancellationToken
            );
            if (errorTopics.Count > 0)
            {
                produceCommandBatch = TerminateErrorCommands(produceCommandBatch, errorTopics);
                if (produceCommandBatch.ProduceCommands.Length == 0)
                    return;
            }

            var groupedProduceCommands = await PartitionProduceCommands(
                produceCommandBatch,
                runtime,
                cancellationToken
            );

            await UpdateTransactions(
                groupedProduceCommands,
                runtime,
                cancellationToken
            );

            var tasks = CreateTopicPartitionSends(
                groupedProduceCommands,
                runtime,
                cancellationToken
            );
            await Task.WhenAll(tasks);
        }

        private static void HandleBeginTransaction(
            BeginTransactionCommand beginTransactionCommand,
            RuntimeConfigurations runtime,
            BlockingCollection<IProducerCommand> commandQueue
        )
        {
            switch (runtime.Transaction, runtime.TransactionalId)
            {
                case (ActiveTransaction, _):
                    beginTransactionCommand.TaskCompletionSource.SetException(new InvalidOperationException("Active transaction in progress"));
                    break;
                case (_, ""):
                    beginTransactionCommand.TaskCompletionSource.SetException(new InvalidOperationException("transaction.id is not initialized"));
                    break;
                default:
                    runtime.Transaction = new ActiveTransaction(runtime.TransactionalId, commandQueue);
                    beginTransactionCommand.TaskCompletionSource.SetResult(runtime.Transaction);
                    break;
            }
        }

        private static async ValueTask HandleCommitTransaction(
            CommitTransactionCommand commitTransactionCommand,
            RuntimeConfigurations runtime,
            CancellationToken cancellationToken
        )
        {
            if (runtime.Transaction is NoTransaction)
            {
                commitTransactionCommand.TaskCompletionSource.SetException(new InvalidOperationException("No active transaction"));
                return;
            }
            var commitRequest = new EndTxnRequest(
                commitTransactionCommand.TransactionId,
                runtime.ProducerId,
                runtime.ProducerEpoch,
                true
            );
            var commitResponse = await runtime.ControllerConnection.ExecuteRequest(
                commitRequest,
                EndTxnRequestSerde.Write,
                EndTxnResponseSerde.Read,
                cancellationToken
            );
            if (commitResponse.ErrorCodeField != 0)
            {
                var error = Errors.Translate(commitResponse.ErrorCodeField);
                commitTransactionCommand.TaskCompletionSource.SetException(new ApiException(error));
            }
            else
            {
                commitTransactionCommand.TaskCompletionSource.SetResult(runtime.Transaction);
                runtime.Transaction = NoTransaction.Instance;
            }
        }

        private static async ValueTask HandleRollbackTransaction(
            RollbackTransactionCommand rollbackTransactionCommand,
            RuntimeConfigurations runtime,
            CancellationToken cancellationToken
        )
        {
            if (runtime.Transaction is NoTransaction)
            {
                rollbackTransactionCommand.TaskCompletionSource.SetException(new InvalidOperationException("No active transaction"));
                return;
            }
            var rollbackRequest = new EndTxnRequest(
                rollbackTransactionCommand.TransactionId,
                runtime.ProducerId,
                runtime.ProducerEpoch,
                false
            );
            var rollbackResponse = await runtime.ControllerConnection.ExecuteRequest(
                rollbackRequest,
                EndTxnRequestSerde.Write,
                EndTxnResponseSerde.Read,
                cancellationToken
            );
            if (rollbackResponse.ErrorCodeField != 0)
            {
                var error = Errors.Translate(rollbackResponse.ErrorCodeField);
                rollbackTransactionCommand.TaskCompletionSource.SetException(new ApiException(error));
            }
            else
            {
                rollbackTransactionCommand.TaskCompletionSource.SetResult(runtime.Transaction);
                runtime.Transaction = NoTransaction.Instance;
            }
        }

        private async ValueTask<IDictionary<ClusterNodeId, IDictionary<TopicName, IDictionary<Partition, (PartitionState PartitionState, IList<ProduceCommand<TKey, TValue>> Commands)>>>> PartitionProduceCommands(
            ProduceCommandBatch<TKey, TValue> produceCommandBatch,
            RuntimeConfigurations runtime,
            CancellationToken cancellationToken
        )
        {
            var assignedCommands = new Dictionary<ClusterNodeId, IDictionary<TopicName, IDictionary<Partition, (PartitionState PartitionState, IList<ProduceCommand<TKey, TValue>> Commands)>>>();
            foreach (var produceCommand in produceCommandBatch.ProduceCommands)
            {
                var topicState = runtime.TopicStates[produceCommand.Topic];
                var partition = produceCommand.Partition;
                if (partition == Partition.Unassigned)
                    partition = await _partitioner.Select(produceCommand.Topic, topicState.PartitionStates.Length, produceCommand.Key, cancellationToken);
                var partitionState = topicState.PartitionStates[partition];
                var clusterNodeId = partitionState.PartitionLeader;
                if (!assignedCommands.TryGetValue(clusterNodeId, out var clusterCommands))
                {
                    clusterCommands = new Dictionary<TopicName, IDictionary<Partition, (PartitionState PartitionState, IList<ProduceCommand<TKey, TValue>> Commands)>>();
                    assignedCommands.Add(clusterNodeId, clusterCommands);
                }
                if (!clusterCommands.TryGetValue(produceCommand.Topic, out var topicCommands))
                {
                    topicCommands = new Dictionary<Partition, (PartitionState PartitionState, IList<ProduceCommand<TKey, TValue>> Commands)>();
                    clusterCommands.Add(produceCommand.Topic, topicCommands);
                }
                if (!topicCommands.TryGetValue(partition, out var partitionCommands))
                {
                    var partitionCommandList = new List<ProduceCommand<TKey, TValue>>();
                    partitionCommands = (partitionState, partitionCommandList);
                    topicCommands.Add(partition, partitionCommands);
                }
                partitionCommands.Commands.Add(produceCommand);
            }
            return assignedCommands;
        }

        /// <summary>
        /// Checks if topic is known, if not it attempts to read metadata from brokers.
        /// The function returns a list of topics that either do not exist or are in an erroneus state.
        /// </summary>
        /// <param name="topicStates"></param>
        /// <param name="produceCommandBatch"></param>
        /// <param name="connection"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private static async ValueTask<ImmutableSortedDictionary<TopicName, Error>> CheckTopicState(
            SortedList<TopicName, TopicState> topicStates,
            ProduceCommandBatch<TKey, TValue> produceCommandBatch,
            IConnection connection,
            CancellationToken cancellationToken
        )
        {
            var newtopics = 0;
            foreach (var ProduceCommand in produceCommandBatch.ProduceCommands)
                if (!topicStates.ContainsKey(ProduceCommand.Topic))
                    newtopics++;
            if (newtopics == 0)
                return ImmutableSortedDictionary<TopicName, Error>.Empty;
            else
                return await UpdateTopicState(
                    topicStates,
                    produceCommandBatch,
                    connection,
                    cancellationToken
                );
        }

        private static async ValueTask<ImmutableSortedDictionary<TopicName, Error>> UpdateTopicState(
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
            var notFound = 0;
            foreach (var topic in metadataResponse.TopicsField)
                if (topic.ErrorCodeField == 0)
                    topicStates[topic.NameField] = CreateTopicState(topic);
                else
                    notFound++;
            if (notFound > 0)
                return metadataResponse
                    .TopicsField
                    .Where(r => r.ErrorCodeField != 0)
                    .ToImmutableSortedDictionary(
                        k => new TopicName(k.NameField),
                        v => Errors.Translate(v.ErrorCodeField),
                        TopicNameCompare.Instance
                    )
                ;
            return ImmutableSortedDictionary<TopicName, Error>.Empty;
        }

        private async ValueTask UpdateTransactions(
            IDictionary<ClusterNodeId, IDictionary<TopicName, IDictionary<Partition, (PartitionState PartitionState, IList<ProduceCommand<TKey, TValue>> Commands)>>> assignedCommands,
            RuntimeConfigurations runtime,
            CancellationToken cancellationToken
        )
        {
            if (runtime.Transaction is not ActiveTransaction activeTransaction)
                return;
            var newTopicPartitions = activeTransaction.AddTopicPartitions(
                assignedCommands
                .SelectMany(c => c.Value
                    .SelectMany(t => t.Value.Keys
                        .Select(p => new TopicPartition(t.Key, p))
                    )
                )
            );
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
                    runtime.ProducerId,
                    runtime.ProducerEpoch,
                    addPartitionsToTxnTopic
                );
                var addPartitionsToTxnResponse = await runtime.ControllerConnection.ExecuteRequest(
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

        private static ImmutableArray<Task> CreateTopicPartitionSends(
            IDictionary<ClusterNodeId, IDictionary<TopicName, IDictionary<Partition, (PartitionState PartitionState, IList<ProduceCommand<TKey, TValue>> Commands)>>> assignedCommands,
            RuntimeConfigurations runtime,
            CancellationToken cancellationToken
        )
        {
            var tasks = ImmutableArray.CreateBuilder<Task>();
            foreach ((var nodeId, var groupedCommands) in assignedCommands)
            {
                var topicProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequest.TopicProduceData>();
                foreach ((var topic, var partitions) in groupedCommands)
                {
                    var partitionProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequest.TopicProduceData.PartitionProduceData>();
                    foreach ((var partition, (var partitionState, var commands)) in partitions)
                    {
                        var batchSize = 0;
                        var attributes = Attributes.None;
                        var minTimestamp = long.MaxValue;
                        var maxTimestamp = long.MinValue;
                        if (runtime.Transaction.TxnState == TxnState.Active)
                            attributes |= Attributes.IsTransactional;
                        foreach (var x in commands)
                        {
                            minTimestamp = Math.Min(minTimestamp, x.Timestamp.TimestampMs);
                            maxTimestamp = Math.Max(maxTimestamp, x.Timestamp.TimestampMs);
                        }
                        (var sizeDelta, var recordList) = BuildRecordArray(commands, minTimestamp);
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
                            ProducerId: runtime.ProducerId,
                            ProducerEpoch: runtime.ProducerEpoch,
                            BaseSequence: partitionState.BaseSequence,
                            recordList
                        );
                        partitionState.BaseSequence += recordList.Length;
                        var recordBatchesBuilder = ImmutableArray.CreateBuilder<IRecords>(1);
                        recordBatchesBuilder.Add(records);
                        partitionProduceDataBuilder.Add(
                            new(
                                partition,
                                recordBatchesBuilder.ToImmutable()
                            )
                        );
                    }
                    topicProduceDataBuilder.Add(
                        new(
                            topic,
                            partitionProduceDataBuilder.ToImmutable()
                        )
                    );
                }
                var request = new ProduceRequest(
                    runtime.TransactionalId,
                    runtime.Acks,
                    runtime.RequestTimeoutMs,
                    topicProduceDataBuilder.ToImmutable()
                );

                var connection = runtime.BrokerConnections[nodeId];
                tasks.Add(
                    HandleRecordSend(
                        connection,
                        request,
                        groupedCommands,
                        runtime,
                        cancellationToken
                    )
                );
            }
            return tasks.ToImmutable();
        }

        private static (int SizeDelta, ImmutableArray<IRecord> Records) BuildRecordArray(
            IEnumerable<ProduceCommand<TKey, TValue>> produceCommands,
            long minTimestampMs
        )
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
                sizeDelta += record.Length;
                sizeDelta += Encoder.SizeOfInt32(record.Length);
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

        private readonly record struct SendResult<TResponse>(
            TResponse? Response,
            Exception? Exception
        ) where TResponse : notnull, Response;

        private static async Task HandleRecordSend(
            IConnection connection,
            ProduceRequest request,
            IDictionary<TopicName, IDictionary<Partition, (PartitionState PartitionState, IList<ProduceCommand<TKey, TValue>> Commands)>> commands,
            RuntimeConfigurations runtime,
            CancellationToken cancellationToken
        )
        {
            var respose = default(ProduceResponse);
            try
            {
                respose = await connection.ExecuteRequest(
                    request with { MaxVersion = 7 },
                    ProduceRequestSerde.Write,
                    ProduceResponseSerde.Read,
                    cancellationToken
                );
            }
            catch (Exception ex)
            {
                foreach (var command in commands.SelectMany(r => r.Value.SelectMany(r => r.Value.Commands)))
                    command.TaskCompletionSource.SetException(ex);
                return;
            }

            foreach (var topicResponse in respose.ResponsesField)
            {
                var topicName = new TopicName(topicResponse.NameField);
                var topicCommands = commands[topicName];
                foreach (var partitionResponse in topicResponse.PartitionResponsesField)
                {
                    var partition = new Partition(partitionResponse.IndexField);
                    (var _, var partitionCommands) = topicCommands[partition];
                    var topicPartition = new TopicPartition(topicName, partition);
                    var offset = partitionResponse.BaseOffsetField;
                    var timestamp = Timestamp.LogAppend(partitionResponse.LogAppendTimeMsField);
                    var error = Errors.Known.NONE;
                    if (partitionResponse.ErrorCodeField == 0)
                    {
                        foreach (var produceCommand in partitionCommands)
                        {
                            var topicPartitionOffset = new TopicPartitionOffset(topicPartition, new Offset(offset++));
                            produceCommand.TaskCompletionSource.SetResult(
                                new ProduceResult<TKey, TValue>(
                                    topicPartitionOffset,
                                    timestamp,
                                    error,
                                    ""
                                )
                            );
                        }
                        runtime.Transaction.InrementBaseSequence(topicPartition, partitionCommands.Count);
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
                    for (int i = 0; i < partitionCommands.Count; i++)
                    {
                        var topicPartitionOffset = new TopicPartitionOffset(topicPartition, Offset.Unset);
                        if (!recordErrors.TryGetValue(i, out var recordError))
                            recordError = "";
                        partitionCommands[i].TaskCompletionSource.SetResult(
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