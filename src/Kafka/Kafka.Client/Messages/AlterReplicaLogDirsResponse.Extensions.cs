using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AlterReplicaLogDirTopicResult = Kafka.Client.Messages.AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult;
using AlterReplicaLogDirPartitionResult = Kafka.Client.Messages.AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult.AlterReplicaLogDirPartitionResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterReplicaLogDirsResponseSerde
    {
        private static readonly Func<Stream, AlterReplicaLogDirsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, AlterReplicaLogDirsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static AlterReplicaLogDirsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterReplicaLogDirsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterReplicaLogDirsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<AlterReplicaLogDirTopicResult>(buffer, b => AlterReplicaLogDirTopicResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV00(Stream buffer, AlterReplicaLogDirsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<AlterReplicaLogDirTopicResult>(buffer, message.ResultsField, (b, i) => AlterReplicaLogDirTopicResultSerde.WriteV00(b, i));
        }
        private static AlterReplicaLogDirsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<AlterReplicaLogDirTopicResult>(buffer, b => AlterReplicaLogDirTopicResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV01(Stream buffer, AlterReplicaLogDirsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<AlterReplicaLogDirTopicResult>(buffer, message.ResultsField, (b, i) => AlterReplicaLogDirTopicResultSerde.WriteV01(b, i));
        }
        private static AlterReplicaLogDirsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadCompactArray<AlterReplicaLogDirTopicResult>(buffer, b => AlterReplicaLogDirTopicResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV02(Stream buffer, AlterReplicaLogDirsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<AlterReplicaLogDirTopicResult>(buffer, message.ResultsField, (b, i) => AlterReplicaLogDirTopicResultSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class AlterReplicaLogDirTopicResultSerde
        {
            public static AlterReplicaLogDirTopicResult ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<AlterReplicaLogDirPartitionResult>(buffer, b => AlterReplicaLogDirPartitionResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, AlterReplicaLogDirTopicResult message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteArray<AlterReplicaLogDirPartitionResult>(buffer, message.PartitionsField, (b, i) => AlterReplicaLogDirPartitionResultSerde.WriteV00(b, i));
            }
            public static AlterReplicaLogDirTopicResult ReadV01(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<AlterReplicaLogDirPartitionResult>(buffer, b => AlterReplicaLogDirPartitionResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, AlterReplicaLogDirTopicResult message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteArray<AlterReplicaLogDirPartitionResult>(buffer, message.PartitionsField, (b, i) => AlterReplicaLogDirPartitionResultSerde.WriteV01(b, i));
            }
            public static AlterReplicaLogDirTopicResult ReadV02(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<AlterReplicaLogDirPartitionResult>(buffer, b => AlterReplicaLogDirPartitionResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, AlterReplicaLogDirTopicResult message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteCompactArray<AlterReplicaLogDirPartitionResult>(buffer, message.PartitionsField, (b, i) => AlterReplicaLogDirPartitionResultSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class AlterReplicaLogDirPartitionResultSerde
            {
                public static AlterReplicaLogDirPartitionResult ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV00(Stream buffer, AlterReplicaLogDirPartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static AlterReplicaLogDirPartitionResult ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV01(Stream buffer, AlterReplicaLogDirPartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static AlterReplicaLogDirPartitionResult ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV02(Stream buffer, AlterReplicaLogDirPartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}