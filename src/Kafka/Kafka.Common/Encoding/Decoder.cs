using Kafka.Common.Records;
using System.Collections.Immutable;

namespace Kafka.Common.Encoding
{
    public static class Decoder
    {
        public static bool ReadBoolean(Stream buffer)
        {
            CheckRemaining(buffer, 1);
            return buffer.ReadByte() switch
            {
                0 => false,
                1 => true,
                var b => throw new InvalidCastException($"Unable to cast {b} to BOOLEAN")
            };
        }

        public static sbyte ReadInt8(Stream buffer)
        {
            CheckRemaining(buffer, 1);
            return unchecked((sbyte)buffer.ReadByte());
        }

        public static short ReadInt16(Stream buffer)
        {
            CheckRemaining(buffer, 2);
            return unchecked((short)(
                (buffer.ReadByte() & 0xff) << 8 |
                (buffer.ReadByte() & 0xff) << 0
            ));
        }

        public static ushort ReadUInt16(Stream buffer) =>
            (ushort)ReadInt16(buffer)
        ;

        public static int ReadInt32(Stream buffer)
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

        public static uint ReadUInt32(Stream buffer) =>
            (uint)ReadInt32(buffer)
        ;

        public static long ReadInt64(Stream buffer)
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

        public static ulong ReadUInt64(Stream buffer) =>
            (ulong)ReadInt64(buffer)
        ;

        public static int ReadVarInt32(Stream buffer)
        {
            var value = unchecked((uint)ZigZagDecode(buffer, 31));
            return (int)(value >> 1) ^ -(int)(value & 1);
        }

        public static uint ReadVarUInt32(Stream buffer) =>
            unchecked((uint)ZigZagDecode(buffer, 31))
        ;

        public static long ReadVarInt64(Stream buffer)
        {
            var value = ZigZagDecode(buffer, 63);
            return (long)(value >> 1) ^ -(long)(value & 1);
        }

        public static double ReadFloat64(Stream buffer)
        {
            var bits = ReadInt64(buffer);
            return BitConverter.Int64BitsToDouble(bits);
        }

        public static Guid ReadUuid(Stream buffer)
        {
            CheckRemaining(buffer, 16);
            var bytes = new byte[16];
            buffer.Read(bytes);
            return new Guid(bytes);
        }

