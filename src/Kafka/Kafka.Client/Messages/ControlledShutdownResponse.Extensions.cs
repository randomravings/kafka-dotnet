using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using RemainingPartition = Kafka.Client.Messages.ControlledShutdownResponse.RemainingPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ControlledShutdownResponseSerde
    {
        private static readonly DecodeDelegate<ControlledShutdownResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<ControlledShutdownResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static ControlledShutdownResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ControlledShutdownResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ControlledShutdownResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var remainingPartitionsField = Decoder.ReadArray<RemainingPartition>(buffer, ref index, RemainingPartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ControlledShutdownResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<RemainingPartition>(buffer, index, message.RemainingPartitionsField, RemainingPartitionSerde.WriteV00);
            return index;
        }
        private static ControlledShutdownResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var remainingPartitionsField = Decoder.ReadArray<RemainingPartition>(buffer, ref index, RemainingPartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ControlledShutdownResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<RemainingPartition>(buffer, index, message.RemainingPartitionsField, RemainingPartitionSerde.WriteV01);
            return index;
        }
        private static ControlledShutdownResponse ReadV02(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var remainingPartitionsField = Decoder.ReadArray<RemainingPartition>(buffer, ref index, RemainingPartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ControlledShutdownResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<RemainingPartition>(buffer, index, message.RemainingPartitionsField, RemainingPartitionSerde.WriteV02);
            return index;
        }
        private static ControlledShutdownResponse ReadV03(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var remainingPartitionsField = Decoder.ReadCompactArray<RemainingPartition>(buffer, ref index, RemainingPartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, ControlledShutdownResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<RemainingPartition>(buffer, index, message.RemainingPartitionsField, RemainingPartitionSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class RemainingPartitionSerde
        {
            public static RemainingPartition ReadV00(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static int WriteV00(byte[] buffer, int index, RemainingPartition message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                return index;
            }
            public static RemainingPartition ReadV01(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static int WriteV01(byte[] buffer, int index, RemainingPartition message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                return index;
            }
            public static RemainingPartition ReadV02(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static int WriteV02(byte[] buffer, int index, RemainingPartition message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                return index;
            }
            public static RemainingPartition ReadV03(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static int WriteV03(byte[] buffer, int index, RemainingPartition message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}