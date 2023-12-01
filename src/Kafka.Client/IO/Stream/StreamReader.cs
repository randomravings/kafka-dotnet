using Kafka.Client.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Stream
{
    internal sealed class StreamReader :
        IStreamReader,
        IDisposable
    {
        private readonly IInputStream _stream;
        private readonly ILogger _logger;

        private IEnumerator<InputRecord> _enumerator = Enumerable
            .Empty<InputRecord>()
            .GetEnumerator()
        ;

        internal StreamReader(
            IInputStream stream,
            ILogger logger
        )
        {
            _stream = stream;
            _logger = logger;
        }

        async ValueTask<InputRecord> IStreamReader.Read(
            CancellationToken cancellationToken
        ) =>
            await Read(cancellationToken)
                .ConfigureAwait(false)
        ;

        async ValueTask<InputRecord> IStreamReader.Read(
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

        Task IStreamReader.Close(
            CancellationToken cancellationToken
        ) => Task.CompletedTask;

        private async ValueTask<InputRecord> Read(
            CancellationToken cancellationToken
        )
        {
            var record = await NextRecord(
                cancellationToken
            ).ConfigureAwait(false);
            _stream.UpdateOffsets(record.TopicPartition, record.Offset + 1);
            return record;
        }

        private async ValueTask<InputRecord> NextRecord(
            CancellationToken cancellationToken
        )
        {
            while (true)
            {
                if (_enumerator.MoveNext())
                    return _enumerator.Current;
                _enumerator.Dispose();
                var records = await _stream.Read(cancellationToken).ConfigureAwait(false);
                _enumerator = records.GetEnumerator();
            }
        }

        void IDisposable.Dispose()
        {
            _enumerator.Dispose();
            GC.SuppressFinalize(this);
        }
    }



    internal sealed class StreamReader<TKey, TValue> :
        IStreamReader<TKey, TValue>,
        IDisposable
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;
        private readonly IInputStream _stream;
        private readonly ILogger _logger;

        private IEnumerator<InputRecord> _enumerator = Enumerable
            .Empty<InputRecord>()
            .GetEnumerator()
        ;

        internal StreamReader(
            IInputStream stream,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        )
        {
            _stream = stream;
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            _logger = logger;
        }

        async ValueTask<ReadRecord<TKey, TValue>> IStreamReader<TKey, TValue>.Read(
            CancellationToken cancellationToken
        ) =>
            await Read(cancellationToken)
                .ConfigureAwait(false)
        ;

        async ValueTask<ReadRecord<TKey, TValue>> IStreamReader<TKey, TValue>.Read(
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

        Task IStreamReader<TKey, TValue>.Close(
            CancellationToken cancellationToken
        ) => Task.CompletedTask;

        private async ValueTask<ReadRecord<TKey, TValue>> Read(
            CancellationToken cancellationToken
        )
        {
            var record = await NextRecord(
                cancellationToken
            ).ConfigureAwait(false);
            var key = _keyDeserializer.Read(record.Key);
            var value = _valueDeserializer.Read(record.Value);
            _stream.UpdateOffsets(record.TopicPartition, record.Offset + 1);
            return new(
                record,
                key,
                value
            );
        }

        private async ValueTask<InputRecord> NextRecord(
            CancellationToken cancellationToken
        )
        {
            while (true)
            {
                if (_enumerator.MoveNext())
                    return _enumerator.Current;
                _enumerator.Dispose();
                var records = await _stream.Read(cancellationToken).ConfigureAwait(false);
                _enumerator = records.GetEnumerator();
            }
        }

        void IDisposable.Dispose()
        {
            _enumerator.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