        public static string ReadString(Stream buffer)
        {
            var length = ReadInt16(buffer);
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static string ReadCompactString(Stream buffer)
        {
            var length = ReadVarUInt32(buffer) - 1;
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static string? ReadNullableString(Stream buffer)
        {
            var length = ReadInt16(buffer);
            if (length == -1)
                return default;
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static string? ReadCompactNullableString(Stream buffer)
        {
            var length = ReadVarUInt32(buffer);
            if (length == 0)
                return default;
            length -= 1;
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static byte[] ReadBytes(Stream buffer)
        {
            var length = ReadInt32(buffer);
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return bytes;
        }

        public static byte[] ReadCompactBytes(Stream buffer)
        {
            var length = ReadVarUInt32(buffer);
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return bytes;
        }

        public static byte[]? ReadNullableBytes(Stream buffer)
        {
            var length = ReadInt32(buffer);
            if (length == -1)
                return default;
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return bytes;
        }

        public static byte[]? ReadCompactNullableBytes(Stream buffer)
        {
            var length = ReadVarUInt32(buffer);
            if (length == 0)
                return default;
            length -= 1;
            CheckRemaining(buffer, length);
            var bytes = new byte[length];
            buffer.Read(bytes);
            return bytes;
        }

        public static IRecords? ReadMessageSet(Stream buffer)
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

        private static Message ReadMessage(Stream buffer, int sequence)
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

        public static IRecords? ReadRecords(Stream buffer)
        {
            var length = ReadInt32(buffer);
            if (length == 0)
                return default;
            return ReadRecords(buffer, length);
        }

        public static IRecords? ReadCompactRecords(Stream buffer)
        {
            var length = ReadVarUInt32(buffer);
            if (length == 0)
                return default;
            return ReadRecords(buffer, length);
        }

        private static IRecords? ReadRecords(Stream buffer, long batchSize)
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

        private static Record ReadRecord(Stream buffer, long offset, long baseTimestamp, int sequence)
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

        private static RecordHeader ReadRecordHeader(Stream buffer)
        {
            var key = ReadCompactString(buffer);
            var value = ReadCompactBytes(buffer);
            return new(key, value);
        }

        public static ImmutableArray<TItem>? ReadArray<TItem>(Stream buffer, Func<Stream, TItem> readItem)
        {
            var length = ReadInt32(buffer);
            if (length == -1)
                return default;
            var items = new TItem[length];
            for (int i = 0; i < length; i++)
                items[i] = readItem(buffer);
            return items.ToImmutableArray();
        }

        public static ImmutableArray<TItem>? ReadCompactArray<TItem>(Stream buffer, Func<Stream, TItem> readItem)
        {
            var length = ReadVarUInt32(buffer);
            if (length == 0)
                return default;
            length -= 1;
            var items = new TItem[length];
            for (int i = 0; i < length; i++)
                items[i] = readItem(buffer);
            return items.ToImmutableArray();
        }

        public static ImmutableDictionary<TKey, TValue>? ReadMap<TKey, TValue>(Stream buffer, Func<Stream, TKey> readKey, Func<Stream, TValue> readValue)
            where TKey : notnull
        {
            var length = ReadInt32(buffer);
            if (length == -1)
                return default;
            var builder = ImmutableDictionary.CreateBuilder<TKey, TValue>();
            for (int i = 0; i < length; i++)
            {
                var key = readKey(buffer);
                var value = readValue(buffer);
                builder.Add(key, value);
            }
            return builder.ToImmutable();
        }

        public static ImmutableDictionary<TKey, TValue> ReadMapDefault<TKey, TValue>(Stream buffer, Func<Stream, TKey> readKey, Func<Stream, TValue> readValue)
            where TKey : notnull =>
            ReadMap(buffer, readKey, readValue) ?? ImmutableDictionary<TKey, TValue>.Empty
        ;

        public static ImmutableDictionary<TKey, TValue>? ReadMapNull<TKey, TValue>()
            where TKey : notnull =>
            default
        ;

        public static ImmutableDictionary<TKey, TValue> ReadMapEmpty<TKey, TValue>()
            where TKey : notnull =>
            ImmutableDictionary<TKey, TValue>.Empty
        ;

        public static ImmutableDictionary<TKey, TValue>? ReadCompactMap<TKey, TValue>(Stream buffer, Func<Stream, TKey> readKey, Func<Stream, TValue> readValue)
            where TKey : notnull
        {
            var length = ReadVarUInt32(buffer);
            if (length == 0)
                return default;
            var builder = ImmutableDictionary.CreateBuilder<TKey, TValue>();
            for (int i = 0; i < length; i++)
            {
                var key = readKey(buffer);
                var value = readValue(buffer);
                builder.Add(key, value);
            }
            return builder.ToImmutable();
        }

        public static ImmutableDictionary<TKey, TValue> ReadCompactMapDefault<TKey, TValue>(Stream buffer, Func<Stream, TKey> readKey, Func<Stream, TValue> readValue)
            where TKey : notnull =>
            ReadMap(buffer, readKey, readValue) ?? ImmutableDictionary<TKey, TValue>.Empty
        ;

        public static ImmutableDictionary<TKey, TValue>? ReadCompactMapNull<TKey, TValue>()
            where TKey : notnull =>
            default
        ;

        public static ImmutableDictionary<TKey, TValue> ReadCompactMapEmpty<TKey, TValue>()
            where TKey : notnull =>
            ImmutableDictionary<TKey, TValue>.Empty
        ;

        private static void CheckRemaining(Stream buffer, long required)
        {
            var remaining = buffer.Length - buffer.Position;
            if (remaining < required)
                throw new EndOfStreamException($"Required bytes to decode: {required} - was {remaining}");
        }

        private static ulong ZigZagDecode(Stream buffer, int bits)
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
