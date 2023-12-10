using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.IO.Write
{
    internal class WriterBuilder :
        IWriterBuilder
    {
        protected readonly IWriteStream _stream;
        protected IPartitioner _partitioner = DefaultPartitioner.Instance;
        protected ILogger _logger = NullLogger.Instance;

        internal WriterBuilder(
            IWriteStream stream,
            IPartitioner partitioner,
            ILogger logger
        )
        {
            _stream = stream;
            _partitioner = partitioner;
            _logger = logger;
        }

        IWriterBuilder IWriterBuilder.WithLogger(
            ILogger logger
        )
        {
            _logger = logger;
            return this;
        }

        IWriterBuilder IWriterBuilder.WithPartitioner(
            IPartitioner partitioner
        )
        {
            _partitioner = partitioner;
            return this;
        }

        IStreamWriterBuilder<TKey> IWriterBuilder.WithKey<TKey>(
            ISerializer<TKey> keySerializer
        ) =>
            new StreamWriterBuilder<TKey>(
                _stream,
                keySerializer,
                _partitioner,
                _logger
            )
        ;
    }

    internal class StreamWriterBuilder<TKey> :
        WriterBuilder,
        IStreamWriterBuilder<TKey>
    {
        protected readonly ISerializer<TKey> _keySerializer;

        internal StreamWriterBuilder(
            IWriteStream stream,
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
            IWriteStream stream,
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
