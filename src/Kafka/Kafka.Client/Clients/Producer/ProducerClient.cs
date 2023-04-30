using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Clients.Producer.Logging;
using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Clients.Producer.Model.Internal;
using Kafka.Client.Messages;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class ProducerClient<TKey, TValue> :
        Client<IProducer<TKey, TValue>, ProducerConfig>,
        IProducer<TKey, TValue>
    {
        private readonly ISerializer<TKey> _keySerializer;
        private readonly ISerializer<TValue> _valueSerializer;
        private readonly IPartitioner _partitioner;
        private readonly CancellationTokenSource _internalCts = new();
        private readonly SortedList<ClusterNodeId, IBrokerChannel> _brokerChannels = new(ClusterNodeIdCompare.Instance);
        private readonly SortedList<TopicName, ProducerTopicMetadata> _topicMetadata = new(TopicNameCompare.Instance);
        private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);
        private Attributes _attributes = Attributes.None;

        private RuntimeConfigurations? _runtimeConfigurations;

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
        }

        async Task<ProduceResult> IProducer<TKey, TValue>.Send(
            ProduceRecord<TKey, TValue> produceRecord,
            CancellationToken cancellationToken
        )
        {
            var runtimeConfigurations = await GetRuntimeConfigurations(cancellationToken);
            var topicMetadata = await GetTopicMetadata(produceRecord.Topic, runtimeConfigurations, cancellationToken);
            var request = await CreateProduceCommand(produceRecord, topicMetadata, cancellationToken);
            return await topicMetadata
                .PartitionMetadata[request.TopicPartition.Partition]
                .BrokerChannel
                .Send(request, cancellationToken)
            ;
        }

        private async ValueTask<RuntimeConfigurations> GetRuntimeConfigurations(CancellationToken cancellationToken)
        {
            if (_runtimeConfigurations != null)
                return _runtimeConfigurations;
            await _semaphoreSlim.WaitAsync(cancellationToken);
            try
            {
                // Did someone beat me to it check.
                if (_runtimeConfigurations != null)
                    return _runtimeConfigurations;
                _runtimeConfigurations = await InitRuntime(_config, _logger, cancellationToken);
                return _runtimeConfigurations;
            }
            finally { _semaphoreSlim.Release(); }
        }

        private async Task<ProducerTopicMetadata> GetTopicMetadata(
            TopicName topic,
            RuntimeConfigurations runtimeConfigurations,
            CancellationToken cancellationToken
        )
        {
            if (_topicMetadata.TryGetValue(topic, out var topicMetadata))
                return topicMetadata;
            await _semaphoreSlim.WaitAsync(cancellationToken);
            try
            {
                // Did someone beat me to it check
                if (_topicMetadata.TryGetValue(topic, out topicMetadata))
                    return topicMetadata;
                topicMetadata = await CreateTopicMetadata(topic, runtimeConfigurations, cancellationToken);
                _topicMetadata.Add(topic, topicMetadata);
                return topicMetadata;
            }
            finally { _semaphoreSlim.Release(); }
        }

        private async ValueTask<ProducerTopicMetadata> CreateTopicMetadata(
            TopicName topicName,
            RuntimeConfigurations runtimeConfigurations,
            CancellationToken cancellationToken
        )
        {
            var metadataResponse = await ProducerProtocol.Metadata(runtimeConfigurations.ControllerConnection, new[] { topicName }, cancellationToken);
            var topic = metadataResponse.TopicsField.FirstOrDefault();
            if (topic == null)
                throw new KeyNotFoundException($"Unknown topic: {topicName.Value}");
            var partitionsBuilder = ImmutableArray.CreateBuilder<ProducerPartitionMetadata>();
            foreach (var partition in topic.PartitionsField.OrderBy(r => r.PartitionIndexField))
            {
                if (!_brokerChannels.TryGetValue(partition.LeaderIdField, out var channel))
                {
                    var broker = metadataResponse.BrokersField.First(r => r.NodeIdField == partition.LeaderIdField);
                    var connection = await _connectionPool.AquireConnection(broker.HostField, broker.PortField, cancellationToken);
                    channel = _config switch
                    {
                        { MaxInFlightRequestsPerConnection: 1 } or { LingerMs: 0 } or { MaxRequestSize: 0 } => new BrokerChannelSingle(
                            runtimeConfigurations.ProducerId,
                            runtimeConfigurations.ProducerEpoch,
                            runtimeConfigurations.Acks,
                            runtimeConfigurations.TransactionalId,
                            runtimeConfigurations.TransactionTimeoutMs,
                            _config,
                            connection,
                            _logger
                        ),
                        _ => new BrokerChannelBatch(
                            runtimeConfigurations.ProducerId,
                            runtimeConfigurations.ProducerEpoch,
                            runtimeConfigurations.Acks,
                            runtimeConfigurations.TransactionalId,
                            runtimeConfigurations.TransactionTimeoutMs,
                            _config,
                            connection,
                            _logger
                        )
                    };
                    _brokerChannels[partition.LeaderIdField] = channel;
                }
                partitionsBuilder.Add(new ProducerPartitionMetadata(partition.PartitionIndexField, channel));
            }
            return new ProducerTopicMetadata(
                topicName,
                partitionsBuilder.ToImmutable()
            );
        }

        private async ValueTask<ProduceCommand> CreateProduceCommand(
            ProduceRecord<TKey, TValue> produceRecord,
            ProducerTopicMetadata topicMetadata,
            CancellationToken cancellationToken
        )
        {
            var keyBytes = _keySerializer.Write(produceRecord.Key);
            var valueBytes = _valueSerializer.Write(produceRecord.Value);
            var partition = produceRecord.Partition;
            var timestamp = produceRecord.Timestamp;
            var header = produceRecord.Headers;
            if (timestamp == Timestamp.None)
                timestamp = Timestamp.Now();
            if (partition == Partition.Unassigned)
                partition = await _partitioner.Select(produceRecord.Topic, topicMetadata.PartitionMetadata.Length, keyBytes, cancellationToken);
            if (header.IsDefault)
                header = ImmutableArray<RecordHeader>.Empty;
            var taskCompletionSource = new TaskCompletionSource<ProduceResult>();
            return new ProduceCommand(
                new(produceRecord.Topic, partition),
                timestamp,
                keyBytes,
                valueBytes,
                header,
                _attributes,
                taskCompletionSource
            );
        }

        Task<ITransaction> IProducer<TKey, TValue>.BeginTransaction(CancellationToken cancellationToken)
        {
            var beginTransactionCommand = new BeginTransactionCommand(new TaskCompletionSource<ITransaction>());
            //_commandQueue.Add(beginTransactionCommand, cancellationToken);
            return beginTransactionCommand.TaskCompletionSource.Task;
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
                ControllerConnection = controllerConnection;
                TopicStates = topicStates;
                Transaction = transaction;
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

            var controllerConnection = await _connectionPool.AquireSharedConnection(cancellationToken);
            controllerConnection = await GetCoordinator(
                controllerConnection,
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
                controllerConnection
            );
        }

        private async ValueTask<IConnection> GetCoordinator(
            IConnection connection,
            CancellationToken cancellationToken
        )
        {

            var findCoordinatorResponse = await ProducerProtocol.FindCoordinator(connection, _config, _logger, cancellationToken);
            var nodeId = findCoordinatorResponse.NodeIdField;
            var host = findCoordinatorResponse.HostField;
            var port = findCoordinatorResponse.PortField;
            if (findCoordinatorResponse.CoordinatorsField.Any())
            {
                nodeId = findCoordinatorResponse.CoordinatorsField[0].NodeIdField;
                host = findCoordinatorResponse.CoordinatorsField[0].HostField;
                port = findCoordinatorResponse.CoordinatorsField[0].PortField;
            }
            if (connection.NodeId == nodeId)
                return connection;

            await connection.Close(cancellationToken);
            connection.Dispose();

            return await _connectionPool.AquireSharedConnection(host, port, cancellationToken);
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

        private async ValueTask UpdateTransactions(
            IDictionary<ClusterNodeId, IDictionary<TopicName, IDictionary<Partition, (PartitionState PartitionState, IList<ProduceCommand> Commands)>>> assignedCommands,
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
                            ProducerLog.ProducePartitionError(_logger, topicParitionResponse.NameField, Errors.Translate(paritionResponse.ErrorCodeField));
            }
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

        protected override async ValueTask OnClose(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            var channelClose = _brokerChannels
                .Values
                .Select(r => r.Close(cancellationToken))
            ;
            await Task.WhenAll(channelClose);
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