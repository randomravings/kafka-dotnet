using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ListPartitionReassignmentsTopics = Kafka.Client.Messages.ListPartitionReassignmentsRequest.ListPartitionReassignmentsTopics;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListPartitionReassignmentsRequestSerde
    {
        private static readonly Func<Stream, ListPartitionReassignmentsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, ListPartitionReassignmentsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static ListPartitionReassignmentsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ListPartitionReassignmentsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ListPartitionReassignmentsRequest ReadV00(Stream buffer)
        {
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<ListPartitionReassignmentsTopics>(buffer, b => ListPartitionReassignmentsTopicsSerde.ReadV00(b));
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                timeoutMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, ListPartitionReassignmentsRequest message)
        {
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteCompactArray<ListPartitionReassignmentsTopics>(buffer, message.TopicsField, (b, i) => ListPartitionReassignmentsTopicsSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ListPartitionReassignmentsTopicsSerde
        {
            public static ListPartitionReassignmentsTopics ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static void WriteV00(Stream buffer, ListPartitionReassignmentsTopics message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}