using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ReassignableTopicResponse = Kafka.Client.Messages.AlterPartitionReassignmentsResponse.ReassignableTopicResponse;
using ReassignablePartitionResponse = Kafka.Client.Messages.AlterPartitionReassignmentsResponse.ReassignableTopicResponse.ReassignablePartitionResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterPartitionReassignmentsResponseSerde
    {
        private static readonly Func<Stream, AlterPartitionReassignmentsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, AlterPartitionReassignmentsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AlterPartitionReassignmentsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterPartitionReassignmentsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterPartitionReassignmentsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var responsesField = Decoder.ReadCompactArray<ReassignableTopicResponse>(buffer, b => ReassignableTopicResponseSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                responsesField
            );
        }
        private static void WriteV00(Stream buffer, AlterPartitionReassignmentsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteCompactArray<ReassignableTopicResponse>(buffer, message.ResponsesField, (b, i) => ReassignableTopicResponseSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ReassignableTopicResponseSerde
        {
            public static ReassignableTopicResponse ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<ReassignablePartitionResponse>(buffer, b => ReassignablePartitionResponseSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, ReassignableTopicResponse message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<ReassignablePartitionResponse>(buffer, message.PartitionsField, (b, i) => ReassignablePartitionResponseSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class ReassignablePartitionResponseSerde
            {
                public static ReassignablePartitionResponse ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static void WriteV00(Stream buffer, ReassignablePartitionResponse message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}