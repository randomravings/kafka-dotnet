using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ReassignablePartitionResponse = Kafka.Client.Messages.AlterPartitionReassignmentsResponse.ReassignableTopicResponse.ReassignablePartitionResponse;
using ReassignableTopicResponse = Kafka.Client.Messages.AlterPartitionReassignmentsResponse.ReassignableTopicResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterPartitionReassignmentsResponseSerde
    {
        private static readonly DecodeDelegate<AlterPartitionReassignmentsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<AlterPartitionReassignmentsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AlterPartitionReassignmentsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AlterPartitionReassignmentsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AlterPartitionReassignmentsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var responsesField = Decoder.ReadCompactArray<ReassignableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReassignableTopicResponseSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                responsesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AlterPartitionReassignmentsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteCompactArray<ReassignableTopicResponse>(buffer, message.ResponsesField, (b, i) => ReassignableTopicResponseSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ReassignableTopicResponseSerde
        {
            public static ReassignableTopicResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<ReassignablePartitionResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReassignablePartitionResponseSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ReassignableTopicResponse message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<ReassignablePartitionResponse>(buffer, message.PartitionsField, (b, i) => ReassignablePartitionResponseSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class ReassignablePartitionResponseSerde
            {
                public static ReassignablePartitionResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, ReassignablePartitionResponse message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}