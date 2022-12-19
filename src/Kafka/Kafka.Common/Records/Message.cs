using Kafka.Common.Attributes;
using Kafka.Common.Hashing;

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
        [property: Serialization(SerializationType.Bytes, 6)] ReadOnlyMemory<byte>? Key,
        [property: Serialization(SerializationType.Bytes, 7)] ReadOnlyMemory<byte>? Value
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

        RecordHeader[] IRecord.Headers => Array.Empty<RecordHeader>();

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
