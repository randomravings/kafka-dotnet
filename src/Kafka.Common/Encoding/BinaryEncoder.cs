using Kafka.Common.Hashing;
using Kafka.Common.Model;
using Kafka.Common.Records;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Kafka.Common.Encoding
{
    public static class BinaryEncoder
    {
        public static void WriteBoolean([NotNull] in Stream buffer, in bool value) =>
            buffer.WriteByte((byte)(value ? 1 : 0))
        ;

        public static int WriteBoolean([NotNull] in byte[] buffer, in int index, in bool value)
        {
            var i = index;
            buffer[i++] = ((byte)(value ? 1 : 0));
            return i;
        }

        public static void WriteInt8([NotNull] in Stream buffer, in sbyte value) =>
            buffer.WriteByte((byte)value)
        ;

        public static int WriteInt8([NotNull] in byte[] buffer, in int index, in sbyte value)
        {
            var i = index;
            buffer[i++] = (byte)value;
            return i;
        }

        public static void WriteInt16([NotNull] in Stream buffer, in short value) =>
            WriteUInt16(buffer, (ushort)value)
        ;

        public static int WriteInt16([NotNull] in byte[] buffer, in int index, in short value) =>
            WriteUInt16(buffer, index, (ushort)value)
        ;

        public static void WriteUInt16([NotNull] in Stream buffer, in ushort value)
        {
            buffer.WriteByte((byte)((value >> 8) & 0xff));
            buffer.WriteByte((byte)((value >> 0) & 0xff));
        }

        public static int WriteUInt16([NotNull] in byte[] buffer, in int index, in ushort value)
        {
            var i = index;
            buffer[i++] = (byte)((value >> 8) & 0xff);
            buffer[i++] = (byte)((value >> 0) & 0xff);
            return i;
        }

        public static void WriteInt32([NotNull] in Stream buffer, in int value) =>
            WriteUInt32(buffer, (uint)value)
        ;

        public static int WriteInt32([NotNull] in byte[] buffer, in int index, in int value) =>
            WriteUInt32(buffer, index, (uint)value)
        ;

        public static void WriteUInt32([NotNull] in Stream buffer, in uint value)
        {
            buffer.WriteByte((byte)((value >> 24) & 0xff));
            buffer.WriteByte((byte)((value >> 16) & 0xff));
            buffer.WriteByte((byte)((value >> 8) & 0xff));
            buffer.WriteByte((byte)((value >> 0) & 0xff));
        }

        public static int WriteUInt32([NotNull] in byte[] buffer, in int index, in uint value)
        {
            var i = index;
            buffer[i++] = (byte)((value >> 24) & 0xff);
            buffer[i++] = (byte)((value >> 16) & 0xff);
            buffer[i++] = (byte)((value >> 8) & 0xff);
            buffer[i++] = (byte)((value >> 0) & 0xff);
            return i;
        }

        public static void WriteInt64([NotNull] in Stream buffer, in long value) =>
            WriteUInt64(buffer, (ulong)value)
        ;

        public static int WriteInt64([NotNull] in byte[] buffer, in int index, in long value) =>
            WriteUInt64(buffer, index, (ulong)value)
        ;

        public static void WriteUInt64([NotNull] Stream buffer, in ulong value)
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

        public static int WriteUInt64([NotNull] in byte[] buffer, in int index, in ulong value)
        {
            var i = index;
            buffer[i++] = (byte)((value >> 56) & 0xff);
            buffer[i++] = (byte)((value >> 48) & 0xff);
            buffer[i++] = (byte)((value >> 40) & 0xff);
            buffer[i++] = (byte)((value >> 32) & 0xff);
            buffer[i++] = (byte)((value >> 24) & 0xff);
            buffer[i++] = (byte)((value >> 16) & 0xff);
            buffer[i++] = (byte)((value >> 8) & 0xff);
            buffer[i++] = (byte)((value >> 0) & 0xff);
            return i;
        }

        public static void WriteVarInt16([NotNull] in Stream buffer, in short value) =>
            WriteVarUInt64(buffer, (ushort)((value << 1) ^ (value >> 15)))
        ;

        public static int WriteVarInt16([NotNull] in byte[] buffer, in int index, in short value) =>
            WriteVarUInt64(buffer, index, (ushort)((value << 1) ^ (value >> 15)))
        ;

        public static void WriteVarUInt16([NotNull] Stream buffer, in ushort value) =>
            WriteVarUInt64(buffer, value)
        ;

        public static int WriteVarUInt16([NotNull] in byte[] buffer, in int index, in ushort value) =>
            WriteVarUInt64(buffer, index, value)
        ;

        public static void WriteVarInt32([NotNull] in Stream buffer, in int value) =>
            WriteVarUInt64(buffer, (uint)((value << 1) ^ (value >> 31)))
        ;

        public static int WriteVarInt32([NotNull] in byte[] buffer, in int index, in int value) =>
            WriteVarUInt64(buffer, index, (uint)((value << 1) ^ (value >> 31)))
        ;

        public static void WriteVarUInt32([NotNull] in Stream buffer, in uint value) =>
            WriteVarUInt64(buffer, value)
        ;

        public static int WriteVarUInt32([NotNull] in byte[] buffer, in int index, in uint value) =>
            WriteVarUInt64(buffer, index, value)
        ;

        public static void WriteVarInt64([NotNull] in Stream buffer, in long value) =>
            WriteVarUInt64(buffer, (ulong)((value << 1) ^ (value >> 63)))
        ;

        public static int WriteVarInt64([NotNull] in byte[] buffer, in int index, in long value) =>
            WriteVarUInt64(buffer, index, (ulong)((value << 1) ^ (value >> 63)))
        ;

        public static void WriteVarUInt64([NotNull] in Stream buffer, in ulong value)
        {
            var v = value;
            while ((v & 0xffffffffffffff80UL) != 0UL)
            {
                buffer.WriteByte((byte)((v & 0x7fUL) | 0x80UL));
                v >>= 7;
            }
            buffer.WriteByte((byte)v);
        }

        public static int WriteVarUInt64([NotNull] in byte[] buffer, in int index, in ulong value)
        {
            var i = index;
            var v = value;
            while ((v & 0xffffffffffffff80UL) != 0UL)
            {
                buffer[i++] = (byte)((v & 0x7fUL) | 0x80UL);
                v >>= 7;
            }
            buffer[i++] = (byte)v;
            return i;
        }

        public static void WriteUuid([NotNull] in Stream buffer, in Guid value)
        {
            var bytes = value.ToByteArray();
            buffer.Write(bytes);
        }

        public static int WriteUuid([NotNull] byte[] buffer, in int index, in Guid value)
        {
            var i = index;
            var bytes = value.ToByteArray();
            bytes.CopyTo(buffer, i);
            return i + bytes.Length;
        }

        public static void WriteFloat64([NotNull] in Stream buffer, in double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            WriteInt64(buffer, bits);
        }

        public static int WriteFloat64([NotNull] in byte[] buffer, in int index, in double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            return WriteInt64(buffer, index, bits);
        }

        public static void WriteString([NotNull] in Stream buffer, in string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            WriteInt16(buffer, (short)bytes.Length);
            buffer.Write(bytes);
        }

        public static int WriteString([NotNull] in byte[] buffer, in int index, in string value)
        {
            var i = index;
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            i = WriteInt16(buffer, i, (short)bytes.Length);
            bytes.CopyTo(buffer, i);
            return i + bytes.Length;
        }

        public static void WriteCompactString([NotNull] in Stream buffer, in string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            WriteVarUInt32(buffer, (uint)(bytes.Length + 1));
            buffer.Write(bytes);
        }

        public static int WriteCompactString([NotNull] in byte[] buffer, in int index, in string value)
        {
            var i = index;
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            i = WriteVarUInt32(buffer, i, (uint)(bytes.Length + 1));
            bytes.CopyTo(buffer, i);
            return i + bytes.Length;
        }

        public static void WriteNullableString([NotNull] in Stream buffer, in string? value)
        {
            if (value == null)
                WriteInt16(buffer, -1);
            else
                WriteString(buffer, value);
        }

        public static int WriteNullableString([NotNull] in byte[] buffer, in int index, in string? value) =>
            value switch
            {
                null => WriteInt16(buffer, index, -1),
                var v => WriteString(buffer, index, v)
            }
        ;

        public static void WriteCompactNullableString([NotNull] in Stream buffer, in string? value)
        {
            if (value == null)
                WriteVarUInt32(buffer, 0);
            else
                WriteCompactString(buffer, value);
        }

        public static int WriteCompactNullableString([NotNull] in byte[] buffer, in int index, in string? value) =>
            value switch
            {
                null => WriteVarUInt32(buffer, index, 0),
                var v => WriteCompactString(buffer, index, v)
            }
        ;

        public static void WriteBytes([NotNull] in Stream buffer, in ReadOnlyMemory<byte> value)
        {
            WriteInt32(buffer, value.Length);
            buffer.Write(value.Span);
        }

        public static int WriteBytes([NotNull] in byte[] buffer, in int index, in ReadOnlyMemory<byte> value)
        {
            var i = index;
            i = WriteInt32(buffer, i, value.Length);
            var span = value.Span;
            for (int j = 0; j < span.Length; j++)
                buffer[i++] = span[j];
            return i;
        }

        public static void WriteCompactBytes([NotNull] Stream buffer, in ReadOnlyMemory<byte> value)
        {
            WriteVarUInt32(buffer, (uint)(value.Length + 1));
            buffer.Write(value.Span);
        }

        public static int WriteCompactBytes([NotNull] in byte[] buffer, in int index, in ReadOnlyMemory<byte> value)
        {
            var i = index;
            i = WriteVarUInt32(buffer, i, (uint)(value.Length + 1));
            var span = value.Span;
            for (int j = 0; j < span.Length; j++)
                buffer[i++] = span[j];
            return i;
        }

        public static void WriteNullableBytes([NotNull] in Stream buffer, in ReadOnlyMemory<byte>? value)
        {
            if (value == null)
                WriteInt32(buffer, -1);
            else
                WriteBytes(buffer, value.Value);
        }

        public static int WriteNullableBytes([NotNull] in byte[] buffer, in int index, in ReadOnlyMemory<byte>? value) =>
            value switch
            {
                null => WriteInt32(buffer, index, -1),
                var v => WriteBytes(buffer, index, v.Value)
            }
        ;

        public static void WriteCompactNullableBytes([NotNull] in Stream buffer, in ReadOnlyMemory<byte>? value)
        {
            if (value == null)
                WriteVarUInt32(buffer, 0u);
            else
                WriteCompactBytes(buffer, value.Value);
        }

        public static int WriteCompactNullableBytes([NotNull] in byte[] buffer, in int index, in ReadOnlyMemory<byte>? value) =>
            value switch
            {
                null => WriteVarUInt32(buffer, index, 0u),
                var v => WriteCompactBytes(buffer, index, v.Value)
            }
        ;

        public static void WriteRecords([NotNull] in Stream buffer, in ImmutableArray<IRecords>? value)
        {
            var records = value.GetValueOrDefault();
            if (records.IsDefault)
            {
                WriteInt32(buffer, -1);
                return;
            }
            var totalBytes = 0;
            for (int i = 0; i < records.Length; i++)
                totalBytes += records[i].BatchLength + RecordsConstants.RecordsHeaderSize;
            WriteInt32(buffer, totalBytes);
            for (int i = 0; i < records.Length; i++)
                WriteRecordBatch(buffer, records[i]);
        }

        public static int WriteRecords([NotNull] in byte[] buffer, in int index, in ImmutableArray<IRecords>? value)
        {
            var i = index;
            var records = value.GetValueOrDefault();
            if (records.IsDefault)
                return WriteInt32(buffer, i, -1);
            var totalBytes = ComputeRecordsSize(records);
            i = WriteInt32(buffer, i, totalBytes);
            for (int j = 0; j < records.Length; j++)
                i = WriteRecordBatch(buffer, i, records[j]);
            return i;
        }

        public static void WriteCompactRecords([NotNull] in Stream buffer, in ImmutableArray<IRecords>? value)
        {
            var records = value.GetValueOrDefault();
            if (records == null)
            {
                WriteVarUInt32(buffer, 0u);
                return;
            }
            var totalBytes = ComputeRecordsSize(records);
            WriteVarUInt32(buffer, (uint)(totalBytes + 1));
            for (int i = 0; i < records.Length; i++)
                WriteRecordBatch(buffer, records[i]);
        }

        public static int WriteCompactRecords([NotNull] in byte[] buffer, in int index, in ImmutableArray<IRecords>? value)
        {
            var i = index;
            var records = value.GetValueOrDefault();
            if (records.IsDefault)
                return WriteVarUInt32(buffer, i, 0u);
            var totalBytes = ComputeRecordsSize(records);
            i = WriteVarUInt32(buffer, i, (uint)(totalBytes + 1));
            for (int j = 0; j < records.Length; j++)
                i = WriteRecordBatch(buffer, i, records[j]);
            return i;
        }

        private static void WriteRecordBatch([NotNull] in Stream buffer, in IRecords value)
        {
            // Write batch header.
            WriteInt64(buffer, value.BaseOffset);
            WriteInt32(buffer, value.BatchLength + RecordsConstants.RecordsSizePadding);
            WriteInt32(buffer, value.PartitionLeaderEpoch);
            WriteInt8(buffer, value.Magic);
            var crcIndex = buffer.Position;     // store crc index.
            buffer.Seek(4, SeekOrigin.Current); // reserve crc slot.
            var crcStart = buffer.Position;     // store crc compute start index.
            WriteInt16(buffer, (short)value.Attributes);
            WriteInt32(buffer, value.LastOffsetDelta);
            WriteInt64(buffer, value.BaseTimestamp);
            WriteInt64(buffer, value.MaxTimestamp);
            WriteInt64(buffer, value.ProducerId);
            WriteInt16(buffer, value.ProducerEpoch);
            WriteInt32(buffer, value.BaseSequence);
            WriteInt32(buffer, value.Records.Count);

            // Write records.
            for (int j = 0; j < value.Records.Count; j++)
                WriteRecord(buffer, value.Records[j]);

            var crcEnd = buffer.Position;

            // Compute and store crc.
            buffer.Seek(crcStart, SeekOrigin.Begin);
            var crc = Crc32c.Update(0U, buffer, crcEnd);
            buffer.Seek(crcIndex, SeekOrigin.Begin);
            WriteInt32(buffer, unchecked((int)crc));
            buffer.Seek(crcEnd, SeekOrigin.Begin);
        }

        private static int WriteRecordBatch([NotNull] in byte[] buffer, in int index, in IRecords value)
        {
            var i = index;
            // Write batch header.
            i = WriteInt64(buffer, i, value.BaseOffset);
            i = WriteInt32(buffer, i, value.BatchLength + RecordsConstants.RecordsSizePadding);
            i = WriteInt32(buffer, i, value.PartitionLeaderEpoch);
            i = WriteInt8(buffer, i, value.Magic);
            var crcIndex = i;       // store crc index.
            i += 4;                 // reserve crc slot.
            var crcStart = i;       // store crc compute start index.
            i = WriteInt16(buffer, i, (short)value.Attributes);
            i = WriteInt32(buffer, i, value.LastOffsetDelta);
            i = WriteInt64(buffer, i, value.BaseTimestamp);
            i = WriteInt64(buffer, i, value.MaxTimestamp);
            i = WriteInt64(buffer, i, value.ProducerId);
            i = WriteInt16(buffer, i, value.ProducerEpoch);
            i = WriteInt32(buffer, i, value.BaseSequence);
            i = WriteInt32(buffer, i, value.Records.Count);

            // Write records.
            for (int j = 0; j < value.Records.Count; j++)
                i = WriteRecord(buffer, i, value.Records[j]);

            // Compute and store crc.
            var crc = Crc32c.Update(buffer, crcStart, i - crcStart);
            WriteInt32(buffer, crcIndex, unchecked((int)crc));

            return i;
        }

        private static void WriteRecord([NotNull] in Stream buffer, in IRecord value)
        {
            // Write record header.
            WriteVarInt32(buffer, value.Length);
            WriteInt8(buffer, 0);
            WriteVarInt64(buffer, value.TimestampDelta);
            WriteVarInt32(buffer, value.OffsetDelta);

            // Write record key.
            if (value.Key.HasValue)
            {
                WriteVarInt32(buffer, value.Key.Value.Length);
                buffer.Write(value.Key.Value.Span);
            }
            else
            {
                WriteVarInt32(buffer, -1);
            }

            // Write record value.
            if (value.Value.HasValue)
            {
                WriteVarInt32(buffer, value.Value.Value.Length);
                buffer.Write(value.Value.Value.Span);
            }
            else
            {
                WriteVarInt32(buffer, -1);
            }

            // Write headers.
            WriteVarInt32(buffer, value.Headers.Count);

            for (int j = 0; j < value.Headers.Count; j++)
                WriteRecordHeader(buffer, value.Headers[j]);
        }

        private static int WriteRecord([NotNull] in byte[] buffer, in int index, in IRecord value)
        {
            var i = index;
            // Write record header.
            i = WriteVarInt32(buffer, i, value.Length);
            i = WriteInt8(buffer, i, 0);
            i = WriteVarInt64(buffer, i, value.TimestampDelta);
            i = WriteVarInt32(buffer, i, value.OffsetDelta);

            // Write record key.
            if (value.Key.HasValue)
            {
                i = WriteVarInt32(buffer, i, value.Key.Value.Length);
                var span = value.Key.Value.Span;
                for (int j = 0; j < span.Length; j++)
                    buffer[i++] = span[j];
            }
            else
            {
                i = WriteVarInt32(buffer, i, -1);
            }

            // Write record value.
            if (value.Value.HasValue)
            {
                i = WriteVarInt32(buffer, i, value.Value.Value.Length);
                var span = value.Value.Value.Span;
                for (int j = 0; j < span.Length; j++)
                    buffer[i++] = span[j];
            }
            else
            {
                i = WriteVarInt32(buffer, i, -1);
            }

            // Write headers.
            i = WriteVarInt32(buffer, i, value.Headers.Count);
            for (int j = 0; j < value.Headers.Count; j++)
                i = WriteRecordHeader(buffer, i, value.Headers[j]);
            return i;
        }

        private static void WriteRecordHeader([NotNull] in Stream buffer, in RecordHeader value)
        {
            WriteCompactString(buffer, value.Key);
            WriteCompactBytes(buffer, value.Value);
        }

        private static int WriteRecordHeader([NotNull] in byte[] buffer, in int index, in RecordHeader value)
        {
            var i = index;
            i = WriteCompactString(buffer, i, value.Key);
            i = WriteCompactBytes(buffer, i, value.Value);
            return i;
        }

        public static int WriteArray<TItem>([NotNull] in byte[] buffer, in int index, in ImmutableArray<TItem> value, [NotNull] in EncodeValue<TItem> encodeItem)
        {
            var i = index;
            if (value.IsDefault)
                return WriteInt32(buffer, i, -1);
            i = WriteInt32(buffer, i, value.Length);
            for (int j = 0; j < value.Length; j++)
                i = encodeItem(buffer, i, value[j]);
            return i;
        }

        public static int WriteCompactArray<TItem>([NotNull] in byte[] buffer, in int index, in ImmutableArray<TItem> value, [NotNull] in EncodeValue<TItem> encodeItem)
        {
            var i = index;
            if (value.IsDefault)
                return WriteVarUInt32(buffer, i, 0);
            i = WriteVarUInt32(buffer, i, (uint)value.Length + 1);
            for (int j = 0; j < value.Length; j++)
                i = encodeItem(buffer, i, value[j]);
            return i;
        }

        public static int WriteTaggedFields([NotNull] in byte[] buffer, in int index, [NotNull] in ImmutableArray<TaggedField> value)
        {
            var i = index;
            i = WriteVarInt32(buffer, i, value.Length);
            if (value.Length == 0)
                return i;
            for (int j = 0; j < value.Length; j++)
                i = WriteTaggedField(buffer, i, value[j]);
            return i;
        }

        public static int WriteTaggedField([NotNull] in byte[] buffer, in int index, [NotNull] in TaggedField value)
        {
            var i = index;
            i = WriteVarInt32(buffer, i, value.Tag);
            return WriteCompactBytes(buffer, i, value.Value);
        }

        public static int SizeOfVarInt32(in int value) =>
            SizeOfVarUInt32((uint)((value << 1) ^ (value >> 31)))
        ;

        public static int SizeOfVarUInt32(in uint value)
        {
            // For implementation notes @see #sizeOfUnsignedVarint(int)
            // Similar logic is applied to allow for 64bit input -> 1-9byte output.
            // return (38 - leadingZeros) / 7 + leadingZeros / 32;
            var leadingZeros = BitOperations.LeadingZeroCount(value);
            var leadingZerosBelow38DividedBy7 = ((38 - leadingZeros) * 0b10010010010010011) >> 19;
            return leadingZerosBelow38DividedBy7 + ((leadingZeros >> 5) & 0x7f);
        }

        public static int SizeOfVarInt64(in long value) =>
            SizeOfVarUInt64((ulong)((value << 1) ^ (value >> 63)))
        ;

        public static int SizeOfVarUInt64(in ulong value)
        {
            // For implementation notes @see #sizeOfUnsignedVarint(int)
            // Similar logic is applied to allow for 64bit input -> 1-9byte output.
            // return (70 - leadingZeros) / 7 + leadingZeros / 64;
            var leadingZeros = BitOperations.LeadingZeroCount(value);
            var leadingZerosBelow70DividedBy7 = ((70 - leadingZeros) * 0b10010010010010011) >> 19;
            return leadingZerosBelow70DividedBy7 + ((leadingZeros >> 6) & 0x7f);
        }

        private static int ComputeRecordsSize(in ImmutableArray<IRecords> records)
        {
            var totalBytes = 0;
            for (int i = 0; i < records.Length; i++)
                totalBytes += records[i].BatchLength + RecordsConstants.RecordsHeaderSize;
            return totalBytes;
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
            in long timestampDelta,
            in int offsetDelta,
            in ReadOnlyMemory<byte>? key,
            in ReadOnlyMemory<byte>? value,
            [NotNull] in IReadOnlyList<RecordHeader> headers
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
            [NotNull] in IReadOnlyList<RecordHeader> headers
        ) =>
            SizeOfVarInt32(headers.Count) +
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
