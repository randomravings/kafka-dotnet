using Kafka.Common.Hashing;
using Kafka.Common.Model;
using Kafka.Common.Records;
using System.Collections.Immutable;
using System.Numerics;

namespace Kafka.Common.Encoding
{
    public static class BinaryEncoder
    {
        public static void WriteBoolean(Stream buffer, bool value) =>
            buffer.WriteByte((byte)(value ? 1 : 0))
        ;

        public static int WriteBoolean(byte[] buffer, int index, bool value)
        {
            buffer[index++] = ((byte)(value ? 1 : 0));
            return index;
        }

        public static void WriteInt8(Stream buffer, sbyte value) =>
            buffer.WriteByte((byte)value)
        ;

        public static int WriteInt8(byte[] buffer, int index, sbyte value)
        {
            buffer[index++] = (byte)value;
            return index;
        }

        public static void WriteInt16(Stream buffer, short value) =>
            WriteUInt16(buffer, (ushort)value)
        ;

        public static int WriteInt16(byte[] buffer, int index, short value) =>
            WriteUInt16(buffer, index, (ushort)value)
        ;

        public static void WriteUInt16(Stream buffer, ushort value)
        {
            buffer.WriteByte((byte)((value >> 8) & 0xff));
            buffer.WriteByte((byte)((value >> 0) & 0xff));
        }

        public static int WriteUInt16(byte[] buffer, int index, ushort value)
        {
            buffer[index++] = (byte)((value >> 8) & 0xff);
            buffer[index++] = (byte)((value >> 0) & 0xff);
            return index;
        }

        public static void WriteInt32(Stream buffer, int value) =>
            WriteUInt32(buffer, (uint)value)
        ;

        public static int WriteInt32(byte[] buffer, int index, int value) =>
            WriteUInt32(buffer, index, (uint)value)
        ;

        public static void WriteUInt32(Stream buffer, uint value)
        {
            buffer.WriteByte((byte)((value >> 24) & 0xff));
            buffer.WriteByte((byte)((value >> 16) & 0xff));
            buffer.WriteByte((byte)((value >> 8) & 0xff));
            buffer.WriteByte((byte)((value >> 0) & 0xff));
        }

        public static int WriteUInt32(byte[] buffer, int index, uint value)
        {
            buffer[index++] = (byte)((value >> 24) & 0xff);
            buffer[index++] = (byte)((value >> 16) & 0xff);
            buffer[index++] = (byte)((value >> 8) & 0xff);
            buffer[index++] = (byte)((value >> 0) & 0xff);
            return index;
        }

        public static void WriteInt64(Stream buffer, long value) =>
            WriteUInt64(buffer, (ulong)value)
        ;

        public static int WriteInt64(byte[] buffer, int index, long value) =>
            WriteUInt64(buffer, index, (ulong)value)
        ;

        public static void WriteUInt64(Stream buffer, ulong value)
        {
            buffer.WriteByte((byte)((value >> 56) & 0xff));
            buffer.WriteByte((byte)((value >> 48) & 0xff));
            buffer.WriteByte((byte)((value >> 40) & 0xff));
            buffer.WriteByte((byte)((value >> 32) & 0xff));
            buffer.WriteByte((byte)((value >> 24) & 0xff));
            buffer.WriteByte((byte)((value >> 16) & 0xff));
            buffer.WriteByte((byte)((value >> 8) & 0xff));
            buffer.WriteByte((byte)((value >> 0) & 0xff));
        }

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

        public static void WriteVarInt16(Stream buffer, short value) =>
            WriteVarUInt64(buffer, (ushort)((value << 1) ^ (value >> 15)))
        ;

        public static int WriteVarInt16(byte[] buffer, int index, short value) =>
            WriteVarUInt64(buffer, index, (ushort)((value << 1) ^ (value >> 15)))
        ;

        public static void WriteVarUInt16(Stream buffer, ushort value) =>
            WriteVarUInt64(buffer, value)
        ;

