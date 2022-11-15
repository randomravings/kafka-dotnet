using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicPartition = Kafka.Client.Messages.ConsumerProtocolSubscription.TopicPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ConsumerProtocolSubscriptionSerde
    {
        private static readonly Func<Stream, ConsumerProtocolSubscription>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, ConsumerProtocolSubscription>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static ConsumerProtocolSubscription Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ConsumerProtocolSubscription message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ConsumerProtocolSubscription ReadV00(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var userDataField = Decoder.ReadNullableBytes(buffer);
            var ownedPartitionsField = ImmutableArray<TopicPartition>.Empty;
            return new(
                topicsField,
                userDataField,
                ownedPartitionsField
            );
        }
        private static void WriteV00(Stream buffer, ConsumerProtocolSubscription message)
        {
            Encoder.WriteArray<string>(buffer, message.TopicsField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteNullableBytes(buffer, message.UserDataField);
        }
        private static ConsumerProtocolSubscription ReadV01(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var userDataField = Decoder.ReadNullableBytes(buffer);
            var ownedPartitionsField = Decoder.ReadArray<TopicPartition>(buffer, b => TopicPartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'OwnedPartitions'");
            return new(
                topicsField,
                userDataField,
                ownedPartitionsField
            );
        }
        private static void WriteV01(Stream buffer, ConsumerProtocolSubscription message)
        {
            Encoder.WriteArray<string>(buffer, message.TopicsField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteNullableBytes(buffer, message.UserDataField);
            Encoder.WriteArray<TopicPartition>(buffer, message.OwnedPartitionsField, (b, i) => TopicPartitionSerde.WriteV01(b, i));
        }
        private static class TopicPartitionSerde
        {
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