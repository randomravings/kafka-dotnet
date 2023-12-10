using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Read
{
    internal class GroupReader<TKey, TValue> :
        Reader<TKey, TValue>,
        IGroupReader<TKey, TValue>
    {
        private protected readonly IGroupReadStream _applicationStream;
        private protected readonly ISet<TopicName> _topics = new SortedSet<TopicName>(TopicNameCompare.Instance);

        internal GroupReader(
            IGroupReadStream stream,
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

        ValueTask<bool> IGroupReader<TKey, TValue>.SetTopics(IEnumerable<TopicName> topics)
        {
            if (_topics.SetEquals(topics))
                return ValueTask.FromResult(false);
            _topics.Clear();
            foreach (var topic in topics)
                _topics.Add(topic);
            _initialized = false;
            return ValueTask.FromResult(true);
        }

        ValueTask<bool> IGroupReader<TKey, TValue>.AddTopics(IEnumerable<TopicName> topics)
        {
            var added = false;
            foreach (var topic in topics)
                added |= _topics.Add(topic);
            _initialized = !added;
            return ValueTask.FromResult(true);
        }

        ValueTask<bool> IGroupReader<TKey, TValue>.RemoveTopics(IEnumerable<TopicName> topics)
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
