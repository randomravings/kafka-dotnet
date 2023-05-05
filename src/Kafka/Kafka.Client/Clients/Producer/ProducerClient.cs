using Kafka.Client.Clients.Consumer.Models;
using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Commands;
using Kafka.Client.Messages;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using static Kafka.Client.Server.ConnectionPool;

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
        private readonly SortedSet<TopicPartition> _transactionMembers = new(TopicPartitionCompare.Instance);
        private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);
        private Attributes _attributes = Attributes.None;
        private RuntimeConfigurations? _runtimeConfigurations;
        private Func<ProduceRecord<TKey, TValue>, RuntimeConfigurations, ProducerTopicMetadata, CancellationToken, ValueTask<ICommand<ProduceResult>>> _sendDelegate;

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
            _sendDelegate = Send;
        }

        async Task<ICommand<ProduceResult>> IProducer<TKey, TValue>.Send(
            ProduceRecord<TKey, TValue> produceRecord,
            CancellationToken cancellationToken
        )
        {
            await _semaphoreSlim.WaitAsync(cancellationToken);
            try
            {
                var runtimeConfigurations = await GetRuntimeConfigurations(cancellationToken);
                var topicMetadata = await GetTopicMetadata(produceRecord.Topic, runtimeConfigurations, cancellationToken);
                var command = await _sendDelegate(produceRecord, runtimeConfigurations, topicMetadata, cancellationToken);
                return command;
            }
            finally { _semaphoreSlim.Release(); }
        }

        async Task IProducer<TKey, TValue>.BeginTransaction(CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken);
            try
            {
                var runtimeConfigurations = await GetRuntimeConfigurations(cancellationToken);
                if(string.IsNullOrEmpty(runtimeConfigurations.TransactionalId))
                    throw new InvalidOperationException("Transactional Id not set");
                if (_attributes.HasFlag(Attributes.IsTransactional))
                    throw new InvalidOperationException("Transaction in progress");
                await FlushChannels(cancellationToken);
                _attributes |= Attributes.IsTransactional;
                _sendDelegate = SendTransational;
            }
            finally { _semaphoreSlim.Release(); }
        }

        private async Task CheckTransactionMembership(
            SendCommand sendCommand,
            RuntimeConfigurations runtimeConfigurations,
            CancellationToken cancellationToken
        )
        {
            // Did someone beat me to it check.
            if (_transactionMembers.Contains(sendCommand.TopicPartition))
                return;
            var addPartitionsToTxnRequest = new AddPartitionsToTxnRequest(
                runtimeConfigurations.TransactionalId,
                runtimeConfigurations.ProducerId,
                runtimeConfigurations.ProducerEpoch,
                ImmutableArray.Create(
                    new AddPartitionsToTxnRequest.AddPartitionsToTxnTopic(
                        sendCommand.TopicPartition.Topic,
                        ImmutableArray.Create(sendCommand.TopicPartition.Partition.Value)
                    )
                )
            );
            var addPartitionsToTxnResponse = await RetryHandler.Run(
                runtimeConfigurations.ControllerConnection,
                addPartitionsToTxnRequest,
                AddPartitionsToTxnRequestSerde.Write,
                AddPartitionsToTxnResponseSerde.Read,
                100,
                10,
                r => r.ResultsField.FirstOrDefault()?.ResultsField.FirstOrDefault()?.ErrorCodeField ?? -1,
                (l, e) => l.LogWarning($"{e}"),
                _logger,
                cancellationToken
            );

            foreach (var topic in addPartitionsToTxnResponse.ResultsField)
                foreach (var partition in topic.ResultsField)
                    if (partition.ErrorCodeField != 0)
                    {
                        var exception = new ApiException(Errors.Translate(partition.ErrorCodeField));
                        sendCommand.TaskCompletionSource.SetException(exception);
                        return;
                    }

            _transactionMembers.Add(sendCommand.TopicPartition);
        }

        async Task IProducer<TKey, TValue>.CommitTransaction(CancellationToken cancellationToken) =>
            await EndTransaction(true, cancellationToken)
        ;

        async Task IProducer<TKey, TValue>.RollbackTransaction(CancellationToken cancellationToken) =>
            await EndTransaction(false, cancellationToken)
        ;

        private async ValueTask<ICommand<ProduceResult>> Send(
            ProduceRecord<TKey, TValue> produceRecord,
            RuntimeConfigurations runtimeConfigurations,
            ProducerTopicMetadata topicMetadata,
            CancellationToken cancellationToken
        )
        {
            var command = await CreateSendCommand(produceRecord, topicMetadata, cancellationToken);
            var channel = await GetChannel(topicMetadata.PartitionMetadata[command.TopicPartition.Partition], runtimeConfigurations, cancellationToken);
            await channel.Send(command, cancellationToken);
            return command;
        }

        private async ValueTask<ICommand<ProduceResult>> SendTransational(
            ProduceRecord<TKey, TValue> produceRecord,
            RuntimeConfigurations runtimeConfigurations,
            ProducerTopicMetadata topicMetadata,
            CancellationToken cancellationToken
        )
        {
            var command = await CreateSendCommand(produceRecord, topicMetadata, cancellationToken);
            await CheckTransactionMembership(command, runtimeConfigurations, cancellationToken);
            var channel = await GetChannel(topicMetadata.PartitionMetadata[command.TopicPartition.Partition], runtimeConfigurations, cancellationToken);
            await channel.Send(command, cancellationToken);
            return command;
        }

        private async Task EndTransaction(bool commit, CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken);
            try
            {
                if (!_attributes.HasFlag(Attributes.IsTransactional))
                    throw new InvalidOperationException("No active transaction");
                await FlushChannels(cancellationToken);
                var runtimeConfigurations = await GetRuntimeConfigurations(cancellationToken);
                var endTxnRequest = new EndTxnRequest(
                    runtimeConfigurations.TransactionalId,
                    runtimeConfigurations.ProducerId,
                    runtimeConfigurations.ProducerEpoch,
                    commit
                );
                var endTxnResponse = await runtimeConfigurations.ControllerConnection.ExecuteRequest(
                    endTxnRequest,
                    EndTxnRequestSerde.Write,
                    EndTxnResponseSerde.Read,
                    cancellationToken
                );
                if (endTxnResponse.ErrorCodeField != 0)
                    throw new ApiException(Errors.Translate(endTxnResponse.ErrorCodeField));
                _transactionMembers.Clear();
            }
            finally { _semaphoreSlim.Release(); }
        }

        private async Task FlushChannels(CancellationToken cancellationToken) =>
            await Task.WhenAll(_brokerChannels.Values.Select(r => r.Flush(cancellationToken)))
        ;

        async Task IProducer<TKey, TValue>.Flush(CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken);
            try
            {
                await FlushChannels(cancellationToken);
            }
            finally { _semaphoreSlim.Release(); }
        }

        private async ValueTask<RuntimeConfigurations> GetRuntimeConfigurations(CancellationToken cancellationToken) =>
            _runtimeConfigurations ??= await InitRuntime(_config, _logger, cancellationToken)
        ;

        private async Task<ProducerTopicMetadata> GetTopicMetadata(
            TopicName topic,
            RuntimeConfigurations runtimeConfigurations,
            CancellationToken cancellationToken
        )
        {
            if (_topicMetadata.TryGetValue(topic, out var topicMetadata))
                return topicMetadata;
            topicMetadata = await ProducerClient<TKey, TValue>.CreateTopicMetadata(topic, runtimeConfigurations, cancellationToken);
            _topicMetadata.Add(topic, topicMetadata);
            return topicMetadata;
        }

        private static async ValueTask<ProducerTopicMetadata> CreateTopicMetadata(
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
                var broker = metadataResponse.BrokersField.First(r => r.NodeIdField == partition.LeaderIdField);
                partitionsBuilder.Add(new ProducerPartitionMetadata(partition.PartitionIndexField, broker.NodeIdField, broker.HostField, broker.PortField));
            }
            return new ProducerTopicMetadata(
                topicName,
                partitionsBuilder.ToImmutable()
            );
        }

        private async Task<IBrokerChannel> GetChannel(
            ProducerPartitionMetadata producerPartitionMetadata,
            RuntimeConfigurations runtimeConfigurations,
            CancellationToken cancellationToken
        )
        {
            if (_brokerChannels.TryGetValue(producerPartitionMetadata.LeaderId, out var channel))
                return channel;
            channel = await CreateChannel(
            runtimeConfigurations,
            producerPartitionMetadata,
            cancellationToken
        );
            _brokerChannels.Add(producerPartitionMetadata.LeaderId, channel);
            return channel;
        }

        private async Task<IBrokerChannel> CreateChannel(
            RuntimeConfigurations runtimeConfigurations,
            ProducerPartitionMetadata producerPartitionMetadata,
            CancellationToken cancellationToken
        )
        {
            var connection = await _connectionPool.AquireConnection(producerPartitionMetadata.Host, producerPartitionMetadata.Port, cancellationToken);
            return _config switch
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
        }

        private async ValueTask<SendCommand> CreateSendCommand(
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
            return new SendCommand(
                TopicPartition: new(produceRecord.Topic, partition),
                Timestamp: timestamp,
                Key: keyBytes,
                Value: valueBytes,
                Headers: header,
                Attributes: _attributes
            );
        }

        private async ValueTask<(long ProducerId, short ProducerEpoch)> GetProducerInstance(
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
            var initProducerIdResponse = await RetryHandler.Run(
                connection,
                initProducerIdRequest,
                InitProducerIdRequestSerde.Write,
                InitProducerIdResponseSerde.Read,
                100,
                10,
                r => r.ErrorCodeField,
                (l, e) => l.LogWarning($"{e}"),
                _logger,
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
                ControllerConnection = controllerConnection;
            }
            public short Acks { get; init; }
            public int RequestTimeoutMs { get; init; }
            public long ProducerId { get; init; }
            public short ProducerEpoch { get; init; }
            public string TransactionalId { get; init; }
            public int TransactionTimeoutMs { get; init; }
            public bool EnableIdempotence { get; init; }
            public IConnection ControllerConnection { get; init; }
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
    }
}