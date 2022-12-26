using Kafka.Common.Records;
using System.Collections.Immutable;

namespace Kafka.Common.Encoding
{
    public static class Decoder
    {
        public static bool ReadBoolean(byte[] buffer, ref int index)
        {
            CheckRemaining(buffer, index, 1);
            return buffer[index++] != 0;
        }

        public static sbyte ReadInt8(byte[] buffer, ref int index)
        {
            CheckRemaining(buffer, index, 1);
            return unchecked((sbyte)buffer[index++]);
        }

        public static short ReadInt16(byte[] buffer, ref int index)
        {
            CheckRemaining(buffer, index, 2);
            var value = unchecked((short)(
                (buffer[index++] & 0xff) << 8 |
                (buffer[index++] & 0xff) << 0
            ));
            buffer = buffer[2..];
            return value;
        }

        public static ushort ReadUInt16(byte[] buffer, ref int index) =>
            (ushort)ReadInt16(buffer, ref index)
        ;

        public static int ReadInt32(byte[] buffer, ref int index)
        {
            CheckRemaining(buffer, index, 4);
            var value = unchecked(
                (buffer[index++] & 0xff) << 24 |
                (buffer[index++] & 0xff) << 16 |
                (buffer[index++] & 0xff) << 8 |
                (buffer[index++] & 0xff) << 0
            );
            buffer = buffer[4..];
            return value;
        }

        public static uint ReadUInt32(byte[] buffer, ref int index) =>
            (uint)ReadInt32(buffer, ref index)
        ;

        public static long ReadInt64(byte[] buffer, ref int index)
        {
            CheckRemaining(buffer, index, 8);
            var value = unchecked(
                ((long)(buffer[index++] & 0xff) << 56) |
                ((long)(buffer[index++] & 0xff) << 48) |
                ((long)(buffer[index++] & 0xff) << 40) |
                ((long)(buffer[index++] & 0xff) << 32) |
                ((long)(buffer[index++] & 0xff) << 24) |
                ((long)(buffer[index++] & 0xff) << 16) |
                ((long)(buffer[index++] & 0xff) << 8) |
                ((long)(buffer[index++] & 0xff) << 0)
            );
            buffer = buffer[8..];
            return value;
        }

        public static ulong ReadUInt64(byte[] buffer, ref int index) =>
            (ulong)ReadInt64(buffer, ref index)
        ;

        public static int ReadVarInt32(byte[] buffer, ref int index)
        {
            var value = unchecked((uint)ZigZagDecode(buffer, ref index, 31));
            return (int)(value >> 1) ^ -(int)(value & 1);
        }

        public static uint ReadVarUInt32(byte[] buffer, ref int index) =>
            unchecked((uint)ZigZagDecode(buffer, ref index, 31))
        ;

        public static long ReadVarInt64(byte[] buffer, ref int index)
        {
            var value = ZigZagDecode(buffer, ref index, 63);
            return (long)(value >> 1) ^ -(long)(value & 1);
        }

        public static double ReadFloat64(byte[] buffer, ref int index)
        {
            var bits = ReadInt64(buffer, ref index);
            return BitConverter.Int64BitsToDouble(bits);
        }

        public static Guid ReadUuid(byte[] buffer, ref int index)
        {
            CheckRemaining(buffer, index, 16);
            return new Guid(buffer[index..(index += 16)]);
        }

        public static string ReadString(byte[] buffer, ref int index)
        {
            var length = ReadInt16(buffer, ref index);
            CheckRemaining(buffer, index, length);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, length);
            index += length;
            return value;
        }

