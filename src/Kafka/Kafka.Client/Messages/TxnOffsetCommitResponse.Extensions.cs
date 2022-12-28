using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TxnOffsetCommitResponsePartition = Kafka.Client.Messages.TxnOffsetCommitResponse.TxnOffsetCommitResponseTopic.TxnOffsetCommitResponsePartition;
using TxnOffsetCommitResponseTopic = Kafka.Client.Messages.TxnOffsetCommitResponse.TxnOffsetCommitResponseTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class TxnOffsetCommitResponseSerde
    {
        private static readonly DecodeDelegate<TxnOffsetCommitResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<TxnOffsetCommitResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static TxnOffsetCommitResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, TxnOffsetCommitResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static TxnOffsetCommitResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(buffer, ref index, TxnOffsetCommitResponseTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, TxnOffsetCommitResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, index, message.TopicsField, TxnOffsetCommitResponseTopicSerde.WriteV00);
            return index;
        }
        private static TxnOffsetCommitResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(buffer, ref index, TxnOffsetCommitResponseTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, TxnOffsetCommitResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, index, message.TopicsField, TxnOffsetCommitResponseTopicSerde.WriteV01);
            return index;
        }
        private static TxnOffsetCommitResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitResponseTopic>(buffer, ref index, TxnOffsetCommitResponseTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, TxnOffsetCommitResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<TxnOffsetCommitResponseTopic>(buffer, index, message.TopicsField, TxnOffsetCommitResponseTopicSerde.WriteV02);
            return index;
        }
        private static TxnOffsetCommitResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TxnOffsetCommitResponseTopic>(buffer, ref index, TxnOffsetCommitResponseTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, TxnOffsetCommitResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<TxnOffsetCommitResponseTopic>(buffer, index, message.TopicsField, TxnOffsetCommitResponseTopicSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TxnOffsetCommitResponseTopicSerde
        {
            public static TxnOffsetCommitResponseTopic ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(buffer, ref index, TxnOffsetCommitResponsePartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TxnOffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, index, message.PartitionsField, TxnOffsetCommitResponsePartitionSerde.WriteV00);
                return index;
            }
            public static TxnOffsetCommitResponseTopic ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(buffer, ref index, TxnOffsetCommitResponsePartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, TxnOffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, index, message.PartitionsField, TxnOffsetCommitResponsePartitionSerde.WriteV01);
                return index;
            }
            public static TxnOffsetCommitResponseTopic ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<TxnOffsetCommitResponsePartition>(buffer, ref index, TxnOffsetCommitResponsePartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, TxnOffsetCommitResponseTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<TxnOffsetCommitResponsePartition>(buffer, index, message.PartitionsField, TxnOffsetCommitResponsePartitionSerde.WriteV02);
                return index;
            }
            public static TxnOffsetCommitResponseTopic ReadV03(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<TxnOffsetCommitResponsePartition>(buffer, ref index, TxnOffsetCommitResponsePartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, TxnOffsetCommitResponseTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<TxnOffsetCommitResponsePartition>(buffer, index, message.PartitionsField, TxnOffsetCommitResponsePartitionSerde.WriteV03);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class TxnOffsetCommitResponsePartitionSerde
            {
                public static TxnOffsetCommitResponsePartition ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, TxnOffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static TxnOffsetCommitResponsePartition ReadV01(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, TxnOffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static TxnOffsetCommitResponsePartition ReadV02(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, TxnOffsetCommitResponsePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static TxnOffsetCommitResponsePartition ReadV03(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, TxnOffsetCommitResponsePartition message)
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