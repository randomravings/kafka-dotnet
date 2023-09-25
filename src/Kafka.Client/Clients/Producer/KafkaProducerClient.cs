using Kafka.Client.Clients.Producer.Logging;
using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Commands;
using Kafka.Client.Messages;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class KafkaProducerClient<TKey, TValue> :
        KafkaClient<IProducer<TKey, TValue>, ProducerConfig>,
        IProducer<TKey, TValue>
    {
        private readonly ISerializer<TKey> _keySerializer;
        private readonly ISerializer<TValue> _valueSerializer;
        private readonly IPartitioner _partitioner;
        private readonly CancellationTokenSource _internalCts = new();
        private readonly SortedList<ClusterNodeId, IProducerProtocol> _brokerChannels = new(ClusterNodeIdCompare.Instance);
        private readonly SortedList<TopicName, ProducerTopicMetadata> _topicMetadata = new(TopicNameCompare.Instance);
        private readonly SortedSet<TopicPartition> _transactionMembers = new(TopicPartitionCompare.Instance);
        private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);
        private Attributes _attributes = Attributes.None;
        private RuntimeConfigurations? _runtimeConfigurations;
        private Func<ProduceRecord<TKey, TValue>, RuntimeConfigurations, ProducerTopicMetadata, CancellationToken, ValueTask<ICommand<ProduceResult>>> _sendDelegate;

        public KafkaProducerClient(
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

        async ValueTask<ICommand<ProduceResult>> IProducer<TKey, TValue>.Send(
            ProduceRecord<TKey, TValue> produceRecord,
            CancellationToken cancellationToken
        )
        {
            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var runtimeConfigurations = await GetRuntimeConfigurations(cancellationToken).ConfigureAwait(false);
                var topicMetadata = await GetTopicMetadata(produceRecord.Topic, runtimeConfigurations, cancellationToken).ConfigureAwait(false);
                var command = await _sendDelegate(produceRecord, runtimeConfigurations, topicMetadata, cancellationToken).ConfigureAwait(false);
                return command;
            }
            finally { _semaphoreSlim.Release(); }
        }

        async ValueTask IProducer<TKey, TValue>.BeginTransaction(CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var runtimeConfigurations = await GetRuntimeConfigurations(cancellationToken).ConfigureAwait(false);
                if(string.IsNullOrEmpty(runtimeConfigurations.TransactionalId))
                    throw new InvalidOperationException("Transactional Id not set");
                if (_attributes.HasFlag(Attributes.IsTransactional))
                    throw new InvalidOperationException("Transaction in progress");
                await FlushChannels(cancellationToken).ConfigureAwait(false);
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
            if (_transactionMembers.Contains(sendCommand.TopicPartition))
                return;
            var partitions = ImmutableArray.Create(
                new AddPartitionsToTxnRequestData.AddPartitionsToTxnTopic(
                    sendCommand.TopicPartition.Topic.TopicName,
                    ImmutableArray.Create(sendCommand.TopicPartition.Partition.Value),
                    ImmutableArray<TaggedField>.Empty
                )
            );
            var transactions = ImmutableArray.Create(
                new AddPartitionsToTxnRequestData.AddPartitionsToTxnTransaction(
                    runtimeConfigurations.TransactionalId,
                    runtimeConfigurations.ProducerId,
                    runtimeConfigurations.ProducerEpoch,
                    false,
                    partitions,
                    ImmutableArray<TaggedField>.Empty
                )
            );
            var addPartitionsToTxnRequest = new AddPartitionsToTxnRequestData(
                TransactionsField: transactions,
                V3AndBelowTransactionalIdField: runtimeConfigurations.TransactionalId,
                V3AndBelowProducerIdField: runtimeConfigurations.ProducerId,
                V3AndBelowProducerEpochField: runtimeConfigurations.ProducerEpoch,
                V3AndBelowTopicsField: partitions,
                ImmutableArray<TaggedField>.Empty
            );
            var addPartitionsToTxnResponse = await runtimeConfigurations.Protocol.AddPartitionsToTxn(
                addPartitionsToTxnRequest,
                cancellationToken
            ).ConfigureAwait(false);

            foreach (var topic in addPartitionsToTxnResponse.ResultsByTopicV3AndBelowField)
                foreach (var partition in topic.ResultsByPartitionField)
                    if (partition.PartitionErrorCodeField != 0)
                    {
                        var exception = new ApiException(Errors.Translate(partition.PartitionErrorCodeField));
                        sendCommand.TaskCompletionSource.SetException(exception);
                        return;
                    }

            _transactionMembers.Add(sendCommand.TopicPartition);
        }

        async ValueTask IProducer<TKey, TValue>.CommitTransaction(CancellationToken cancellationToken) =>
            await EndTransaction(true, cancellationToken).ConfigureAwait(false)
        ;

        async ValueTask IProducer<TKey, TValue>.RollbackTransaction(CancellationToken cancellationToken) =>
            await EndTransaction(false, cancellationToken).ConfigureAwait(false)
        ;

        private async ValueTask<ICommand<ProduceResult>> Send(
            ProduceRecord<TKey, TValue> produceRecord,
            RuntimeConfigurations runtimeConfigurations,
            ProducerTopicMetadata topicMetadata,
            CancellationToken cancellationToken
        )
        {
            var command = await CreateSendCommand(produceRecord, topicMetadata, cancellationToken).ConfigureAwait(false);
            var channel = GetChannel(topicMetadata.PartitionMetadata[command.TopicPartition.Partition], runtimeConfigurations);
            await channel.Send(command, cancellationToken).ConfigureAwait(false);
            return command;
        }

        private async ValueTask<ICommand<ProduceResult>> SendTransational(
            ProduceRecord<TKey, TValue> produceRecord,
            RuntimeConfigurations runtimeConfigurations,
            ProducerTopicMetadata topicMetadata,
            CancellationToken cancellationToken
        )
        {
            var command = await CreateSendCommand(produceRecord, topicMetadata, cancellationToken).ConfigureAwait(false);
            await CheckTransactionMembership(command, runtimeConfigurations, cancellationToken).ConfigureAwait(false);
            var channel = GetChannel(topicMetadata.PartitionMetadata[command.TopicPartition.Partition], runtimeConfigurations);
            await channel.Send(command, cancellationToken).ConfigureAwait(false);
            return command;
        }

        private async Task EndTransaction(bool commit, CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (!_attributes.HasFlag(Attributes.IsTransactional))
                    throw new InvalidOperationException("No active transaction");
                await FlushChannels(cancellationToken).ConfigureAwait(false);
                var runtimeConfigurations = await GetRuntimeConfigurations(cancellationToken).ConfigureAwait(false);
                var endTxnRequest = new EndTxnRequestData(
                    runtimeConfigurations.TransactionalId,
                    runtimeConfigurations.ProducerId,
                    runtimeConfigurations.ProducerEpoch,
                    commit,
                    ImmutableArray<TaggedField>.Empty
                );
                var endTxnResponse = await runtimeConfigurations.Protocol.EndTxn(
                    endTxnRequest,
                    cancellationToken
                ).ConfigureAwait(false);
                if (endTxnResponse.ErrorCodeField != 0)
                    throw new ApiException(Errors.Translate(endTxnResponse.ErrorCodeField));
                _transactionMembers.Clear();
            }
            finally { _semaphoreSlim.Release(); }
        }

        private async ValueTask FlushChannels(CancellationToken cancellationToken) =>
            await Task.WhenAll(_brokerChannels.Values.Select(r => r.Flush(cancellationToken).AsTask())).ConfigureAwait(false)
        ;

        async ValueTask IProducer<TKey, TValue>.Flush(CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await FlushChannels(cancellationToken).ConfigureAwait(false);
            }
            finally { _semaphoreSlim.Release(); }
        }

        private async ValueTask<RuntimeConfigurations> GetRuntimeConfigurations(CancellationToken cancellationToken) =>
            _runtimeConfigurations ??= await InitRuntime(Config, Logger, cancellationToken).ConfigureAwait(false)
        ;

        private async ValueTask<ProducerTopicMetadata> GetTopicMetadata(
            TopicName topic,
            RuntimeConfigurations runtimeConfigurations,
            CancellationToken cancellationToken
        )
        {
            if (_topicMetadata.TryGetValue(topic, out var topicMetadata))
                return topicMetadata;
            topicMetadata = await KafkaProducerClient<TKey, TValue>.CreateTopicMetadata(topic, runtimeConfigurations, cancellationToken).ConfigureAwait(false);
            _topicMetadata.Add(topic, topicMetadata);
            return topicMetadata;
        }

        private static async ValueTask<ProducerTopicMetadata> CreateTopicMetadata(
            TopicName topicName,
            RuntimeConfigurations runtimeConfigurations,
            CancellationToken cancellationToken
        )
        {
            var metadataRequest = new MetadataRequestData(
                ImmutableArray.Create(
                    new MetadataRequestData.MetadataRequestTopic(
                        Guid.Empty,
                        topicName,
                        ImmutableArray<TaggedField>.Empty
                    )
                ),
                false,
                false,
                false,
                ImmutableArray<TaggedField>.Empty
            );
            var metadataResponse = await runtimeConfigurations.Protocol.Metadata(
                metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);
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

        private IProducerProtocol GetChannel(
            ProducerPartitionMetadata producerPartitionMetadata,
            RuntimeConfigurations runtimeConfigurations
        )
        {
            if (_brokerChannels.TryGetValue(producerPartitionMetadata.LeaderId, out var channel))
                return channel;
            channel = CreateChannel(
                runtimeConfigurations,
                producerPartitionMetadata
            );
            _brokerChannels.Add(producerPartitionMetadata.LeaderId, channel);
            return channel;
        }

        private IProducerProtocol CreateChannel(
            RuntimeConfigurations runtimeConfigurations,
            ProducerPartitionMetadata producerPartitionMetadata
        )
        {
            var connection = new SaslPlaintextTransport(producerPartitionMetadata.Host, producerPartitionMetadata.Port);
            var protocol = CreateProtocol(connection);
            return Config switch
            {
                { MaxInFlightRequestsPerConnection: 1 } or { LingerMs: 0 } or { MaxRequestSize: 0 } => new ProducerChannelSingle(
                    runtimeConfigurations.ProducerId,
                    runtimeConfigurations.ProducerEpoch,
                    runtimeConfigurations.Acks,
                    runtimeConfigurations.TransactionalId,
                    runtimeConfigurations.TransactionTimeoutMs,
                    protocol,
                    Config,
                    Logger
                ),
                _ => new ProducerChannelBatch(
                    runtimeConfigurations.ProducerId,
                    runtimeConfigurations.ProducerEpoch,
                    runtimeConfigurations.Acks,
                    runtimeConfigurations.TransactionalId,
                    runtimeConfigurations.TransactionTimeoutMs,
                    protocol,
                    Config,
                    Logger
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
                partition = await _partitioner.SelectPartition(
                    produceRecord.Topic,
                    topicMetadata.PartitionMetadata.Length,
                    keyBytes,
                    cancellationToken
                ).ConfigureAwait(false);
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

        private static async ValueTask<(long ProducerId, short ProducerEpoch)> GetProducerInstance(
            IProducerConnection protocol,
            string? transactionalId,
            int transactionTimeoutMs,
            long producerId,
            short producerEpoch,
            CancellationToken cancellationToken
        )
        {
            var initProducerIdRequest = new InitProducerIdRequestData(
                transactionalId,
                transactionTimeoutMs,
                producerId,
                producerEpoch,
                ImmutableArray<TaggedField>.Empty
            );
            var initProducerIdResponse = await protocol.InitProducerId(
                initProducerIdRequest,
                cancellationToken
            ).ConfigureAwait(false);
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
                IProducerConnection protocol
            )
            {
                Acks = acks;
                RequestTimeoutMs = requestTimeoutMs;
                ProducerId = producerId;
                ProducerEpoch = producerEpoch;
                TransactionalId = transactionalId;
                TransactionTimeoutMs = transactionTimeoutMs;
                EnableIdempotence = enableIdempotence;
                Protocol = protocol;
            }
            public short Acks { get; init; }
            public int RequestTimeoutMs { get; init; }
            public long ProducerId { get; init; }
            public short ProducerEpoch { get; init; }
            public string TransactionalId { get; init; }
            public int TransactionTimeoutMs { get; init; }
            public bool EnableIdempotence { get; init; }
            public IProducerConnection Protocol { get; init; }
        }

        private async ValueTask<RuntimeConfigurations> InitRuntime(
            ProducerConfig config,
            ILogger logger,
            CancellationToken cancellationToken
        )
        {
            var acks = ParseAcks(config, logger);
            var requestTimeoutMs = config.RequestTimeoutMs;
            var producerId = -1L;
            var producerEpoch = (short)-1;
            var transactionalId = config.TransactionalId;
            var transactionTimeoutMs = config.TransactionTimeoutMs;
            var enableIdempotence = config.EnableIdempotence || !string.IsNullOrEmpty(transactionalId);

            var connection = RandomizeConnection();
#pragma warning disable CA2000 // Dispose objects before losing scope
            var protocol = CreateProtocol(connection);
#pragma warning restore CA2000 // Dispose objects before losing scope
            if (transactionalId != null)
                protocol = await GetCoordinator(
                    protocol,
                    transactionalId,
                    cancellationToken
                ).ConfigureAwait(false);

            if (enableIdempotence)
                (producerId, producerEpoch) = await GetProducerInstance(
                    protocol,
                    transactionalId,
                    transactionTimeoutMs,
                    producerId,
                    producerEpoch,
                    cancellationToken
                ).ConfigureAwait(false);

            return new RuntimeConfigurations(
                acks,
                requestTimeoutMs,
                producerId,
                producerEpoch,
                transactionalId ?? "",
                transactionTimeoutMs,
                enableIdempotence,
                protocol
            );
        }

        private IProducerConnection CreateProtocol(
            ITransport connection
        ) =>
            new ProducerProtocol(connection, Config, Logger)
        ;

        private async ValueTask<IProducerConnection> GetCoordinator(
            IProducerConnection protocol,
            string transactionalId,
            CancellationToken cancellationToken
        )
        {
            var findCoordinatorRequest = new FindCoordinatorRequestData(
                transactionalId,
                (sbyte)CoordinatorType.TRANSACTION,
                ImmutableArray.Create(transactionalId),
                ImmutableArray<TaggedField>.Empty
            );
            var findCoordinatorResponse = await protocol.FindCoordinator(
                findCoordinatorRequest,
                cancellationToken
            ).ConfigureAwait(false);
            var nodeId = findCoordinatorResponse.NodeIdField;
            var host = findCoordinatorResponse.HostField;
            var port = findCoordinatorResponse.PortField;
            if (findCoordinatorResponse.CoordinatorsField.Any())
            {
                nodeId = findCoordinatorResponse.CoordinatorsField[0].NodeIdField;
                host = findCoordinatorResponse.CoordinatorsField[0].HostField;
                port = findCoordinatorResponse.CoordinatorsField[0].PortField;
            }
            if (protocol.NodeId == nodeId)
                return protocol;

            await protocol.Close(cancellationToken).ConfigureAwait(false);
            var connection = new SaslPlaintextTransport(host, port);
            return CreateProtocol(connection);
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
            ProducerLog.DefaultAcks(logger, producerConfig.Acks);
            return -1;
        }

        protected override async ValueTask OnClose(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            var channelClose = _brokerChannels
                .Values
                .Select(r => r.Close(cancellationToken).AsTask())
            ;
            await Task.WhenAll(channelClose).ConfigureAwait(false);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _semaphoreSlim.Dispose();
            _internalCts.Dispose();
        }
    }
}