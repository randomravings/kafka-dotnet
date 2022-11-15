using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslAuthenticateResponseSerde
    {
        private static readonly Func<Stream, SaslAuthenticateResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, SaslAuthenticateResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static SaslAuthenticateResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, SaslAuthenticateResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static SaslAuthenticateResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadNullableString(buffer);
            var authBytesField = Decoder.ReadBytes(buffer);
            var sessionLifetimeMsField = default(long);
            return new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField
            );
        }
        private static void WriteV00(Stream buffer, SaslAuthenticateResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteBytes(buffer, message.AuthBytesField);
        }
        private static SaslAuthenticateResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadNullableString(buffer);
            var authBytesField = Decoder.ReadBytes(buffer);
            var sessionLifetimeMsField = Decoder.ReadInt64(buffer);
            return new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField
            );
        }
        private static void WriteV01(Stream buffer, SaslAuthenticateResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteBytes(buffer, message.AuthBytesField);
            Encoder.WriteInt64(buffer, message.SessionLifetimeMsField);
        }
        private static SaslAuthenticateResponse ReadV02(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var authBytesField = Decoder.ReadCompactBytes(buffer);
            var sessionLifetimeMsField = Decoder.ReadInt64(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField
            );
        }
        private static void WriteV02(Stream buffer, SaslAuthenticateResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteCompactBytes(buffer, message.AuthBytesField);
            Encoder.WriteInt64(buffer, message.SessionLifetimeMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}