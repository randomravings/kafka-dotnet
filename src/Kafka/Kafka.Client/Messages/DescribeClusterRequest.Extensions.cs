using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClusterRequestSerde
    {
        private static readonly Func<Stream, DescribeClusterRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, DescribeClusterRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeClusterRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeClusterRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeClusterRequest ReadV00(Stream buffer)
        {
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                includeClusterAuthorizedOperationsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeClusterRequest message)
        {
            Encoder.WriteBoolean(buffer, message.IncludeClusterAuthorizedOperationsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}