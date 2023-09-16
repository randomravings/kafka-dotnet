using Kafka.Common.Model;
using Kafka.Common.Records;
using System.Collections.Immutable;

namespace Kafka.Common.Encoding
{
    public static class BinaryDecoder
    {
        public static DecodeResult<bool> ReadBoolean(byte[] buffer, int index)
        {
            CheckRemaining(buffer, index, 1);
            return new (index + 1, buffer[index] != 0);
        }

        public static DecodeResult<sbyte> ReadInt8(byte[] buffer, int index)
        {
            CheckRemaining(buffer, index, 1);
            return new (index + 1, unchecked((sbyte)buffer[index]));
        }

        public static DecodeResult<short> ReadInt16(byte[] buffer, int index)
        {
            CheckRemaining(buffer, index, 2);
            var value = unchecked((short)(
                (buffer[index++] & 0xff) << 8 |
                (buffer[index++] & 0xff) << 0
            ));
            return new (index, value);
        }

        public static DecodeResult<ushort> ReadUInt16(byte[] buffer, int index)
        {
            (index, var value) = ReadInt16(buffer, index);
            return new (index, (ushort)value);
        }

        public static DecodeResult<int> ReadInt32(byte[] buffer, int index)
        {
            CheckRemaining(buffer, index, 4);
            var value = unchecked(
                (buffer[index++] & 0xff) << 24 |
                (buffer[index++] & 0xff) << 16 |
                (buffer[index++] & 0xff) << 8 |
                (buffer[index++] & 0xff) << 0
            );
            return new (index, value);
        }

        public static DecodeResult<uint> ReadUInt32(byte[] buffer, int index)
        {
            (index, var value) = ReadInt32(buffer, index);
            return new (index, (uint)value);
        }

        public static DecodeResult<long> ReadInt64(byte[] buffer, int index)
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
            return new (index, value);
        }

        public static DecodeResult<ulong> ReadUInt64(byte[] buffer, int index)
        {
            (index, var value) = ReadInt64(buffer, index);
            return new (index, (ulong)value);
        }

        public static DecodeResult<int> ReadVarInt32(byte[] buffer, int index)
        {
            (index, var value) = ZigZagDecode(buffer, index, 31);
            return new (index, unchecked(((int)(value >> 1) ^ -(int)(value & 1))));
        }

        public static DecodeResult<uint> ReadVarUInt32(byte[] buffer, int index)
        {
            (index, var value) = ZigZagDecode(buffer, index, 31);
            return new (index, unchecked((uint)value));
        }

        public static DecodeResult<long> ReadVarInt64(byte[] buffer, int index)
        {
            (index, var value) = ZigZagDecode(buffer, index, 63);
            return new (index, unchecked((long)(value >> 1) ^ -(long)(value & 1)));
        }

        public static DecodeResult<double> ReadFloat64(byte[] buffer, int index)
        {
            (index, var bits) = ReadInt64(buffer, index);
            return new (index, BitConverter.Int64BitsToDouble(bits));
        }

        public static DecodeResult<Guid> ReadUuid(byte[] buffer, int index)
        {
            CheckRemaining(buffer, index, 16);
            return new (index + 16, new Guid(buffer.AsSpan(index, 16)));
        }

