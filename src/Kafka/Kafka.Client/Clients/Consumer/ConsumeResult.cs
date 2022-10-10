using Kafka.Common;
using System.Collections;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public sealed class ConsumeResult<TKey, TValue> :
        IEnumerable<ConsumerRecord<TKey, TValue>>
        where TKey : notnull
        where TValue : notnull
    {
        private readonly ImmutableDictionary<TopicPartition, ImmutableArray<ConsumerRecord<TKey, TValue>>> _records;
        public ConsumeResult(IDictionary<TopicPartition, IList<ConsumerRecord<TKey, TValue>>> records) =>
            _records = records.ToImmutableDictionary(k => k.Key, v => v.Value.ToImmutableArray());

        public IEnumerator<ConsumerRecord<TKey, TValue>> GetEnumerator()
        {
            foreach (var record in _records.Values.SelectMany(r => r))
                yield return record;
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator()
        ;
    }
}
