using Kafka.Client;
using Kafka.Client.Model;
using Kafka.Common.Exceptions;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Read
{
    internal abstract class Reader<TKey, TValue> :
        IReader<TKey, TValue>,
        IDisposable
    {
        private readonly IReadStream _stream;
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private protected readonly ILogger _logger;
        private ReadRecordsEnumerator _enumerator = ReadRecordsEnumerator.Empty;
        private bool _disposed;
        private protected bool _initialized;

        internal Reader(
            IReadStream stream,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        )
        {
            _stream = stream;
            _logger = logger;
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        async ValueTask<ReadRecord<TKey, TValue>> IReader<TKey, TValue>.Read(
            CancellationToken cancellationToken
        ) =>
            await Read(cancellationToken)
            .ConfigureAwait(false)
            ;

        async ValueTask<ReadRecord<TKey, TValue>> IReader<TKey, TValue>.Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        )
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(
                cancellationToken
            );
            cts.CancelAfter(timeout);
            return await Read(cts.Token)
                .ConfigureAwait(false)
            ;
        }

        Task IReader<TKey, TValue>.Close(
            CancellationToken cancellationToken
        ) => Task.CompletedTask;

        private async ValueTask<ReadRecord<TKey, TValue>> Read(
            CancellationToken cancellationToken
        )
        {
            var record = await NextRecord(
                cancellationToken
            ).ConfigureAwait(false);
            if (record.Error.Code != 0)
                throw new ApiException(record.Error);
            var key = _keyDeserializer.Read(record.Key);
            var value = _valueDeserializer.Read(record.Value);
            _stream.UpdateOffset(record.TopicPartition, record.Offset + 1);
            return new(
                record.TopicPartition,
                record.Offset,
                record.Timestamp,
                key,
                value,
                record.Headers
            );
        }

        private async ValueTask<ReadRecord> NextRecord(
            CancellationToken cancellationToken
        )
        {
            if (!_initialized)
                await Initialize(
                    cancellationToken
                ).ConfigureAwait(false);
            while (true)
            {
                if (_enumerator.TryGetNext(out var record))
                    return record;
                var records = await _stream.Read(cancellationToken).ConfigureAwait(false);
                _enumerator = new(records);
            }
        }

        protected abstract ValueTask Initialize(CancellationToken cancellationToken);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                }
                _disposed = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
