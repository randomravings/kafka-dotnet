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
        private static readonly Func<Stream, WriteTxnMarkersRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, WriteTxnMarkersRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static WriteTxnMarkersRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, WriteTxnMarkersRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static WriteTxnMarkersRequest ReadV00(Stream buffer)
        {
            var markersField = Decoder.ReadArray<WritableTxnMarker>(buffer, b => WritableTxnMarkerSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            return new(
                markersField
            );
        }
        private static void WriteV00(Stream buffer, WriteTxnMarkersRequest message)
        {
            Encoder.WriteArray<WritableTxnMarker>(buffer, message.MarkersField, (b, i) => WritableTxnMarkerSerde.WriteV00(b, i));
        }
        private static WriteTxnMarkersRequest ReadV01(Stream buffer)
        {
            var markersField = Decoder.ReadCompactArray<WritableTxnMarker>(buffer, b => WritableTxnMarkerSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                markersField
            );
        }
        private static void WriteV01(Stream buffer, WriteTxnMarkersRequest message)
        {
            Encoder.WriteCompactArray<WritableTxnMarker>(buffer, message.MarkersField, (b, i) => WritableTxnMarkerSerde.WriteV01(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class WritableTxnMarkerSerde
        {
            public static WritableTxnMarker ReadV00(Stream buffer)
            {
                var producerIdField = Decoder.ReadInt64(buffer);
                var producerEpochField = Decoder.ReadInt16(buffer);
                var transactionResultField = Decoder.ReadBoolean(buffer);
                var topicsField = Decoder.ReadArray<WritableTxnMarkerTopic>(buffer, b => WritableTxnMarkerTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var coordinatorEpochField = Decoder.ReadInt32(buffer);
                return new(
                    producerIdField,
                    producerEpochField,
                    transactionResultField,
                    topicsField,
                    coordinatorEpochField
                );
            }
            public static void WriteV00(Stream buffer, WritableTxnMarker message)
            {
                Encoder.WriteInt64(buffer, message.ProducerIdField);
                Encoder.WriteInt16(buffer, message.ProducerEpochField);
                Encoder.WriteBoolean(buffer, message.TransactionResultField);
                Encoder.WriteArray<WritableTxnMarkerTopic>(buffer, message.TopicsField, (b, i) => WritableTxnMarkerTopicSerde.WriteV00(b, i));
                Encoder.WriteInt32(buffer, message.CoordinatorEpochField);
            }
            public static WritableTxnMarker ReadV01(Stream buffer)
            {
                var producerIdField = Decoder.ReadInt64(buffer);
                var producerEpochField = Decoder.ReadInt16(buffer);
                var transactionResultField = Decoder.ReadBoolean(buffer);
                var topicsField = Decoder.ReadCompactArray<WritableTxnMarkerTopic>(buffer, b => WritableTxnMarkerTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var coordinatorEpochField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    producerIdField,
                    producerEpochField,
                    transactionResultField,
                    topicsField,
                    coordinatorEpochField
                );
            }
            public static void WriteV01(Stream buffer, WritableTxnMarker message)
            {
                Encoder.WriteInt64(buffer, message.ProducerIdField);
                Encoder.WriteInt16(buffer, message.ProducerEpochField);
                Encoder.WriteBoolean(buffer, message.TransactionResultField);
                Encoder.WriteCompactArray<WritableTxnMarkerTopic>(buffer, message.TopicsField, (b, i) => WritableTxnMarkerTopicSerde.WriteV01(b, i));
                Encoder.WriteInt32(buffer, message.CoordinatorEpochField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class WritableTxnMarkerTopicSerde
            {
                public static WritableTxnMarkerTopic ReadV00(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var partitionIndexesField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                    return new(
                        nameField,
                        partitionIndexesField
                    );
                }
                public static void WriteV00(Stream buffer, WritableTxnMarkerTopic message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                }
                public static WritableTxnMarkerTopic ReadV01(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        partitionIndexesField
                    );
                }
                public static void WriteV01(Stream buffer, WritableTxnMarkerTopic message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}