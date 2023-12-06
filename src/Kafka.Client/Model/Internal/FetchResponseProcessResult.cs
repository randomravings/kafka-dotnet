using System.Collections.Immutable;

namespace Kafka.Client.Model.Internal
{
    internal readonly record struct FetchResponseProcessResult(
        int OffsetsProcessed,
        ImmutableArray<ReadRecord> Records
    )
    {
        public static implicit operator FetchResponseProcessResult(
            (int OffsetsProcessed, ImmutableArray<ReadRecord> Records) value
        ) => new(value.OffsetsProcessed, value.Records);
    }
}
