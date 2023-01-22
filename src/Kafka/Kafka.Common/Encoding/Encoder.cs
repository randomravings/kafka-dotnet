using Kafka.Common.Hashing;
using Kafka.Common.Records;
using System.Linq;
using System.Collections.Immutable;
using System.Numerics;

namespace Kafka.Common.Encoding
{
    public static class Encoder
    {
        public static int WriteBoolean(byte[] buffer, int index, bool value)
        {
            buffer[index++] = ((byte)(value ? 1 : 0));
            return index;
        }

        public static int WriteInt8(byte[] buffer, int index, sbyte value)
        {
            buffer[index++] = (byte)value;
            return index;
        }

        public static int WriteInt16(byte[] buffer, int index, short value) =>
            WriteUInt16(buffer, index, (ushort)value)
        ;

        public static int WriteUInt16(byte[] buffer, int index, ushort value)
        {
            buffer[index++] = (byte)((value >> 8) & 0xff);
            buffer[index++] = (byte)((value >> 0) & 0xff);
            return index;
        }

        public static int WriteInt32(byte[] buffer, int index, int value) =>
            WriteUInt32(buffer, index, (uint)value)
        ;

        public static int WriteUInt32(byte[] buffer, int index, uint value)
        {
            buffer[index++] = (byte)((value >> 24) & 0xff);
            buffer[index++] = (byte)((value >> 16) & 0xff);
            buffer[index++] = (byte)((value >> 8) & 0xff);
            buffer[index++] = (byte)((value >> 0) & 0xff);
            return index;
        }

        public static int WriteInt64(byte[] buffer, int index, long value) =>
            WriteUInt64(buffer, index, (ulong)value)
        ;

        public static int WriteUInt64(byte[] buffer, int index, ulong value)
        {
            buffer[index++] = (byte)((value >> 56) & 0xff);
            buffer[index++] = (byte)((value >> 48) & 0xff);
            buffer[index++] = (byte)((value >> 40) & 0xff);
            buffer[index++] = (byte)((value >> 32) & 0xff);
            buffer[index++] = (byte)((value >> 24) & 0xff);
            buffer[index++] = (byte)((value >> 16) & 0xff);
            buffer[index++] = (byte)((value >> 8) & 0xff);
            buffer[index++] = (byte)((value >> 0) & 0xff);
            return index;
        }

        public static int WriteVarInt16(byte[] buffer, int index, short value) =>
            WriteVarUInt64(buffer, index, (ushort)((value << 1) ^ (value >> 15)))
        ;

        public static int WriteVarUInt16(byte[] buffer, int index, ushort value) =>
            WriteVarUInt64(buffer, index, value)
        ;

        public static int WriteVarInt32(byte[] buffer, int index, int value) =>
            WriteVarUInt64(buffer, index, (uint)((value << 1) ^ (value >> 31)))
        ;

        public static int WriteVarUInt32(byte[] buffer, int index, uint value) =>
            WriteVarUInt64(buffer, index, value)
        ;

        public static int WriteVarInt64(byte[] buffer, int index, long value) =>
            WriteVarUInt64(buffer, index, (ulong)((value << 1) ^ (value >> 63)))
        ;

        public static int WriteVarUInt64(byte[] buffer, int index, ulong value)
        {
            var v = value;
            while ((v & 0xffffffffffffff80UL) != 0UL)
            {
                buffer[index++] = (byte)((v & 0x7fUL) | 0x80UL);
                v >>= 7;
            }
            buffer[index++] = (byte)v;
            return index;
        }

        public static int WriteUuid(byte[] buffer, int index, Guid value)
        {
            var bytes = value.ToByteArray();
            bytes.CopyTo(buffer, index);
            return index + bytes.Length;
        }

        public static int WriteFloat64(byte[] buffer, int index, double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            return WriteInt64(buffer, index, bits);
        }

        public static int WriteString(byte[] buffer, int index, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            index = WriteInt16(buffer, index, (short)bytes.Length);
            bytes.CopyTo(buffer, index);
            return index + bytes.Length;
        }

        public static int WriteCompactString(byte[] buffer, int index, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            index = WriteVarUInt32(buffer, index, (uint)(bytes.Length + 1));
            bytes.CopyTo(buffer, index);
            return index + bytes.Length;
        }

        public static int WriteNullableString(byte[] buffer, int index, string? value) =>
            value switch
            {
                null => WriteInt16(buffer, index, -1),
                var v => WriteString(buffer, index, v)
            }
        ;

        public static int WriteCompactNullableString(byte[] buffer, int index, string? value) =>
            value switch
            {
                null => WriteVarUInt32(buffer, index, 0),
                var v => WriteCompactString(buffer, index, v)
            }
        ;

        public static int WriteBytes(byte[] buffer, int index, ReadOnlyMemory<byte> value)
        {
            index = WriteInt32(buffer, index, value.Length);
            foreach (var b in value.Span)
                buffer[index++] = b;
            return index;
        }

        public static int WriteCompactBytes(byte[] buffer, int index, ReadOnlyMemory<byte> value)
        {
            index = WriteVarUInt32(buffer, index, (uint)(value.Length + 1));
            foreach (var b in value.Span)
                buffer[index++] = b;
            return index;
        }

