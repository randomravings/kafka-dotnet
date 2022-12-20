using Kafka.Common.Types;
using System.Collections;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public sealed record ConsumeResult<TKey, TValue>(
        ImmutableArray<ConsumerRecord<TKey, TValue>> Records
    );
}
