using Kafka.Common.Records;
using System.Collections.Immutable;
using System.Numerics;

namespace Kafka.Common.Encoding
{
    public static class Encoder
    {
        public static Memory<byte> WriteBoolean(Memory<byte> buffer, bool value)
        {
            buffer.Span[0] = ((byte)(value ? 1 : 0));
            return buffer[1..];
        }

        public static Memory<byte> WriteInt8(Memory<byte> buffer, sbyte value)
        {
            buffer.Span[0] = (byte)value;
            return buffer[1..];
        }

        public static Memory<byte> WriteInt16(Memory<byte> buffer, short value) =>
            WriteUInt16(buffer, (ushort)value)
        ;

        public static Memory<byte> WriteUInt16(Memory<byte> buffer, ushort value)
        {
            buffer.Span[0] = (byte)((value >> 8) & 0xff);
            buffer.Span[1] = (byte)((value >> 0) & 0xff);
            return buffer[2..];
        }

        public static Memory<byte> WriteInt32(Memory<byte> buffer, int value) =>
            WriteUInt32(buffer, (uint)value)
        ;

        public static Memory<byte> WriteUInt32(Memory<byte> buffer, uint value)
        {
            buffer.Span[0] = (byte)((value >> 24) & 0xff);
            buffer.Span[1] = (byte)((value >> 16) & 0xff);
            buffer.Span[2] = (byte)((value >> 8) & 0xff);
            buffer.Span[3] = (byte)((value >> 0) & 0xff);
            return buffer[4..];
        }

        public static Memory<byte> WriteInt64(Memory<byte> buffer, long value) =>
            WriteUInt64(buffer, (ulong)value)
        ;

        public static Memory<byte> WriteUInt64(Memory<byte> buffer, ulong value)
        {
            buffer.Span[0] = (byte)((value >> 56) & 0xff);
            buffer.Span[1] = (byte)((value >> 48) & 0xff);
            buffer.Span[2] = (byte)((value >> 40) & 0xff);
            buffer.Span[3] = (byte)((value >> 32) & 0xff);
            buffer.Span[4] = (byte)((value >> 24) & 0xff);
            buffer.Span[5] = (byte)((value >> 16) & 0xff);
            buffer.Span[6] = (byte)((value >> 8) & 0xff);
            buffer.Span[7] = (byte)((value >> 0) & 0xff);
            return buffer[8..];
        }

        public static Memory<byte> WriteVarInt16(Memory<byte> buffer, short value) =>
            WriteVarUInt64(buffer, (ushort)((value << 1) ^ (value >> 15)))
        ;

        public static Memory<byte> WriteVarUInt16(Memory<byte> buffer, ushort value) =>
            WriteVarUInt64(buffer, value)
        ;

        public static Memory<byte> WriteVarInt32(Memory<byte> buffer, int value) =>
            WriteVarUInt64(buffer, (uint)((value << 1) ^ (value >> 31)))
        ;

        public static Memory<byte> WriteVarUInt32(Memory<byte> buffer, uint value) =>
            WriteVarUInt64(buffer, value)
        ;

        public static Memory<byte> WriteVarInt64(Memory<byte> buffer, long value) =>
            WriteVarUInt64(buffer, (ulong)((value << 1) ^ (value >> 63)))
        ;

        public static Memory<byte> WriteVarUInt64(Memory<byte> buffer, ulong value)
        {
            var v = value;
            while ((v & 0xffffffffffffff80UL) != 0UL)
            {
                buffer.Span[0] = (byte)((v & 0x7fUL) | 0x80UL);
                buffer = buffer[1..];
                v >>= 7;
            }
            buffer.Span[0] = (byte)v;
            return buffer[1..];
        }

        public static Memory<byte> WriteUuid(Memory<byte> buffer, Guid value)
        {
            var bytes = value.ToByteArray();
            bytes.CopyTo(buffer);
            return buffer[bytes.Length..];
        }

        public static Memory<byte> WriteFloat64(Memory<byte> buffer, double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            return WriteInt64(buffer, bits);
        }

        public static Memory<byte> WriteString(Memory<byte> buffer, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            buffer = WriteInt16(buffer, (short)bytes.Length);
            bytes.CopyTo(buffer);
            return buffer[bytes.Length..];
        }

        public static Memory<byte> WriteCompactString(Memory<byte> buffer, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            buffer = WriteVarUInt32(buffer, (uint)bytes.Length + 1);
            bytes.CopyTo(buffer);
            return buffer[bytes.Length..];
        }

        public static Memory<byte> WriteNullableString(Memory<byte> buffer, string? value) =>
            value switch
            {
                null => WriteInt16(buffer, -1),
                var v => WriteString(buffer, v)
            }
        ;

        public static Memory<byte> WriteCompactNullableString(Memory<byte> buffer, string? value) =>
            value switch
            {
                null => WriteVarUInt32(buffer, 0),
                var v => WriteCompactString(buffer, v)
            }
        ;

        public static Memory<byte> WriteBytes(Memory<byte> buffer, ImmutableArray<byte> value)
        {
            buffer = WriteInt32(buffer, value.Length);
            value.AsSpan().CopyTo(buffer.Span);
            return buffer[value.Length..];
        }

