using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using WritableTxnMarkerTopicResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult;
using WritableTxnMarkerResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult;
using WritableTxnMarkerPartitionResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult.WritableTxnMarkerPartitionResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class WriteTxnMarkersResponseSerde
    {
        private static readonly DecodeDelegate<WriteTxnMarkersResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate<WriteTxnMarkersResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static WriteTxnMarkersResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, WriteTxnMarkersResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static WriteTxnMarkersResponse ReadV00(byte[] buffer, ref int index)
        {
            var markersField = Decoder.ReadArray<WritableTxnMarkerResult>(buffer, ref index, WritableTxnMarkerResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            return new(
                markersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, WriteTxnMarkersResponse message)
        {
            index = Encoder.WriteArray<WritableTxnMarkerResult>(buffer, index, message.MarkersField, WritableTxnMarkerResultSerde.WriteV00);
            return index;
        }
        private static WriteTxnMarkersResponse ReadV01(byte[] buffer, ref int index)
        {
            var markersField = Decoder.ReadCompactArray<WritableTxnMarkerResult>(buffer, ref index, WritableTxnMarkerResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                markersField
            );
        }
        private static int WriteV01(byte[] buffer, int index, WriteTxnMarkersResponse message)
        {
            index = Encoder.WriteCompactArray<WritableTxnMarkerResult>(buffer, index, message.MarkersField, WritableTxnMarkerResultSerde.WriteV01);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class WritableTxnMarkerResultSerde
        {
            public static WritableTxnMarkerResult ReadV00(byte[] buffer, ref int index)
            {
                var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                var TopicsField = Decoder.ReadArray<WritableTxnMarkerTopicResult>(buffer, ref index, WritableTxnMarkerTopicResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                return new(
                    ProducerIdField,
                    TopicsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, WritableTxnMarkerResult message)
            {
                index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                index = Encoder.WriteArray<WritableTxnMarkerTopicResult>(buffer, index, message.TopicsField, WritableTxnMarkerTopicResultSerde.WriteV00);
                return index;
            }
            public static WritableTxnMarkerResult ReadV01(byte[] buffer, ref int index)
            {
                var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                var TopicsField = Decoder.ReadCompactArray<WritableTxnMarkerTopicResult>(buffer, ref index, WritableTxnMarkerTopicResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ProducerIdField,
                    TopicsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, WritableTxnMarkerResult message)
            {
                index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                index = Encoder.WriteCompactArray<WritableTxnMarkerTopicResult>(buffer, index, message.TopicsField, WritableTxnMarkerTopicResultSerde.WriteV01);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class WritableTxnMarkerTopicResultSerde
            {
                public static WritableTxnMarkerTopicResult ReadV00(byte[] buffer, ref int index)
                {
                    var NameField = Decoder.ReadString(buffer, ref index);
                    var PartitionsField = Decoder.ReadArray<WritableTxnMarkerPartitionResult>(buffer, ref index, WritableTxnMarkerPartitionResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        NameField,
                        PartitionsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, WritableTxnMarkerTopicResult message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteArray<WritableTxnMarkerPartitionResult>(buffer, index, message.PartitionsField, WritableTxnMarkerPartitionResultSerde.WriteV00);
                    return index;
                }
                public static WritableTxnMarkerTopicResult ReadV01(byte[] buffer, ref int index)
                {
                    var NameField = Decoder.ReadCompactString(buffer, ref index);
                    var PartitionsField = Decoder.ReadCompactArray<WritableTxnMarkerPartitionResult>(buffer, ref index, WritableTxnMarkerPartitionResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        NameField,
                        PartitionsField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, WritableTxnMarkerTopicResult message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactArray<WritableTxnMarkerPartitionResult>(buffer, index, message.PartitionsField, WritableTxnMarkerPartitionResultSerde.WriteV01);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                private static class WritableTxnMarkerPartitionResultSerde
                {
                    public static WritableTxnMarkerPartitionResult ReadV00(byte[] buffer, ref int index)
                    {
                        var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                        var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                        return new(
                            PartitionIndexField,
                            ErrorCodeField
                        );
                    }
                    public static int WriteV00(byte[] buffer, int index, WritableTxnMarkerPartitionResult message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                        index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                        return index;
                    }
                    public static WritableTxnMarkerPartitionResult ReadV01(byte[] buffer, ref int index)
                    {
                        var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                        var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            PartitionIndexField,
                            ErrorCodeField
                        );
                    }
                    public static int WriteV01(byte[] buffer, int index, WritableTxnMarkerPartitionResult message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                        index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
            }
        }
    }
}