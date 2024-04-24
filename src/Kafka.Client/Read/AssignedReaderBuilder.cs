using Kafka.Client;
using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Immutable;

namespace Kafka.Client.Read
{
    internal class AssignedReaderBuilder :
        IAssignedReaderBuilder
    {
        protected readonly IAssignedReadStream _stream;
        protected IReadOnlyList<TopicPartitionOffset> _topicPartitionOffsets = [];
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
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets,
            ILogger logger
        )
        {
            _stream = stream;
            _topicPartitionOffsets = topicPartitionOffsets;
            _logger = logger;
        }

        IAssignedReaderBuilder IAssignedReaderBuilder.WithTopicPartitionOffsets(IEnumerable<TopicPartitionOffset> topicPartitionOffsets)
        {
            _topicPartitionOffsets = topicPartitionOffsets.ToImmutableArray();
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
            new AssignedReaderBuilder<TKey>(
                _stream,
                _topicPartitionOffsets,
                keyDeserializer,
                _logger
            )
        ;
    }

    internal class AssignedReaderBuilder<TKey> :
        AssignedReaderBuilder,
        IManualReaderBuilder<TKey>
    {
        protected readonly IDeserializer<TKey> _keyDeserializer;

        internal AssignedReaderBuilder(
            IAssignedReadStream stream,
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets,
            IDeserializer<TKey> keyDeserializer,
            ILogger logger
        ) : base(stream, topicPartitionOffsets, logger)
        {
            _keyDeserializer = keyDeserializer;
        }

        IManualReaderBuilder<TKey, TValue> IManualReaderBuilder<TKey>.WithValue<TValue>(
            IDeserializer<TValue> valueDeserializer
        ) =>
            new AssignedReaderBuilder<TKey, TValue>(
                _stream,
                _topicPartitionOffsets,
                _keyDeserializer,
                valueDeserializer,
                _logger
            )
        ;
    }

    internal class AssignedReaderBuilder<TKey, TValue> :
        AssignedReaderBuilder<TKey>,
        IManualReaderBuilder<TKey, TValue>
    {
        private readonly IDeserializer<TValue> _valueDeserializer;

        internal AssignedReaderBuilder(
            IAssignedReadStream stream,
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, topicPartitionOffsets, keyDeserializer, logger)
        {
            _valueDeserializer = valueDeserializer;
        }

        IAssignedReader<TKey, TValue> IManualReaderBuilder<TKey, TValue>.Build() =>
            new AssignedReader<TKey, TValue>(
                _stream,
                _topicPartitionOffsets,
                _keyDeserializer,
                _valueDeserializer,
                _logger
            )
        ;
    }
}
