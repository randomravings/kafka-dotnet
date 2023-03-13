using Kafka.Common.Model;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record ConsumeResult(
        TopicPartition TopicPartition,
        ImmutableArray<IRecords>? Records,
        short ErrorCode
    );

    internal sealed record ConsumeResult<TKey, TValue>(
        TopicPartition TopicPartition,
        IEnumerator<ConsumerRecord<TKey, TValue>> Records,
        Error Error
    )
    {
        private static readonly IEnumerator<ConsumerRecord<TKey, TValue>> EMPTY_ENUMERATOR =
            ImmutableArray<ConsumerRecord<TKey, TValue>>.Empty.AsEnumerable().GetEnumerator()
        ;
        public static ConsumeResult<TKey, TValue> Empty { get; } =
            new(
                TopicPartition.Empty,
                EMPTY_ENUMERATOR,
                Errors.Known.NONE
            )
        ;
    }
}
