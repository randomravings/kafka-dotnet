using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicPartition = Kafka.Client.Messages.ConsumerProtocolAssignment.TopicPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ConsumerProtocolAssignmentSerde
    {
        private static readonly DecodeDelegate<ConsumerProtocolAssignment>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<ConsumerProtocolAssignment>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static ConsumerProtocolAssignment Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ConsumerProtocolAssignment message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ConsumerProtocolAssignment ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var assignedPartitionsField = Decoder.ReadArray<TopicPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicPartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'AssignedPartitions'");
            var userDataField = Decoder.ReadNullableBytes(ref buffer);
            return new(
                assignedPartitionsField,
                userDataField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ConsumerProtocolAssignment message)
        {
            buffer = Encoder.WriteArray<TopicPartition>(buffer, message.AssignedPartitionsField, (b, i) => TopicPartitionSerde.WriteV00(b, i));
            buffer = Encoder.WriteNullableBytes(buffer, message.UserDataField);
            return buffer;
        }
        private static ConsumerProtocolAssignment ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var assignedPartitionsField = Decoder.ReadArray<TopicPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicPartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'AssignedPartitions'");
            var userDataField = Decoder.ReadNullableBytes(ref buffer);
            return new(
                assignedPartitionsField,
                userDataField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ConsumerProtocolAssignment message)
        {
            buffer = Encoder.WriteArray<TopicPartition>(buffer, message.AssignedPartitionsField, (b, i) => TopicPartitionSerde.WriteV01(b, i));
            buffer = Encoder.WriteNullableBytes(buffer, message.UserDataField);
            return buffer;
        }
        private static class TopicPartitionSerde
        {
            public static TopicPartition ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicPartition message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static TopicPartition ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, TopicPartition message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
        }
    }
}