using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ListPartitionReassignmentsTopics = Kafka.Client.Messages.ListPartitionReassignmentsRequest.ListPartitionReassignmentsTopics;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListPartitionReassignmentsRequestSerde
    {
        private static readonly DecodeDelegate<ListPartitionReassignmentsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<ListPartitionReassignmentsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static ListPartitionReassignmentsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ListPartitionReassignmentsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ListPartitionReassignmentsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<ListPartitionReassignmentsTopics>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListPartitionReassignmentsTopicsSerde.ReadV00(ref b));
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                timeoutMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ListPartitionReassignmentsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteCompactArray<ListPartitionReassignmentsTopics>(buffer, message.TopicsField, (b, i) => ListPartitionReassignmentsTopicsSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ListPartitionReassignmentsTopicsSerde
        {
            public static ListPartitionReassignmentsTopics ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionIndexesField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionIndexesField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ListPartitionReassignmentsTopics message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionIndexesField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}