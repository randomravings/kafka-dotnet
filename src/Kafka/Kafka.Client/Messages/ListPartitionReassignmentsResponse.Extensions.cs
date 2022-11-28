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
        private static readonly DecodeDelegate<ListPartitionReassignmentsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<ListPartitionReassignmentsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static ListPartitionReassignmentsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ListPartitionReassignmentsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ListPartitionReassignmentsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var topicsField = Decoder.ReadCompactArray<OngoingTopicReassignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => OngoingTopicReassignmentSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ListPartitionReassignmentsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteCompactArray<OngoingTopicReassignment>(buffer, message.TopicsField, (b, i) => OngoingTopicReassignmentSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class OngoingTopicReassignmentSerde
        {
            public static OngoingTopicReassignment ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<OngoingPartitionReassignment>(ref buffer, (ref ReadOnlyMemory<byte> b) => OngoingPartitionReassignmentSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, OngoingTopicReassignment message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<OngoingPartitionReassignment>(buffer, message.PartitionsField, (b, i) => OngoingPartitionReassignmentSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class OngoingPartitionReassignmentSerde
            {
                public static OngoingPartitionReassignment ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var replicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Replicas'");
                    var addingReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
                    var removingReplicasField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        replicasField,
                        addingReplicasField,
                        removingReplicasField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, OngoingPartitionReassignment message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.ReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.AddingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteCompactArray<int>(buffer, message.RemovingReplicasField, (b, i) => Encoder.WriteInt32(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}