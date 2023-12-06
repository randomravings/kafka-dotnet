using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Read
{
    internal class ApplicationReaderBuilder :
        IApplicationReaderBuilder
    {
        protected readonly IApplicationReadStream _stream;
        protected IReadOnlySet<TopicName> _topics = ImmutableSortedSet<TopicName>.Empty;
        protected ILogger _logger = NullLogger.Instance;

        internal ApplicationReaderBuilder(
            IApplicationReadStream stream,
            ILogger logger
        )
        {
            _stream = stream;
            _logger = logger;
        }

        protected ApplicationReaderBuilder(
            IApplicationReadStream stream,
            IReadOnlySet<TopicName> topics,
            ILogger logger
        )
        {
            _stream = stream;
            _topics = topics;
            _logger = logger;
        }

        IApplicationReaderBuilder IApplicationReaderBuilder.WithTopic(TopicName topic)
        {
            _topics = new SortedSet<TopicName>(TopicNameCompare.Instance)
            {
                topic
            };
            return this;
        }

        IApplicationReaderBuilder IApplicationReaderBuilder.WithTopics(params TopicName[] topics)
        {
            _topics = new SortedSet<TopicName>(topics, TopicNameCompare.Instance);
            return this;
        }

        IApplicationReaderBuilder IApplicationReaderBuilder.WithTopics(IEnumerable<TopicName> topics)
        {
            _topics = new SortedSet<TopicName>(topics, TopicNameCompare.Instance);
            return this;
        }

        IApplicationReaderBuilder IApplicationReaderBuilder.WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        IApplicationReader IApplicationReaderBuilder.Build() =>
            new ApplicationReader(
                _stream,
                _topics,
                _logger
            )
        ;

        IApplicationReaderBuilder<TKey> IApplicationReaderBuilder.WithKey<TKey>(
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
        ApplicationReaderBuilder,
        IApplicationReaderBuilder<TKey>
    {
        protected readonly IDeserializer<TKey> _keyDeserializer;

        internal ApplicationReaderBuilder(
            IApplicationReadStream stream,
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
            IApplicationReadStream stream,
            IReadOnlySet<TopicName> topics,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, topics, keyDeserializer, logger)
        {
            _valueDeserializer = valueDeserializer;
        }

        IApplicationReader<TKey, TValue> IApplicationReaderBuilder<TKey, TValue>.Build() =>
            new ApplicationReader<TKey, TValue>(
                _stream,
                _topics,
                _keyDeserializer,
                _valueDeserializer,
                _logger
            )
        ;
    }
}
