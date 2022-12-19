using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ReassignablePartitionResponse = Kafka.Client.Messages.AlterPartitionReassignmentsResponse.ReassignableTopicResponse.ReassignablePartitionResponse;
using ReassignableTopicResponse = Kafka.Client.Messages.AlterPartitionReassignmentsResponse.ReassignableTopicResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterPartitionReassignmentsResponseSerde
    {
        private static readonly DecodeDelegate<AlterPartitionReassignmentsResponse>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<AlterPartitionReassignmentsResponse>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static AlterPartitionReassignmentsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterPartitionReassignmentsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterPartitionReassignmentsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var responsesField = Decoder.ReadCompactArray<ReassignableTopicResponse>(buffer, ref index, ReassignableTopicResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                responsesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterPartitionReassignmentsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteCompactArray<ReassignableTopicResponse>(buffer, index, message.ResponsesField, ReassignableTopicResponseSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class ReassignableTopicResponseSerde
        {
            public static ReassignableTopicResponse ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<ReassignablePartitionResponse>(buffer, ref index, ReassignablePartitionResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ReassignableTopicResponse message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<ReassignablePartitionResponse>(buffer, index, message.PartitionsField, ReassignablePartitionResponseSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class ReassignablePartitionResponseSerde
            {
                public static ReassignablePartitionResponse ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, ReassignablePartitionResponse message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}