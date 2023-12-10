using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Collections
{
    internal sealed class ImmutableTopicPartitionMap<TValue>
        where TValue : class
    {
        private readonly ImmutableArray<KeyValuePair<TopicPartition, TValue>> _values;
        private readonly ImmutableDictionary<TopicPartition, int> _ids;
        private readonly ImmutableDictionary<TopicPartition, int> _names;

        internal ImmutableTopicPartitionMap(
            IEnumerable<KeyValuePair<TopicPartition, TValue>> values
        )
        {
            _values = values.ToImmutableArray();
            var idsBuilder = ImmutableDictionary.CreateBuilder<TopicPartition, int>(TopicPartitionByIdCompare.Equality);
            var namesBuilder = ImmutableDictionary.CreateBuilder<TopicPartition, int>(TopicPartitionCompare.Equality);
            for(int i = 0; i < _values.Length; i++)
            {
                var item = _values[i];
                if (!item.Key.Topic.TopicId.IsEmpty)
                    idsBuilder.Add(item.Key, i);
                if (!item.Key.Topic.TopicName.IsEmpty)
                    namesBuilder.Add(item.Key, i);
            }
            _ids = idsBuilder.ToImmutable();
            _names = namesBuilder.ToImmutable();
            if (_names.Count != _values.Length)
                throw new ArgumentException("TopicParition with empty or null topic names are not allowed", nameof(values));
        }

        public ImmutableArray<KeyValuePair<TopicPartition, TValue>> Values => _values;

        public KeyValuePair<TopicPartition, TValue> this[in TopicPartition key]
        {
            get
            {
                if (Get(key, out var value))
                    return value;
                else
                    throw new KeyNotFoundException(key.ToString());
            }
        }

        public bool Contains(
            in TopicPartition key
        ) =>
            TryGetIndex(key, out _)
        ;

        public bool Get(
            in TopicPartition key,
            [MaybeNullWhen(false)] out KeyValuePair<TopicPartition, TValue> value
        )
        {   
            if(TryGetIndex(key, out var index))
            {
                value = _values[index];
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        public bool Set(
            in TopicPartition key,
            Action<TValue> setter
        )
        {
            if (TryGetIndex(key, out var index))
            {
                setter(_values[index].Value);
                return true;
            }
            return false;
        }

        private bool TryGetIndex(
            in TopicPartition key,
            [MaybeNullWhen(false)] out int index
        ) =>
            key.Topic.TopicId.IsEmpty ?
                _names.TryGetValue(key, out index) :
                _ids.TryGetValue(key, out index)
        ;
    }
}
