using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using StopReplicaPartitionError = Kafka.Client.Messages.StopReplicaResponse.StopReplicaPartitionError;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class StopReplicaResponseSerde
    {
        private static readonly DecodeDelegate<StopReplicaResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<StopReplicaResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static StopReplicaResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, StopReplicaResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static StopReplicaResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = Decoder.ReadArray<StopReplicaPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => StopReplicaPartitionErrorSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, StopReplicaResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<StopReplicaPartitionError>(buffer, message.PartitionErrorsField, (b, i) => StopReplicaPartitionErrorSerde.WriteV00(b, i));
            return buffer;
        }
        private static StopReplicaResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = Decoder.ReadArray<StopReplicaPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => StopReplicaPartitionErrorSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, StopReplicaResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<StopReplicaPartitionError>(buffer, message.PartitionErrorsField, (b, i) => StopReplicaPartitionErrorSerde.WriteV01(b, i));
            return buffer;
        }
        private static StopReplicaResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = Decoder.ReadCompactArray<StopReplicaPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => StopReplicaPartitionErrorSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, StopReplicaResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<StopReplicaPartitionError>(buffer, message.PartitionErrorsField, (b, i) => StopReplicaPartitionErrorSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static StopReplicaResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = Decoder.ReadCompactArray<StopReplicaPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => StopReplicaPartitionErrorSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, StopReplicaResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<StopReplicaPartitionError>(buffer, message.PartitionErrorsField, (b, i) => StopReplicaPartitionErrorSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class StopReplicaPartitionErrorSerde
        {
            public static StopReplicaPartitionError ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, StopReplicaPartitionError message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static StopReplicaPartitionError ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, StopReplicaPartitionError message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static StopReplicaPartitionError ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, StopReplicaPartitionError message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static StopReplicaPartitionError ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, StopReplicaPartitionError message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}