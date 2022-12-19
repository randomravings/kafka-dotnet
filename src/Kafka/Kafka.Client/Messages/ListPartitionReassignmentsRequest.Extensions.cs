using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ListPartitionReassignmentsTopics = Kafka.Client.Messages.ListPartitionReassignmentsRequest.ListPartitionReassignmentsTopics;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListPartitionReassignmentsRequestSerde
    {
        private static readonly DecodeDelegate<ListPartitionReassignmentsRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<ListPartitionReassignmentsRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static ListPartitionReassignmentsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ListPartitionReassignmentsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ListPartitionReassignmentsRequest ReadV00(byte[] buffer, ref int index)
        {
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<ListPartitionReassignmentsTopics>(buffer, ref index, ListPartitionReassignmentsTopicsSerde.ReadV00);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                timeoutMsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ListPartitionReassignmentsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteCompactArray<ListPartitionReassignmentsTopics>(buffer, index, message.TopicsField, ListPartitionReassignmentsTopicsSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class ListPartitionReassignmentsTopicsSerde
        {
            public static ListPartitionReassignmentsTopics ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ListPartitionReassignmentsTopics message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}