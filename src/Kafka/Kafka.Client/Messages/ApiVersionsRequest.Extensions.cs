using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ApiVersionsRequestSerde
    {
        private static readonly DecodeDelegate<ApiVersionsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<ApiVersionsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static ApiVersionsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ApiVersionsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ApiVersionsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var clientSoftwareNameField = "";
            var clientSoftwareVersionField = "";
            return new(
                clientSoftwareNameField,
                clientSoftwareVersionField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ApiVersionsRequest message)
        {
            return buffer;
        }
        private static ApiVersionsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var clientSoftwareNameField = "";
            var clientSoftwareVersionField = "";
            return new(
                clientSoftwareNameField,
                clientSoftwareVersionField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ApiVersionsRequest message)
        {
            return buffer;
        }
        private static ApiVersionsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var clientSoftwareNameField = "";
            var clientSoftwareVersionField = "";
            return new(
                clientSoftwareNameField,
                clientSoftwareVersionField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ApiVersionsRequest message)
        {
            return buffer;
        }
        private static ApiVersionsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var clientSoftwareNameField = Decoder.ReadCompactString(ref buffer);
            var clientSoftwareVersionField = Decoder.ReadCompactString(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                clientSoftwareNameField,
                clientSoftwareVersionField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, ApiVersionsRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.ClientSoftwareNameField);
            buffer = Encoder.WriteCompactString(buffer, message.ClientSoftwareVersionField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}