        public static int WriteNullableBytes(byte[] buffer, int index, ReadOnlyMemory<byte>? value) =>
            value switch
            {
                null => WriteInt32(buffer, index, -1),
                var v => WriteBytes(buffer, index, v.Value)
            }
        ;

        public static int WriteCompactNullableBytes(byte[] buffer, int index, ReadOnlyMemory<byte>? value) =>
            value switch
            {
                null => WriteVarUInt32(buffer, index, 0),
                var v => WriteCompactBytes(buffer, index, v.Value)
            }
        ;

        public static int WriteRecords(byte[] buffer, int index, ImmutableArray<IRecords>? records)
        {
            if (records == null)
                return WriteInt32(buffer, index, -1);
            var totalBytes = records.Value.Sum(r => r.Size + RECORDS_HEADER_SIZE);
            index = WriteInt32(buffer, index, totalBytes);
            foreach(var record in records.Value)
                index = WriteRecordBatch(buffer, index, record);
            return index;
        }

        public static int WriteCompactRecords(byte[] buffer, int index, ImmutableArray<IRecords>? records)
        {
            if (records == null)
                return WriteVarUInt32(buffer, index, 0);
            var totalBytes = Convert.ToUInt32(records.Value.Sum(r => r.Size + RECORDS_HEADER_SIZE));
            index = WriteVarUInt32(buffer, index, totalBytes + 1);
            foreach (var record in records.Value)
                index = WriteRecordBatch(buffer, index, record);
            return index;
        }

        private const int RECORDS_HEADER_SIZE = 61;
        private const int RECORDS_LOG_OVERHEAD = 12;
        private const int RECORDS_SIZE_PADDING = RECORDS_HEADER_SIZE - RECORDS_LOG_OVERHEAD;

        private static int WriteRecordBatch(byte[] buffer, int index, IRecords records)
        {
            // Write batch header.
            index = WriteInt64(buffer, index, records.Offset);
            index = WriteInt32(buffer, index, records.Size + RECORDS_SIZE_PADDING);
            index = WriteInt32(buffer, index, records.PartitionLeaderEpoch);
            index = WriteInt8(buffer, index, records.Magic);
            var crcIndex = index;   // store crc index.
            index += 4;             // reserve crc slot.
            var crcStart = index;   // store crc compute start index.
            index = WriteInt16(buffer, index, (short)records.Attributes);
            index = WriteInt32(buffer, index, records.LastOffsetDelta);
            index = WriteInt64(buffer, index, records.BaseTimestamp);
            index = WriteInt64(buffer, index, records.MaxTimestamp);
            index = WriteInt64(buffer, index, records.ProducerId);
            index = WriteInt16(buffer, index, records.ProducerEpoch);
            index = WriteInt32(buffer, index, records.BaseSequence);
            index = WriteInt32(buffer, index, records.Count);

            // Write records.
            foreach (var record in records)
                index = WriteRecord(buffer, index, record);

            // Compute and store crc.
            var crc = Crc32c.Update(buffer, crcStart, index - crcStart);
            WriteInt32(buffer, crcIndex, unchecked((int)crc));

            return index;
        }

        private static int WriteRecord(byte[] buffer, int index, IRecord record)
        {
            // Write record header.
            index = WriteVarInt32(buffer, index, record.Length);
            index = WriteInt8(buffer, index, 0);
            index = WriteVarInt64(buffer, index, record.TimestampDelta);
            index = WriteVarInt32(buffer, index, record.OffsetDelta);

            // Write record key.
            if(record.Key.HasValue)
            {
                index = WriteVarInt32(buffer, index, record.Key.Value.Length);
                foreach (var b in record.Key.Value.Span)
                    buffer[index++] = b;
            }
            else
            {
                index = WriteVarInt32(buffer, index, -1);
            }

            // Write record value.
            if (record.Value.HasValue)
            {
                index = WriteVarInt32(buffer, index, record.Value.Value.Length);
                foreach (var b in record.Value.Value.Span)
                    buffer[index++] = b;
            }
            else
            {
                index = WriteVarInt32(buffer, index, -1);
            }

            // Write headers.
            index = WriteVarInt32(buffer, index, record.Headers.Length);
            foreach (var header in record.Headers)
                index = WriteRecordHeader(buffer, index, header);
            return index;
        }

        private static int WriteRecordHeader(byte[] buffer, int index, RecordHeader header)
        {
            index = WriteCompactString(buffer, index, header.Key);
            index = WriteCompactBytes(buffer, index, header.Value);
            return index;
        }

        public static int WriteArray<TItem>(byte[] buffer, int index, ImmutableArray<TItem>? array, EncodeDelegate<TItem> encodeItem)
        {
            if (array == null)
                return WriteInt32(buffer, index, -1);
            index = WriteInt32(buffer, index, array.Value.Length);
            foreach (var item in array)
                index = encodeItem(buffer, index, item);
            return index;
        }

        public static int WriteCompactArray<TItem>(byte[] buffer, int index, ImmutableArray<TItem>? array, EncodeDelegate<TItem> encodeItem)
        {
            if (array == null)
                return WriteVarUInt32(buffer, index, 0);
            index = WriteVarUInt32(buffer, index, (uint)array.Value.Length + 1);
            foreach (var item in array)
                index = encodeItem(buffer, index, item);
            return index;
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
