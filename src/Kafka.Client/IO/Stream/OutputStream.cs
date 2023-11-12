using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Net;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Net;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Stream
{
    internal sealed class OutputStream :
        IOutputStream
    {
        private readonly CancellationTokenSource _internalCts = new();
        private readonly SortedList<ClusterNodeId, ProducerChannel> _brokerChannels = new(ClusterNodeIdCompare.Instance);
        private readonly SortedList<TopicPartition, ProducerChannel> _brokerChannelsByTopicPartition = new(TopicPartitionCompare.Instance);
        private readonly SortedList<TopicName, ProducerTopicMetadata> _producerMetadata = new(TopicNameCompare.Instance);
        private readonly SortedSet<TopicPartition> _transactionMembers = new(TopicPartitionCompare.Instance);
        private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);
        private Attributes _attributes = Attributes.None;
        private readonly string _transactionalId;
        private readonly int _transactionTimeoutMs;
        private readonly bool _enableIdempotence;
        private readonly OutputStreamConfig _producerConfig;
        private readonly ILogger _logger;
        private readonly IConnectionManager<IClientConnection> _connections;

        private long _producerId = -1;
        private short _producerEpoch = -1;
        private IClientConnection? _coordinator;

        public OutputStream(
            IConnectionManager<IClientConnection> connections,
            OutputStreamConfig producerConfig,
            ILogger logger
        )
        {
            _producerConfig = producerConfig;
            _logger = logger;
            _connections = connections;
            _transactionalId = producerConfig.TransactionalId ?? "";
        }

        async ValueTask<ProducerTopicMetadata> IOutputStream.MetadataForTopic(
            TopicName topic,
            CancellationToken cancellationToken
        ) =>
            await MetadataForTopic(
                topic,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<ProducerTopicMetadata> MetadataForTopic(
            TopicName topic,
            CancellationToken cancellationToken
        )
        {
            if (_producerMetadata.TryGetValue(topic, out var metadata) && metadata.ExpireTime < DateTimeOffset.UtcNow)
                return metadata;
            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (_producerMetadata.TryGetValue(topic, out metadata) && metadata.ExpireTime < DateTimeOffset.UtcNow)
                    return metadata;
                metadata = await CreateTopicMetadata(topic, cancellationToken).ConfigureAwait(false);
                _producerMetadata[topic] = metadata;
                return metadata;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        IStreamWriterBuilder IOutputStream.CreateWriter(
            TopicName topic
        ) =>
            new StreamWriterBuilder(
                this,
                topic
            )
        ;

        async Task<TaskCompletionSource<ProduceResult>> IOutputStream.Write(
            ProduceRecord produceRecord,
            CancellationToken cancellationToken
        )
        {
            var callback = new TaskCompletionSource<ProduceResult>();
            var command = new ProduceCommand(
                produceRecord,
                callback
            );
            var channel = await GetChannel(
                produceRecord.TopicPartition,
                cancellationToken
            ).ConfigureAwait(false);
            await Task.Yield();
            channel.Send(command, cancellationToken);
            return callback;
        }

        async Task<ITransaction> IOutputStream.BeginTransaction(CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (string.IsNullOrEmpty(_transactionalId))
                    throw new InvalidOperationException("Transactional Id not set");
                if (_attributes.HasFlag(Attributes.IsTransactional))
                    throw new InvalidOperationException("Transaction in progress");
                await FlushChannels(cancellationToken).ConfigureAwait(false);
                _attributes |= Attributes.IsTransactional;
                _logger.TransactionBegin();
                return new Transaction(EndTransaction);
            }
            finally { _semaphoreSlim.Release(); }
        }

        private async ValueTask<IClientConnection> GetCoordinator(
            CancellationToken cancellationToken
        )
        {
            if (_coordinator != null)
                return _coordinator;
            _coordinator = await CreateController(
                cancellationToken
            ).ConfigureAwait(false);
            return _coordinator;
        }

        private async Task CheckTransactionMembership(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        )
        {
            if (_transactionMembers.Contains(topicPartition))
                return;
            var partitions = ImmutableArray.Create(
                new AddPartitionsToTxnRequestData.AddPartitionsToTxnTopic(
                    topicPartition.Topic.TopicName,
                    ImmutableArray.Create(topicPartition.Partition.Value),
                    ImmutableArray<TaggedField>.Empty
                )
            );
            var transactions = ImmutableArray.Create(
                new AddPartitionsToTxnRequestData.AddPartitionsToTxnTransaction(
                    _transactionalId,
                    _producerId,
                    _producerEpoch,
                    false,
                    partitions,
                    ImmutableArray<TaggedField>.Empty
                )
            );
            var addPartitionsToTxnRequest = new AddPartitionsToTxnRequestData(
                TransactionsField: transactions,
                V3AndBelowTransactionalIdField: _transactionalId,
                V3AndBelowProducerIdField: _producerId,
                V3AndBelowProducerEpochField: _producerEpoch,
                V3AndBelowTopicsField: partitions,
                ImmutableArray<TaggedField>.Empty
            );
            var coordinator = await GetCoordinator(cancellationToken).ConfigureAwait(false);
            var addPartitionsToTxnResponse = await coordinator.AddPartitionsToTxn(
                addPartitionsToTxnRequest,
                cancellationToken
            ).ConfigureAwait(false);

            foreach (var topic in addPartitionsToTxnResponse.ResultsByTopicV3AndBelowField)
                foreach (var partition in topic.ResultsByPartitionField)
                    if (partition.PartitionErrorCodeField != 0)
                        throw new ApiException(Errors.Translate(partition.PartitionErrorCodeField));
            _transactionMembers.Add(topicPartition);
        }

        private async Task EndTransaction(bool commit, CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (!_attributes.HasFlag(Attributes.IsTransactional))
                    throw new InvalidOperationException("No active transaction");
                await FlushChannels(cancellationToken).ConfigureAwait(false);
                var endTxnRequest = new EndTxnRequestData(
                    _transactionalId,
                    _producerId,
                    _producerEpoch,
                    commit,
                    ImmutableArray<TaggedField>.Empty
                );
                var coordinator = await GetCoordinator(cancellationToken).ConfigureAwait(false);
                var endTxnResponse = await coordinator.EndTxn(
                    endTxnRequest,
                    cancellationToken
                ).ConfigureAwait(false);
                if (endTxnResponse.ErrorCodeField != 0)
                    throw new ApiException(Errors.Translate(endTxnResponse.ErrorCodeField));
                _transactionMembers.Clear();
                if (commit)
                    _logger.TransactionCommit();
                else
                    _logger.TransactionRollback();
            }
            finally { _semaphoreSlim.Release(); }
        }

        private async ValueTask FlushChannels(CancellationToken cancellationToken)
        {
            var flushTasks = _brokerChannels.Values.Select(r => r.Flush(cancellationToken));
            await Task.WhenAll(flushTasks).ConfigureAwait(false);
        }

        async Task IOutputStream.Flush(CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await FlushChannels(cancellationToken).ConfigureAwait(false);
            }
            finally { _semaphoreSlim.Release(); }
        }

        private async ValueTask<ProducerChannel> GetChannel(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        )
        {
            if (_brokerChannelsByTopicPartition.TryGetValue(topicPartition, out var channel))
                return channel;

            var metadata = await MetadataForTopic(
                topicPartition.Topic.TopicName,
                cancellationToken
            ).ConfigureAwait(false);
            await Task.Yield();
            var nodeId = metadata.PartitionMetadata[topicPartition.Partition].LeaderId;

            if (_brokerChannels.TryGetValue(nodeId, out channel))
            {
                _brokerChannelsByTopicPartition.Add(topicPartition, channel);
                return channel;
            }

            channel = await CreateChannel(
                nodeId,
                cancellationToken
            ).ConfigureAwait(false);
            await Task.Yield();
            _brokerChannels.Add(nodeId, channel);
            _brokerChannelsByTopicPartition.Add(topicPartition, channel);

            return channel;
        }

        private async ValueTask<ProducerTopicMetadata> CreateTopicMetadata(
            TopicName topic,
            CancellationToken cancellationToken
        )
        {
            var metadataRequest = new MetadataRequestData(
                ImmutableArray.Create(
                    new MetadataRequestData.MetadataRequestTopic(
                        Guid.Empty,
                        topic,
                        ImmutableArray<TaggedField>.Empty
                    )
                ),
                false,
                false,
                false,
                ImmutableArray<TaggedField>.Empty
            );
            var controller = await _connections.Controller(cancellationToken).ConfigureAwait(false);
            var metadataResponse = await controller.Metadata(
                metadataRequest,
                cancellationToken
            ).ConfigureAwait(false);
            var metadatacResponseTopic = metadataResponse
                .TopicsField
                .FirstOrDefault() ??
                throw new KeyNotFoundException($"Unknown topic: {topic.Value}")
            ;
            var partitionsBuilder = ImmutableArray.CreateBuilder<ProducerPartitionMetadata>();
            foreach (var partition in metadatacResponseTopic.PartitionsField.OrderBy(r => r.PartitionIndexField))
            {
                var broker = metadataResponse
                    .BrokersField
                    .First(r => r.NodeIdField == partition.LeaderIdField)
                ;
                var producerPartitionMetadata = new ProducerPartitionMetadata(
                    partition.PartitionIndexField,
                    broker.NodeIdField,
                    broker.HostField,
                    broker.PortField
                );
                partitionsBuilder.Add(producerPartitionMetadata);
            }
            return new ProducerTopicMetadata(
                topic,
                partitionsBuilder.ToImmutable(),
                DateTimeOffset.UtcNow.AddSeconds(10)
            );
        }

        private async ValueTask<ProducerChannel> CreateChannel(
            ClusterNodeId nodeId,
            CancellationToken cancellationToken
        )
        {
            var connection = await _connections.Connection(nodeId, cancellationToken)
                .ConfigureAwait(false)
            ;
            return new(
                _producerId,
                _producerEpoch,
                connection,
                _producerConfig,
                _logger
            );
        }

        private static async ValueTask<(long ProducerId, short ProducerEpoch)> GetProducerInstance(
            IClientConnection protocol,
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

        private async ValueTask<IClientConnection> CreateController(
            CancellationToken cancellationToken
        )
        {
            var coordinator = await _connections.Controller(
                cancellationToken
            ).ConfigureAwait(false);

            // If transactional then the coordinator is not the same as controller.
            if (!string.IsNullOrEmpty(_transactionalId) || _enableIdempotence)
            {
                coordinator = await FindCoordinator(
                    coordinator,
                    _transactionalId,
                    cancellationToken
                ).ConfigureAwait(false);

                (_producerId, _producerEpoch) = await GetProducerInstance(
                    coordinator,
                    _transactionalId,
                    _transactionTimeoutMs,
                    _producerId,
                    _producerEpoch,
                    cancellationToken
                ).ConfigureAwait(false);
            }
            return coordinator;
        }

        private async ValueTask<IClientConnection> FindCoordinator(
            IClientConnection protocol,
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
            if (findCoordinatorResponse.CoordinatorsField.Any())
                nodeId = findCoordinatorResponse.CoordinatorsField[0].NodeIdField;
            if (protocol.NodeId == nodeId)
                return protocol;
            else
                return await _connections.Connection(nodeId, cancellationToken)
                    .ConfigureAwait(false)
                ;
        }

        async Task IOutputStream.Close(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            var channelClose = _brokerChannels
                .Values
                .Select(r => r.Close(cancellationToken).AsTask())
            ;
            await Task.WhenAll(channelClose).ConfigureAwait(false);
        }

        void IDisposable.Dispose()
        {
            _internalCts.Dispose();
            _semaphoreSlim.Dispose();
        }
    }
}