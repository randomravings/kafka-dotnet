using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.IO.Stream
{
    internal class StreamReaderBuilder :
        IStreamReaderBuilder
    {
        protected readonly IInputStream _stream;
        protected ILogger _logger = NullLogger.Instance;

        internal StreamReaderBuilder(
            IInputStream stream,
            ILogger logger
        )
        {
            _stream = stream;
            _logger = logger;
        }

        IStreamReaderBuilder IStreamReaderBuilder.WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        IStreamReader IStreamReaderBuilder.Build() =>
            new StreamReader(
                _stream,
                _logger
            )
        ;

        IStreamReaderBuilder<TKey> IStreamReaderBuilder.WithKey<TKey>(
            IDeserializer<TKey> keyDeserializer
        ) =>
            new StreamReaderValueBuilder<TKey>(
                _stream,
                keyDeserializer,
                _logger
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
            IDeserializer<TKey> keyDeserializer,
            ILogger logger
        ) : base(stream, logger)
        {
            _keyDeserializer = keyDeserializer;
        }

        IStreamReaderBuilder<TKey, TValue> IStreamReaderBuilder<TKey>.WithValue<TValue>(
            IDeserializer<TValue> valueDeserializer
        ) =>
            new StreamReaderBuilder<TKey, TValue>(
                _stream,
                _keyDeserializer,
                valueDeserializer,
                _logger
            )
        ;
    }

    internal class StreamReaderBuilder<TKey, TValue> :
        StreamReaderValueBuilder<TKey>,
        IStreamReaderBuilder<TKey, TValue>
    {
        private readonly IDeserializer<TValue> _valueDeserializer;

        internal StreamReaderBuilder(
            IInputStream stream,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, keyDeserializer, logger)
        {
            _valueDeserializer = valueDeserializer;
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
