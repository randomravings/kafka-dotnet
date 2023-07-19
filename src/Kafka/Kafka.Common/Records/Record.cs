using System.Collections.Immutable;
using Kafka.Common.Model;

namespace Kafka.Common.Records
{
    /// <summary>
    /// Record for magic 2  .
    /// </summary>
    /// <param name="Length">Size of the record in bytes.</param>
    /// <param name="Attributes">
    /// <code>
    ///   bit 0~2:
    ///     0: no compression
    ///     1: gzip
    ///     2: snappy
    ///     3: lz4
    ///     4: zstd
    ///   bit 3: timestampType
    ///   bit 4: isTransactional (0 means not transactional)
    ///   bit 5: isControlBatch (0 means not a control batch)
    ///   bit 6: hasDeleteHorizonMs (0 means baseTimestamp is not set as the delete horizon for compaction)
    ///   bit 7~15: unused
    /// </code>
    /// </param>
    /// <param name="TimestampDelta">Timestamp relative to Record Batch.</param>
    /// <param name="OffsetDelta">Offset relative to Record Batch.</param>
    /// <param name="Key">Key bytes, null if no key in record.</param>
    /// <param name="Value">Value bytes, null if no value in record.</param>
    /// <param name="Headers">Record Headers, empty if no header.</param>
    public record Record(
        int Length,
        Attributes Attributes,
        long TimestampDelta,
        int OffsetDelta,
        ReadOnlyMemory<byte>? Key,
        ReadOnlyMemory<byte>? Value,
        ImmutableArray<RecordHeader> Headers
    ) : IRecord
    {
        int IRecord.Length => Length;

        Attributes IRecord.Attributes => Attributes.None;

        long IRecord.TimestampDelta => TimestampDelta;

        int IRecord.OffsetDelta => OffsetDelta;

        ReadOnlyMemory<byte>? IRecord.Key => Key;

        ReadOnlyMemory<byte>? IRecord.Value => Value;

        IReadOnlyList<RecordHeader> IRecord.Headers => Headers;
    }
}