        public static DecodeResult<string> ReadString(byte[] buffer, int index)
        {
            (index, var length) = ReadInt16(buffer, index);
            CheckRemaining(buffer, index, length);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, length);
            return new (index + length, value);
        }

        public static DecodeResult<string> ReadCompactString(byte[] buffer, int index)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            var intLength = Convert.ToInt32(length) - 1;
            CheckRemaining(buffer, index, intLength);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, intLength);
            return new (index + intLength, value);
        }

        public static DecodeResult<string?> ReadNullableString(byte[] buffer, int index)
        {
            (index, var length) = ReadInt16(buffer, index);
            if (length == -1)
                return new (index, default);
            CheckRemaining(buffer, index, length);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, length);
            return new (index + length, value);
        }

        public static DecodeResult<string?> ReadCompactNullableString(byte[] buffer, int index)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            if (length == 0)
                return new (index, default);
            var intLength = Convert.ToInt32(length) - 1;
            CheckRemaining(buffer, index, intLength);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, intLength);
            return new (index + intLength, value);
        }

        public static DecodeResult<byte[]> ReadBytes(byte[] buffer, int index)
        {
            (index, var length) = ReadInt32(buffer, index);
            CheckRemaining(buffer, index, length);
            var endIndex = index + length;
            return new (endIndex, buffer[index..endIndex]);
        }

        public static DecodeResult<byte[]> ReadCompactBytes(byte[] buffer, int index)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            var intLength = Convert.ToInt32(length) - 1;
            CheckRemaining(buffer, index, intLength);
            var endIndex = index + intLength;
            return new (endIndex, buffer[index..endIndex]);
        }

        public static DecodeResult<byte[]?> ReadNullableBytes(byte[] buffer, int index)
        {
            (index, var length) = ReadInt32(buffer, index);
            if (length == -1)
                return new (index, default);
            CheckRemaining(buffer, index, length);
            var endIndex = index + length;
            return new (endIndex, buffer[index..endIndex]);
        }

        public static DecodeResult<byte[]?> ReadCompactNullableBytes(byte[] buffer, int index)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            if (length == 0)
                return new (index, default);
            var intLength = Convert.ToInt32(length) - 1;
            CheckRemaining(buffer, index, intLength);
            var endIndex = index + intLength;
            return new (endIndex, buffer[index..endIndex]);
        }

        public static DecodeResult<ImmutableArray<IRecords>?> ReadRecords(byte[] buffer, int index)
        {
            (index, var length) = ReadInt32(buffer, index);
            return ReadRecordBatches(buffer, length, index);
        }

        public static DecodeResult<ImmutableArray<IRecords>?> ReadCompactRecords(byte[] buffer, int index)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            var intLength = Convert.ToInt32(length) - 1;
            return ReadRecordBatches(buffer, intLength, index);
        }

        private static DecodeResult<ImmutableArray<IRecords>?> ReadRecordBatches(byte[] buffer, int length, int index)
        {
            if (length == 0)
                return new (index, null);
            CheckRemaining(buffer, index, length);
            var recordBatchesBuilder = ImmutableArray.CreateBuilder<IRecords>();
            var limit = length + index;
            while (index < limit)
            {
                (index, var recordBatch) = ReadRecordBatch(buffer, index);
                recordBatchesBuilder.Add(recordBatch);
            }
            return new (index, recordBatchesBuilder.ToImmutable());
        }

        private static DecodeResult<IRecords> ReadRecordBatch(byte[] buffer, int index)
        {
            (index, var baseOffset) = ReadInt64(buffer, index);
            (index, var size) = ReadInt32(buffer, index);
            (index, var partitionLeaderEpoch) = ReadInt32(buffer, index);
            (index, var magic) = ReadInt8(buffer, index);
            (index, var crc) = ReadInt32(buffer, index);
            (index, var attributes) = ReadInt16(buffer, index);
            (index, var lastOffsetDelta) = ReadInt32(buffer, index);
            (index, var baseTimestamp) = ReadInt64(buffer, index);
            (index, var maxTimestamp) = ReadInt64(buffer, index);
            (index, var producerId) = ReadInt64(buffer, index);
            (index, var producerEpoch) = ReadInt16(buffer, index);
            (index, var baseSequence) = ReadInt32(buffer, index);

            var records = default(ImmutableArray<IRecord>?);
            var attributeFlags = (Attributes)attributes;
            if (attributeFlags.HasFlag(Attributes.IsControlBatch))
                (index, records) = ReadArray(
                    buffer,
                    index,
                    ReadControlRecord
                );
            else
                (index, records) = ReadArray(
                    buffer,
                    index,
                    ReadRecord
                );
            return new (index, new RecordBatch(
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
                Records: records ?? ImmutableArray<IRecord>.Empty
            ));
        }

        private static DecodeResult<IRecord> ReadControlRecord(byte[] buffer, int index)
        {
            var version = default(short);
            var typeFlags = default(ControlType);

            (index, var length) = ReadVarInt32(buffer, index);
            (index, var attributes) = ReadInt8(buffer, index);
            (index, var timestampDelta) = ReadVarInt64(buffer, index);
            (index, var offsetDelta) = ReadVarInt32(buffer, index);
            var key = default(ReadOnlyMemory<byte>?);
            (index, var keyLength) = ReadVarInt32(buffer, index);
            if (keyLength >= 0)
            {
                (index, version) = ReadInt16(buffer, index);
                (index, var type) = ReadInt16(buffer, index);
                typeFlags = (ControlType)type;
                key = buffer.AsMemory(index, keyLength);
            }
            var value = default(ReadOnlyMemory<byte>?);
            (index, var valueLength) = ReadVarInt32(buffer, index);
            if (valueLength >= 0)
            {
                value = buffer.AsMemory(index, valueLength);
                index += valueLength;
            }
            var headers = ImmutableArray<RecordHeader>.Empty;
            (index, var headerCount) = ReadVarInt32(buffer, index);
            if (headerCount > 0)
            {
                var headersBuilder = ImmutableArray.CreateBuilder<RecordHeader>(headerCount);
                for (int i = 0; i < headerCount; i++)
                {
                    (index, var recordHeader) = ReadRecordHeader(buffer, index);
                    headersBuilder.Add(recordHeader);
                }
                headers = headersBuilder.ToImmutable();
            }
            return new (index, new ControlRecord(
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

        private static DecodeResult<IRecord> ReadRecord(byte[] buffer, int index)
        {
            (index, var length) = ReadVarInt32(buffer, index);
            (index, var attributes) = ReadInt8(buffer, index);
            (index, var timestampDelta) = ReadVarInt64(buffer, index);
            (index, var offsetDelta) = ReadVarInt32(buffer, index);
            var key = default(ReadOnlyMemory<byte>?);
            (index, var keyLength) = ReadVarInt32(buffer, index);
            if (keyLength >= 0)
            {
                key = buffer.AsMemory(index, keyLength);
                index += keyLength;
            }
            var value = default(ReadOnlyMemory<byte>?);
            (index, var valueLength) = ReadVarInt32(buffer, index);
            if (valueLength >= 0)
            {
                value = buffer.AsMemory(index, valueLength);
                index += valueLength;
            }
            var headers = ImmutableArray<RecordHeader>.Empty;
            (index, var headerCount) = ReadVarInt32(buffer, index);
            if (headerCount > 0)
            {
                var headersBuilder = ImmutableArray.CreateBuilder<RecordHeader>(headerCount);
                for (int i = 0; i < headerCount; i++)
                {
                    (index, var recordHeader) = ReadRecordHeader(buffer, index);
                    headersBuilder.Add(recordHeader);
                }
                headers = headersBuilder.ToImmutable();
            }
            return new (index, new Record(
                Length: length,
                Attributes: (Attributes)attributes,
                TimestampDelta: timestampDelta,
                OffsetDelta: offsetDelta,
                Key: key,
                Value: value,
                Headers: headers
            ));
        }

        private static DecodeResult<RecordHeader> ReadRecordHeader(byte[] buffer, int index)
        {
            (index, var key) = ReadCompactString(buffer, index);
            (index, var value) = ReadCompactBytes(buffer, index);
            return new (index, new(key, value));
        }

        public static DecodeResult<ImmutableArray<TItem>?> ReadArray<TItem>(byte[] buffer, int index, DecodeDelegate<TItem> readItem)
        {
            (index, var length) = ReadInt32(buffer, index);
            if (length == -1)
                return new (index, default);
            var items = ImmutableArray.CreateBuilder<TItem>(length);
            for (int i = 0; i < length; i++)
            {
                (index, var item) = readItem(buffer, index);
                items.Add(item);
            }
            return new (index, items.ToImmutable());
        }

        public static DecodeResult<ImmutableArray<TItem>?> ReadCompactArray<TItem>(byte[] buffer, int index, DecodeDelegate<TItem> readItem)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            if (length == 0)
                return new (index, default);
            var intLength = Convert.ToInt32(length) - 1;
            var items = ImmutableArray.CreateBuilder<TItem>(intLength);
            for (int i = 0; i < intLength; i++)
            {
                (index, var item) = readItem(buffer, index);
                items.Add(item);
            }
            return new (index, items.ToImmutable());
        }

        public static DecodeResult<ImmutableArray<TaggedField>> ReadTaggedFields(byte[] buffer, int index)
        {
            (index, var count) = ReadVarInt32(buffer, index);
            if(count == 0)
                return new (index, ImmutableArray<TaggedField>.Empty);
            var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>(count);
            while(count > 0)
            {
                (index, var taggedField) = ReadTaggedField(buffer, index);
                taggedFieldsBuilder.Add(taggedField);
            }
            return new (index, taggedFieldsBuilder.ToImmutable());
        }

        public static DecodeResult<TaggedField> ReadTaggedField(byte[] buffer, int index)
        {
            (index, var tag) = ReadVarInt32(buffer, index);
            (index, var value) = ReadCompactBytes(buffer, index);
            return new (index, new(tag, value));
        }

        private static void CheckRemaining(byte[] buffer, int index, long length)
        {
            var required = index + length;
            if (buffer.Length < required)
                throw new EndOfStreamException($"No enough bytes - required length: {required} - was: {buffer.Length}");
        }

        private static DecodeResult<ulong> ZigZagDecode(byte[] buffer, int index, int bits)
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
            return new (index, value);
        }
    }
}
