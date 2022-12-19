using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using StopReplicaPartitionError = Kafka.Client.Messages.StopReplicaResponse.StopReplicaPartitionError;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class StopReplicaResponseSerde
    {
        private static readonly DecodeDelegate<StopReplicaResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<StopReplicaResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static StopReplicaResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, StopReplicaResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static StopReplicaResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = Decoder.ReadArray<StopReplicaPartitionError>(buffer, ref index, StopReplicaPartitionErrorSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, StopReplicaResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<StopReplicaPartitionError>(buffer, index, message.PartitionErrorsField, StopReplicaPartitionErrorSerde.WriteV00);
            return index;
        }
        private static StopReplicaResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = Decoder.ReadArray<StopReplicaPartitionError>(buffer, ref index, StopReplicaPartitionErrorSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, StopReplicaResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<StopReplicaPartitionError>(buffer, index, message.PartitionErrorsField, StopReplicaPartitionErrorSerde.WriteV01);
            return index;
        }
        private static StopReplicaResponse ReadV02(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = Decoder.ReadCompactArray<StopReplicaPartitionError>(buffer, ref index, StopReplicaPartitionErrorSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, StopReplicaResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<StopReplicaPartitionError>(buffer, index, message.PartitionErrorsField, StopReplicaPartitionErrorSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static StopReplicaResponse ReadV03(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = Decoder.ReadCompactArray<StopReplicaPartitionError>(buffer, ref index, StopReplicaPartitionErrorSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, StopReplicaResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<StopReplicaPartitionError>(buffer, index, message.PartitionErrorsField, StopReplicaPartitionErrorSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static StopReplicaResponse ReadV04(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = Decoder.ReadCompactArray<StopReplicaPartitionError>(buffer, ref index, StopReplicaPartitionErrorSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                partitionErrorsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, StopReplicaResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<StopReplicaPartitionError>(buffer, index, message.PartitionErrorsField, StopReplicaPartitionErrorSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class StopReplicaPartitionErrorSerde
        {
            public static StopReplicaPartitionError ReadV00(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV00(byte[] buffer, int index, StopReplicaPartitionError message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static StopReplicaPartitionError ReadV01(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV01(byte[] buffer, int index, StopReplicaPartitionError message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static StopReplicaPartitionError ReadV02(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV02(byte[] buffer, int index, StopReplicaPartitionError message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static StopReplicaPartitionError ReadV03(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV03(byte[] buffer, int index, StopReplicaPartitionError message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static StopReplicaPartitionError ReadV04(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV04(byte[] buffer, int index, StopReplicaPartitionError message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}