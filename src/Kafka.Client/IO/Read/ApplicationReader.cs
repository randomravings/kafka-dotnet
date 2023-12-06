using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Read
{
    internal class ApplicationReader<TKey, TValue> :
        Reader<TKey, TValue>,
        IApplicationReader<TKey, TValue>
    {
        private protected readonly IApplicationReadStream _applicationStream;
        private protected readonly ISet<TopicName> _topics = new SortedSet<TopicName>(TopicNameCompare.Instance);

        internal ApplicationReader(
            IApplicationReadStream stream,
            IReadOnlySet<TopicName> topics,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, keyDeserializer, valueDeserializer, logger)
        {
            _applicationStream = stream;
            foreach (var topic in topics)
                _topics.Add(topic);
        }

        ValueTask<bool> IApplicationReader<TKey, TValue>.SetTopics(IEnumerable<TopicName> topics)
        {
            if (_topics.SetEquals(topics))
                return ValueTask.FromResult(false);
            _topics.Clear();
            foreach (var topic in topics)
                _topics.Add(topic);
            _initialized = false;
            return ValueTask.FromResult(true);
        }

        ValueTask<bool> IApplicationReader<TKey, TValue>.AddTopics(IEnumerable<TopicName> topics)
        {
            var added = false;
            foreach (var topic in topics)
                added |= _topics.Add(topic);
            _initialized = !added;
            return ValueTask.FromResult(true);
        }

        ValueTask<bool> IApplicationReader<TKey, TValue>.RemoveTopics(IEnumerable<TopicName> topics)
        {
            var removed = false;
            foreach (var topic in topics)
                removed |= _topics.Remove(topic);
            _initialized = !removed;
            return ValueTask.FromResult(true);
        }

        protected override async ValueTask Initialize(CancellationToken cancellationToken)
        {
            await _applicationStream.AddReader(
                _topics.ToImmutableSortedSet(TopicNameCompare.Instance),
                cancellationToken
            ).ConfigureAwait(false);
            _initialized = true;
        }
    }
}
