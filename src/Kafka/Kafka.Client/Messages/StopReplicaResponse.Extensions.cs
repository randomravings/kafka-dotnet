using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using StopReplicaPartitionError = Kafka.Client.Messages.StopReplicaResponse.StopReplicaPartitionError;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class StopReplicaResponseSerde
    {
        private static readonly Func<Stream, StopReplicaResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, StopReplicaResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static StopReplicaResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, StopReplicaResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static StopReplicaResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = Decoder.ReadArray<StopReplicaPartitionError>(buffer, b => StopReplicaPartitionErrorSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static void WriteV00(Stream buffer, StopReplicaResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<StopReplicaPartitionError>(buffer, message.PartitionErrorsField, (b, i) => StopReplicaPartitionErrorSerde.WriteV00(b, i));
        }
        private static StopReplicaResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = Decoder.ReadArray<StopReplicaPartitionError>(buffer, b => StopReplicaPartitionErrorSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static void WriteV01(Stream buffer, StopReplicaResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<StopReplicaPartitionError>(buffer, message.PartitionErrorsField, (b, i) => StopReplicaPartitionErrorSerde.WriteV01(b, i));
        }
        private static StopReplicaResponse ReadV02(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = Decoder.ReadCompactArray<StopReplicaPartitionError>(buffer, b => StopReplicaPartitionErrorSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static void WriteV02(Stream buffer, StopReplicaResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<StopReplicaPartitionError>(buffer, message.PartitionErrorsField, (b, i) => StopReplicaPartitionErrorSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static StopReplicaResponse ReadV03(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = Decoder.ReadCompactArray<StopReplicaPartitionError>(buffer, b => StopReplicaPartitionErrorSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static void WriteV03(Stream buffer, StopReplicaResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<StopReplicaPartitionError>(buffer, message.PartitionErrorsField, (b, i) => StopReplicaPartitionErrorSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class StopReplicaPartitionErrorSerde
        {
            public static StopReplicaPartitionError ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV00(Stream buffer, StopReplicaPartitionError message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static StopReplicaPartitionError ReadV01(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV01(Stream buffer, StopReplicaPartitionError message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static StopReplicaPartitionError ReadV02(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV02(Stream buffer, StopReplicaPartitionError message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static StopReplicaPartitionError ReadV03(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV03(Stream buffer, StopReplicaPartitionError message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}