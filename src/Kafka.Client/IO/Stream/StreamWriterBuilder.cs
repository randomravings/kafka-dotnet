using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.IO.Stream
{
    internal class StreamWriterBuilder :
        IStreamWriterBuilder
    {
        protected readonly IOutputStream _stream;
        protected IPartitioner _partitioner = DefaultPartitioner.Instance;
        protected ILogger _logger = NullLogger.Instance;

        internal StreamWriterBuilder(
            IOutputStream stream,
            IPartitioner partitioner,
            ILogger logger
        )
        {
            _stream = stream;
            _partitioner = partitioner;
            _logger = logger;
        }

        IStreamWriterBuilder IStreamWriterBuilder.WithLogger(
            ILogger logger
        )
        {
            _logger = logger;
            return this;
        }

        IStreamWriterBuilder IStreamWriterBuilder.WithPartitioner(
            IPartitioner partitioner
        )
        {
            _partitioner = partitioner;
            return this;
        }

        IStreamWriterBuilder<TKey> IStreamWriterBuilder.WithKey<TKey>(
            ISerializer<TKey> keySerializer
        ) =>
            new StreamWriterBuilder<TKey>(
                _stream,
                keySerializer,
                _partitioner,
                _logger
            )
        ;

        IStreamWriter IStreamWriterBuilder.Build() =>
            new StreamWriter(
                _stream,
                _partitioner,
                _logger
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
            ISerializer<TKey> keySerializer,
            IPartitioner partitioner,
            ILogger logger
        )
            : base(stream, partitioner, logger)
        {
            _keySerializer = keySerializer;
        }

        IStreamWriterBuilder<TKey, TValue> IStreamWriterBuilder<TKey>.WithValue<TValue>(
            ISerializer<TValue> valueSerialzier
        ) =>
            new StreamWriterBuilder<TKey, TValue>(
                _stream,
                _keySerializer,
                valueSerialzier,
                _partitioner,
                _logger
            )
        ;
    }

    internal sealed class StreamWriterBuilder<TKey, TValue> :
        StreamWriterBuilder<TKey>,
        IStreamWriterBuilder<TKey, TValue>
    {
        private readonly ISerializer<TValue> _valueSerializer;

        internal StreamWriterBuilder(
            IOutputStream stream,
            ISerializer<TKey> keySerializer,
            ISerializer<TValue> valueSerializer,
            IPartitioner partitioner,
            ILogger logger
        )
            : base(stream, keySerializer, partitioner, logger)
        {
            _valueSerializer = valueSerializer;
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
