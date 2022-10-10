using Kafka.Common.Attributes;
using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    /// <summary>
    /// Record for magic 2  .
    /// </summary>
    /// <param name="BaseOffset">
    /// Passed to record to enable computing of the actual offset from delta.
    /// <para>Note: This is not serialized.</para>
    /// </param>
    /// <param name="BaseTimestamp">
    /// Passed to record to enable computing of the actual timestamp from delta.
    /// <para>Note: This is not serialized.</para>
    /// </param>
    /// <param name="Sequence">
    /// Passed to record to explicitly show the sequence in the batch.
    /// <para>Note: This is not serialized.</para>
    /// </param>
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
    public sealed record Record(
        [property: SerializationIgnore] long BaseOffset,
        [property: SerializationIgnore] long BaseTimestamp,
        [property: SerializationIgnore] int Sequence,
        [property: Serialization(SerializationType.VarInt32, 0)] int Length,
        [property: Serialization(SerializationType.Int16, 1)] Attributes Attributes,
        [property: Serialization(SerializationType.VarInt64, 2)] long TimestampDelta,
        [property: Serialization(SerializationType.VarInt32, 3)] int OffsetDelta,
        [property: Serialization(SerializationType.CompactBytes, 4)] byte[]? Key,
        [property: Serialization(SerializationType.CompactBytes, 5)] byte[]? Value,
        [property: Serialization(SerializationType.Array, 0)] ImmutableArray<RecordHeader> Headers
    ) : IRecord
    {
        int IRecord.Sequence => Sequence;

        long IRecord.Offset => BaseOffset + OffsetDelta;

        int IRecord.SizeInBytes => Length;

        sbyte IRecord.Magic => -1;

        int IRecord.Crc => 0;

        Attributes IRecord.Attributes => Attributes.None;

        long IRecord.Timestamp => BaseTimestamp + TimestampDelta;

        byte[]? IRecord.Key => Key;

        byte[]? IRecord.Value => Value;

        long IRecord.TimestampDelta => TimestampDelta;

        int IRecord.OffsetDelta => OffsetDelta;

        CompressionType IRecord.CompressionType => CompressionType.None;

        TimestampType IRecord.TimestampType => TimestampType.None;

        RecordHeader[] IRecord.Headers => Array.Empty<RecordHeader>();

        void IRecord.EnsureValid()
        {
            // CRC performed at batch level.
        }
    }
}
