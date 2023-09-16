using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="Topic">Topic to send record to.</param>
    /// <param name="Partition">Partition to send record to. <see cref="Partition.Unassigned"/> will defer partition assigmne to partitioner.</param>
    /// <param name="Timestamp">Timestamp to stamp record. <see cref="Timestamp.None"/> will defer timestamp selection</param>
    /// <param name="Key">Key for the record. A null value will ignore the assigned partitioner at cause the record to be randomly assigned.</param>
    /// <param name="Value">Value for the record. A null value is only useful if accomanied by a key to delete it from a compacted topic.</param>
    /// <param name="Headers">Header key values for the record.</param>
    public sealed record ProduceRecord<TKey, TValue>(
        TopicName Topic,
        OptionalValue<TKey> Key,
        OptionalValue<TValue> Value,
        Partition Partition,
        Timestamp Timestamp,
        ImmutableArray<RecordHeader> Headers
    )
    {
        public ProduceRecord(
            TopicName Topic,
            OptionalValue<TKey> Key,
            OptionalValue<TValue> Value
        ) : this(
                Topic,
                Key,
                Value,
                Partition.Unassigned,
                Timestamp.None,
                ImmutableArray<RecordHeader>.Empty
            )
        { }

        public ProduceRecord(
            TopicName Topic,
            OptionalValue<TKey> Key,
            OptionalValue<TValue> Value,
            Timestamp Timestamp
        ) : this(
                Topic,
                Key,
                Value,
                Partition.Unassigned,
                Timestamp,
                ImmutableArray<RecordHeader>.Empty
            )
        { }

        public ProduceRecord(
            TopicName Topic,
            OptionalValue<TKey> Key,
            OptionalValue<TValue> Value,
            Timestamp Timestamp,
            ImmutableArray<RecordHeader> Headers
        ) : this(
                Topic,
                Key,
                Value,
                Partition.Unassigned,
                Timestamp,
                Headers
            )
        { }
    }
}
