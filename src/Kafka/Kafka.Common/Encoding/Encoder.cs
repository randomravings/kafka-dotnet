using Kafka.Common.Records;
using System.Collections.Immutable;
using System.Numerics;

namespace Kafka.Common.Encoding
{
    public static class Encoder
    {
        public static int WriteBoolean(MemoryStream buffer, bool value)
        {
            buffer.WriteByte((byte)(value ? 1 : 0));
            return 1;
        }

        public static int WriteInt8(MemoryStream buffer, sbyte value)
        {
            buffer.WriteByte((byte)value);
            return 1;
        }

        public static int WriteInt16(MemoryStream buffer, short value)
        {
            buffer.WriteByte((byte)((value >> 8) & 0xff));
            buffer.WriteByte((byte)value);
            return 2;
        }

        public static int WriteUInt16(MemoryStream buffer, ushort value)
        {
            buffer.WriteByte((byte)((value >> 8) & 0xff));
            buffer.WriteByte((byte)value);
            return 2;
        }

        public static int WriteInt32(MemoryStream buffer, int value) =>
            WriteUInt32(buffer, (uint)value)
        ;

        public static int WriteUInt32(MemoryStream buffer, uint value)
        {
            for (int i = 24; i >= 0; i -= 8)
                buffer.WriteByte((byte)((value >> i) & 0xff));
            return 4;
        }

        public static int WriteInt64(MemoryStream buffer, long value)
        {
            for (int i = 56; i >= 0; i -= 8)
                buffer.WriteByte((byte)((value >> i) & 0xff));
            return 8;
        }

        public static int WriteVarUInt32(MemoryStream buffer, uint value) =>
            WriteVarUInt64(buffer, value)
        ;

        public static int WriteVarInt32(MemoryStream buffer, int value) =>
            WriteVarUInt64(buffer, (uint)((value << 1) ^ (value >> 31)))
        ;

        public static int WriteVarInt64(MemoryStream buffer, long value) =>
            WriteVarUInt64(buffer, (ulong)((value << 1) ^ (value >> 63)))
        ;

        public static int WriteVarUInt64(MemoryStream buffer, ulong value)
        {
            var i = 0;
            var v = value;
            while ((v & 0xffffffffffffff80UL) != 0UL)
            {
                buffer.WriteByte((byte)((v & 0x7fUL) | 0x80UL));
                v >>= 7;
                i++;
            }
            buffer.WriteByte((byte)v);
            return i + 1;
        }

        public static int WriteUuid(MemoryStream buffer, Guid value)
        {
            buffer.Write(value.ToByteArray());
            return 16;
        }

        public static int WriteFloat64(MemoryStream buffer, double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            return WriteInt64(buffer, bits);
        }

        public static int WriteString(MemoryStream buffer, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            var len = WriteInt16(buffer, (short)value.Length);
            buffer.Write(bytes);
            return len + bytes.Length;
        }

        public static int WriteCompactString(MemoryStream buffer, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            var len = WriteVarUInt32(buffer, (uint)value.Length);
            buffer.Write(bytes);
            return len + bytes.Length;
        }

        public static int WriteNullableString(MemoryStream buffer, string? value) =>
            value switch
            {
                string s => WriteString(buffer, s),
                _ => WriteInt16(buffer, -1)
            }
        ;

        public static int WriteCompactNullableString(MemoryStream buffer, string? value) =>
            value switch
            {
                string s => WriteCompactString(buffer, s),
                _ => WriteVarUInt32(buffer, 0)
            }
        ;

        public static int WriteBytes(MemoryStream buffer, byte[] value)
        {
            var len = WriteInt32(buffer, value.Length);
            buffer.Write(value);
            return len + value.Length;
        }

        public static int WriteBytes(MemoryStream buffer, ImmutableArray<byte> value)
        {
            var len = WriteInt32(buffer, value.Length);
            buffer.Write(value.AsSpan());
            return len + value.Length;
        }

        public static int WriteCompactBytes(MemoryStream buffer, byte[] value)
        {
            var len = WriteVarUInt32(buffer, (uint)value.Length);
            buffer.Write(value);
            return len + value.Length;
        }

        public static int WriteCompactBytes(MemoryStream buffer, ImmutableArray<byte> value)
        {
            var len = WriteVarUInt32(buffer, (uint)value.Length);
            buffer.Write(value.AsSpan());
            return len + value.Length;
        }

        public static int WriteNullableBytes(MemoryStream buffer, byte[]? value) =>
            value switch
            {
                byte[] b => WriteBytes(buffer, b),
                _ => WriteInt32(buffer, -1)

            }
        ;

