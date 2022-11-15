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
        [property: Serialization(SerializationType.Bytes, 6)] byte[]? Key,
        [property: Serialization(SerializationType.Bytes, 7)] byte[]? Value
    ) : IRecord
    {
        int IRecord.Sequence => Sequence;
        
        long IRecord.Offset => Offset;
        
        int IRecord.SizeInBytes => MessageSize;

        sbyte IRecord.Magic => MagicByte;

        int IRecord.Crc => Crc;

        long IRecord.Timestamp => Timestamp;

        byte[]? IRecord.Key => Key;

        byte[]? IRecord.Value => Value;

        long IRecord.TimestampDelta => 0;

        int IRecord.OffsetDelta => 0;

        TimestampType IRecord.TimestampType => (TimestampType)(Attributes & Attributes.TimestampType);

        CompressionType IRecord.CompressionType => (CompressionType)(Attributes & Attributes.CompressionType);

        RecordHeader[] IRecord.Headers => Array.Empty<RecordHeader>();

        void IRecord.EnsureValid()
        {
            var pos = 0L;
            var crc = 0U;
            var bytes = new MemoryStream(21);
            // CRC magic byte, attributes and timestamp.
            Encoding.Encoder.WriteInt8(bytes, MagicByte);
            Encoding.Encoder.WriteInt32(bytes, (int)Attributes);
            if(MagicByte > 0)
                Encoding.Encoder.WriteInt64(bytes, Timestamp);
            crc = Crc32.Update(crc, bytes.GetBuffer()[(int)pos..(int)(bytes.Position - pos)]);
            pos = bytes.Position;
            // CRC Key
            if (Key != null)
            {
                Encoding.Encoder.WriteInt32(bytes, Key.Length);
                crc = Crc32.Update(crc, bytes.GetBuffer()[(int)pos..(int)(bytes.Position - pos)]);
                crc = Crc32.Update(crc, Key);
                pos = bytes.Position;
            }
            // CRC Value
            if (Value != null)
            {
                Encoding.Encoder.WriteInt32(bytes, Value.Length);
                crc = Crc32.Update(crc, bytes.GetBuffer()[(int)pos..(int)(bytes.Position - pos)]);
                crc = Crc32.Update(crc, Value);
            }
            // Throw if not valid.
            if (crc != Crc)
                throw new InvalidDataException("Crc32 check failed");
        }
    }
}
