using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using WritableTxnMarkerTopic = Kafka.Client.Messages.WriteTxnMarkersRequest.WritableTxnMarker.WritableTxnMarkerTopic;
using WritableTxnMarker = Kafka.Client.Messages.WriteTxnMarkersRequest.WritableTxnMarker;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class WriteTxnMarkersRequestSerde
    {
        private static readonly DecodeDelegate<WriteTxnMarkersRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate<WriteTxnMarkersRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static WriteTxnMarkersRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, WriteTxnMarkersRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static WriteTxnMarkersRequest ReadV00(byte[] buffer, ref int index)
        {
            var markersField = Decoder.ReadArray<WritableTxnMarker>(buffer, ref index, WritableTxnMarkerSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            return new(
                markersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, WriteTxnMarkersRequest message)
        {
            index = Encoder.WriteArray<WritableTxnMarker>(buffer, index, message.MarkersField, WritableTxnMarkerSerde.WriteV00);
            return index;
        }
        private static WriteTxnMarkersRequest ReadV01(byte[] buffer, ref int index)
        {
            var markersField = Decoder.ReadCompactArray<WritableTxnMarker>(buffer, ref index, WritableTxnMarkerSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                markersField
            );
        }
        private static int WriteV01(byte[] buffer, int index, WriteTxnMarkersRequest message)
        {
            index = Encoder.WriteCompactArray<WritableTxnMarker>(buffer, index, message.MarkersField, WritableTxnMarkerSerde.WriteV01);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class WritableTxnMarkerSerde
        {
            public static WritableTxnMarker ReadV00(byte[] buffer, ref int index)
            {
                var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                var ProducerEpochField = Decoder.ReadInt16(buffer, ref index);
                var TransactionResultField = Decoder.ReadBoolean(buffer, ref index);
                var TopicsField = Decoder.ReadArray<WritableTxnMarkerTopic>(buffer, ref index, WritableTxnMarkerTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var CoordinatorEpochField = Decoder.ReadInt32(buffer, ref index);
                return new(
                    ProducerIdField,
                    ProducerEpochField,
                    TransactionResultField,
                    TopicsField,
                    CoordinatorEpochField
                );
            }
            public static int WriteV00(byte[] buffer, int index, WritableTxnMarker message)
            {
                index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
                index = Encoder.WriteBoolean(buffer, index, message.TransactionResultField);
                index = Encoder.WriteArray<WritableTxnMarkerTopic>(buffer, index, message.TopicsField, WritableTxnMarkerTopicSerde.WriteV00);
                index = Encoder.WriteInt32(buffer, index, message.CoordinatorEpochField);
                return index;
            }
            public static WritableTxnMarker ReadV01(byte[] buffer, ref int index)
            {
                var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                var ProducerEpochField = Decoder.ReadInt16(buffer, ref index);
                var TransactionResultField = Decoder.ReadBoolean(buffer, ref index);
                var TopicsField = Decoder.ReadCompactArray<WritableTxnMarkerTopic>(buffer, ref index, WritableTxnMarkerTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                var CoordinatorEpochField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ProducerIdField,
                    ProducerEpochField,
                    TransactionResultField,
                    TopicsField,
                    CoordinatorEpochField
                );
            }
            public static int WriteV01(byte[] buffer, int index, WritableTxnMarker message)
            {
                index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
                index = Encoder.WriteBoolean(buffer, index, message.TransactionResultField);
                index = Encoder.WriteCompactArray<WritableTxnMarkerTopic>(buffer, index, message.TopicsField, WritableTxnMarkerTopicSerde.WriteV01);
                index = Encoder.WriteInt32(buffer, index, message.CoordinatorEpochField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class WritableTxnMarkerTopicSerde
            {
                public static WritableTxnMarkerTopic ReadV00(byte[] buffer, ref int index)
                {
                    var NameField = Decoder.ReadString(buffer, ref index);
                    var PartitionIndexesField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                    return new(
                        NameField,
                        PartitionIndexesField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, WritableTxnMarkerTopic message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                    return index;
                }
                public static WritableTxnMarkerTopic ReadV01(byte[] buffer, ref int index)
                {
                    var NameField = Decoder.ReadCompactString(buffer, ref index);
                    var PartitionIndexesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        NameField,
                        PartitionIndexesField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, WritableTxnMarkerTopic message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}