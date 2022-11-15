using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ReassignablePartition = Kafka.Client.Messages.AlterPartitionReassignmentsRequest.ReassignableTopic.ReassignablePartition;
using ReassignableTopic = Kafka.Client.Messages.AlterPartitionReassignmentsRequest.ReassignableTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterPartitionReassignmentsRequestSerde
    {
        private static readonly Func<Stream, AlterPartitionReassignmentsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, AlterPartitionReassignmentsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AlterPartitionReassignmentsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterPartitionReassignmentsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterPartitionReassignmentsRequest ReadV00(Stream buffer)
        {
            var timeoutMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<ReassignableTopic>(buffer, b => ReassignableTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                timeoutMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, AlterPartitionReassignmentsRequest message)
        {
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteCompactArray<ReassignableTopic>(buffer, message.TopicsField, (b, i) => ReassignableTopicSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ReassignableTopicSerde
        {
            public static ReassignableTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<ReassignablePartition>(buffer, b => ReassignablePartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, ReassignableTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<ReassignablePartition>(buffer, message.PartitionsField, (b, i) => ReassignablePartitionSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class ReassignablePartitionSerde
            {
                public static ReassignablePartition ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var replicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b));
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        replicasField
                    );
                }
                public static void WriteV00(Stream buffer, ReassignablePartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}