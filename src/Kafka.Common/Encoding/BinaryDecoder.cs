using Kafka.Common.Model;
using Kafka.Common.Records;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Encoding
{
    public static class BinaryDecoder
    {
        public static DecodeResult<bool> ReadBoolean([NotNull] in byte[] buffer, in int index)
        {
            return new(index + 1, buffer[index] != 0);
        }

        public static DecodeResult<sbyte> ReadInt8([NotNull] in byte[] buffer, in int index)
        {
            return new(index + 1, unchecked((sbyte)buffer[index]));
        }

        public static DecodeResult<short> ReadInt16([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var value = unchecked((short)(
                (buffer[i++] & 0xff) << 8 |
                (buffer[i++] & 0xff) << 0
            ));
            return new(i, value);
        }

        public static DecodeResult<ushort> ReadUInt16([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var value) = ReadInt16(buffer, i);
            return new(i, (ushort)value);
        }

        public static DecodeResult<int> ReadInt32([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var value = unchecked(
                (buffer[i++] & 0xff) << 24 |
                (buffer[i++] & 0xff) << 16 |
                (buffer[i++] & 0xff) << 8 |
                (buffer[i++] & 0xff) << 0
            );
            return new(i, value);
        }

        public static DecodeResult<uint> ReadUInt32([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var value) = ReadInt32(buffer, i);
            return new(i, (uint)value);
        }

        public static DecodeResult<long> ReadInt64([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var value = unchecked(
                ((long)(buffer[i++] & 0xff) << 56) |
                ((long)(buffer[i++] & 0xff) << 48) |
                ((long)(buffer[i++] & 0xff) << 40) |
                ((long)(buffer[i++] & 0xff) << 32) |
                ((long)(buffer[i++] & 0xff) << 24) |
                ((long)(buffer[i++] & 0xff) << 16) |
                ((long)(buffer[i++] & 0xff) << 8) |
                ((long)(buffer[i++] & 0xff) << 0)
            );
            return new(i, value);
        }

        public static DecodeResult<ulong> ReadUInt64([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var value) = ReadInt64(buffer, i);
            return new(i, (ulong)value);
        }

        public static DecodeResult<int> ReadVarInt32([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var value) = ZigZagDecode(buffer, i, 31);
            return new(i, unchecked((int)(value >> 1) ^ -(int)(value & 1)));
        }

        public static DecodeResult<uint> ReadVarUInt32([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var value) = ZigZagDecode(buffer, i, 31);
            return new(i, unchecked((uint)value));
        }

        public static DecodeResult<long> ReadVarInt64([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var value) = ZigZagDecode(buffer, i, 63);
            return new(i, unchecked((long)(value >> 1) ^ -(long)(value & 1)));
        }

        public static DecodeResult<double> ReadFloat64([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var bits) = ReadInt64(buffer, i);
            return new(i, BitConverter.Int64BitsToDouble(bits));
        }

        public static DecodeResult<Guid> ReadUuid([NotNull] in byte[] buffer, in int index) =>
            new(index + 16, new Guid(buffer.AsSpan(index, 16)));

        public static DecodeResult<string> ReadString([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var length) = ReadInt16(buffer, i);
            var value = System.Text.Encoding.UTF8.GetString(buffer, i, length);
            return new(i + length, value);
        }

        public static DecodeResult<string> ReadCompactString([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var length) = ReadVarUInt32(buffer, i);
            var intLength = Convert.ToInt32(length) - 1;
            var value = System.Text.Encoding.UTF8.GetString(buffer, i, intLength);
            return new(i + intLength, value);
        }

        public static DecodeResult<string?> ReadNullableString([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var length) = ReadInt16(buffer, i);
            if (length == -1)
                return new(i, default);
            var value = System.Text.Encoding.UTF8.GetString(buffer, i, length);
            return new(i + length, value);
        }

        public static DecodeResult<string?> ReadCompactNullableString([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var length) = ReadVarUInt32(buffer, i);
            if (length == 0)
                return new(i, default);
            var intLength = Convert.ToInt32(length) - 1;
            var value = System.Text.Encoding.UTF8.GetString(buffer, i, intLength);
            return new(i + intLength, value);
        }

        public static DecodeResult<byte[]> ReadBytes([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var length) = ReadInt32(buffer, i);
            var endIndex = i + length;
            return new(endIndex, buffer[i..endIndex]);
        }

        public static DecodeResult<byte[]> ReadCompactBytes([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var length) = ReadVarUInt32(buffer, i);
            var intLength = Convert.ToInt32(length) - 1;
            var endIndex = i + intLength;
            return new(endIndex, buffer[i..endIndex]);
        }

        public static DecodeResult<byte[]?> ReadNullableBytes([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var length) = ReadInt32(buffer, i);
            if (length == -1)
                return new(i, default);
            var endIndex = i + length;
            return new(endIndex, buffer[i..endIndex]);
        }

        public static DecodeResult<byte[]?> ReadCompactNullableBytes([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var length) = ReadVarUInt32(buffer, i);
            if (length == 0)
                return new(i, default);
            var intLength = Convert.ToInt32(length) - 1;
            var endIndex = i + intLength;
            return new(endIndex, buffer[i..endIndex]);
        }

        public static DecodeResult<ImmutableArray<IRecords>> ReadRecords([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var length) = ReadInt32(buffer, i);
            return ReadRecordBatches(buffer, length, i);
        }

        public static DecodeResult<ImmutableArray<IRecords>> ReadCompactRecords([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var length) = ReadVarUInt32(buffer, i);
            var intLength = Convert.ToInt32(length) - 1;
            return ReadRecordBatches(buffer, intLength, i);
        }

        private static DecodeResult<ImmutableArray<IRecords>> ReadRecordBatches([NotNull] in byte[] buffer, int length, in int index)
        {
            if (length == 0)
                return new(index, default);
            var i = index;
            var limit = length + index;
            var recordBatchesBuilder = ImmutableArray.CreateBuilder<IRecords>();
            while (i < limit)
            {
                (i, var recordBatch) = ReadRecordBatch(buffer, i);
                recordBatchesBuilder.Add(recordBatch);
            }
            return new(i, recordBatchesBuilder.ToImmutable());
        }

        private static DecodeResult<IRecords> ReadRecordBatch([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var records = ImmutableArray<IRecord>.Empty;
            (i, var baseOffset) = ReadInt64(buffer, i);
            (i, var size) = ReadInt32(buffer, i);
            (i, var partitionLeaderEpoch) = ReadInt32(buffer, i);
            (i, var magic) = ReadInt8(buffer, i);
            (i, var crc) = ReadInt32(buffer, i);
            (i, var attributes) = ReadInt16(buffer, i);
            (i, var lastOffsetDelta) = ReadInt32(buffer, i);
            (i, var baseTimestamp) = ReadInt64(buffer, i);
            (i, var maxTimestamp) = ReadInt64(buffer, i);
            (i, var producerId) = ReadInt64(buffer, i);
            (i, var producerEpoch) = ReadInt16(buffer, i);
            (i, var baseSequence) = ReadInt32(buffer, i);

            var attributeFlags = (Attributes)attributes;
            if (attributeFlags.HasFlag(Attributes.IsControlBatch))
                (i, records) = ReadArray(
                    buffer,
                    i,
                    ReadControlRecord
                );
            else
                (i, records) = ReadArray(
                    buffer,
                    i,
                    ReadRecord
                );
            return new(i, new RecordBatch(
                BaseOffset: baseOffset,
                BatchLength: size,
                PartitionLeaderEpoch: partitionLeaderEpoch,
                Magic: magic,
                Crc: crc,
                Attributes: attributeFlags,
                LastOffsetDelta: lastOffsetDelta,
                BaseTimestamp: baseTimestamp,
                MaxTimestamp: maxTimestamp,
                ProducerId: producerId,
                ProducerEpoch: producerEpoch,
                BaseSequence: baseSequence,
                Records: records
            ));
        }

        private static DecodeResult<IRecord> ReadControlRecord([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var version = default(short);
            var typeFlags = default(ControlType);
            var key = default(ReadOnlyMemory<byte>?);
            var value = default(ReadOnlyMemory<byte>?);
            (i, var length) = ReadVarInt32(buffer, i);
            (i, var attributes) = ReadInt8(buffer, i);
            (i, var timestampDelta) = ReadVarInt64(buffer, i);
            (i, var offsetDelta) = ReadVarInt32(buffer, i);
            (i, var keyLength) = ReadVarInt32(buffer, i);
            if (keyLength >= 0)
            {
                (i, version) = ReadInt16(buffer, i);
                (i, var typeFlagsValue) = ReadInt16(buffer, i);
                typeFlags = (ControlType)typeFlagsValue;
                key = buffer.AsMemory(i, keyLength);
            }
            (i, var valueLength) = ReadVarInt32(buffer, i);
            if (valueLength >= 0)
            {
                value = buffer.AsMemory(i, valueLength);
                i += valueLength;
            }
            var headers = ImmutableArray<RecordHeader>.Empty;
            (i, var headerCount) = ReadVarInt32(buffer, i);
            if (headerCount > 0)
            {
                var headersBuilder = ImmutableArray.CreateBuilder<RecordHeader>(headerCount);
                while(headerCount >= 0)
                {
                    (i, var recordHeader) = ReadRecordHeader(buffer, i);
                    headersBuilder.Add(recordHeader);
                }
                headers = headersBuilder.ToImmutable();
            }
            return new(i, new ControlRecord(
                Length: length,
                Attributes: (Attributes)attributes,
                TimestampDelta: timestampDelta,
                OffsetDelta: offsetDelta,
                Key: key,
                Value: value,
                Headers: headers,
                Version: version,
                Type: typeFlags
            ));
        }

        private static DecodeResult<IRecord> ReadRecord([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var key = default(ReadOnlyMemory<byte>?);
            var value = default(ReadOnlyMemory<byte>?);
            var headers = ImmutableArray<RecordHeader>.Empty;
            (i, var length) = ReadVarInt32(buffer, i);
            (i, var attributes) = ReadInt8(buffer, i);
            (i, var timestampDelta) = ReadVarInt64(buffer, i);
            (i, var offsetDelta) = ReadVarInt32(buffer, i);
            (i, var keyLength) = ReadVarInt32(buffer, i);
            if (keyLength >= 0)
            {
                key = buffer.AsMemory(i, keyLength);
                i += keyLength;
            }
            (i, var valueLength) = ReadVarInt32(buffer, i);
            if (valueLength >= 0)
            {
                value = buffer.AsMemory(i, valueLength);
                i += valueLength;
            }
            (i, var headerCount) = ReadVarInt32(buffer, i);
            if (headerCount > 0)
            {
                var headersBuilder = ImmutableArray.CreateBuilder<RecordHeader>(headerCount);
                while (headerCount >= 0)
                {
                    (i, var recordHeader) = ReadRecordHeader(buffer, i);
                    headersBuilder.Add(recordHeader);
                }
                headers = headersBuilder.ToImmutable();
            }
            return new(i, new Record(
                Length: length,
                Attributes: (Attributes)attributes,
                TimestampDelta: timestampDelta,
                OffsetDelta: offsetDelta,
                Key: key,
                Value: value,
                Headers: headers
            ));
        }

        private static DecodeResult<RecordHeader> ReadRecordHeader(
            [NotNull] in byte[] buffer,
            in int index
        )
        {
            var i = index;
            (i, var key) = ReadCompactString(buffer, i);
            (i, var value) = ReadCompactBytes(buffer, i);
            return new(i, new(key, value));
        }

        public static DecodeResult<ImmutableArray<TItem>> ReadArray<TItem>([NotNull] in byte[] buffer, in int index, [NotNull] in DecodeValue<TItem> readItem)
        {
            var i = index;
            (i, var length) = ReadInt32(buffer, i);
            if (length == -1)
                return new(i, default);
            var items = ImmutableArray.CreateBuilder<TItem>(length);
            for (int j = 0; j < length; j++)
            {
                (i, var item) = readItem(buffer, i);
                items.Add(item);
            }
            return new(i, items.ToImmutable());
        }

        public static DecodeResult<ImmutableArray<TItem>> ReadCompactArray<TItem>([NotNull] in byte[] buffer, in int index, [NotNull] in DecodeValue<TItem> readItem)
        {
            var (i, length) = ReadVarUInt32(buffer, index);
            if (length == 0)
                return new(i, default);
            var intLength = Convert.ToInt32(length) - 1;
            var items = ImmutableArray.CreateBuilder<TItem>(intLength);
            for (int j = 0; j < intLength; j++)
            {
                (i, var item) = readItem(buffer, i);
                items.Add(item);
            }
            return new(i, items.ToImmutable());
        }

        public static DecodeResult<ImmutableArray<TaggedField>> ReadTaggedFields([NotNull] in byte[] buffer, in int index)
        {
            var (i, count) = ReadVarInt32(buffer, index);
            if (count == 0)
                return new(i, []);
            var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>(count);
            for (int j = 0; j < count; j++)
            {
                (i, var taggedField) = ReadTaggedField(buffer, index);
                taggedFieldsBuilder.Add(taggedField);
            }
            return new(i, taggedFieldsBuilder.ToImmutable());
        }

        public static DecodeResult<TaggedField> ReadTaggedField([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            (i, var tag) = ReadVarInt32(buffer, i);
            (i, var value) = ReadCompactBytes(buffer, i);
            return new(i, new(tag, value));
        }

        private static DecodeResult<ulong> ZigZagDecode([NotNull] in byte[] buffer, in int index, int bits)
        {
            var i = index;
            var value = 0UL;
            var bit = 0;
            while (bit <= bits)
            {
                var b = buffer[i++];
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
            return new(i, value);
        }
    }
}
