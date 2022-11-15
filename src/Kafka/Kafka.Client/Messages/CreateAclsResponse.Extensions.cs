using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AclCreationResult = Kafka.Client.Messages.CreateAclsResponse.AclCreationResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateAclsResponseSerde
    {
        private static readonly Func<Stream, CreateAclsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, CreateAclsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreateAclsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, CreateAclsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static CreateAclsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<AclCreationResult>(buffer, b => AclCreationResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV00(Stream buffer, CreateAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<AclCreationResult>(buffer, message.ResultsField, (b, i) => AclCreationResultSerde.WriteV00(b, i));
        }
        private static CreateAclsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<AclCreationResult>(buffer, b => AclCreationResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV01(Stream buffer, CreateAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<AclCreationResult>(buffer, message.ResultsField, (b, i) => AclCreationResultSerde.WriteV01(b, i));
        }
        private static CreateAclsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadCompactArray<AclCreationResult>(buffer, b => AclCreationResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV02(Stream buffer, CreateAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<AclCreationResult>(buffer, message.ResultsField, (b, i) => AclCreationResultSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static CreateAclsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadCompactArray<AclCreationResult>(buffer, b => AclCreationResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV03(Stream buffer, CreateAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<AclCreationResult>(buffer, message.ResultsField, (b, i) => AclCreationResultSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class AclCreationResultSerde
        {
            public static AclCreationResult ReadV00(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                return new(
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV00(Stream buffer, AclCreationResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            }
            public static AclCreationResult ReadV01(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                return new(
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV01(Stream buffer, AclCreationResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            }
            public static AclCreationResult ReadV02(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV02(Stream buffer, AclCreationResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static AclCreationResult ReadV03(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    errorMessageField
                );
            }
            public static void WriteV03(Stream buffer, AclCreationResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}