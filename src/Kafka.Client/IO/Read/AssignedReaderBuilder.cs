using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.IO.Read
{
    internal class AssignedReaderBuilder :
        IAssignedReaderBuilder
    {
        protected readonly IAssignedReadStream _stream;
        protected IReadOnlyList<TopicPartition> _topicPartitions = [];
        protected ILogger _logger = NullLogger.Instance;

        internal AssignedReaderBuilder(
            IAssignedReadStream stream,
            ILogger logger
        )
        {
            _stream = stream;
            _logger = logger;
        }

        protected AssignedReaderBuilder(
            IAssignedReadStream stream,
            IReadOnlyList<TopicPartition> topicPartitions,
            ILogger logger
        )
        {
            _stream = stream;
            _topicPartitions = topicPartitions;
            _logger = logger;
        }

        IAssignedReaderBuilder IAssignedReaderBuilder.WithTopicPartitions(params TopicPartition[] topicPartitions)
        {
            _topicPartitions = topicPartitions;
            return this;
        }

        IAssignedReaderBuilder IAssignedReaderBuilder.WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        IManualReaderBuilder<TKey> IAssignedReaderBuilder.WithKey<TKey>(
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
        AssignedReaderBuilder,
        IManualReaderBuilder<TKey>
    {
        protected readonly IDeserializer<TKey> _keyDeserializer;

        internal ManualReaderBuilder(
            IAssignedReadStream stream,
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
            IAssignedReadStream stream,
            IReadOnlyList<TopicPartition> topics,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, topics, keyDeserializer, logger)
        {
            _valueDeserializer = valueDeserializer;
        }

        IAssignedReader<TKey, TValue> IManualReaderBuilder<TKey, TValue>.Build() =>
            new AssignedReader<TKey, TValue>(
                _stream,
                _topicPartitions,
                _keyDeserializer,
                _valueDeserializer,
                _logger
            )
        ;
    }
}