        public static int WriteVarUInt16(byte[] buffer, int index, ushort value) =>
            WriteVarUInt64(buffer, index, value)
        ;

        public static void WriteVarInt32(Stream buffer, int value) =>
            WriteVarUInt64(buffer, (uint)((value << 1) ^ (value >> 31)))
        ;

        public static int WriteVarInt32(byte[] buffer, int index, int value) =>
            WriteVarUInt64(buffer, index, (uint)((value << 1) ^ (value >> 31)))
        ;

        public static void WriteVarUInt32(Stream buffer, uint value) =>
            WriteVarUInt64(buffer, value)
        ;

        public static int WriteVarUInt32(byte[] buffer, int index, uint value) =>
            WriteVarUInt64(buffer, index, value)
        ;

        public static void WriteVarInt64(Stream buffer, long value) =>
            WriteVarUInt64(buffer, (ulong)((value << 1) ^ (value >> 63)))
        ;

        public static int WriteVarInt64(byte[] buffer, int index, long value) =>
            WriteVarUInt64(buffer, index, (ulong)((value << 1) ^ (value >> 63)))
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

        public static void WriteUuid(Stream buffer, Guid value)
        {
            var bytes = value.ToByteArray();
            buffer.Write(bytes);
        }

        public static int WriteUuid(byte[] buffer, int index, Guid value)
        {
            var bytes = value.ToByteArray();
            bytes.CopyTo(buffer, index);
            return index + bytes.Length;
        }

        public static void WriteFloat64(Stream buffer, double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            WriteInt64(buffer, bits);
        }

        public static int WriteFloat64(byte[] buffer, int index, double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            return WriteInt64(buffer, index, bits);
        }

        public static void WriteString(Stream buffer, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            WriteInt16(buffer, (short)bytes.Length);
            buffer.Write(bytes);
        }

        public static int WriteString(byte[] buffer, int index, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            index = WriteInt16(buffer, index, (short)bytes.Length);
            bytes.CopyTo(buffer, index);
            return index + bytes.Length;
        }

        public static void WriteCompactString(Stream buffer, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            WriteVarUInt32(buffer, (uint)(bytes.Length + 1));
            buffer.Write(bytes);
        }

        public static int WriteCompactString(byte[] buffer, int index, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            index = WriteVarUInt32(buffer, index, (uint)(bytes.Length + 1));
            bytes.CopyTo(buffer, index);
            return index + bytes.Length;
        }

        public static void WriteNullableString(Stream buffer, string? value)
        {
            if (value == null)
                WriteInt16(buffer, -1);
            else
                WriteString(buffer, value);
        }

        public static int WriteNullableString(byte[] buffer, int index, string? value) =>
            value switch
            {
                null => WriteInt16(buffer, index, -1),
                var v => WriteString(buffer, index, v)
            }
        ;

        public static void WriteCompactNullableString(Stream buffer, string? value)
        {
            if (value == null)
                WriteVarUInt32(buffer, 0);
            else
                WriteCompactString(buffer, value);
        }

        public static int WriteCompactNullableString(byte[] buffer, int index, string? value) =>
            value switch
            {
                null => WriteVarUInt32(buffer, index, 0),
                var v => WriteCompactString(buffer, index, v)
            }
        ;

        public static void WriteBytes(Stream buffer, ReadOnlyMemory<byte> value)
        {
            WriteInt32(buffer, value.Length);
            buffer.Write(value.Span);
        }

        public static int WriteBytes(byte[] buffer, int index, ReadOnlyMemory<byte> value)
        {
            index = WriteInt32(buffer, index, value.Length);
            foreach (var b in value.Span)
                buffer[index++] = b;
            return index;
        }

        public static void WriteCompactBytes(Stream buffer, ReadOnlyMemory<byte> value)
        {
            WriteVarUInt32(buffer, (uint)(value.Length + 1));
            buffer.Write(value.Span);
        }

