using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AlterReplicaLogDirPartitionResult = Kafka.Client.Messages.AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult.AlterReplicaLogDirPartitionResult;
using AlterReplicaLogDirTopicResult = Kafka.Client.Messages.AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterReplicaLogDirsResponseSerde
    {
        private static readonly DecodeDelegate<AlterReplicaLogDirsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<AlterReplicaLogDirsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static AlterReplicaLogDirsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AlterReplicaLogDirsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AlterReplicaLogDirsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<AlterReplicaLogDirTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirTopicResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AlterReplicaLogDirsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<AlterReplicaLogDirTopicResult>(buffer, message.ResultsField, (b, i) => AlterReplicaLogDirTopicResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static AlterReplicaLogDirsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<AlterReplicaLogDirTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirTopicResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, AlterReplicaLogDirsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<AlterReplicaLogDirTopicResult>(buffer, message.ResultsField, (b, i) => AlterReplicaLogDirTopicResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static AlterReplicaLogDirsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadCompactArray<AlterReplicaLogDirTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirTopicResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, AlterReplicaLogDirsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<AlterReplicaLogDirTopicResult>(buffer, message.ResultsField, (b, i) => AlterReplicaLogDirTopicResultSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class AlterReplicaLogDirTopicResultSerde
        {
            public static AlterReplicaLogDirTopicResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<AlterReplicaLogDirPartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirPartitionResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, AlterReplicaLogDirTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteArray<AlterReplicaLogDirPartitionResult>(buffer, message.PartitionsField, (b, i) => AlterReplicaLogDirPartitionResultSerde.WriteV00(b, i));
                return buffer;
            }
            public static AlterReplicaLogDirTopicResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<AlterReplicaLogDirPartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirPartitionResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, AlterReplicaLogDirTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteArray<AlterReplicaLogDirPartitionResult>(buffer, message.PartitionsField, (b, i) => AlterReplicaLogDirPartitionResultSerde.WriteV01(b, i));
                return buffer;
            }
            public static AlterReplicaLogDirTopicResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<AlterReplicaLogDirPartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterReplicaLogDirPartitionResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, AlterReplicaLogDirTopicResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteCompactArray<AlterReplicaLogDirPartitionResult>(buffer, message.PartitionsField, (b, i) => AlterReplicaLogDirPartitionResultSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class AlterReplicaLogDirPartitionResultSerde
            {
                public static AlterReplicaLogDirPartitionResult ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, AlterReplicaLogDirPartitionResult message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static AlterReplicaLogDirPartitionResult ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, AlterReplicaLogDirPartitionResult message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static AlterReplicaLogDirPartitionResult ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, AlterReplicaLogDirPartitionResult message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}