using Kafka.Client.Config;
using Kafka.Client;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Model.Internal;
using Kafka.Client.Net;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Net;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Write
{
    internal sealed class WriteStream(
        ICluster<INodeLink> connections,
        WriteStreamConfig writeStreamConfig,
        ILogger logger
    ) :
        IWriteStream,
        IDisposable
    {
        private readonly CancellationTokenSource _internalCts = new();
        private readonly ConcurrentDictionary<TopicPartition, WriteChannel> _brokerChannelsByTopicPartition = new(TopicPartitionCompare.Equality);
        private readonly ConcurrentDictionary<NodeId, WriteChannel> _brokerChannels = [];
        private readonly ConcurrentDictionary<Topic, TopicMetadata> _topicMetadata = new(TopicCompare.Equality);
        private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);
        private readonly string? _transactionalId = writeStreamConfig.TransactionalId;
        private readonly int _transactionTimeoutMs = writeStreamConfig.TransactionTimeoutMs;
        private readonly bool _enableIdempotence = writeStreamConfig.EnableIdempotence || !string.IsNullOrEmpty(writeStreamConfig.TransactionalId);
        private readonly WriteStreamConfig _writeStreamConfig = writeStreamConfig;
        private readonly ILogger _logger = logger;
        private readonly ICluster<INodeLink> _connections = connections;

        private Transaction? _activeTransaction;
        private readonly Attributes _attributes = Attributes.None;
        private bool _initialized;
        private long _producerId = -1;
        private short _producerEpoch = -1;

        async Task<TopicMetadata> IWriteStream.MetadataForTopic(
            TopicName topic,
            CancellationToken cancellationToken
        )
        {
            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                return await MetadataForTopic(
                    topic,
                    cancellationToken
                ).ConfigureAwait(false);
            }
            finally
            {
                _semaphoreSlim.Release();
            }

        }

        private async Task<TopicMetadata> MetadataForTopic(
            TopicName topic,
            CancellationToken cancellationToken
        )
        {
            if (_topicMetadata.TryGetValue(topic, out var metadata) && metadata.ExpireTime < DateTimeOffset.UtcNow)
                return metadata;
            _topicMetadata.Remove(topic, out _);
            metadata = await CreateTopicMetadata(topic, cancellationToken).ConfigureAwait(false);
            _topicMetadata.TryAdd(topic, metadata);
            return metadata;
        }

        IWriterBuilder IWriteStream.CreateWriter() =>
            new WriterBuilder(
                this,
                DefaultPartitioner.Instance,
                _logger
            )
        ;

        async Task<WriteResult> IWriteStream.Write(
            WriteRecord writeRecord,
            CancellationToken cancellationToken
        )
        {
            await EnsureInstance(
                cancellationToken
            ).ConfigureAwait(false);

            var attributes = _attributes;
            var transactional = TryGetTransaction(out var transaction) &&
                await transaction.EnsureTransactionMembership(
                    writeRecord.TopicPartition,
                    cancellationToken
                ).ConfigureAwait(false);
            if (transactional)
                attributes |= Attributes.IsTransactional;

            var callback = new TaskCompletionSource<WriteResult>(
                TaskCreationOptions.RunContinuationsAsynchronously
            );
            var command = new WriteCommand(
                writeRecord,
                attributes,
                callback
            );
            var channel = await GetChannel(
                writeRecord.TopicPartition,
                cancellationToken
            ).ConfigureAwait(false);
            channel.Send(command, cancellationToken);
            await Task.Yield();
            return await callback
                .Task
                .WaitAsync(cancellationToken)
                .ConfigureAwait(false)
            ;
        }

        private bool TryGetTransaction([MaybeNullWhen(false)] out Transaction transaction)
        {
            while (true)
            {
                transaction = _activeTransaction;
                switch (transaction)
                {
                    case null:
                        return false;
                    case { IsCompleted: true }:
                        if (Interlocked.CompareExchange(ref _activeTransaction, null, transaction) == transaction)
                            return false;
                        else
                            break;
                    default:
                        return true;
                }
            }
        }

        async Task<ITransaction> IWriteStream.BeginTransaction(CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                if (_activeTransaction != null)
                    throw new InvalidOperationException("Transaction in progress");
                if (string.IsNullOrEmpty(_transactionalId))
                    throw new InvalidOperationException("Transactional Id not set");
                _logger.TransactionBegin();
                var connection = await _connections.Controller(
                    cancellationToken
                ).ConfigureAwait(false);
                var nodeId = await FindCoordinator(
                    connection,
                    _transactionalId,
                    cancellationToken
                ).ConfigureAwait(false);
                if (connection.NodeId != nodeId)
                    connection = await _connections.Connection(
                        nodeId,
                        cancellationToken
                    ).ConfigureAwait(false);
                _activeTransaction = new Transaction(
                    connection,
                    _producerId,
                    _producerEpoch,
                    _transactionalId,
                    _logger
                );
                _logger.TransactionBegin();
                return _activeTransaction;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task FlushChannels(CancellationToken cancellationToken)
        {
            var flushTasks = _brokerChannels.Select(r => r.Value.Flush(cancellationToken));
            await Task.WhenAll(flushTasks).ConfigureAwait(false);
        }

        async Task IWriteStream.Flush(CancellationToken cancellationToken)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await FlushChannels(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task<WriteChannel> GetChannel(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        )
        {
            if (_brokerChannelsByTopicPartition.TryGetValue(topicPartition, out var channel))
                return channel;

            await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (_brokerChannelsByTopicPartition.TryGetValue(topicPartition, out channel))
                    return channel;
                var metadata = await MetadataForTopic(
                    topicPartition.Topic.TopicName,
                    cancellationToken
                ).ConfigureAwait(false);
                var nodeId = metadata.PartitionMetadata[topicPartition.Partition].LeaderId;

                if (!_brokerChannels.TryGetValue(nodeId, out channel))
                {
                    channel = await CreateChannel(
                        nodeId,
                        cancellationToken
                    ).ConfigureAwait(false);
                    _brokerChannels.TryAdd(nodeId, channel);
                }

                _brokerChannelsByTopicPartition.TryAdd(topicPartition, channel);
                return channel;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task<TopicMetadata> CreateTopicMetadata(
            TopicName topic,
            CancellationToken cancellationToken
        )
        {
            var metadataRequest = new MetadataRequestData(
                [
                    new MetadataRequestData.MetadataRequestTopic(
                        Guid.Empty,
                        topic,
                        []
                    ),
                ],
                false,
                false,
                false,
                []
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
            var partitionsBuilder = ImmutableArray.CreateBuilder<Model.Internal.PartitionMetadata>();
            foreach (var partition in metadatacResponseTopic.PartitionsField.OrderBy(r => r.PartitionIndexField))
            {
                var broker = metadataResponse
                    .BrokersField
                    .First(r => r.NodeIdField == partition.LeaderIdField)
                ;
                var partitionMetadata = new Model.Internal.PartitionMetadata(
                    partition.PartitionIndexField,
                    broker.NodeIdField,
                    broker.HostField,
                    broker.PortField
                );
                partitionsBuilder.Add(partitionMetadata);
            }
            return new TopicMetadata(
                topic,
                partitionsBuilder.ToImmutable(),
                DateTimeOffset.UtcNow.AddSeconds(10)
            );
        }

        private async Task<WriteChannel> CreateChannel(
            NodeId nodeId,
            CancellationToken cancellationToken
        )
        {
            var connection = await _connections.Connection(nodeId, cancellationToken)
                .ConfigureAwait(false)
            ;
            return new(
                nodeId,
                _producerId,
                _producerEpoch,
                connection,
                _writeStreamConfig,
                _logger
            );
        }

        private async Task EnsureInstance(
            CancellationToken cancellationToken
        )
        {
            if (_initialized)
                return;
            else
                await CreateInstance(
                    cancellationToken
                ).ConfigureAwait(false);
        }

        private async Task CreateInstance(
            CancellationToken cancellationToken
        )
        {
            await _semaphoreSlim.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                if (_initialized)
                    return;

                var connection = await _connections.Controller(
                    cancellationToken
                ).ConfigureAwait(false);
                if (_enableIdempotence)
                {
                    var initProducerIdRequest = new InitProducerIdRequestData(
                        _transactionalId,
                        _transactionTimeoutMs,
                        _producerId,
                        _producerEpoch,
                        []
                    );
                    var initProducerIdResponse = await connection.InitProducerId(
                        initProducerIdRequest,
                        cancellationToken
                    ).ConfigureAwait(false);

                    _producerId = initProducerIdResponse.ProducerIdField;
                    _producerEpoch = initProducerIdResponse.ProducerEpochField;
                }

                if (!string.IsNullOrEmpty(_transactionalId))
                {
                    var nodeId = await FindCoordinator(
                        connection,
                        _transactionalId,
                        cancellationToken
                    ).ConfigureAwait(false);
                    if (connection.NodeId != nodeId)
                        connection = await _connections.Connection(
                            nodeId,
                            cancellationToken
                        ).ConfigureAwait(false);
                }
                _logger.WriteInstance(_producerId, _producerEpoch, _enableIdempotence, _transactionalId);
                _initialized = true;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }


        private async Task<NodeId> FindCoordinator(
            INodeLink protocol,
            string transactionalId,
            CancellationToken cancellationToken
        )
        {
            var maxTries = 10;
            var tries = 0;
            while (true)
            {
                var findCoordinatorRequest = new FindCoordinatorRequestData(
                transactionalId,
                (sbyte)CoordinatorType.Transaction,
                [transactionalId],
                []
            );
                var findCoordinatorResponse = await protocol.FindCoordinator(
                    findCoordinatorRequest,
                    cancellationToken
                ).ConfigureAwait(false);

                if (findCoordinatorResponse.ErrorCodeField != 0)
                {
                    var error = ApiErrors.Translate(findCoordinatorResponse.ErrorCodeField);
                    if (!error.Retriable || tries >= maxTries)
                        throw new ApiException(error);

                    _logger.LogApiError(error);
                    cancellationToken.WaitHandle.WaitOne(1000);
                    tries++;
                }

                var nodeId = findCoordinatorResponse.NodeIdField;
                if (findCoordinatorResponse.CoordinatorsField.Any())
                    nodeId = findCoordinatorResponse.CoordinatorsField[0].NodeIdField;
                return nodeId;
            }
        }

        async Task IWriteStream.Close(CancellationToken cancellationToken)
        {
            await _internalCts.CancelAsync().ConfigureAwait(false);
            var channelClose = _brokerChannels
                .Select(r => r.Value.Close(cancellationToken))
            ;
            await Task.WhenAll(channelClose).ConfigureAwait(false);
        }

        void IDisposable.Dispose()
        {
            _activeTransaction?.Dispose();
            _internalCts.Dispose();
            _semaphoreSlim.Dispose();
        }
    }
}