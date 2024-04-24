using Kafka.Client;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Net;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Write
{
    internal sealed class Transaction(
        INodeLink transactionCoordinator,
        long producerId,
        short producerEpoch,
        string transactionalId,
        ILogger logger
    ) :
        ITransaction
    {
        private SpinLock _spinLock;
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private readonly INodeLink _transactionCoordinator = transactionCoordinator;
        private readonly long _producerId = producerId;
        private readonly short _producerEpoch = producerEpoch;
        private readonly string _transactionalId = transactionalId;
        private readonly HashSet<TopicPartition> _topicPartitions = new(TopicPartitionCompare.Equality);
        private readonly ILogger _logger = logger;
        private bool _completed;

        public bool IsCompleted { get; private set; }

        async Task ITransaction.Commit(CancellationToken cancellationToken)
        {
            await EndTransaction(
                true,
                cancellationToken
            ).ConfigureAwait(false);
        }
        async Task ITransaction.Rollback(CancellationToken cancellationToken)
        {
            await EndTransaction(
                false,
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async Task<bool> EnsureTransactionMembership(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        )
        {
            if (_topicPartitions.Contains(topicPartition))
                return true;

            await AddPartitionToTransaction(
                topicPartition,
                cancellationToken
            ).ConfigureAwait(false);
            return true;
        }

        public void Dispose()
        {
            try
            {
                using var cts = new CancellationTokenSource();
                cts.CancelAfter(5000);
                EndTransaction(
                    false,
                    cts.Token
                ).Wait(cts.Token);
            }
            catch (OperationCanceledException) { }
            catch (InvalidOperationException) { }
            catch (ApiException) { }
            finally
            {
                _semaphore.Dispose();
            }
        }

        private async Task AddPartitionToTransaction(
            TopicPartition topicPartition,
            CancellationToken cancellationToken
        )
        {
            await _semaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                var partitions = ImmutableArray.Create(
                    new AddPartitionsToTxnRequestData.AddPartitionsToTxnTopic(
                        topicPartition.Topic.TopicName,
                        [topicPartition.Partition.Value],
                        []
                    )
                );
                var transactions = ImmutableArray.Create(
                    new AddPartitionsToTxnRequestData.AddPartitionsToTxnTransaction(
                        _transactionalId,
                        _producerId,
                        _producerEpoch,
                        false,
                        partitions,
                        []
                    )
                );
                var addPartitionsToTxnRequest = new AddPartitionsToTxnRequestData(
                    TransactionsField: transactions,
                    V3AndBelowTransactionalIdField: _transactionalId,
                    V3AndBelowProducerIdField: _producerId,
                    V3AndBelowProducerEpochField: _producerEpoch,
                    V3AndBelowTopicsField: partitions,
                    []
                );
                var addPartitionsToTxnResponse = await _transactionCoordinator.AddPartitionsToTxn(
                    addPartitionsToTxnRequest,
                    cancellationToken
                ).ConfigureAwait(false);

                foreach (var topic in addPartitionsToTxnResponse.ResultsByTopicV3AndBelowField)
                    foreach (var partition in topic.ResultsByPartitionField)
                        if (partition.PartitionErrorCodeField != 0)
                            throw new ApiException(ApiErrors.Translate(partition.PartitionErrorCodeField));
                AddTopicPartition(
                    topicPartition
                );
                _logger.TransactionAdd(topicPartition);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task EndTransaction(bool commit, CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                if (_completed)
                    throw new InvalidOperationException("Transaction is no longer active");
                var endTxnRequest = new EndTxnRequestData(
                    _transactionalId,
                    _producerId,
                    _producerEpoch,
                    commit,
                    []
                );
                var endTxnResponse = await _transactionCoordinator.EndTxn(
                    endTxnRequest,
                    cancellationToken
                ).ConfigureAwait(false);
                if (endTxnResponse.ErrorCodeField != 0)
                    throw new ApiException(ApiErrors.Translate(endTxnResponse.ErrorCodeField));
                _topicPartitions.Clear();
                if (commit)
                    _logger.TransactionCommit();
                else
                    _logger.TransactionRollback();
                _completed = true;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private bool ContainsTopicPartition(
            in ISet<TopicPartition> topicPartitions,
            in TopicPartition topicPartition
        )
        {
            var lockTaken = false;
            _spinLock.Enter(ref lockTaken);
            try
            {
                return topicPartitions.Contains(topicPartition);
            }
            finally
            {
                if (lockTaken)
                    _spinLock.Exit(false);
            }
        }

        private bool AddTopicPartition(
            in TopicPartition topicPartition
        )
        {
            var lockTaken = false;
            _spinLock.Enter(ref lockTaken);
            try
            {
                return _topicPartitions.Add(topicPartition);
            }
            finally
            {
                if (lockTaken)
                    _spinLock.Exit(false);
            }
        }
    }
}
