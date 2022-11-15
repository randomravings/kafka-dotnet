using Kafka.Common.Records;
using System;
using System.Collections.Immutable;
using System.Numerics;

namespace Kafka.Common.Encoding
{
    public static class Encoder
    {
        public static void WriteBoolean(Stream buffer, bool value) =>
            buffer.WriteByte((byte)(value ? 1 : 0))
        ;

        public static void WriteInt8(Stream buffer, sbyte value) =>
            buffer.WriteByte((byte)value)
        ;

        public static void WriteInt16(Stream buffer, short value)
        {
            buffer.WriteByte((byte)((value >> 8) & 0xff));
            buffer.WriteByte((byte)value);
        }

        public static void WriteUInt16(Stream buffer, ushort value)
        {
            buffer.WriteByte((byte)((value >> 8) & 0xff));
            buffer.WriteByte((byte)value);
        }

        public static void WriteInt32(Stream buffer, int value) =>
            WriteUInt32(buffer, (uint)value)
        ;

        public static void WriteUInt32(Stream buffer, uint value)
        {
            for (int i = 24; i >= 0; i -= 8)
                buffer.WriteByte((byte)((value >> i) & 0xff));
        }

        public static void WriteInt64(Stream buffer, long value) =>
            WriteVarUInt64(buffer, (ulong)value)
        ;

        public static void WriteUInt64(Stream buffer, ulong value)
        {
            for (int i = 56; i >= 0; i -= 8)
                buffer.WriteByte((byte)((value >> i) & 0xff));
        }

        public static void WriteVarInt16(Stream buffer, short value) =>
            WriteVarUInt64(buffer, (ushort)((value << 1) ^ (value >> 15)))
        ;

        public static void WriteVarUInt16(Stream buffer, ushort value) =>
            WriteVarUInt64(buffer, value)
        ;

        public static void WriteVarInt32(Stream buffer, int value) =>
            WriteVarUInt64(buffer, (uint)((value << 1) ^ (value >> 31)))
        ;

        public static void WriteVarUInt32(Stream buffer, uint value) =>
            WriteVarUInt64(buffer, value)
        ;

        public static void WriteVarInt64(Stream buffer, long value) =>
            WriteVarUInt64(buffer, (ulong)((value << 1) ^ (value >> 63)))
        ;

        public static void WriteVarUInt64(Stream buffer, ulong value)
        {
            var v = value;
            while ((v & 0xffffffffffffff80UL) != 0UL)
            {
                buffer.WriteByte((byte)((v & 0x7fUL) | 0x80UL));
                v >>= 7;
            }
            buffer.WriteByte((byte)v);
        }

        public static void WriteUuid(Stream buffer, Guid value) =>
            buffer.Write(value.ToByteArray())
        ;

        public static void WriteFloat64(Stream buffer, double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            WriteInt64(buffer, bits);
        }

        public static void WriteString(Stream buffer, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            WriteInt16(buffer, (short)bytes.Length);
            buffer.Write(bytes);
        }

        public static void WriteCompactString(Stream buffer, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            WriteVarUInt32(buffer, (uint)bytes.Length + 1);
            buffer.Write(bytes);
        }

        public static void WriteNullableString(Stream buffer, string? value)
        {
            if (value == null)
                WriteInt16(buffer, -1);
            else
                WriteString(buffer, value);
        }

        public static void WriteCompactNullableString(Stream buffer, string? value)
        {
            if (value == null)
                WriteVarUInt32(buffer, 0);
            else
                WriteCompactString(buffer, value);
        }

        public static void WriteBytes(Stream buffer, byte[] value)
        {
            WriteInt32(buffer, value.Length);
            buffer.Write(value);
        }

        public static void WriteBytes(Stream buffer, ImmutableArray<byte> value)
        {
            WriteInt32(buffer, value.Length);
            buffer.Write(value.AsSpan());
        }

        public static void WriteCompactBytes(Stream buffer, byte[] value)
        {
            WriteVarUInt32(buffer, (uint)value.Length + 1);
            buffer.Write(value);
        }

        public static void WriteCompactBytes(Stream buffer, ImmutableArray<byte> value)
        {
            WriteVarUInt32(buffer, (uint)value.Length);
            buffer.Write(value.AsSpan());
        }

        public static void WriteNullableBytes(Stream buffer, byte[]? value)
        {
            if (value == null)
                WriteInt32(buffer, -1);
            else
                WriteBytes(buffer, value);
        }

        public static void WriteCompactNullableBytes(Stream buffer, byte[]? value)
        {
            if (value == null)
                WriteVarUInt32(buffer, 0);
            else
                WriteCompactBytes(buffer, value);
        }

        public static void WriteMessageSet(Stream buffer, IRecords? records)
        {
            if (records == null)
            {
                WriteInt32(buffer, -1);
                return;
            }
            var pos = buffer.Position;
            foreach (var record in records)
                WriteMessage(buffer, record);
        }

        private static void WriteMessage(Stream buffer, IRecord record)
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

        public static void WriteRecords(Stream buffer, IRecords? records)
        {
            if (records == null)
                WriteInt32(buffer, -1);
            else
                WriteRecordsInternal(buffer, records);
        }

        public static void WriteCompactRecords(Stream buffer, IRecords? records)
        {
            if (records == null)
                WriteVarUInt32(buffer, 0);
            else
                WriteRecordsInternal(buffer, records);
        }

        private static long WriteRecordsInternal(Stream buffer, IRecords records)
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

        private static void WriteRecord(Stream buffer, IRecord record)
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

        private static void WriteRecordHeader(Stream buffer, RecordHeader header)
        {
            WriteCompactString(buffer, header.HeaderKey);
            WriteCompactBytes(buffer, header.Value);
        }

        public static void WriteArray<TItem>(Stream buffer, ImmutableArray<TItem>? array, Action<Stream, TItem> encodeItem)
        {
            if (array == null)
            {
                WriteInt32(buffer, -1);
                return;
            }
            WriteInt32(buffer, array.Value.Length);
            foreach (var item in array)
                encodeItem(buffer, item);
        }

        public static void WriteCompactArray<TItem>(Stream buffer, ImmutableArray<TItem>? array, Action<Stream, TItem> encodeItem)
        {
            if (array == null)
            {
                WriteVarUInt32(buffer, 0);
                return;
            }
            WriteVarUInt32(buffer, (uint)array.Value.Length + 1);
            foreach (var item in array)
                encodeItem(buffer, item);
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
