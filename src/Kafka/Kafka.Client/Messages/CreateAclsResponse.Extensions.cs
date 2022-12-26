using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AclCreationResult = Kafka.Client.Messages.CreateAclsResponse.AclCreationResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateAclsResponseSerde
    {
        private static readonly DecodeDelegate<CreateAclsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<CreateAclsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static CreateAclsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, CreateAclsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static CreateAclsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<AclCreationResult>(buffer, ref index, AclCreationResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, CreateAclsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<AclCreationResult>(buffer, index, message.ResultsField, AclCreationResultSerde.WriteV00);
            return index;
        }
        private static CreateAclsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<AclCreationResult>(buffer, ref index, AclCreationResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, CreateAclsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<AclCreationResult>(buffer, index, message.ResultsField, AclCreationResultSerde.WriteV01);
            return index;
        }
        private static CreateAclsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<AclCreationResult>(buffer, ref index, AclCreationResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, CreateAclsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<AclCreationResult>(buffer, index, message.ResultsField, AclCreationResultSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static CreateAclsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<AclCreationResult>(buffer, ref index, AclCreationResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, CreateAclsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<AclCreationResult>(buffer, index, message.ResultsField, AclCreationResultSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class AclCreationResultSerde
        {
            public static AclCreationResult ReadV00(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV00(byte[] buffer, int index, AclCreationResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                return index;
            }
            public static AclCreationResult ReadV01(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV01(byte[] buffer, int index, AclCreationResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                return index;
            }
            public static AclCreationResult ReadV02(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV02(byte[] buffer, int index, AclCreationResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static AclCreationResult ReadV03(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    ErrorMessageField
                );
            }
            public static int WriteV03(byte[] buffer, int index, AclCreationResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}