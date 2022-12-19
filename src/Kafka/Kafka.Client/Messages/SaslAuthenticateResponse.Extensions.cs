using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslAuthenticateResponseSerde
    {
        private static readonly DecodeDelegate<SaslAuthenticateResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<SaslAuthenticateResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static SaslAuthenticateResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, SaslAuthenticateResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static SaslAuthenticateResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
            var authBytesField = Decoder.ReadBytes(buffer, ref index);
            var sessionLifetimeMsField = default(long);
            return new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, SaslAuthenticateResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteBytes(buffer, index, message.AuthBytesField);
            return index;
        }
        private static SaslAuthenticateResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
            var authBytesField = Decoder.ReadBytes(buffer, ref index);
            var sessionLifetimeMsField = Decoder.ReadInt64(buffer, ref index);
            return new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, SaslAuthenticateResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteBytes(buffer, index, message.AuthBytesField);
            index = Encoder.WriteInt64(buffer, index, message.SessionLifetimeMsField);
            return index;
        }
        private static SaslAuthenticateResponse ReadV02(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var authBytesField = Decoder.ReadCompactBytes(buffer, ref index);
            var sessionLifetimeMsField = Decoder.ReadInt64(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                errorMessageField,
                authBytesField,
                sessionLifetimeMsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, SaslAuthenticateResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteCompactBytes(buffer, index, message.AuthBytesField);
            index = Encoder.WriteInt64(buffer, index, message.SessionLifetimeMsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}