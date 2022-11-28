using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicPartitions = Kafka.Client.Messages.ElectLeadersRequest.TopicPartitions;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ElectLeadersRequestSerde
    {
        private static readonly DecodeDelegate<ElectLeadersRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<ElectLeadersRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static ElectLeadersRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ElectLeadersRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ElectLeadersRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var electionTypeField = default(sbyte);
            var topicPartitionsField = Decoder.ReadArray<TopicPartitions>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicPartitionsSerde.ReadV00(ref b));
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            return new(
                electionTypeField,
                topicPartitionsField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ElectLeadersRequest message)
        {
            buffer = Encoder.WriteArray<TopicPartitions>(buffer, message.TopicPartitionsField, (b, i) => TopicPartitionsSerde.WriteV00(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            return buffer;
        }
        private static ElectLeadersRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var electionTypeField = Decoder.ReadInt8(ref buffer);
            var topicPartitionsField = Decoder.ReadArray<TopicPartitions>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicPartitionsSerde.ReadV01(ref b));
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            return new(
                electionTypeField,
                topicPartitionsField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ElectLeadersRequest message)
        {
            buffer = Encoder.WriteInt8(buffer, message.ElectionTypeField);
            buffer = Encoder.WriteArray<TopicPartitions>(buffer, message.TopicPartitionsField, (b, i) => TopicPartitionsSerde.WriteV01(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            return buffer;
        }
        private static ElectLeadersRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var electionTypeField = Decoder.ReadInt8(ref buffer);
            var topicPartitionsField = Decoder.ReadCompactArray<TopicPartitions>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicPartitionsSerde.ReadV02(ref b));
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                electionTypeField,
                topicPartitionsField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ElectLeadersRequest message)
        {
            buffer = Encoder.WriteInt8(buffer, message.ElectionTypeField);
            buffer = Encoder.WriteCompactArray<TopicPartitions>(buffer, message.TopicPartitionsField, (b, i) => TopicPartitionsSerde.WriteV02(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TopicPartitionsSerde
        {
            public static TopicPartitions ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicPartitions message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static TopicPartitions ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, TopicPartitions message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static TopicPartitions ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, TopicPartitions message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}