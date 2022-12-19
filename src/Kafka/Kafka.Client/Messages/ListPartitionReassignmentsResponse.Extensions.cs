using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OngoingPartitionReassignment = Kafka.Client.Messages.ListPartitionReassignmentsResponse.OngoingTopicReassignment.OngoingPartitionReassignment;
using OngoingTopicReassignment = Kafka.Client.Messages.ListPartitionReassignmentsResponse.OngoingTopicReassignment;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListPartitionReassignmentsResponseSerde
    {
        private static readonly DecodeDelegate<ListPartitionReassignmentsResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<ListPartitionReassignmentsResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static ListPartitionReassignmentsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ListPartitionReassignmentsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ListPartitionReassignmentsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<OngoingTopicReassignment>(buffer, ref index, OngoingTopicReassignmentSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ListPartitionReassignmentsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteCompactArray<OngoingTopicReassignment>(buffer, index, message.TopicsField, OngoingTopicReassignmentSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class OngoingTopicReassignmentSerde
        {
            public static OngoingTopicReassignment ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<OngoingPartitionReassignment>(buffer, ref index, OngoingPartitionReassignmentSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, OngoingTopicReassignment message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<OngoingPartitionReassignment>(buffer, index, message.PartitionsField, OngoingPartitionReassignmentSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class OngoingPartitionReassignmentSerde
            {
                public static OngoingPartitionReassignment ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var replicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                    var addingReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                    var removingReplicasField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        replicasField,
                        addingReplicasField,
                        removingReplicasField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, OngoingPartitionReassignment message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
                    index = Encoder.WriteCompactArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}