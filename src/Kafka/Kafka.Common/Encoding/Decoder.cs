using Kafka.Common.Records;
using System.Collections.Immutable;

namespace Kafka.Common.Encoding
{
    internal static class Decoder
    {
        public static bool ReadBoolean(MemoryStream buffer)
        {
            CheckRemaining(buffer, 1);
            return buffer.ReadByte() switch
            {
                0 => false,
                1 => true,
                var b => throw new InvalidCastException($"Unable to cast {b} to BOOLEAN")
            };
        }

        public static sbyte ReadInt8(MemoryStream buffer)
        {
            CheckRemaining(buffer, 1);
            return unchecked((sbyte)buffer.ReadByte());
        }

        public static short ReadInt16(MemoryStream buffer)
        {
            CheckRemaining(buffer, 2);
            return unchecked((short)(
                (buffer.ReadByte() & 0xff) << 8 |
                (buffer.ReadByte() & 0xff) << 0
            ));
        }

        public static int ReadInt32(MemoryStream buffer)
        {
            CheckRemaining(buffer, 4);
            var value = 0;
            for (int i = 0; i < 4; i++)
            {
                value <<= 8;
                value |= buffer.ReadByte() & 0xff;
            }
            return value;
        }

        public static long ReadInt64(MemoryStream buffer)
        {
            CheckRemaining(buffer, 8);
            var value = 0L;
            for (int i = 0; i < 8; i++)
            {
                value <<= 8;
                value |= (long)buffer.ReadByte() & 0xff;
            }
            return value;
        }

        public static uint ReadUInt32(MemoryStream buffer) =>
            (uint)ReadInt32(buffer)
        ;

        public static int ReadVarInt32(MemoryStream buffer)
        {
            var value = unchecked((uint)ZigZagDecode(buffer, 31));
            return (int)(value >> 1) ^ -(int)(value & 1);
        }

        public static uint ReadVarUInt32(MemoryStream buffer) =>
            unchecked((uint)ZigZagDecode(buffer, 31))
        ;

        public static long ReadVarInt64(MemoryStream buffer)
        {
            var value = ZigZagDecode(buffer, 63);
            return (long)(value >> 1) ^ -(long)(value & 1);
        }

        public static double ReadFloat64(MemoryStream buffer)
        {
            var bits = ReadInt64(buffer);
            return BitConverter.Int64BitsToDouble(bits);
        }

        public static Guid ReadUUID(MemoryStream buffer)
        {
            CheckRemaining(buffer, 16);
            var bytes = new byte[16];
            buffer.Read(bytes);
            return new Guid(bytes);
        }

