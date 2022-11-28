using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AclCreationResult = Kafka.Client.Messages.CreateAclsResponse.AclCreationResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateAclsResponseSerde
    {
        private static readonly DecodeDelegate<CreateAclsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<CreateAclsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreateAclsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, CreateAclsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static CreateAclsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<AclCreationResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclCreationResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, CreateAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<AclCreationResult>(buffer, message.ResultsField, (b, i) => AclCreationResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static CreateAclsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<AclCreationResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclCreationResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, CreateAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<AclCreationResult>(buffer, message.ResultsField, (b, i) => AclCreationResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static CreateAclsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadCompactArray<AclCreationResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclCreationResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, CreateAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<AclCreationResult>(buffer, message.ResultsField, (b, i) => AclCreationResultSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static CreateAclsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadCompactArray<AclCreationResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclCreationResultSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, CreateAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<AclCreationResult>(buffer, message.ResultsField, (b, i) => AclCreationResultSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class AclCreationResultSerde
        {
            public static AclCreationResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
                return new(
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, AclCreationResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                return buffer;
            }
            public static AclCreationResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
                return new(
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, AclCreationResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                return buffer;
            }
            public static AclCreationResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, AclCreationResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static AclCreationResult ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    errorMessageField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, AclCreationResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}