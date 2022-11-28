using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ReassignableTopic = Kafka.Client.Messages.AlterPartitionReassignmentsRequest.ReassignableTopic;
using ReassignablePartition = Kafka.Client.Messages.AlterPartitionReassignmentsRequest.ReassignableTopic.ReassignablePartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterPartitionReassignmentsRequestSerde
    {
        private static readonly DecodeDelegate<AlterPartitionReassignmentsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<AlterPartitionReassignmentsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AlterPartitionReassignmentsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AlterPartitionReassignmentsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AlterPartitionReassignmentsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<ReassignableTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReassignableTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                timeoutMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AlterPartitionReassignmentsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteCompactArray<ReassignableTopic>(buffer, message.TopicsField, (b, i) => ReassignableTopicSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ReassignableTopicSerde
        {
            public static ReassignableTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<ReassignablePartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReassignablePartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ReassignableTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<ReassignablePartition>(buffer, message.PartitionsField, (b, i) => ReassignablePartitionSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class ReassignablePartitionSerde
            {
                public static ReassignablePartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var replicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b));
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        replicasField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, ReassignablePartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}