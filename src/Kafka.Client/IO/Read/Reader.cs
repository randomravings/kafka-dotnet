using Kafka.Client.Model;
using Kafka.Common.Exceptions;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Read
{
    internal abstract class Reader :
        IReader,
        IDisposable
    {
        private protected readonly IReadStream _stream;
        private protected readonly ILogger _logger;
        private protected bool _initialized;


        private ReadRecordsEnumerator _enumerator = ReadRecordsEnumerator.Empty;
        private bool _disposed;

        internal Reader(
            IReadStream stream,
            ILogger logger
        )
        {
            _stream = stream;
            _logger = logger;
        }

        async ValueTask<ReadRecord> IReader.Read(
            CancellationToken cancellationToken
        ) =>
            await Read(cancellationToken)
                .ConfigureAwait(false)
        ;

        async ValueTask<ReadRecord> IReader.Read(
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

        Task IReader.Close(
            CancellationToken cancellationToken
        ) => Task.CompletedTask;

        private async ValueTask<ReadRecord> Read(
            CancellationToken cancellationToken
        )
        {
            var record = await NextRecord(
                cancellationToken
            ).ConfigureAwait(false);
            _stream.UpdateOffsets(record.TopicPartition, record.Offset + 1);
            return record;
        }

        protected async ValueTask<ReadRecord<TKey, TValue>> Read<TKey, TValue>(
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            CancellationToken cancellationToken
        )
        {
            var record = await NextRecord(
                cancellationToken
            ).ConfigureAwait(false);
            if (record.Error.Code != 0)
                throw new ApiException(record.Error);
            var key = keyDeserializer.Read(record.Key);
            var value = valueDeserializer.Read(record.Value);
            _stream.UpdateOffsets(record.TopicPartition, record.Offset + 1);
            return new(
                record.TopicPartition,
                record.Offset,
                record.Timestamp,
                key,
                value,
                record.Headers
            );
        }

        protected async ValueTask<ReadRecord> NextRecord(
            CancellationToken cancellationToken
        )
        {
            if(!_initialized)
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



    internal abstract class Reader<TKey, TValue> :
        Reader,
        IReader<TKey, TValue>
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;

        internal Reader(
            IReadStream stream,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, logger)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        async ValueTask<ReadRecord<TKey, TValue>> IReader<TKey, TValue>.Read(
            CancellationToken cancellationToken
        ) =>
            await Read(_keyDeserializer, _valueDeserializer, cancellationToken)
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
            return await Read(_keyDeserializer, _valueDeserializer, cts.Token)
                .ConfigureAwait(false)
            ;
        }

        Task IReader<TKey, TValue>.Close(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
