using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model.Internal
{
    internal readonly record struct FetchResponseProcessResult(
        int OffsetsProcessed,
        IReadOnlyList<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>> Records
    )
    {
        public static FetchResponseProcessResult Empty { get; } = new(
            0,
            ImmutableArray<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>.Empty
        );
    }
}
