using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.IO.Stream
{
    internal class StreamWriterBuilder :
        IStreamWriterBuilder
    {
        protected readonly IOutputStream _stream;
        internal StreamWriterBuilder(
            IOutputStream stream
        )
        {
            _stream = stream;
        }
        IStreamWriterBuilder<TKey> IStreamWriterBuilder.WithKey<TKey>(
            ISerializer<TKey> keySerializer
        ) =>
            new StreamWriterBuilder<TKey>(
                _stream,
                keySerializer
            )
        ;
    }

    internal class StreamWriterBuilder<TKey> :
        StreamWriterBuilder,
        IStreamWriterBuilder<TKey>
    {
        protected readonly ISerializer<TKey> _keySerializer;
        internal StreamWriterBuilder(
            IOutputStream stream,
            ISerializer<TKey> keySerializer
        )
            : base(stream)
        {
            _keySerializer = keySerializer;
        }

        IStreamWriterBuilder<TKey, TValue> IStreamWriterBuilder<TKey>.WithValue<TValue>(
            ISerializer<TValue> valueSerialzier
        ) =>
            new StreamWriterBuilder<TKey, TValue>(
                _stream,
                _keySerializer,
                valueSerialzier
            )
        ;
    }

    internal sealed class StreamWriterBuilder<TKey, TValue> :
        StreamWriterBuilder<TKey>,
        IStreamWriterBuilder<TKey, TValue>
    {
        private readonly ISerializer<TValue> _valueSerializer;
        private ILogger _logger = NullLogger.Instance;
        private IPartitioner _partitioner = DefaultPartitioner.Instance;

        internal StreamWriterBuilder(
            IOutputStream stream,
            ISerializer<TKey> keySerializer,
            ISerializer<TValue> valueSerializer
        )
            : base(stream, keySerializer)
        {
            _valueSerializer = valueSerializer;
        }

        IStreamWriterBuilder<TKey, TValue> IStreamWriterBuilder<TKey, TValue>.WithLogger(
            ILogger logger
        )
        {
            _logger = logger;
            return this;
        }

        IStreamWriterBuilder<TKey, TValue> IStreamWriterBuilder<TKey, TValue>.WithPartitioner(
            IPartitioner partitioner
        )
        {
            _partitioner = partitioner;
            return this;
        }

        IStreamWriter<TKey, TValue> IStreamWriterBuilder<TKey, TValue>.Build() =>
            new StreamWriter<TKey, TValue>(
                _stream,
                _keySerializer,
                _valueSerializer,
                _partitioner,
                _logger
            )
        ;
    }
}
