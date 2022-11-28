using Kafka.Common.Attributes;
using Kafka.Common.Hashing;
using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    public sealed record Message(
        [property: SerializationIgnore] int Sequence,
        [property: Serialization(SerializationType.Int64, 0)] long Offset,
        [property: Serialization(SerializationType.Int32, 1)] int MessageSize,
        [property: Serialization(SerializationType.Int32, 2)] int Crc,
        [property: Serialization(SerializationType.Int8, 3)] sbyte MagicByte,
        [property: Serialization(SerializationType.Int8, 4)] Attributes Attributes,
        [property: Serialization(SerializationType.Int64, 5)] long Timestamp,
        [property: Serialization(SerializationType.Bytes, 6)] ImmutableArray<byte>? Key,
        [property: Serialization(SerializationType.Bytes, 7)] ImmutableArray<byte>? Value
    ) : IRecord
    {
        int IRecord.Sequence => Sequence;
        
        long IRecord.Offset => Offset;
        
        int IRecord.SizeInBytes => MessageSize;

        sbyte IRecord.Magic => MagicByte;

        int IRecord.Crc => Crc;

        long IRecord.Timestamp => Timestamp;

        ImmutableArray<byte>? IRecord.Key => Key;

        ImmutableArray<byte>? IRecord.Value => Value;

        long IRecord.TimestampDelta => 0;

        int IRecord.OffsetDelta => 0;

        TimestampType IRecord.TimestampType => (TimestampType)(Attributes & Attributes.TimestampType);

        CompressionType IRecord.CompressionType => (CompressionType)(Attributes & Attributes.CompressionType);

        RecordHeader[] IRecord.Headers => Array.Empty<RecordHeader>();

        void IRecord.EnsureValid()
        {
            var pos = 0;
            var crc = 0U;
            var bytes = new byte[21].AsMemory();
            var slice = bytes;
            // CRC magic byte, attributes and timestamp.
            slice = Encoding.Encoder.WriteInt8(slice, MagicByte);
            slice = Encoding.Encoder.WriteInt32(slice, (int)Attributes);
            if(MagicByte > 0)
                slice = Encoding.Encoder.WriteInt64(slice, Timestamp);
            var len = bytes.Length - slice.Length - pos;
            crc = Crc32.Update(crc, bytes[pos..len].Span);
            pos += len;
            // CRC Key
            if (Key != null)
            {
                slice = Encoding.Encoder.WriteInt32(slice, Key.Value.Length);
                len = bytes.Length - slice.Length - pos;
                crc = Crc32.Update(crc, bytes[pos..len].Span);
                pos += len;
                crc = Crc32.Update(crc, Key.Value);
            }
            // CRC Value
            if (Value != null)
            {
                Encoding.Encoder.WriteInt32(bytes, Value.Value.Length);
                len = bytes.Length - slice.Length - pos;
                crc = Crc32.Update(crc, bytes[pos..len].Span);
            }
            // Throw if not valid.
            if (crc != Crc)
                throw new InvalidDataException("Crc32 check failed");
        }
    }
}