        public static string ReadString(MemoryStream buffer)
        {
            var length = ReadInt16(buffer);
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static string ReadCompactString(MemoryStream buffer)
        {
            var length = ReadVarUInt32(buffer);
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static string? ReadNullableString(MemoryStream buffer)
        {
            var length = ReadInt16(buffer);
            if (length == -1)
                return default;
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static string? ReadCompactNullableString(MemoryStream buffer)
        {
            var length = ReadVarUInt32(buffer);
            if (length == 0)
                return default;
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static byte[] ReadBytes(MemoryStream buffer)
        {
            var length = ReadInt32(buffer);
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return bytes;
        }

        public static byte[] ReadCompactBytes(MemoryStream buffer)
        {
            var length = ReadVarUInt32(buffer);
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return bytes;
        }

        public static byte[]? ReadNullableBytes(MemoryStream buffer)
        {
            var length = ReadInt32(buffer);
            if (length == -1)
                return default;
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return bytes;
        }

        public static byte[]? ReadCompactNullableBytes(MemoryStream buffer)
        {
            var length = ReadVarUInt32(buffer);
            if (length == 0)
                return default;
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return bytes;
        }

        public static IRecords? ReadMessageSet(MemoryStream buffer)
        {
            var records = ImmutableList.CreateBuilder<IRecord>();
            while (buffer.Position < buffer.Length)
                records.Add(
                    ReadMessage(
                        buffer,
                        records.Count
                    )
                );
            return new MessageSet(
                Records: records.ToImmutable()
            );
        }

        private static Message ReadMessage(MemoryStream buffer, int sequence)
        {
            var offset = ReadInt64(buffer);
            var messageSize = ReadInt32(buffer);
            var crc = ReadInt32(buffer);
            var magic = ReadInt8(buffer);
            var attributes = (Records.Attributes)ReadInt16(buffer);
            var timestamp = 0L;
            if (magic == 1)
                timestamp = ReadInt64(buffer);
            var key = ReadBytes(buffer);
            var value = ReadBytes(buffer);
            return new Message(
                Sequence: sequence,
                Offset: offset,
                MessageSize: messageSize,
                Crc: crc,
                MagicByte: magic,
                Attributes: attributes,
                Timestamp: timestamp,
                Key: key,
                Value: value
            );
        }

        public static IRecords? ReadRecords(MemoryStream buffer)
        {
            var offset = ReadInt64(buffer);
            var size = ReadInt32(buffer);
            var partitionLeaderEpoch = ReadInt32(buffer);
            var magic = ReadInt8(buffer);
            var crc = ReadInt32(buffer);
            var attributes = ReadInt16(buffer);
            var lastOffsetDelta = ReadInt32(buffer);
            var baseTimestamp = ReadInt64(buffer);
            var maxTimestamp = ReadInt64(buffer);
            var producerId = ReadInt64(buffer);
            var producerEpoch = ReadInt16(buffer);
            var baseSequence = ReadInt32(buffer);
            var records = ImmutableList.CreateBuilder<IRecord>();
            while (buffer.Position < buffer.Length)
                records.Add(
                    ReadRecord(
                        buffer,
                        offset,
                        baseTimestamp,
                        records.Count
                    )
                );
            return new RecordBatch(
                BaseOffset: offset,
                BatchLength: size,
                PartitionLeaderEpoch: partitionLeaderEpoch,
                Magic: magic,
                Crc: crc,
                Attributes: (Records.Attributes)attributes,
                LastOffsetDelta: lastOffsetDelta,
                BaseTimestamp: baseTimestamp,
                MaxTimestamp: maxTimestamp,
                ProducerId: producerId,
                ProducerEpoch: producerEpoch,
                BaseSequence: baseSequence,
                Records: records.ToImmutable()
            );
        }

        private static Record ReadRecord(MemoryStream buffer, long offset, long baseTimestamp, int sequence)
        {
            var length = ReadVarInt32(buffer);
            var attributes = ReadInt16(buffer);
            var timestampDelta = ReadVarInt64(buffer);
            var offsetDelta = ReadVarInt32(buffer);
            var key = ReadCompactBytes(buffer);
            var value = ReadCompactBytes(buffer);
            var headers = ReadArray(
                buffer,
                ReadRecordHeader
            );
            return new Record(
                BaseOffset: offset,
                BaseTimestamp: baseTimestamp,
                Sequence: sequence,
                Length: length,
                Attributes: 0,
                TimestampDelta: timestampDelta,
                OffsetDelta: offsetDelta,
                Key: key,
                Value: value,
                Headers: headers ?? ImmutableArray<RecordHeader>.Empty
            );
        }

        private static RecordHeader ReadRecordHeader(MemoryStream buffer)
        {
            var key = ReadCompactString(buffer);
            var value = ReadCompactBytes(buffer);
            return new(key, value);
        }

        public static ImmutableArray<TItem>? ReadArray<TItem>(MemoryStream buffer, Func<MemoryStream, TItem> readItem)
        {
            var length = ReadInt32(buffer);
            if (length == -1)
                return default;
            var items = new TItem[length];
            for (int i = 0; i < length; i++)
                items[i] = readItem(buffer);
            return items.ToImmutableArray();
        }

        public static ImmutableArray<TItem>? ReadCompactArray<TItem>(MemoryStream buffer, Func<MemoryStream, TItem> readItem)
        {
            var length = ReadVarUInt32(buffer);
            if (length == 0)
                return default;
            var items = new TItem[length];
            for (int i = 0; i < length; i++)
                items[i] = readItem(buffer);
            return items.ToImmutableArray();
        }

        private static void CheckRemaining(MemoryStream buffer, long required)
        {
            var remaining = buffer.Length - buffer.Position;
            if (remaining < required)
                throw new EndOfStreamException($"Required bytes to decode: {required} - was {remaining}");
        }

        private static ulong ZigZagDecode(MemoryStream buffer, int bits)
        {
            var value = 0UL;
            var i = 0;
            while (i <= bits)
            {
                var b = buffer.ReadByte();
                if (b < 0)
                    throw new EndOfStreamException();
                value |= ((ulong)b & 0x7f) << i;
                if ((b & 0x80) == 0)
                    break;
                else
                    i += 7;
            }
            if (i > bits)
                throw new InvalidDataException($"ZigZag decoding exceeded ({bits}) bits");
            return value;
        }
    }
}
