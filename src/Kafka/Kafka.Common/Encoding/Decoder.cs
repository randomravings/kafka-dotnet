using Kafka.Common.Records;
using System.Collections.Immutable;

namespace Kafka.Common.Encoding
{
    public static class Decoder
    {
        public static bool ReadBoolean(ref ReadOnlyMemory<byte> buffer)
        {
            CheckRemaining(buffer, 1);
            var value = buffer.Span[0] != 0;
            buffer = buffer[1..];
            return value;
        }

        public static sbyte ReadInt8(ref ReadOnlyMemory<byte> buffer)
        {
            CheckRemaining(buffer, 1);
            var value = unchecked((sbyte)buffer.Span[0]);
            buffer = buffer[1..];
            return value;
        }

        public static short ReadInt16(ref ReadOnlyMemory<byte> buffer)
        {
            CheckRemaining(buffer, 2);
            var value = unchecked((short)(
                (buffer.Span[0] & 0xff) << 8 |
                (buffer.Span[1] & 0xff) << 0
            ));
            buffer = buffer[2..];
            return value;
        }

        public static ushort ReadUInt16(ref ReadOnlyMemory<byte> buffer) =>
            (ushort)ReadInt16(ref buffer)
        ;

        public static int ReadInt32(ref ReadOnlyMemory<byte> buffer)
        {
            CheckRemaining(buffer, 4);
            var value = unchecked(
                (buffer.Span[0] & 0xff) << 24 |
                (buffer.Span[1] & 0xff) << 16 |
                (buffer.Span[2] & 0xff) << 8 |
                (buffer.Span[3] & 0xff) << 0
            );
            buffer = buffer[4..];
            return value;
        }

        public static uint ReadUInt32(ref ReadOnlyMemory<byte> buffer) =>
            (uint)ReadInt32(ref buffer)
        ;

        public static long ReadInt64(ref ReadOnlyMemory<byte> buffer)
        {
            CheckRemaining(buffer, 8);
            var value = unchecked(
                ((long)(buffer.Span[0] & 0xff) << 56) |
                ((long)(buffer.Span[1] & 0xff) << 48) |
                ((long)(buffer.Span[2] & 0xff) << 40) |
                ((long)(buffer.Span[3] & 0xff) << 32) |
                ((long)(buffer.Span[4] & 0xff) << 24) |
                ((long)(buffer.Span[5] & 0xff) << 16) |
                ((long)(buffer.Span[6] & 0xff) << 8) |
                ((long)(buffer.Span[7] & 0xff) << 0)
            );
            buffer = buffer[8..];
            return value;
        }

        public static ulong ReadUInt64(ref ReadOnlyMemory<byte> buffer) =>
            (ulong)ReadInt64(ref buffer)
        ;

        public static int ReadVarInt32(ref ReadOnlyMemory<byte> buffer)
        {
            var value = unchecked((uint)ZigZagDecode(ref buffer, 31));
            return (int)(value >> 1) ^ -(int)(value & 1);
        }

        public static uint ReadVarUInt32(ref ReadOnlyMemory<byte> buffer) =>
            unchecked((uint)ZigZagDecode(ref buffer, 31))
        ;

        public static long ReadVarInt64(ref ReadOnlyMemory<byte> buffer)
        {
            var value = ZigZagDecode(ref buffer, 63);
            return (long)(value >> 1) ^ -(long)(value & 1);
        }

        public static double ReadFloat64(ref ReadOnlyMemory<byte> buffer)
        {
            var bits = ReadInt64(ref buffer);
            return BitConverter.Int64BitsToDouble(bits);
        }

        public static Guid ReadUuid(ref ReadOnlyMemory<byte> buffer)
        {
            CheckRemaining(buffer, 16);
            var bytes = buffer[0..16];
            buffer = buffer[16..];
            return new Guid(bytes.Span);
        }

