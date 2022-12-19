using Kafka.Common.Attributes;
using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    public sealed record ControlRecord(
        [property: Serialization(SerializationType.Int16, 0)] short Version,
        [property: Serialization(SerializationType.Int16, 1)] ControlType Value
    ) : IRecord
    {
        public static ControlRecord Empty = new(-1, ControlType.None);

        int IRecord.Sequence => 0;

        long IRecord.Offset => -1;

        int IRecord.SizeInBytes => 4;

        sbyte IRecord.Magic => 2;

        int IRecord.Crc => 0;

        Attributes IRecord.Attributes => Attributes.None;

        long IRecord.Timestamp => -1;

        ReadOnlyMemory<byte>? IRecord.Key => default;

        ReadOnlyMemory<byte>? IRecord.Value => default;

        long IRecord.TimestampDelta => 0;

        int IRecord.OffsetDelta => 0;

        TimestampType IRecord.TimestampType => TimestampType.None;

        CompressionType IRecord.CompressionType => CompressionType.None;

        RecordHeader[] IRecord.Headers => Array.Empty<RecordHeader>();

        void IRecord.EnsureValid()
        {
            if (Version == 0 && Value != ControlType.None)
                throw new Exceptions.CorruptRecordException($"Invalid Control record: {this}");
        }
    }
}
