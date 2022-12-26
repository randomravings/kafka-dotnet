using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicPartition = Kafka.Client.Messages.ConsumerProtocolSubscription.TopicPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ConsumerProtocolSubscriptionSerde
    {
        private static readonly DecodeDelegate<ConsumerProtocolSubscription>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<ConsumerProtocolSubscription>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static ConsumerProtocolSubscription Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ConsumerProtocolSubscription message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ConsumerProtocolSubscription ReadV00(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var userDataField = Decoder.ReadNullableBytes(buffer, ref index);
            var ownedPartitionsField = ImmutableArray<TopicPartition>.Empty;
            var generationIdField = default(int);
            return new(
                topicsField,
                userDataField,
                ownedPartitionsField,
                generationIdField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ConsumerProtocolSubscription message)
        {
            index = Encoder.WriteArray<string>(buffer, index, message.TopicsField, Encoder.WriteCompactString);
            index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
            return index;
        }
        private static ConsumerProtocolSubscription ReadV01(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var userDataField = Decoder.ReadNullableBytes(buffer, ref index);
            var ownedPartitionsField = Decoder.ReadArray<TopicPartition>(buffer, ref index, TopicPartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'OwnedPartitions'");
            var generationIdField = default(int);
            return new(
                topicsField,
                userDataField,
                ownedPartitionsField,
                generationIdField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ConsumerProtocolSubscription message)
        {
            index = Encoder.WriteArray<string>(buffer, index, message.TopicsField, Encoder.WriteCompactString);
            index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
            index = Encoder.WriteArray<TopicPartition>(buffer, index, message.OwnedPartitionsField, TopicPartitionSerde.WriteV01);
            return index;
        }
        private static ConsumerProtocolSubscription ReadV02(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var userDataField = Decoder.ReadNullableBytes(buffer, ref index);
            var ownedPartitionsField = Decoder.ReadArray<TopicPartition>(buffer, ref index, TopicPartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'OwnedPartitions'");
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            return new(
                topicsField,
                userDataField,
                ownedPartitionsField,
                generationIdField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ConsumerProtocolSubscription message)
        {
            index = Encoder.WriteArray<string>(buffer, index, message.TopicsField, Encoder.WriteCompactString);
            index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
            index = Encoder.WriteArray<TopicPartition>(buffer, index, message.OwnedPartitionsField, TopicPartitionSerde.WriteV02);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            return index;
        }
        private static class TopicPartitionSerde
        {
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