        public static string ReadCompactString(byte[] buffer, ref int index)
        {
            var length = Convert.ToInt32(ReadVarUInt32(buffer, ref index) - 1);
            CheckRemaining(buffer, index, length);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, length);
            index += length;
            return value;
        }

        public static string? ReadNullableString(byte[] buffer, ref int index)
        {
            var length = ReadInt16(buffer, ref index);
            if (length == -1)
                return default;
            CheckRemaining(buffer, index, length);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, length);
            index += length;
            return value;
        }

        public static string? ReadCompactNullableString(byte[] buffer, ref int index)
        {
            var length = Convert.ToInt32(ReadVarUInt32(buffer, ref index));
            if (length == 0)
                return default;
            length -= 1;
            CheckRemaining(buffer, index, length);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, length);
            index += length;
            return value;
        }

        public static byte[] ReadBytes(byte[] buffer, ref int index)
        {
            var length = ReadInt32(buffer, ref index);
            CheckRemaining(buffer, index, length);
            return buffer[index..(index += length)];
        }

        public static byte[] ReadCompactBytes(byte[] buffer, ref int index)
        {
            var length = Convert.ToInt32(ReadVarUInt32(buffer, ref index)) - 1;
            CheckRemaining(buffer, index, length);
            return buffer[index..(index += length)];
        }

        public static byte[]? ReadNullableBytes(byte[] buffer, ref int index)
        {
            var length = ReadInt32(buffer, ref index);
            if (length == -1)
                return default;
            CheckRemaining(buffer, index, length);
            return buffer[index..(index += length)];
        }

        public static byte[]? ReadCompactNullableBytes(byte[] buffer, ref int index)
        {
            var length = Convert.ToInt32(ReadVarUInt32(buffer, ref index));
            if (length == 0)
                return default;
            length -= 1;
            CheckRemaining(buffer, index, length);
            return buffer[index..(index += length)];
        }

        public static IRecords? ReadMessageSet(byte[] buffer, ref int index)
        {
            var records = ImmutableList.CreateBuilder<IRecord>();
            while (buffer.Length > 0)
                records.Add(
                    ReadMessage(
                        buffer,
                        ref index,
                        records.Count
                    )
                );
            return new MessageSet(
                Records: records.ToImmutable()
            );
        }

        private static IRecord ReadMessage(byte[] buffer, ref int index, int sequence)
        {
            var offset = ReadInt64(buffer, ref index);
            var messageSize = ReadInt32(buffer, ref index);
            var crc = ReadInt32(buffer, ref index);
            var magic = ReadInt8(buffer, ref index);
            var attributes = (Records.Attributes)ReadInt16(buffer, ref index);
            var timestamp = 0L;
            if (magic == 1)
                timestamp = ReadInt64(buffer, ref index);
            var key = ReadBytes(buffer, ref index);
            var value = ReadBytes(buffer, ref index);
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

        public static IRecords? ReadRecords(byte[] buffer, ref int index)
        {
            var length = ReadInt32(buffer, ref index);
            if (length == 0)
                return default;
            CheckRemaining(buffer, index, length);
            return ReadRecordsInternal(buffer, ref index);
        }

        public static IRecords? ReadCompactRecords(byte[] buffer, ref int index)
        {
            var length = ReadVarUInt32(buffer, ref index);
            if (length == 0)
                return default;
            CheckRemaining(buffer, index, length);
            return ReadRecordsInternal(buffer, ref index);
        }

        private static IRecords? ReadRecordsInternal(byte[] buffer, ref int index)
        {
            var baseOffset = ReadInt64(buffer, ref index);
            var size = ReadInt32(buffer, ref index);
            var partitionLeaderEpoch = ReadInt32(buffer, ref index);
            var magic = ReadInt8(buffer, ref index);
            var crc = ReadInt32(buffer, ref index);
            var attributes = ReadInt16(buffer, ref index);
            var lastOffsetDelta = ReadInt32(buffer, ref index);
            var baseTimestamp = ReadInt64(buffer, ref index);
            var maxTimestamp = ReadInt64(buffer, ref index);
            var producerId = ReadInt64(buffer, ref index);
            var producerEpoch = ReadInt16(buffer, ref index);
            var baseSequence = ReadInt32(buffer, ref index);

            var records = ReadArray(
                buffer,
                ref index,
                ReadRecord
            ) ?? ImmutableArray<IRecord>.Empty;
            return new RecordBatch(
                BaseOffset: baseOffset,
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
                Records: records
            );
        }

        private static IRecord ReadRecord(byte[] buffer, ref int index)
        {
            var length = ReadVarInt32(buffer, ref index);
            var attributes = ReadInt8(buffer, ref index);
            var timestampDelta = ReadVarInt64(buffer, ref index);
            var offsetDelta = ReadVarInt32(buffer, ref index);
            var key = default(ReadOnlyMemory<byte>?);
            var keyLength = ReadVarInt32(buffer, ref index);
            if (keyLength >= 0)
                key = buffer[index..(index += keyLength)].AsMemory();
            var value = default(ReadOnlyMemory<byte>?);
            var valueLength = ReadVarInt32(buffer, ref index);
            if (valueLength >= 0)
                value = buffer[index..(index += valueLength)].AsMemory();
            var headers = ImmutableArray<RecordHeader>.Empty;
            var headerCount = ReadVarInt32(buffer, ref index);
            if(headerCount > 0)
            {
                var headersBuilder = ImmutableArray.CreateBuilder<RecordHeader>(headerCount);
                for(int i = 0; i < headerCount; i++)
                    headersBuilder.Add(ReadRecordHeader(buffer, ref index));
                headers = headersBuilder.ToImmutable();
            }
            return new Record(
                Length: length,
                Attributes: (Attributes) attributes,
                TimestampDelta: timestampDelta,
                OffsetDelta: offsetDelta,
                Key: key,
                Value: value,
                Headers: headers
            );
        }

        private static RecordHeader ReadRecordHeader(byte[] buffer, ref int index)
        {
            var key = ReadCompactString(buffer, ref index);
            var value = ReadCompactBytes(buffer, ref index);
            return new(key, value);
        }

        public static ImmutableArray<TItem>? ReadArray<TItem>(byte[] buffer, ref int index, DecodeDelegate<TItem> readItem)
        {
            var length = ReadInt32(buffer, ref index);
            if (length == -1)
                return default;
            var items = new TItem[length];
            for (int i = 0; i < length; i++)
                items[i] = readItem(buffer, ref index);
            return items.ToImmutableArray();
        }

        public static ImmutableArray<TItem>? ReadCompactArray<TItem>(byte[] buffer, ref int index, DecodeDelegate<TItem> readItem)
        {
            var length = Convert.ToInt32(ReadVarUInt32(buffer, ref index));
            if (length == 0)
                return default;
            length -= 1;
            var items = new TItem[length];
            for (int i = 0; i < length; i++)
                items[i] = readItem(buffer, ref index);
            return items.ToImmutableArray();
        }

        private static void CheckRemaining(byte[] buffer, int index, long length)
        {
            var required = index + length;
            if (buffer.Length < required)
                throw new EndOfStreamException($"Buffer overflow");
        }

        private static ulong ZigZagDecode(byte[] buffer, ref int index, int bits)
        {
            var value = 0UL;
            var bit = 0;
            while (bit <= bits)
            {
                var b = buffer[index++];
                if (b < 0)
                    throw new EndOfStreamException();
                value |= ((ulong)b & 0x7f) << bit;
                if ((b & 0x80) == 0)
                    break;
                else
                    bit += 7;
            }
            if (bit > bits)
                throw new InvalidDataException($"ZigZag decoding exceeded ({bits}) bits");
            return value;
        }
    }
}
