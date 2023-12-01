using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record ReadRecord<TKey, TValue>(
        InputRecord Record,
        OptionalValue<TKey> Key,
        OptionalValue<TValue> Value
    );
}