        public static int WriteCompactBytes(byte[] buffer, int index, ReadOnlyMemory<byte> value)
        {
            index = WriteVarUInt32(buffer, index, (uint)(value.Length + 1));
            foreach (var b in value.Span)
                buffer[index++] = b;
            return index;
        }

        public static void WriteNullableBytes(Stream buffer, ReadOnlyMemory<byte>? value)
        {
            if (value == null)
                WriteInt32(buffer, -1);
            else
                WriteBytes(buffer, value.Value);
        }

        public static int WriteNullableBytes(byte[] buffer, int index, ReadOnlyMemory<byte>? value) =>
            value switch
            {
                null => WriteInt32(buffer, index, -1),
                var v => WriteBytes(buffer, index, v.Value)
            }
        ;

        public static void WriteCompactNullableBytes(Stream buffer, ReadOnlyMemory<byte>? value)
        {
            if (value == null)
                WriteVarUInt32(buffer, 0);
            else
                WriteCompactBytes(buffer, value.Value);
        }

        public static int WriteCompactNullableBytes(byte[] buffer, int index, ReadOnlyMemory<byte>? value) =>
            value switch
            {
                null => WriteVarUInt32(buffer, index, 0),
                var v => WriteCompactBytes(buffer, index, v.Value)
            }
        ;

        public static void WriteRecords(Stream buffer, ImmutableArray<IRecords>? records)
        {
            if (records == null)
            {
                WriteInt32(buffer, -1);
                return;
            }
            var totalBytes = records.Value.Sum(r => r.BatchLength + RECORDS_HEADER_SIZE);
            WriteInt32(buffer, totalBytes);
            foreach (var record in records.Value)
                WriteRecordBatch(buffer, record);
        }

        public static int WriteRecords(byte[] buffer, int index, ImmutableArray<IRecords>? records)
        {
            if (records == null)
                return WriteInt32(buffer, index, -1);
            var totalBytes = records.Value.Sum(r => r.BatchLength + RECORDS_HEADER_SIZE);
            index = WriteInt32(buffer, index, totalBytes);
            foreach (var record in records.Value)
                index = WriteRecordBatch(buffer, index, record);
            return index;
        }

        public static void WriteCompactRecords(Stream buffer, ImmutableArray<IRecords>? records)
        {
            if (records == null)
            {
                WriteVarUInt32(buffer, 0);
                return;
            }
            var totalBytes = Convert.ToUInt32(records.Value.Sum(r => r.BatchLength + RECORDS_HEADER_SIZE));
            WriteVarUInt32(buffer, totalBytes + 1);
            foreach (var record in records.Value)
                WriteRecordBatch(buffer, record);
        }

        public static int WriteCompactRecords(byte[] buffer, int index, ImmutableArray<IRecords>? records)
        {
            if (records == null)
                return WriteVarUInt32(buffer, index, 0);
            var totalBytes = Convert.ToUInt32(records.Value.Sum(r => r.BatchLength + RECORDS_HEADER_SIZE));
            index = WriteVarUInt32(buffer, index, totalBytes + 1);
            foreach (var record in records.Value)
                index = WriteRecordBatch(buffer, index, record);
            return index;
        }

        private const int RECORDS_HEADER_SIZE = 61;
        private const int RECORDS_LOG_OVERHEAD = 12;
        private const int RECORDS_SIZE_PADDING = RECORDS_HEADER_SIZE - RECORDS_LOG_OVERHEAD;

