using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ApiVersionsRequestSerde
    {
        private static readonly Func<Stream, ApiVersionsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, ApiVersionsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static ApiVersionsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ApiVersionsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ApiVersionsRequest ReadV00(Stream buffer)
        {
            var clientSoftwareNameField = "";
            var clientSoftwareVersionField = "";
            return new(
                clientSoftwareNameField,
                clientSoftwareVersionField
            );
        }
        private static void WriteV00(Stream buffer, ApiVersionsRequest message)
        {
        }
        private static ApiVersionsRequest ReadV01(Stream buffer)
        {
            var clientSoftwareNameField = "";
            var clientSoftwareVersionField = "";
            return new(
                clientSoftwareNameField,
                clientSoftwareVersionField
            );
        }
        private static void WriteV01(Stream buffer, ApiVersionsRequest message)
        {
        }
        private static ApiVersionsRequest ReadV02(Stream buffer)
        {
            var clientSoftwareNameField = "";
            var clientSoftwareVersionField = "";
            return new(
                clientSoftwareNameField,
                clientSoftwareVersionField
            );
        }
        private static void WriteV02(Stream buffer, ApiVersionsRequest message)
        {
        }
        private static ApiVersionsRequest ReadV03(Stream buffer)
        {
            var clientSoftwareNameField = Decoder.ReadCompactString(buffer);
            var clientSoftwareVersionField = Decoder.ReadCompactString(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                clientSoftwareNameField,
                clientSoftwareVersionField
            );
        }
        private static void WriteV03(Stream buffer, ApiVersionsRequest message)
        {
            Encoder.WriteCompactString(buffer, message.ClientSoftwareNameField);
            Encoder.WriteCompactString(buffer, message.ClientSoftwareVersionField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}