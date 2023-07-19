using Kafka.Common.Model;
using Kafka.Common.Records;
using System.Collections.Immutable;

namespace Kafka.Common.Encoding
{
    public static class BinaryDecoder
    {
        public static (int Offset, bool Value) ReadBoolean(byte[] buffer, int index)
        {
            CheckRemaining(buffer, index, 1);
            return (index + 1, buffer[index] != 0);
        }

        public static (int Offset, sbyte Value) ReadInt8(byte[] buffer, int index)
        {
            CheckRemaining(buffer, index, 1);
            return (index + 1, unchecked((sbyte)buffer[index]));
        }

        public static (int Offset, short Value) ReadInt16(byte[] buffer, int index)
        {
            CheckRemaining(buffer, index, 2);
            var value = unchecked((short)(
                (buffer[index++] & 0xff) << 8 |
                (buffer[index++] & 0xff) << 0
            ));
            return (index, value);
        }

        public static (int Offset, ushort Value) ReadUInt16(byte[] buffer, int index)
        {
            (index, var value) = ReadInt16(buffer, index);
            return (index, (ushort)value);
        }

        public static (int Offset, int Value) ReadInt32(byte[] buffer, int index)
        {
            CheckRemaining(buffer, index, 4);
            var value = unchecked(
                (buffer[index++] & 0xff) << 24 |
                (buffer[index++] & 0xff) << 16 |
                (buffer[index++] & 0xff) << 8 |
                (buffer[index++] & 0xff) << 0
            );
            return (index, value);
        }

        public static (int Offset, uint Value) ReadUInt32(byte[] buffer, int index)
        {
            (index, var value) = ReadInt32(buffer, index);
            return (index, (uint)value);
        }

        public static (int Offset, long Value) ReadInt64(byte[] buffer, int index)
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
            return (index, value);
        }

        public static (int Offset, ulong Value) ReadUInt64(byte[] buffer, int index)
        {
            (index, var value) = ReadInt64(buffer, index);
            return (index, (ulong)value);
        }

        public static (int Offset, int Value) ReadVarInt32(byte[] buffer, int index)
        {
            (index, var value) = ZigZagDecode(buffer, index, 31);
            return (index, unchecked(((int)(value >> 1) ^ -(int)(value & 1))));
        }

        public static (int Offset, uint Value) ReadVarUInt32(byte[] buffer, int index)
        {
            (index, var value) = ZigZagDecode(buffer, index, 31);
            return (index, unchecked((uint)value));
        }

        public static (int Offset, long Value) ReadVarInt64(byte[] buffer, int index)
        {
            (index, var value) = ZigZagDecode(buffer, index, 63);
            return (index, unchecked((long)(value >> 1) ^ -(long)(value & 1)));
        }

        public static (int Offset, double Value) ReadFloat64(byte[] buffer, int index)
        {
            (index, var bits) = ReadInt64(buffer, index);
            return (index, BitConverter.Int64BitsToDouble(bits));
        }

        public static (int Offset, Guid Value) ReadUuid(byte[] buffer, int index)
        {
            CheckRemaining(buffer, index, 16);
            return (index + 16, new Guid(buffer.AsSpan(index, 16)));
        }

