using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicPartition = Kafka.Client.Messages.ConsumerProtocolAssignment.TopicPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ConsumerProtocolAssignmentSerde
    {
        private static readonly DecodeDelegate<ConsumerProtocolAssignment>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<ConsumerProtocolAssignment>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static ConsumerProtocolAssignment Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ConsumerProtocolAssignment message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ConsumerProtocolAssignment ReadV00(byte[] buffer, ref int index)
        {
            var assignedPartitionsField = Decoder.ReadArray<TopicPartition>(buffer, ref index, TopicPartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'AssignedPartitions'");
            var userDataField = Decoder.ReadNullableBytes(buffer, ref index);
            return new(
                assignedPartitionsField,
                userDataField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ConsumerProtocolAssignment message)
        {
            index = Encoder.WriteArray<TopicPartition>(buffer, index, message.AssignedPartitionsField, TopicPartitionSerde.WriteV00);
            index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
            return index;
        }
        private static ConsumerProtocolAssignment ReadV01(byte[] buffer, ref int index)
        {
            var assignedPartitionsField = Decoder.ReadArray<TopicPartition>(buffer, ref index, TopicPartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'AssignedPartitions'");
            var userDataField = Decoder.ReadNullableBytes(buffer, ref index);
            return new(
                assignedPartitionsField,
                userDataField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ConsumerProtocolAssignment message)
        {
            index = Encoder.WriteArray<TopicPartition>(buffer, index, message.AssignedPartitionsField, TopicPartitionSerde.WriteV01);
            index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
            return index;
        }
        private static ConsumerProtocolAssignment ReadV02(byte[] buffer, ref int index)
        {
            var assignedPartitionsField = Decoder.ReadArray<TopicPartition>(buffer, ref index, TopicPartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'AssignedPartitions'");
            var userDataField = Decoder.ReadNullableBytes(buffer, ref index);
            return new(
                assignedPartitionsField,
                userDataField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ConsumerProtocolAssignment message)
        {
            index = Encoder.WriteArray<TopicPartition>(buffer, index, message.AssignedPartitionsField, TopicPartitionSerde.WriteV02);
            index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
            return index;
        }
        private static class TopicPartitionSerde
        {
            public static TopicPartition ReadV00(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicPartition message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static TopicPartition ReadV01(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, TopicPartition message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static TopicPartition ReadV02(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    PartitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, TopicPartition message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
        }
    }
}