        private static void WriteRecordBatch(Stream buffer, IRecords records)
        {
            // Write batch header.
            WriteInt64(buffer, records.BaseOffset);
            WriteInt32(buffer, records.BatchLength + RECORDS_SIZE_PADDING);
            WriteInt32(buffer, records.PartitionLeaderEpoch);
            WriteInt8(buffer, records.Magic);
            var crcIndex = buffer.Position;     // store crc index.
            buffer.Seek(4, SeekOrigin.Current); // reserve crc slot.
            var crcStart = buffer.Position;     // store crc compute start index.
            WriteInt16(buffer, (short)records.Attributes);
            WriteInt32(buffer, records.LastOffsetDelta);
            WriteInt64(buffer, records.BaseTimestamp);
            WriteInt64(buffer, records.MaxTimestamp);
            WriteInt64(buffer, records.ProducerId);
            WriteInt16(buffer, records.ProducerEpoch);
            WriteInt32(buffer, records.BaseSequence);
            WriteInt32(buffer, records.Count);

            // Write records.
            foreach (var record in records)
                WriteRecord(buffer, record);

            var crcEnd = buffer.Position;

            // Compute and store crc.
            buffer.Seek(crcStart, SeekOrigin.Begin);
            var crc = Crc32c.Update(0U, buffer, crcEnd);
            buffer.Seek(crcIndex, SeekOrigin.Begin);
            WriteInt32(buffer, unchecked((int)crc));
            buffer.Seek(crcEnd, SeekOrigin.Begin);
        }

