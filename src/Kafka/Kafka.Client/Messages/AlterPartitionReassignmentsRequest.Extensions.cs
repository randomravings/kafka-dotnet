using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ReassignablePartition = Kafka.Client.Messages.AlterPartitionReassignmentsRequest.ReassignableTopic.ReassignablePartition;
using ReassignableTopic = Kafka.Client.Messages.AlterPartitionReassignmentsRequest.ReassignableTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterPartitionReassignmentsRequestSerde
    {
        private static readonly DecodeDelegate<AlterPartitionReassignmentsRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<AlterPartitionReassignmentsRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static AlterPartitionReassignmentsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterPartitionReassignmentsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterPartitionReassignmentsRequest ReadV00(byte[] buffer, ref int index)
        {
            var timeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<ReassignableTopic>(buffer, ref index, ReassignableTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                timeoutMsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterPartitionReassignmentsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = Encoder.WriteCompactArray<ReassignableTopic>(buffer, index, message.TopicsField, ReassignableTopicSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class ReassignableTopicSerde
        {
            public static ReassignableTopic ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<ReassignablePartition>(buffer, ref index, ReassignablePartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ReassignableTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<ReassignablePartition>(buffer, index, message.PartitionsField, ReassignablePartitionSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class ReassignablePartitionSerde
            {
                public static ReassignablePartition ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ReplicasField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, ReassignablePartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}