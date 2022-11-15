using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OngoingPartitionReassignment = Kafka.Client.Messages.ListPartitionReassignmentsResponse.OngoingTopicReassignment.OngoingPartitionReassignment;
using OngoingTopicReassignment = Kafka.Client.Messages.ListPartitionReassignmentsResponse.OngoingTopicReassignment;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListPartitionReassignmentsResponseSerde
    {
        private static readonly Func<Stream, ListPartitionReassignmentsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, ListPartitionReassignmentsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static ListPartitionReassignmentsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ListPartitionReassignmentsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ListPartitionReassignmentsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var topicsField = Decoder.ReadCompactArray<OngoingTopicReassignment>(buffer, b => OngoingTopicReassignmentSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, ListPartitionReassignmentsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteCompactArray<OngoingTopicReassignment>(buffer, message.TopicsField, (b, i) => OngoingTopicReassignmentSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class OngoingTopicReassignmentSerde
        {
            public static OngoingTopicReassignment ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<OngoingPartitionReassignment>(buffer, b => OngoingPartitionReassignmentSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, OngoingTopicReassignment message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<OngoingPartitionReassignment>(buffer, message.PartitionsField, (b, i) => OngoingPartitionReassignmentSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class OngoingPartitionReassignmentSerde
            {
                public static OngoingPartitionReassignment ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var replicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                    var addingReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                    var removingReplicasField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        replicasField,
                        addingReplicasField,
                        removingReplicasField
                    );
                }
                public static void WriteV00(Stream buffer, OngoingPartitionReassignment message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteCompactArray<int>(buffer, message.AddingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteCompactArray<int>(buffer, message.RemovingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}