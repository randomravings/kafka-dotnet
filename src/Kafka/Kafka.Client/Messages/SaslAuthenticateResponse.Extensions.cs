using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslAuthenticateResponseSerde
    {
        private static readonly DecodeDelegate<SaslAuthenticateResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<SaslAuthenticateResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static SaslAuthenticateResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, SaslAuthenticateResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static SaslAuthenticateResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadNullableString(ref buffer);
            var authBytesField = Decoder.ReadBytes(ref buffer);
            var sessionLifetimeMsField = default(long);
            return new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, SaslAuthenticateResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteBytes(buffer, message.AuthBytesField);
            return buffer;
        }
        private static SaslAuthenticateResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadNullableString(ref buffer);
            var authBytesField = Decoder.ReadBytes(ref buffer);
            var sessionLifetimeMsField = Decoder.ReadInt64(ref buffer);
            return new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, SaslAuthenticateResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteBytes(buffer, message.AuthBytesField);
            buffer = Encoder.WriteInt64(buffer, message.SessionLifetimeMsField);
            return buffer;
        }
        private static SaslAuthenticateResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var authBytesField = Decoder.ReadCompactBytes(ref buffer);
            var sessionLifetimeMsField = Decoder.ReadInt64(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, SaslAuthenticateResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteCompactBytes(buffer, message.AuthBytesField);
            buffer = Encoder.WriteInt64(buffer, message.SessionLifetimeMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}