using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DeleteRecordsTopic = Kafka.Client.Messages.DeleteRecordsRequest.DeleteRecordsTopic;
using DeleteRecordsPartition = Kafka.Client.Messages.DeleteRecordsRequest.DeleteRecordsTopic.DeleteRecordsPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteRecordsRequestSerde
    {
        private static readonly DecodeDelegate<DeleteRecordsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<DeleteRecordsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static DeleteRecordsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DeleteRecordsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DeleteRecordsRequest ReadV00(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<DeleteRecordsTopic>(buffer, ref index, DeleteRecordsTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DeleteRecordsRequest message)
        {
            index = Encoder.WriteArray<DeleteRecordsTopic>(buffer, index, message.TopicsField, DeleteRecordsTopicSerde.WriteV00);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static DeleteRecordsRequest ReadV01(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<DeleteRecordsTopic>(buffer, ref index, DeleteRecordsTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DeleteRecordsRequest message)
        {
            index = Encoder.WriteArray<DeleteRecordsTopic>(buffer, index, message.TopicsField, DeleteRecordsTopicSerde.WriteV01);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static DeleteRecordsRequest ReadV02(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<DeleteRecordsTopic>(buffer, ref index, DeleteRecordsTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                timeoutMsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DeleteRecordsRequest message)
        {
            index = Encoder.WriteCompactArray<DeleteRecordsTopic>(buffer, index, message.TopicsField, DeleteRecordsTopicSerde.WriteV02);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DeleteRecordsTopicSerde
        {
            public static DeleteRecordsTopic ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<DeleteRecordsPartition>(buffer, ref index, DeleteRecordsPartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DeleteRecordsTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<DeleteRecordsPartition>(buffer, index, message.PartitionsField, DeleteRecordsPartitionSerde.WriteV00);
                return index;
            }
            public static DeleteRecordsTopic ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<DeleteRecordsPartition>(buffer, ref index, DeleteRecordsPartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, DeleteRecordsTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<DeleteRecordsPartition>(buffer, index, message.PartitionsField, DeleteRecordsPartitionSerde.WriteV01);
                return index;
            }
            public static DeleteRecordsTopic ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<DeleteRecordsPartition>(buffer, ref index, DeleteRecordsPartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, DeleteRecordsTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<DeleteRecordsPartition>(buffer, index, message.PartitionsField, DeleteRecordsPartitionSerde.WriteV02);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class DeleteRecordsPartitionSerde
            {
                public static DeleteRecordsPartition ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var OffsetField = Decoder.ReadInt64(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        OffsetField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, DeleteRecordsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                    return index;
                }
                public static DeleteRecordsPartition ReadV01(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var OffsetField = Decoder.ReadInt64(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        OffsetField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, DeleteRecordsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                    return index;
                }
                public static DeleteRecordsPartition ReadV02(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var OffsetField = Decoder.ReadInt64(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        OffsetField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, DeleteRecordsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.OffsetField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}