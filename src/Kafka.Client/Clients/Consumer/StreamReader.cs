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

        private readonly ConcurrentQueue<FetchResultEnumerator> _fetchResultEnumerators = new();
        private FetchResultEnumerator _enumerator = FetchResultEnumerator.Empty;
        private bool disposedValue;
        private readonly ManualResetEventSlim _resetEvent = new(true);

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
            var record = await NextRecord(cancellationToken).ConfigureAwait(false);
            _trackedOffsets[record.TopicPartition] = record.Offset + 1;
            return record;
        }

        async Task IStreamReader<TKey, TValue>.Close(CancellationToken cancellationToken) =>
            await Closing(cancellationToken).ConfigureAwait(false)
        ;

        protected abstract ValueTask PrepareFetch(CancellationToken cancellationToken);

        protected abstract ValueTask Closing(CancellationToken cancellationToken);

        protected void ResetFetchResults()
        {
            _fetchResultEnumerators.Clear();
            _enumerator = FetchResultEnumerator.Empty;
        }

        protected IConsumerChannel CreateChannel(
            NodeAssignment assignment
        )
        {
            var connection = new SaslPlaintextTransport(assignment.Host, assignment.Port);
            var protocol = new ConsumerProtocol(connection, _config, _logger);
            return new ConsumerChannel(
                assignment.NodeId,
                protocol,
                _fetchResultEnumerators,
                _resetEvent,
                _config,
                _logger
            );
        }

        private async ValueTask<ConsumerRecord<TKey, TValue>> NextRecord(CancellationToken cancellationToken)
        {
            await PrepareFetch(cancellationToken).ConfigureAwait(false);
            while (true)
            {
                switch (_enumerator.MoveNext())
                {
                    case FetchEnumeratorState.Active:
                        return _enumerator.ReadRecord(_keyDeserializer, _valueDeserializer);
                    case FetchEnumeratorState.End:
                        var record = _enumerator.ReadRecord(_keyDeserializer, _valueDeserializer);
                        _enumerator.Close();
                        return record;
                }
                while (true)
                {
                    if (_fetchResultEnumerators.TryDequeue(out var enumerator))
                    {
                        _enumerator = enumerator;
                        break;
                    }
                    _resetEvent.Wait(cancellationToken);
                    _resetEvent.Reset();
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _resetEvent.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
