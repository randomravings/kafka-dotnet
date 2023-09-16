using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Collections;
using Kafka.Common.Network;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Kafka.Client.Clients.Consumer
{
    internal abstract class StreamReader<TKey, TValue> :
        IStreamReader<TKey, TValue>
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        protected readonly ConsumerConfig _config;
        protected readonly ILogger<IConsumer<TKey, TValue>> _logger;
        protected readonly int _sessionTimeoutMs;
        protected readonly int _maxPollIntervalMs;
        protected readonly IList<IConsumerChannel> _consumerChannels = new List<IConsumerChannel>();
        protected readonly ConcurrentTopicPartitionOffsets _trackedOffsets = new();

        private readonly BlockingCollection<FetchResultEnumerator> _fetchResultEnumerators = new();
        private FetchResultEnumerator _enumerator = FetchResultEnumerator.Empty;
        private CancellationTokenSource _internalCTS = new();
        private readonly AutoResetEvent _autoCommitHandle = new(false);
        private readonly SemaphoreSlim _commitSync = new(1, 1);

        protected StreamReader(
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ConsumerConfig config,
            ILogger<IConsumer<TKey, TValue>> logger
        )
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            _sessionTimeoutMs = config.SessionTimeoutMs;
            _maxPollIntervalMs = config.MaxPollIntervalMs;
            _config = config;
            _logger = logger;
        }

        async Task<ConsumerRecord<TKey, TValue>> IStreamReader<TKey, TValue>.Fetch(CancellationToken cancellationToken)
        {
            await Fetching(cancellationToken).ConfigureAwait(false);
            var record = NextRecord(cancellationToken);
            _trackedOffsets[record.TopicPartition] = record.Offset + 1;
            return record;
        }

        async Task IStreamReader<TKey, TValue>.Close(CancellationToken cancellationToken) =>
            await Closing(cancellationToken).ConfigureAwait(false)
        ;

        void IDisposable.Dispose()
        {
            _fetchResultEnumerators.Dispose();
            _internalCTS.Dispose();
            _commitSync.Dispose();
            _autoCommitHandle.Dispose();
            _enumerator.Dispose();
        }

        protected abstract ValueTask Fetching(CancellationToken cancellationToken);

        protected abstract ValueTask Closing(CancellationToken cancellationToken);

        protected void ResetFetchResults()
        {
            while (_fetchResultEnumerators.Count > 0)
            {
                var enumerator = _fetchResultEnumerators.Take();
                enumerator.Dispose();
            }
            _enumerator.Dispose();
            _enumerator = FetchResultEnumerator.Empty;
        }

        protected IConsumerChannel CreateChannel(NodeAssignment assignment)
        {
            var connection = new SaslPlaintextTransport(assignment.Host, assignment.Port);
            var protocol = new ConsumerProtocol(connection, _config, _logger);
            return new ConsumerChannel(assignment.NodeId, protocol, assignment.TopicPartitionOffsets, _fetchResultEnumerators, _config, _logger);
        }

        private ConsumerRecord<TKey, TValue> NextRecord(CancellationToken cancellationToken)
        {
            while (!_enumerator.MoveNext())
            {
                _enumerator.Dispose();
                _enumerator = _fetchResultEnumerators.Take(cancellationToken);
            }
            return _enumerator.ReadRecord(_keyDeserializer, _valueDeserializer);
        }
    }
}
