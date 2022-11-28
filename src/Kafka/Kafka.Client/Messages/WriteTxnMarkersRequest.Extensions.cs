using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using WritableTxnMarkerTopic = Kafka.Client.Messages.WriteTxnMarkersRequest.WritableTxnMarker.WritableTxnMarkerTopic;
using WritableTxnMarker = Kafka.Client.Messages.WriteTxnMarkersRequest.WritableTxnMarker;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class WriteTxnMarkersRequestSerde
    {
        private static readonly DecodeDelegate<WriteTxnMarkersRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<WriteTxnMarkersRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static WriteTxnMarkersRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, WriteTxnMarkersRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static WriteTxnMarkersRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var markersField = Decoder.ReadArray<WritableTxnMarker>(ref buffer, (ref ReadOnlyMemory<byte> b) => WritableTxnMarkerSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            return new(
                markersField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, WriteTxnMarkersRequest message)
        {
            buffer = Encoder.WriteArray<WritableTxnMarker>(buffer, message.MarkersField, (b, i) => WritableTxnMarkerSerde.WriteV00(b, i));
            return buffer;
        }
        private static WriteTxnMarkersRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var markersField = Decoder.ReadCompactArray<WritableTxnMarker>(ref buffer, (ref ReadOnlyMemory<byte> b) => WritableTxnMarkerSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                markersField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, WriteTxnMarkersRequest message)
        {
            buffer = Encoder.WriteCompactArray<WritableTxnMarker>(buffer, message.MarkersField, (b, i) => WritableTxnMarkerSerde.WriteV01(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class WritableTxnMarkerSerde
        {
            public static WritableTxnMarker ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var producerIdField = Decoder.ReadInt64(ref buffer);
                var producerEpochField = Decoder.ReadInt16(ref buffer);
                var transactionResultField = Decoder.ReadBoolean(ref buffer);
                var topicsField = Decoder.ReadArray<WritableTxnMarkerTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => WritableTxnMarkerTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var coordinatorEpochField = Decoder.ReadInt32(ref buffer);
                return new(
                    producerIdField,
                    producerEpochField,
                    transactionResultField,
                    topicsField,
                    coordinatorEpochField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, WritableTxnMarker message)
            {
                buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
                buffer = Encoder.WriteBoolean(buffer, message.TransactionResultField);
                buffer = Encoder.WriteArray<WritableTxnMarkerTopic>(buffer, message.TopicsField, (b, i) => WritableTxnMarkerTopicSerde.WriteV00(b, i));
                buffer = Encoder.WriteInt32(buffer, message.CoordinatorEpochField);
                return buffer;
            }
            public static WritableTxnMarker ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var producerIdField = Decoder.ReadInt64(ref buffer);
                var producerEpochField = Decoder.ReadInt16(ref buffer);
                var transactionResultField = Decoder.ReadBoolean(ref buffer);
                var topicsField = Decoder.ReadCompactArray<WritableTxnMarkerTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => WritableTxnMarkerTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var coordinatorEpochField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    producerIdField,
                    producerEpochField,
                    transactionResultField,
                    topicsField,
                    coordinatorEpochField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, WritableTxnMarker message)
            {
                buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
                buffer = Encoder.WriteBoolean(buffer, message.TransactionResultField);
                buffer = Encoder.WriteCompactArray<WritableTxnMarkerTopic>(buffer, message.TopicsField, (b, i) => WritableTxnMarkerTopicSerde.WriteV01(b, i));
                buffer = Encoder.WriteInt32(buffer, message.CoordinatorEpochField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class WritableTxnMarkerTopicSerde
            {
                public static WritableTxnMarkerTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var partitionIndexesField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                    return new(
                        nameField,
                        partitionIndexesField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, WritableTxnMarkerTopic message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                    return buffer;
                }
                public static WritableTxnMarkerTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var partitionIndexesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        partitionIndexesField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, WritableTxnMarkerTopic message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}