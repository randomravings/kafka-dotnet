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
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<ConsumerProtocolSubscription>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static ConsumerProtocolSubscription Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ConsumerProtocolSubscription message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ConsumerProtocolSubscription ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var userDataField = Decoder.ReadNullableBytes(ref buffer);
            var ownedPartitionsField = ImmutableArray<TopicPartition>.Empty;
            return new(
                topicsField,
                userDataField,
                ownedPartitionsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ConsumerProtocolSubscription message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.TopicsField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteNullableBytes(buffer, message.UserDataField);
            return buffer;
        }
        private static ConsumerProtocolSubscription ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var userDataField = Decoder.ReadNullableBytes(ref buffer);
            var ownedPartitionsField = Decoder.ReadArray<TopicPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicPartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'OwnedPartitions'");
            return new(
                topicsField,
                userDataField,
                ownedPartitionsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ConsumerProtocolSubscription message)
        {
            buffer = Encoder.WriteArray<string>(buffer, message.TopicsField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteNullableBytes(buffer, message.UserDataField);
            buffer = Encoder.WriteArray<TopicPartition>(buffer, message.OwnedPartitionsField, (b, i) => TopicPartitionSerde.WriteV01(b, i));
            return buffer;
        }
        private static class TopicPartitionSerde
        {
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