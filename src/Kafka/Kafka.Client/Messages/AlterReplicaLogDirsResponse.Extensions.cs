using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterReplicaLogDirTopicResult = Kafka.Client.Messages.AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult;
using AlterReplicaLogDirPartitionResult = Kafka.Client.Messages.AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult.AlterReplicaLogDirPartitionResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterReplicaLogDirsResponseSerde
    {
        private static readonly DecodeDelegate<AlterReplicaLogDirsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<AlterReplicaLogDirsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static AlterReplicaLogDirsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterReplicaLogDirsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterReplicaLogDirsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<AlterReplicaLogDirTopicResult>(buffer, ref index, AlterReplicaLogDirTopicResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterReplicaLogDirsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<AlterReplicaLogDirTopicResult>(buffer, index, message.ResultsField, AlterReplicaLogDirTopicResultSerde.WriteV00);
            return index;
        }
        private static AlterReplicaLogDirsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<AlterReplicaLogDirTopicResult>(buffer, ref index, AlterReplicaLogDirTopicResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AlterReplicaLogDirsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<AlterReplicaLogDirTopicResult>(buffer, index, message.ResultsField, AlterReplicaLogDirTopicResultSerde.WriteV01);
            return index;
        }
        private static AlterReplicaLogDirsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<AlterReplicaLogDirTopicResult>(buffer, ref index, AlterReplicaLogDirTopicResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, AlterReplicaLogDirsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<AlterReplicaLogDirTopicResult>(buffer, index, message.ResultsField, AlterReplicaLogDirTopicResultSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class AlterReplicaLogDirTopicResultSerde
        {
            public static AlterReplicaLogDirTopicResult ReadV00(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<AlterReplicaLogDirPartitionResult>(buffer, ref index, AlterReplicaLogDirPartitionResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, AlterReplicaLogDirTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteArray<AlterReplicaLogDirPartitionResult>(buffer, index, message.PartitionsField, AlterReplicaLogDirPartitionResultSerde.WriteV00);
                return index;
            }
            public static AlterReplicaLogDirTopicResult ReadV01(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<AlterReplicaLogDirPartitionResult>(buffer, ref index, AlterReplicaLogDirPartitionResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, AlterReplicaLogDirTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteArray<AlterReplicaLogDirPartitionResult>(buffer, index, message.PartitionsField, AlterReplicaLogDirPartitionResultSerde.WriteV01);
                return index;
            }
            public static AlterReplicaLogDirTopicResult ReadV02(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<AlterReplicaLogDirPartitionResult>(buffer, ref index, AlterReplicaLogDirPartitionResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, AlterReplicaLogDirTopicResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteCompactArray<AlterReplicaLogDirPartitionResult>(buffer, index, message.PartitionsField, AlterReplicaLogDirPartitionResultSerde.WriteV02);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class AlterReplicaLogDirPartitionResultSerde
            {
                public static AlterReplicaLogDirPartitionResult ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, AlterReplicaLogDirPartitionResult message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static AlterReplicaLogDirPartitionResult ReadV01(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, AlterReplicaLogDirPartitionResult message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static AlterReplicaLogDirPartitionResult ReadV02(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, AlterReplicaLogDirPartitionResult message)
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