        public static string ReadString(ref ReadOnlyMemory<byte> buffer)
        {
            var length = ReadInt16(ref buffer);
            CheckRemaining(buffer, length);
            var bytes = buffer[0..length];
            buffer = buffer[length..];
            return System.Text.Encoding.UTF8.GetString(bytes.Span);
        }

        public static string ReadCompactString(ref ReadOnlyMemory<byte> buffer)
        {
            var length = Convert.ToInt32(ReadVarUInt32(ref buffer) - 1);
            CheckRemaining(buffer, length);
            var bytes = buffer[0..length];
            buffer = buffer[length..];
            return System.Text.Encoding.UTF8.GetString(bytes.Span);
        }

        public static string? ReadNullableString(ref ReadOnlyMemory<byte> buffer)
        {
            var length = ReadInt16(ref buffer);
            if (length == -1)
                return default;
            CheckRemaining(buffer, length);
            var bytes = buffer[0..length];
            buffer = buffer[length..];
            return System.Text.Encoding.UTF8.GetString(bytes.Span);
        }

        public static string? ReadCompactNullableString(ref ReadOnlyMemory<byte> buffer)
        {
            var length = Convert.ToInt32(ReadVarUInt32(ref buffer));
            if (length == 0)
                return default;
            length -= 1;
            CheckRemaining(buffer, length);
            var bytes = buffer[0..length];
            buffer = buffer[length..];
            return System.Text.Encoding.UTF8.GetString(bytes.Span);
        }

        public static ImmutableArray<byte> ReadBytes(ref ReadOnlyMemory<byte> buffer)
        {
            var length = ReadInt32(ref buffer);
            CheckRemaining(buffer, length);
            var bytes = buffer[0..length];
            buffer = buffer[length..];
            return ImmutableArrayFromSpan(bytes);
        }

        public static ImmutableArray<byte> ReadCompactBytes(ref ReadOnlyMemory<byte> buffer)
        {
            var length = Convert.ToInt32(ReadVarUInt32(ref buffer));
            CheckRemaining(buffer, length);
            var bytes = buffer[0..length];
            buffer = buffer[length..];
            return ImmutableArrayFromSpan(bytes);
        }

        public static ImmutableArray<byte>? ReadNullableBytes(ref ReadOnlyMemory<byte> buffer)
        {
            var length = ReadInt32(ref buffer);
            if (length == -1)
                return default;
            CheckRemaining(buffer, length);
            var bytes = buffer[0..length];
            buffer = buffer[length..];
            return ImmutableArrayFromSpan(bytes);
        }

        public static ImmutableArray<byte>? ReadCompactNullableBytes(ref ReadOnlyMemory<byte> buffer)
        {
            var length = Convert.ToInt32(ReadVarUInt32(ref buffer));
            if (length == 0)
                return default;
            length -= 1;
            CheckRemaining(buffer, length);
            var bytes = buffer[0..length];
            buffer = buffer[length..];
            return ImmutableArrayFromSpan(bytes);
        }

        public static IRecords? ReadMessageSet(ref ReadOnlyMemory<byte> buffer)
        {
            var records = ImmutableList.CreateBuilder<IRecord>();
            while (buffer.Length > 0)
                records.Add(
                    ReadMessage(
                        ref buffer,
                        records.Count
                    )
                );
            return new MessageSet(
                Records: records.ToImmutable()
            );
        }

