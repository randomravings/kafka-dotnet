using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicPartitions = Kafka.Client.Messages.ElectLeadersRequest.TopicPartitions;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ElectLeadersRequestSerde
    {
        private static readonly DecodeDelegate<ElectLeadersRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<ElectLeadersRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static ElectLeadersRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ElectLeadersRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ElectLeadersRequest ReadV00(byte[] buffer, ref int index)
        {
            var electionTypeField = default(sbyte);
            var topicPartitionsField = Decoder.ReadArray<TopicPartitions>(buffer, ref index, TopicPartitionsSerde.ReadV00);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                electionTypeField,
                topicPartitionsField,
                timeoutMsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ElectLeadersRequest message)
        {
            index = Encoder.WriteArray<TopicPartitions>(buffer, index, message.TopicPartitionsField, TopicPartitionsSerde.WriteV00);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static ElectLeadersRequest ReadV01(byte[] buffer, ref int index)
        {
            var electionTypeField = Decoder.ReadInt8(buffer, ref index);
            var topicPartitionsField = Decoder.ReadArray<TopicPartitions>(buffer, ref index, TopicPartitionsSerde.ReadV01);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            return new(
                electionTypeField,
                topicPartitionsField,
                timeoutMsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ElectLeadersRequest message)
        {
            index = Encoder.WriteInt8(buffer, index, message.ElectionTypeField);
            index = Encoder.WriteArray<TopicPartitions>(buffer, index, message.TopicPartitionsField, TopicPartitionsSerde.WriteV01);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static ElectLeadersRequest ReadV02(byte[] buffer, ref int index)
        {
            var electionTypeField = Decoder.ReadInt8(buffer, ref index);
            var topicPartitionsField = Decoder.ReadCompactArray<TopicPartitions>(buffer, ref index, TopicPartitionsSerde.ReadV02);
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                electionTypeField,
                topicPartitionsField,
                timeoutMsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ElectLeadersRequest message)
        {
            index = Encoder.WriteInt8(buffer, index, message.ElectionTypeField);
            index = Encoder.WriteCompactArray<TopicPartitions>(buffer, index, message.TopicPartitionsField, TopicPartitionsSerde.WriteV02);
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TopicPartitionsSerde
        {
            public static TopicPartitions ReadV00(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicPartitions message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static TopicPartitions ReadV01(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, TopicPartitions message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static TopicPartitions ReadV02(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicField,
                    partitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, TopicPartitions message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}