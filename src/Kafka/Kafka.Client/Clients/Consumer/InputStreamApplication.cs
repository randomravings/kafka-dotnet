using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class InputStreamApplication<TKey, TValue> :
        IInputStreamApplication<TKey, TValue>
    {
        private readonly IReadOnlySet<TopicName> _topics;
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private readonly IConnectionPool _connectionPool;
        private readonly ConsumerConfig _config;
        private readonly ILogger<IConsumer<TKey, TValue>> _logger;
        private readonly IConsumerGroup _group;
        private IConsumerGroupInstance? _instance = null;
        private int _roundRobiner = 0;

        public InputStreamApplication(
            IReadOnlySet<TopicName> topics,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            IConnectionPool connectionPool,
            ConsumerConfig config,
            ILogger<IConsumer<TKey, TValue>> logger
        )
        {
            _topics = topics;
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            _connectionPool = connectionPool;
            _config = config;
            _logger = logger;

            _group = new ConsumerGroup(_connectionPool, _config, _logger);
        }

        async Task<IFetchResult<TKey, TValue>> IInputStream<TKey, TValue>.Fetch(CancellationToken cancellationToken)
        {
            var instance = await EnsureInstance(cancellationToken);
            var node = instance.NodeAssignments[_roundRobiner];
            var offsets = instance.ReadOffsets.Where(r => node.TopicPartitions.Contains(r.Key));
            var fetchResponse = await ConsumerProtocol.Fetch(
                node.Connection,
                offsets,
                _config,
                cancellationToken
            );
            if (fetchResponse.ErrorCodeField == 0)
            {
                _roundRobiner = (_roundRobiner + 1) % instance.NodeAssignments.Length;
                return new FetchResultEnumerator<TKey, TValue>(
                    fetchResponse,
                    _keyDeserializer,
                    _valueDeserializer,
                    (tp, o) => SetNextOffset(instance, tp, o)
                );
            }
            else
            {
                var error = Errors.Translate(fetchResponse.ErrorCodeField);
                throw new ApiException(error);
            }
        }

        private async Task<IConsumerGroupInstance> EnsureInstance(CancellationToken cancellationToken)
        {
            switch (_instance)
            {
                case { State: CoordinatorState.Consuming }:
                    return _instance;
                default:
                    _roundRobiner = 0;
                    _instance = await _group.JoinGroup(
                        _topics,
                        cancellationToken
                    );
                    await _instance.Start(cancellationToken);
                    return _instance;
            }
        }

        private static void SetNextOffset(IConsumerGroupInstance instance, TopicPartition topicPartition, Offset offset) =>
            instance.ReadOffsets[topicPartition] = offset
        ;

        async Task IInputStream<TKey, TValue>.Close(CancellationToken cancellationToken)
        {
            if(_instance != null)
                await _instance.Close(cancellationToken);
        }

        ValueTask<CommitResult> IInputStreamApplication<TKey, TValue>.Commit(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        ValueTask<CommitResult> IInputStreamApplication<TKey, TValue>.Commit(TopicPartitionOffset topicPartitionOffset, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        ValueTask<ImmutableArray<TopicPartitionOffset>> IInputStreamApplication<TKey, TValue>.Commit(ImmutableSortedDictionary<TopicPartition, Offset> topicPartitionOffsets, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
