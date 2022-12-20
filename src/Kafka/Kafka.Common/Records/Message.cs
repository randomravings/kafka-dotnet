using Kafka.Common.Hashing;
using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    public sealed record Message(
        int Sequence,
        long Offset,
        int MessageSize,
        int Crc,
        sbyte MagicByte,
        Attributes Attributes,
        long Timestamp,
        ReadOnlyMemory<byte>? Key,
        ReadOnlyMemory<byte>? Value
    ) : IRecord
    {
        int IRecord.Sequence => Sequence;
        
        long IRecord.Offset => Offset;
        
        int IRecord.SizeInBytes => MessageSize;

        sbyte IRecord.Magic => MagicByte;

        int IRecord.Crc => Crc;

        long IRecord.Timestamp => Timestamp;

        ReadOnlyMemory<byte>? IRecord.Key => Key;

        ReadOnlyMemory<byte>? IRecord.Value => Value;

        long IRecord.TimestampDelta => 0;

        int IRecord.OffsetDelta => 0;

        TimestampType IRecord.TimestampType => (TimestampType)(Attributes & Attributes.TimestampType);

        CompressionType IRecord.CompressionType => (CompressionType)(Attributes & Attributes.CompressionType);

        ImmutableArray<RecordHeader> IRecord.Headers => ImmutableArray<RecordHeader>.Empty;

        void IRecord.EnsureValid()
        {
            var crc = 0U;
            var offset = 0;
            var pos = 0;
            var bytes = new byte[21];
            // CRC magic byte, attributes and timestamp.
            pos = Encoding.Encoder.WriteInt8(bytes, pos, MagicByte);
            pos = Encoding.Encoder.WriteInt32(bytes, pos, (int)Attributes);
            if(MagicByte > 0)
                pos = Encoding.Encoder.WriteInt64(bytes, pos, Timestamp);
            crc = Crc32.Update(crc, bytes, offset, pos);
            offset = pos;
            // CRC Key
            if (Key != null)
            {
                pos = Encoding.Encoder.WriteInt32(bytes, pos, Key.Value.Length);
                crc = Crc32.Update(crc, bytes, offset, pos);
                offset = pos;
            }
            // CRC Value
            if (Value != null)
            {
                Encoding.Encoder.WriteInt32(bytes, pos, Value.Value.Length);
                crc = Crc32.Update(crc, bytes, offset, pos);
            }
            // Throw if not valid.
            if (crc != Crc)
                throw new InvalidDataException("Crc32 check failed");
        }
    }
}
