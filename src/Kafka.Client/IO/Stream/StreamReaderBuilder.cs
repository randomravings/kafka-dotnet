using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.IO.Stream
{
    internal class StreamReaderBuilder :
        IStreamReaderBuilder
    {
        protected readonly IInputStream _stream;

        internal StreamReaderBuilder(
            IInputStream stream
        )
        {
            _stream = stream;
        }

        IStreamReaderBuilder<TKey> IStreamReaderBuilder.WithKey<TKey>(IDeserializer<TKey> keyDeserializer) =>
            new StreamReaderValueBuilder<TKey>(
                _stream,
                keyDeserializer
            )
        ;
    }

    internal class StreamReaderValueBuilder<TKey> :
        StreamReaderBuilder,
        IStreamReaderBuilder<TKey>
    {
        protected readonly IDeserializer<TKey> _keyDeserializer;
        internal StreamReaderValueBuilder(
            IInputStream stream,
            IDeserializer<TKey> keyDeserializer
        ) : base(stream)
        {
            _keyDeserializer = keyDeserializer;
        }

        IStreamReaderBuilder<TKey, TValue> IStreamReaderBuilder<TKey>.WithValue<TValue>(IDeserializer<TValue> valueDeserializer) =>
            new StreamReaderBuilder<TKey, TValue>(
                _stream,
                _keyDeserializer,
                valueDeserializer
            )
        ;
    }

    internal class StreamReaderBuilder<TKey, TValue> :
        StreamReaderValueBuilder<TKey>,
        IStreamReaderBuilder<TKey, TValue>
    {
        private readonly IDeserializer<TValue> _valueDeserializer;
        private ILogger _logger = NullLogger.Instance;
        internal StreamReaderBuilder(
            IInputStream stream,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        ) : base(stream, keyDeserializer)
        {
            _valueDeserializer = valueDeserializer;
        }
        IStreamReaderBuilder<TKey, TValue> IStreamReaderBuilder<TKey, TValue>.WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        IStreamReader<TKey, TValue> IStreamReaderBuilder<TKey, TValue>.Build() =>
            new StreamReader<TKey, TValue>(
                _stream,
                _keyDeserializer,
                _valueDeserializer,
                _logger
            )
        ;
    }
}