        public static (int Offset, string Value) ReadString(byte[] buffer, int index)
        {
            (index, var length) = ReadInt16(buffer, index);
            CheckRemaining(buffer, index, length);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, length);
            return (index + length, value);
        }

        public static (int Offset, string Value) ReadCompactString(byte[] buffer, int index)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            var intLength = Convert.ToInt32(length) - 1;
            CheckRemaining(buffer, index, intLength);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, intLength);
            return (index + intLength, value);
        }

        public static (int Offset, string? Value) ReadNullableString(byte[] buffer, int index)
        {
            (index, var length) = ReadInt16(buffer, index);
            if (length == -1)
                return (index, default);
            CheckRemaining(buffer, index, length);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, length);
            return (index + length, value);
        }

        public static (int Offset, string? Value) ReadCompactNullableString(byte[] buffer, int index)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            if (length == 0)
                return (index, default);
            var intLength = Convert.ToInt32(length) - 1;
            CheckRemaining(buffer, index, intLength);
            var value = System.Text.Encoding.UTF8.GetString(buffer, index, intLength);
            return (index + intLength, value);
        }

        public static (int Offset, byte[] Value) ReadBytes(byte[] buffer, int index)
        {
            (index, var length) = ReadInt32(buffer, index);
            CheckRemaining(buffer, index, length);
            var endIndex = index + length;
            return (endIndex, buffer[index..endIndex]);
        }

        public static (int Offset, byte[] Value) ReadCompactBytes(byte[] buffer, int index)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            var intLength = Convert.ToInt32(length) - 1;
            CheckRemaining(buffer, index, intLength);
            var endIndex = index + intLength;
            return (endIndex, buffer[index..endIndex]);
        }

        public static (int Offset, byte[]? Value) ReadNullableBytes(byte[] buffer, int index)
        {
            (index, var length) = ReadInt32(buffer, index);
            if (length == -1)
                return (index, default);
            CheckRemaining(buffer, index, length);
            var endIndex = index + length;
            return (endIndex, buffer[index..endIndex]);
        }

        public static (int Offset, byte[]? Value) ReadCompactNullableBytes(byte[] buffer, int index)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            if (length == 0)
                return (index, default);
            var intLength = Convert.ToInt32(length) - 1;
            CheckRemaining(buffer, index, intLength);
            var endIndex = index + intLength;
            return (endIndex, buffer[index..endIndex]);
        }

        public static (int Offset, ImmutableArray<IRecords>? Value) ReadRecords(byte[] buffer, int index)
        {
            (index, var length) = ReadInt32(buffer, index);
            return ReadRecordBatches(buffer, length, index);
        }

        public static (int Offset, ImmutableArray<IRecords>? Value) ReadCompactRecords(byte[] buffer, int index)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            var intLength = Convert.ToInt32(length) - 1;
            return ReadRecordBatches(buffer, intLength, index);
        }

        private static (int Offset, ImmutableArray<IRecords>? Value) ReadRecordBatches(byte[] buffer, int length, int index)
        {
            if (length == 0)
                return (index, null);
            CheckRemaining(buffer, index, length);
            var recordBatchesBuilder = ImmutableArray.CreateBuilder<IRecords>();
            var limit = length + index;
            while (index < limit)
            {
                (index, var recordBatch) = ReadRecordBatch(buffer, index);
                recordBatchesBuilder.Add(recordBatch);
            }
            return (index, recordBatchesBuilder.ToImmutable());
        }

        private static (int Offset, IRecords Value) ReadRecordBatch(byte[] buffer, int index)
        {
            (index, var baseOffset) = ReadInt64(buffer, index);
            (index, var size) = ReadInt32(buffer, index);
            (index, var partitionLeaderEpoch) = ReadInt32(buffer, index);
            (index, var magic) = ReadInt8(buffer, index);
            (index, var crc) = ReadInt32(buffer, index);
            (index, var attributes) = ((int, Attributes))ReadInt16(buffer, index);
            (index, var lastOffsetDelta) = ReadInt32(buffer, index);
            (index, var baseTimestamp) = ReadInt64(buffer, index);
            (index, var maxTimestamp) = ReadInt64(buffer, index);
            (index, var producerId) = ReadInt64(buffer, index);
            (index, var producerEpoch) = ReadInt16(buffer, index);
            (index, var baseSequence) = ReadInt32(buffer, index);

            var records = default(ImmutableArray<IRecord>?);
            if (attributes.HasFlag(Attributes.IsControlBatch))
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
            return (index, new RecordBatch(
                BaseOffset: baseOffset,
                BatchLength: size,
                PartitionLeaderEpoch: partitionLeaderEpoch,
                Magic: magic,
                Crc: crc,
                Attributes: attributes,
                LastOffsetDelta: lastOffsetDelta,
                BaseTimestamp: baseTimestamp,
                MaxTimestamp: maxTimestamp,
                ProducerId: producerId,
                ProducerEpoch: producerEpoch,
                BaseSequence: baseSequence,
                Records: records ?? ImmutableArray<IRecord>.Empty
            ));
        }

        private static (int Offset, IRecord Value) ReadControlRecord(byte[] buffer, int index)
        {
            var version = default(short);
            var type = default(ControlType);

            (index, var length) = ReadVarInt32(buffer, index);
            (index, var attributes) = ((int, Attributes))ReadInt8(buffer, index);
            (index, var timestampDelta) = ReadVarInt64(buffer, index);
            (index, var offsetDelta) = ReadVarInt32(buffer, index);
            var key = default(ReadOnlyMemory<byte>?);
            (index, var keyLength) = ReadVarInt32(buffer, index);
            if (keyLength >= 0)
            {
                (index, version) = ReadInt16(buffer, index);
                (index, type) = ((int, ControlType))ReadInt16(buffer, index);
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
            return (index, new ControlRecord(
                Length: length,
                Attributes: attributes,
                TimestampDelta: timestampDelta,
                OffsetDelta: offsetDelta,
                Key: key,
                Value: value,
                Headers: headers,
                Version: version,
                Type: type
            ));
        }

        private static (int Offset, IRecord Value) ReadRecord(byte[] buffer, int index)
        {
            (index, var length) = ReadVarInt32(buffer, index);
            (index, var attributes) = ((int, Attributes))ReadInt8(buffer, index);
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
            return (index, new Record(
                Length: length,
                Attributes: attributes,
                TimestampDelta: timestampDelta,
                OffsetDelta: offsetDelta,
                Key: key,
                Value: value,
                Headers: headers
            ));
        }

        private static (int Offset, RecordHeader Value) ReadRecordHeader(byte[] buffer, int index)
        {
            (index, var key) = ReadCompactString(buffer, index);
            (index, var value) = ReadCompactBytes(buffer, index);
            return (index, new(key, value));
        }

        public static (int Offset, ImmutableArray<TItem>? Value) ReadArray<TItem>(byte[] buffer, int index, DecodeDelegate<TItem> readItem)
        {
            (index, var length) = ReadInt32(buffer, index);
            if (length == -1)
                return (index, default);
            var items = ImmutableArray.CreateBuilder<TItem>(length);
            for (int i = 0; i < length; i++)
            {
                (index, var item) = readItem(buffer, index);
                items.Add(item);
            }
            return (index, items.ToImmutable());
        }

        public static (int Offset, ImmutableArray<TItem>? Value) ReadCompactArray<TItem>(byte[] buffer, int index, DecodeDelegate<TItem> readItem)
        {
            (index, var length) = ReadVarUInt32(buffer, index);
            if (length == 0)
                return (index, default);
            var intLength = Convert.ToInt32(length) - 1;
            var items = ImmutableArray.CreateBuilder<TItem>(intLength);
            for (int i = 0; i < intLength; i++)
            {
                (index, var item) = readItem(buffer, index);
                items.Add(item);
            }
            return (index, items.ToImmutable());
        }

        public static (int Offset, ImmutableArray<TaggedField> Value) ReadTaggedFields(byte[] buffer, int index)
        {
            (index, var count) = ReadVarInt32(buffer, index);
            if(count == 0)
                return (index, ImmutableArray<TaggedField>.Empty);
            var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>(count);
            while(count > 0)
            {
                (index, var taggedField) = ReadTaggedField(buffer, index);
                taggedFieldsBuilder.Add(taggedField);
            }
            return (index, taggedFieldsBuilder.ToImmutable());
        }

        public static (int Offset, TaggedField Value) ReadTaggedField(byte[] buffer, int index)
        {
            (index, var tag) = ReadVarInt32(buffer, index);
            (index, var value) = ReadCompactBytes(buffer, index);
            return (index, new(tag, value));
        }

        private static void CheckRemaining(byte[] buffer, int index, long length)
        {
            var required = index + length;
            if (buffer.Length < required)
                throw new EndOfStreamException($"No enough bytes - required length: {required} - was: {buffer.Length}");
        }

        private static (int Offset, ulong Value) ZigZagDecode(byte[] buffer, int index, int bits)
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
            return (index, value);
        }
    }
}
