using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicPartition = Kafka.Client.Messages.ConsumerProtocolAssignment.TopicPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ConsumerProtocolAssignmentSerde
    {
        private static readonly Func<Stream, ConsumerProtocolAssignment>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, ConsumerProtocolAssignment>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static ConsumerProtocolAssignment Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ConsumerProtocolAssignment message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ConsumerProtocolAssignment ReadV00(Stream buffer)
        {
            var assignedPartitionsField = Decoder.ReadArray<TopicPartition>(buffer, b => TopicPartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'AssignedPartitions'");
            var userDataField = Decoder.ReadNullableBytes(buffer);
            return new(
                assignedPartitionsField,
                userDataField
            );
        }
        private static void WriteV00(Stream buffer, ConsumerProtocolAssignment message)
        {
            Encoder.WriteArray<TopicPartition>(buffer, message.AssignedPartitionsField, (b, i) => TopicPartitionSerde.WriteV00(b, i));
            Encoder.WriteNullableBytes(buffer, message.UserDataField);
        }
        private static ConsumerProtocolAssignment ReadV01(Stream buffer)
        {
            var assignedPartitionsField = Decoder.ReadArray<TopicPartition>(buffer, b => TopicPartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'AssignedPartitions'");
            var userDataField = Decoder.ReadNullableBytes(buffer);
            return new(
                assignedPartitionsField,
                userDataField
            );
        }
        private static void WriteV01(Stream buffer, ConsumerProtocolAssignment message)
        {
            Encoder.WriteArray<TopicPartition>(buffer, message.AssignedPartitionsField, (b, i) => TopicPartitionSerde.WriteV01(b, i));
            Encoder.WriteNullableBytes(buffer, message.UserDataField);
        }
        private static class TopicPartitionSerde
        {
            public static TopicPartition ReadV00(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TopicPartition message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static TopicPartition ReadV01(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, TopicPartition message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
        }
    }
}