        private static Message ReadMessage(ref ReadOnlyMemory<byte> buffer, int sequence)
        {
            var offset = ReadInt64(ref buffer);
            var messageSize = ReadInt32(ref buffer);
            var crc = ReadInt32(ref buffer);
            var magic = ReadInt8(ref buffer);
            var attributes = (Records.Attributes)ReadInt16(ref buffer);
            var timestamp = 0L;
            if (magic == 1)
                timestamp = ReadInt64(ref buffer);
            var key = ReadBytes(ref buffer);
            var value = ReadBytes(ref buffer);
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

        public static IRecords? ReadRecords(ref ReadOnlyMemory<byte> buffer)
        {
            var length = ReadInt32(ref buffer);
            if (length == 0)
                return default;
            return ReadRecords(ref buffer, length);
        }

        public static IRecords? ReadCompactRecords(ref ReadOnlyMemory<byte> buffer)
        {
            var length = ReadVarUInt32(ref buffer);
            if (length == 0)
                return default;
            return ReadRecords(ref buffer, length);
        }

        private static IRecords? ReadRecords(ref ReadOnlyMemory<byte> buffer, long batchSize)
        {
            var offset = ReadInt64(ref buffer);
            var size = ReadInt32(ref buffer);
            var partitionLeaderEpoch = ReadInt32(ref buffer);
            var magic = ReadInt8(ref buffer);
            var crc = ReadInt32(ref buffer);
            var attributes = ReadInt16(ref buffer);
            var lastOffsetDelta = ReadInt32(ref buffer);
            var baseTimestamp = ReadInt64(ref buffer);
            var maxTimestamp = ReadInt64(ref buffer);
            var producerId = ReadInt64(ref buffer);
            var producerEpoch = ReadInt16(ref buffer);
            var baseSequence = ReadInt32(ref buffer);
            var records = ImmutableList.CreateBuilder<IRecord>();
            while (buffer.Length > 0)
                records.Add(
                    ReadRecord(
                        ref buffer,
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

        private static Record ReadRecord(ref ReadOnlyMemory<byte> buffer, long offset, long baseTimestamp, int sequence)
        {
            var length = ReadVarInt32(ref buffer);
            var attributes = ReadInt16(ref buffer);
            var timestampDelta = ReadVarInt64(ref buffer);
            var offsetDelta = ReadVarInt32(ref buffer);
            var key = ReadCompactBytes(ref buffer);
            var value = ReadCompactBytes(ref buffer);
            var headers = ReadArray(
                ref buffer,
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

        private static RecordHeader ReadRecordHeader(ref ReadOnlyMemory<byte> buffer)
        {
            var key = ReadCompactString(ref buffer);
            var value = ReadCompactBytes(ref buffer);
            return new(key, value);
        }

        public static ImmutableArray<TItem>? ReadArray<TItem>(ref ReadOnlyMemory<byte> buffer, DecodeDelegate<TItem> readItem)
        {
            var length = ReadInt32(ref buffer);
            if (length == -1)
                return default;
            var items = new TItem[length];
            for (int i = 0; i < length; i++)
                items[i] = readItem(ref buffer);
            return items.ToImmutableArray();
        }

        public static ImmutableArray<TItem>? ReadCompactArray<TItem>(ref ReadOnlyMemory<byte> buffer, DecodeDelegate<TItem> readItem)
        {
            var length = Convert.ToInt32(ReadVarUInt32(ref buffer));
            if (length == 0)
                return default;
            length -= 1;
            var items = new TItem[length];
            for (int i = 0; i < length; i++)
                items[i] = readItem(ref buffer);
            return items.ToImmutableArray();
        }

        private static void CheckRemaining(ReadOnlyMemory<byte> buffer, long required)
        {
            if (buffer.Length < required)
                throw new EndOfStreamException($"Required bytes to decode: {required} - was {buffer.Length}");
        }

        private static ulong ZigZagDecode(ref ReadOnlyMemory<byte> buffer, int bits)
        {
            var value = 0UL;
            var i = 0;
            while (i <= bits)
            {
                var b = buffer.Span[0];
                buffer = buffer[1..];
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

        private static ImmutableArray<T> ImmutableArrayFromSpan<T>(ReadOnlyMemory<T> buffer)
        {
            var builder = ImmutableArray.CreateBuilder<T>(buffer.Length);
            foreach (var i in buffer.Span)
                builder.Add(i);
            return builder.MoveToImmutable();
        }
    }
}
