using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslAuthenticateRequestSerde
    {
        private static readonly DecodeDelegate<SaslAuthenticateRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<SaslAuthenticateRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static SaslAuthenticateRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, SaslAuthenticateRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static SaslAuthenticateRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var authBytesField = Decoder.ReadBytes(ref buffer);
            return new(
                authBytesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, SaslAuthenticateRequest message)
        {
            buffer = Encoder.WriteBytes(buffer, message.AuthBytesField);
            return buffer;
        }
        private static SaslAuthenticateRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var authBytesField = Decoder.ReadBytes(ref buffer);
            return new(
                authBytesField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, SaslAuthenticateRequest message)
        {
            buffer = Encoder.WriteBytes(buffer, message.AuthBytesField);
            return buffer;
        }
        private static SaslAuthenticateRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var authBytesField = Decoder.ReadCompactBytes(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                authBytesField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, SaslAuthenticateRequest message)
        {
            buffer = Encoder.WriteCompactBytes(buffer, message.AuthBytesField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}