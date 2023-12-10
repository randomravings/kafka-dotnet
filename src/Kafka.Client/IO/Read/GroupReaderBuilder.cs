using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Read
{
    internal class GroupReaderBuilder :
        IGroupReaderBuilder
    {
        protected readonly IGroupReadStream _stream;
        protected IReadOnlySet<TopicName> _topics = ImmutableSortedSet<TopicName>.Empty;
        protected ILogger _logger = NullLogger.Instance;

        internal GroupReaderBuilder(
            IGroupReadStream stream,
            ILogger logger
        )
        {
            _stream = stream;
            _logger = logger;
        }

        protected GroupReaderBuilder(
            IGroupReadStream stream,
            IReadOnlySet<TopicName> topics,
            ILogger logger
        )
        {
            _stream = stream;
            _topics = topics;
            _logger = logger;
        }

        IGroupReaderBuilder IGroupReaderBuilder.WithTopic(TopicName topic)
        {
            _topics = new SortedSet<TopicName>(TopicNameCompare.Instance)
            {
                topic
            };
            return this;
        }

        IGroupReaderBuilder IGroupReaderBuilder.WithTopics(params TopicName[] topics)
        {
            _topics = new SortedSet<TopicName>(topics, TopicNameCompare.Instance);
            return this;
        }

        IGroupReaderBuilder IGroupReaderBuilder.WithTopics(IEnumerable<TopicName> topics)
        {
            _topics = new SortedSet<TopicName>(topics, TopicNameCompare.Instance);
            return this;
        }

        IGroupReaderBuilder IGroupReaderBuilder.WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        IApplicationReaderBuilder<TKey> IGroupReaderBuilder.WithKey<TKey>(
            IDeserializer<TKey> keyDeserializer
        ) =>
            new ApplicationReaderBuilder<TKey>(
                _stream,
                _topics,
                keyDeserializer,
                _logger
            )
        ;
    }

    internal class ApplicationReaderBuilder<TKey> :
        GroupReaderBuilder,
        IApplicationReaderBuilder<TKey>
    {
        protected readonly IDeserializer<TKey> _keyDeserializer;

        internal ApplicationReaderBuilder(
            IGroupReadStream stream,
            IReadOnlySet<TopicName> topics,
            IDeserializer<TKey> keyDeserializer,
            ILogger logger
        ) : base(stream, topics, logger)
        {
            _topics = topics;
            _keyDeserializer = keyDeserializer;
        }

        IApplicationReaderBuilder<TKey, TValue> IApplicationReaderBuilder<TKey>.WithValue<TValue>(
            IDeserializer<TValue> valueDeserializer
        ) =>
            new ApplicationReaderBuilder<TKey, TValue>(
                _stream,
                _topics,
                _keyDeserializer,
                valueDeserializer,
                _logger
            )
        ;
    }

    internal class ApplicationReaderBuilder<TKey, TValue> :
        ApplicationReaderBuilder<TKey>,
        IApplicationReaderBuilder<TKey, TValue>
    {
        private readonly IDeserializer<TValue> _valueDeserializer;

        internal ApplicationReaderBuilder(
            IGroupReadStream stream,
            IReadOnlySet<TopicName> topics,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, topics, keyDeserializer, logger)
        {
            _valueDeserializer = valueDeserializer;
        }

        IGroupReader<TKey, TValue> IApplicationReaderBuilder<TKey, TValue>.Build() =>
            new GroupReader<TKey, TValue>(
                _stream,
                _topics,
                _keyDeserializer,
                _valueDeserializer,
                _logger
            )
        ;
    }
}
