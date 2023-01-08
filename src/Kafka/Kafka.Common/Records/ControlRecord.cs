using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    public sealed record ControlRecord(
        int Length,
        Attributes Attributes,
        long TimestampDelta,
        int OffsetDelta,
        ReadOnlyMemory<byte>? Key,
        ReadOnlyMemory<byte>? Value,
        ImmutableArray<RecordHeader> Headers,
        short Version,
        ControlType Type
    ) : Record(
            Length,
            Attributes,
            TimestampDelta,
            OffsetDelta,
            Key,
            Value,
            Headers
        )
    {
        public static ControlRecord Empty { get; } = new(
            -1,
            Attributes.None,
            -1,
            -1,
            null,
            null,
            ImmutableArray<RecordHeader>.Empty,
            -1,
            ControlType.None
        );
    };
}