        public static int WriteCompactNullableBytes(MemoryStream buffer, byte[]? value) =>
            value switch
            {

                byte[] b => WriteCompactBytes(buffer, b),
                _ => WriteVarUInt32(buffer, 0)
            }
        ;

        public static long WriteMessageSet(MemoryStream buffer, IRecords records)
        {
            var pos = buffer.Position;
            foreach (var record in records)
                WriteMessage(buffer, record);
            return buffer.Position - pos;
        }

        private static void WriteMessage(MemoryStream buffer, IRecord record)
        {
            WriteInt64(buffer, record.Offset);
            WriteInt32(buffer, record.SizeInBytes);
            WriteInt32(buffer, record.Crc);
            WriteInt8(buffer, record.Magic);
            WriteInt16(buffer, (short)record.Attributes);
            if (record.Magic == 1)
                WriteInt64(buffer, record.Timestamp);
            WriteNullableBytes(buffer, record.Key);
            WriteNullableBytes(buffer, record.Value);
        }

        public static long WriteRecords(MemoryStream buffer, IRecords records)
        {
            var pos = buffer.Position;
            WriteInt64(buffer, records.Offset);
            WriteInt32(buffer, records.Size);
            WriteInt32(buffer, records.PartitionLeaderEpoch);
            WriteInt8(buffer, records.Magic);
            WriteInt32(buffer, records.Crc);
            WriteInt16(buffer, (short)records.Attributes);
            WriteInt32(buffer, records.LastOffsetDelta);
            WriteInt64(buffer, records.BaseTimestamp);
            WriteInt64(buffer, records.MaxTimestamp);
            WriteInt64(buffer, records.ProducerId);
            WriteInt16(buffer, records.ProducerEpoch);
            WriteInt32(buffer, records.BaseSequence);
            foreach (var record in records)
                WriteRecord(buffer, record);
            return buffer.Position - pos;
        }

        private static void WriteRecord(MemoryStream buffer, IRecord record)
        {
            WriteVarInt32(buffer, record.SizeInBytes);
            WriteInt16(buffer, (short)record.Attributes);
            WriteVarInt64(buffer, record.TimestampDelta);
            WriteVarInt32(buffer, record.OffsetDelta);
            WriteCompactNullableBytes(buffer, record.Key);
            WriteCompactNullableBytes(buffer, record.Value);
            foreach (var header in record.Headers)
                WriteRecordHeader(buffer, header);
        }

        private static void WriteRecordHeader(MemoryStream buffer, RecordHeader header)
        {
            WriteCompactString(buffer, header.HeaderKey);
            WriteCompactBytes(buffer, header.Value);
        }

        public static int WriteArray<TItem>(MemoryStream buffer, TItem[]? array, Func<MemoryStream, TItem, int> encodeItem)
        {
            if (array == null)
                return WriteInt32(buffer, -1);
            var size = WriteInt32(buffer, array.Length);
            foreach (var item in array)
                size += encodeItem(buffer, item);
            return size;
        }

        public static int WriteCompactArray<TItem>(MemoryStream buffer, TItem[]? array, Func<MemoryStream, TItem, int> encodeItem)
        {
            if (array == null)
                return WriteVarUInt32(buffer, 0);
            var size = WriteVarUInt32(buffer, (uint)array.Length);
            foreach (var item in array)
                size += encodeItem(buffer, item);
            return size;
        }

        public static int SizeOfInt32(int value) =>
            SizeOfUInt32((uint)((value << 1) ^ (value >> 31)))
        ;

        public static int SizeOfUInt32(uint value)
        {
            // For implementation notes @see #sizeOfUnsignedVarint(int)
            // Similar logic is applied to allow for 64bit input -> 1-9byte output.
            // return (38 - leadingZeros) / 7 + leadingZeros / 32;
            var leadingZeros = BitOperations.LeadingZeroCount(value);
            var leadingZerosBelow38DividedBy7 = ((38 - leadingZeros) * 0b10010010010010011) >> 19;
            return leadingZerosBelow38DividedBy7 + ((leadingZeros >> 5) & 0x7f);
        }

        public static int SizeOfInt64(long value) =>
            SizeOfUInt64((ulong)((value << 1) ^ (value >> 63)))
        ;

        private static int SizeOfUInt64(ulong value)
        {
            // For implementation notes @see #sizeOfUnsignedVarint(int)
            // Similar logic is applied to allow for 64bit input -> 1-9byte output.
            // return (70 - leadingZeros) / 7 + leadingZeros / 64;
            var leadingZeros = BitOperations.LeadingZeroCount(value);
            var leadingZerosBelow70DividedBy7 = ((70 - leadingZeros) * 0b10010010010010011) >> 19;
            return leadingZerosBelow70DividedBy7 + ((leadingZeros >> 6) & 0x7f);
        }
    }
}