        public static Memory<byte> WriteCompactBytes(Memory<byte> buffer, ImmutableArray<byte> value)
        {
            buffer = WriteVarUInt32(buffer, (uint)value.Length + 1);
            value.AsSpan().CopyTo(buffer.Span);
            return buffer[value.Length..];
        }

        public static Memory<byte> WriteNullableBytes(Memory<byte> buffer, ImmutableArray<byte>? value) =>
            value switch
            {
                null => WriteInt32(buffer, -1),
                var v => WriteBytes(buffer, v.Value)
            }
        ;

        public static Memory<byte> WriteCompactNullableBytes(Memory<byte> buffer, ImmutableArray<byte>? value) =>
            value switch
            {
                null => WriteVarUInt32(buffer, 0),
                var v => WriteCompactBytes(buffer, v.Value)
            }
        ;

        public static Memory<byte> WriteMessageSet(Memory<byte> buffer, IRecords? records)
        {
            if (records == null)
                return WriteInt32(buffer, -1);
            foreach (var record in records)
                buffer = WriteMessage(buffer, record);
            return buffer;
        }

        private static Memory<byte> WriteMessage(Memory<byte> buffer, IRecord record)
        {
            buffer = WriteInt64(buffer, record.Offset);
            buffer = WriteInt32(buffer, record.SizeInBytes);
            buffer = WriteInt32(buffer, record.Crc);
            buffer = WriteInt8(buffer, record.Magic);
            buffer = WriteInt16(buffer, (short)record.Attributes);
            if (record.Magic == 1)
                buffer = WriteInt64(buffer, record.Timestamp);
            buffer = WriteNullableBytes(buffer, record.Key);
            buffer = WriteNullableBytes(buffer, record.Value);
            return buffer;
        }

        public static Memory<byte> WriteRecords(Memory<byte> buffer, IRecords? records) =>
            records switch
            {
                null => WriteInt32(buffer, -1),
                var v => WriteRecordsInternal(buffer, v)
            }
        ;

        public static Memory<byte> WriteCompactRecords(Memory<byte> buffer, IRecords? records) =>
            records switch
            {
                null => WriteVarUInt32(buffer, 0),
                var v => WriteRecordsInternal(buffer, v),
            }
        ;

        private static Memory<byte> WriteRecordsInternal(Memory<byte> buffer, IRecords records)
        {
            buffer = WriteInt64(buffer, records.Offset);
            buffer = WriteInt32(buffer, records.Size);
            buffer = WriteInt32(buffer, records.PartitionLeaderEpoch);
            buffer = WriteInt8(buffer, records.Magic);
            buffer = WriteInt32(buffer, records.Crc);
            buffer = WriteInt16(buffer, (short)records.Attributes);
            buffer = WriteInt32(buffer, records.LastOffsetDelta);
            buffer = WriteInt64(buffer, records.BaseTimestamp);
            buffer = WriteInt64(buffer, records.MaxTimestamp);
            buffer = WriteInt64(buffer, records.ProducerId);
            buffer = WriteInt16(buffer, records.ProducerEpoch);
            buffer = WriteInt32(buffer, records.BaseSequence);
            foreach (var record in records)
                buffer = WriteRecord(buffer, record);
            return buffer;
        }

        private static Memory<byte> WriteRecord(Memory<byte> buffer, IRecord record)
        {
            buffer = WriteVarInt32(buffer, record.SizeInBytes);
            buffer = WriteInt16(buffer, (short)record.Attributes);
            buffer = WriteVarInt64(buffer, record.TimestampDelta);
            buffer = WriteVarInt32(buffer, record.OffsetDelta);
            buffer = WriteCompactNullableBytes(buffer, record.Key);
            buffer = WriteCompactNullableBytes(buffer, record.Value);
            foreach (var header in record.Headers)
                buffer = WriteRecordHeader(buffer, header);
            return buffer;
        }

        private static Memory<byte> WriteRecordHeader(Memory<byte> buffer, RecordHeader header)
        {
            buffer = WriteCompactString(buffer, header.HeaderKey);
            buffer = WriteCompactBytes(buffer, header.Value);
            return buffer;
        }

        public static Memory<byte> WriteArray<TItem>(Memory<byte> buffer, ImmutableArray<TItem>? array, EncodeDelegate<TItem> encodeItem)
        {
            if (array == null)
                return WriteInt32(buffer, -1);
            buffer = WriteInt32(buffer, array.Value.Length);
            foreach (var item in array)
                buffer = encodeItem(buffer, item);
            return buffer;
        }

        public static Memory<byte> WriteCompactArray<TItem>(Memory<byte> buffer, ImmutableArray<TItem>? array, EncodeDelegate<TItem> encodeItem)
        {
            if (array == null)
                return WriteVarUInt32(buffer, 0);
            buffer = WriteVarUInt32(buffer, (uint)array.Value.Length + 1);
            foreach (var item in array)
                buffer = encodeItem(buffer, item);
            return buffer;
        }

        public static void WriteInt32(Stream buffer, int value)
        {
            for (int i = 24; i >= 0; i -= 8)
                buffer.WriteByte((byte)((value >> i) & 0xff));
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
