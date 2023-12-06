using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.IO.Read
{
    internal class ManualReaderBuilder :
        IManualReaderBuilder
    {
        protected readonly IManualReadStream _stream;
        protected IReadOnlyList<TopicPartition> _topicPartitions = [];
        protected ILogger _logger = NullLogger.Instance;

        internal ManualReaderBuilder(
            IManualReadStream stream,
            ILogger logger
        )
        {
            _stream = stream;
            _logger = logger;
        }

        protected ManualReaderBuilder(
            IManualReadStream stream,
            IReadOnlyList<TopicPartition> topicPartitions,
            ILogger logger
        )
        {
            _stream = stream;
            _topicPartitions = topicPartitions;
            _logger = logger;
        }

        IManualReaderBuilder IManualReaderBuilder.WithTopicPartitions(params TopicPartition[] topicPartitions)
        {
            _topicPartitions = topicPartitions;
            return this;
        }

        IManualReaderBuilder IManualReaderBuilder.WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        IManualReaderBuilder<TKey> IManualReaderBuilder.WithKey<TKey>(
            IDeserializer<TKey> keyDeserializer
        ) =>
            new ManualReaderBuilder<TKey>(
                _stream,
                _topicPartitions,
                keyDeserializer,
                _logger
            )
        ;
    }

    internal class ManualReaderBuilder<TKey> :
        ManualReaderBuilder,
        IManualReaderBuilder<TKey>
    {
        protected readonly IDeserializer<TKey> _keyDeserializer;

        internal ManualReaderBuilder(
            IManualReadStream stream,
            IReadOnlyList<TopicPartition> topics,
            IDeserializer<TKey> keyDeserializer,
            ILogger logger
        ) : base(stream, topics, logger)
        {
            _topicPartitions = topics;
            _keyDeserializer = keyDeserializer;
        }

        IManualReaderBuilder<TKey, TValue> IManualReaderBuilder<TKey>.WithValue<TValue>(
            IDeserializer<TValue> valueDeserializer
        ) =>
            new ManualReaderBuilder<TKey, TValue>(
                _stream,
                _topicPartitions,
                _keyDeserializer,
                valueDeserializer,
                _logger
            )
        ;
    }

    internal class ManualReaderBuilder<TKey, TValue> :
        ManualReaderBuilder<TKey>,
        IManualReaderBuilder<TKey, TValue>
    {
        private readonly IDeserializer<TValue> _valueDeserializer;

        internal ManualReaderBuilder(
            IManualReadStream stream,
            IReadOnlyList<TopicPartition> topics,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, topics, keyDeserializer, logger)
        {
            _valueDeserializer = valueDeserializer;
        }

        IManualReader<TKey, TValue> IManualReaderBuilder<TKey, TValue>.Build() =>
            new ManualReader<TKey, TValue>(
                _stream,
                _topicPartitions,
                _keyDeserializer,
                _valueDeserializer,
                _logger
            )
        ;
    }
}