        private static int WriteRecordBatch(byte[] buffer, int index, IRecords records)
        {
            // Write batch header.
            index = WriteInt64(buffer, index, records.BaseOffset);
            index = WriteInt32(buffer, index, records.BatchLength + RECORDS_SIZE_PADDING);
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

        private static void WriteRecord(Stream buffer, IRecord record)
        {
            // Write record header.
            WriteVarInt32(buffer, record.Length);
            WriteInt8(buffer, 0);
            WriteVarInt64(buffer, record.TimestampDelta);
            WriteVarInt32(buffer, record.OffsetDelta);

            // Write record key.
            if (record.Key.HasValue)
            {
                WriteVarInt32(buffer, record.Key.Value.Length);
                buffer.Write(record.Key.Value.Span);
            }
            else
            {
                WriteVarInt32(buffer, -1);
            }

            // Write record value.
            if (record.Value.HasValue)
            {
                WriteVarInt32(buffer, record.Value.Value.Length);
                buffer.Write(record.Value.Value.Span);
            }
            else
            {
                WriteVarInt32(buffer, -1);
            }

            // Write headers.
            WriteVarInt32(buffer, record.Headers.Count);
            foreach (var header in record.Headers)
                WriteRecordHeader(buffer, header);
        }

        private static int WriteRecord(byte[] buffer, int index, IRecord record)
        {
            // Write record header.
            index = WriteVarInt32(buffer, index, record.Length);
            index = WriteInt8(buffer, index, 0);
            index = WriteVarInt64(buffer, index, record.TimestampDelta);
            index = WriteVarInt32(buffer, index, record.OffsetDelta);

            // Write record key.
            if (record.Key.HasValue)
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
            index = WriteVarInt32(buffer, index, record.Headers.Count);
            foreach (var header in record.Headers)
                index = WriteRecordHeader(buffer, index, header);
            return index;
        }

        public static int WriteRecord(
            byte[] buffer,
            long timestampDelta,
            int offsetDelta,
            ReadOnlyMemory<byte>? key,
            ReadOnlyMemory<byte>? value,
            ImmutableArray<RecordHeader> headers
        )
        {
            var index = 0;
            // Write record header.
            index = WriteVarInt32(buffer, index, buffer.Length);
            index = WriteInt8(buffer, index, 0);
            index = WriteVarInt64(buffer, index, timestampDelta);
            index = WriteVarInt32(buffer, index, offsetDelta);

            // Write record key.
            if (key.HasValue)
            {
                index = WriteVarInt32(buffer, index, key.Value.Length);
                foreach (var b in key.Value.Span)
                    buffer[index++] = b;
            }
            else
            {
                index = WriteVarInt32(buffer, index, -1);
            }

            // Write record value.
            if (value.HasValue)
            {
                index = WriteVarInt32(buffer, index, value.Value.Length);
                foreach (var b in value.Value.Span)
                    buffer[index++] = b;
            }
            else
            {
                index = WriteVarInt32(buffer, index, -1);
            }

            // Write headers.
            index = WriteVarInt32(buffer, index, headers.Length);
            foreach (var header in headers)
                index = WriteRecordHeader(buffer, index, header);
            return index;
        }

        private static void WriteRecordHeader(Stream buffer, RecordHeader header)
        {
            WriteCompactString(buffer, header.Key);
            WriteCompactBytes(buffer, header.Value);
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

        public static int WriteTaggedFields(byte[] buffer, int index, ImmutableArray<TaggedField> taggedFields)
        {
            index = WriteVarInt32(buffer, index, taggedFields.Length);
            if (taggedFields.Length == 0)
                return index;
            foreach(var taggedField in taggedFields)
                index = WriteTaggedField(buffer, index, taggedField);
            return index;
        }

        public static int WriteTaggedField(byte[] buffer, int index, TaggedField taggedField)
        {
            index = WriteVarInt32(buffer, index, taggedField.Tag);
            return WriteCompactBytes(buffer, index, taggedField.Value);
        }

        public static int SizeOfVarInt32(int value) =>
            SizeOfVarUInt32((uint)((value << 1) ^ (value >> 31)))
        ;

        public static int SizeOfVarUInt32(uint value)
        {
            // For implementation notes @see #sizeOfUnsignedVarint(int)
            // Similar logic is applied to allow for 64bit input -> 1-9byte output.
            // return (38 - leadingZeros) / 7 + leadingZeros / 32;
            var leadingZeros = BitOperations.LeadingZeroCount(value);
            var leadingZerosBelow38DividedBy7 = ((38 - leadingZeros) * 0b10010010010010011) >> 19;
            return leadingZerosBelow38DividedBy7 + ((leadingZeros >> 5) & 0x7f);
        }

        public static int SizeOfVarInt64(long value) =>
            SizeOfVarUInt64((ulong)((value << 1) ^ (value >> 63)))
        ;

        public static int SizeOfVarUInt64(ulong value)
        {
            // For implementation notes @see #sizeOfUnsignedVarint(int)
            // Similar logic is applied to allow for 64bit input -> 1-9byte output.
            // return (70 - leadingZeros) / 7 + leadingZeros / 64;
            var leadingZeros = BitOperations.LeadingZeroCount(value);
            var leadingZerosBelow70DividedBy7 = ((70 - leadingZeros) * 0b10010010010010011) >> 19;
            return leadingZerosBelow70DividedBy7 + ((leadingZeros >> 6) & 0x7f);
        }

        /// <summary>
        /// Used to compute the precise record size in bytes.
        /// </summary>
        /// <param name="timestampDelta"></param>
        /// <param name="offsetDelta"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static int ComputeRecordSize(
            long timestampDelta,
            int offsetDelta,
            ReadOnlyMemory<byte>? key,
            ReadOnlyMemory<byte>? value,
            ImmutableArray<RecordHeader> headers
        ) =>
            SizeOfVarInt64(timestampDelta) +
            SizeOfVarInt32(offsetDelta) +
            1 + // Attributes
            SizeOfVarInt32(key?.Length ?? -1) +
            (key?.Length ?? 0) +
            SizeOfVarInt32(value?.Length ?? -1) +
            (value?.Length ?? 0) +
            ComputeHeadersSize(headers)
        ;

        /// <summary>
        /// Used to compute the precise Record header size in bytes.
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static int ComputeHeadersSize(
            ImmutableArray<RecordHeader> headers
        ) =>
            SizeOfVarInt32(headers.Length) +
            headers.Sum(
                r =>
                    SizeOfVarInt32(r.Key.Length) +
                    r.Key.Length +
                    SizeOfVarInt32(r.Value.Length) +
                    r.Value.Length
            )
        ;
    }
}
