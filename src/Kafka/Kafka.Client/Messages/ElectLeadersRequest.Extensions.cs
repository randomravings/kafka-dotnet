using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicPartitions = Kafka.Client.Messages.ElectLeadersRequest.TopicPartitions;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ElectLeadersRequestSerde
    {
        private static readonly Func<Stream, ElectLeadersRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, ElectLeadersRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static ElectLeadersRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ElectLeadersRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ElectLeadersRequest ReadV00(Stream buffer)
        {
            var electionTypeField = default(sbyte);
            var topicPartitionsField = Decoder.ReadArray<TopicPartitions>(buffer, b => TopicPartitionsSerde.ReadV00(b));
            var timeoutMsField = Decoder.ReadInt32(buffer);
            return new(
                electionTypeField,
                topicPartitionsField,
                timeoutMsField
            );
        }
        private static void WriteV00(Stream buffer, ElectLeadersRequest message)
        {
            Encoder.WriteArray<TopicPartitions>(buffer, message.TopicPartitionsField, (b, i) => TopicPartitionsSerde.WriteV00(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
        private static ElectLeadersRequest ReadV01(Stream buffer)
        {
            var electionTypeField = Decoder.ReadInt8(buffer);
            var topicPartitionsField = Decoder.ReadArray<TopicPartitions>(buffer, b => TopicPartitionsSerde.ReadV01(b));
            var timeoutMsField = Decoder.ReadInt32(buffer);
            return new(
                electionTypeField,
                topicPartitionsField,
                timeoutMsField
            );
        }
        private static void WriteV01(Stream buffer, ElectLeadersRequest message)
        {
            Encoder.WriteInt8(buffer, message.ElectionTypeField);
            Encoder.WriteArray<TopicPartitions>(buffer, message.TopicPartitionsField, (b, i) => TopicPartitionsSerde.WriteV01(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
        private static ElectLeadersRequest ReadV02(Stream buffer)
        {
            var electionTypeField = Decoder.ReadInt8(buffer);
            var topicPartitionsField = Decoder.ReadCompactArray<TopicPartitions>(buffer, b => TopicPartitionsSerde.ReadV02(b));
            var timeoutMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                electionTypeField,
                topicPartitionsField,
                timeoutMsField
            );
        }
        private static void WriteV02(Stream buffer, ElectLeadersRequest message)
        {
            Encoder.WriteInt8(buffer, message.ElectionTypeField);
            Encoder.WriteCompactArray<TopicPartitions>(buffer, message.TopicPartitionsField, (b, i) => TopicPartitionsSerde.WriteV02(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TopicPartitionsSerde
        {
            public static TopicPartitions ReadV00(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TopicPartitions message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static TopicPartitions ReadV01(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, TopicPartitions message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static TopicPartitions ReadV02(Stream buffer)
            {
                var topicField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, TopicPartitions message)
            {
                Encoder.WriteCompactString(buffer, message.TopicField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}