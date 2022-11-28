using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClusterRequestSerde
    {
        private static readonly DecodeDelegate<DescribeClusterRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<DescribeClusterRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeClusterRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeClusterRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeClusterRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                includeClusterAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeClusterRequest message)
        {
            buffer = Encoder.WriteBoolean(buffer, message.IncludeClusterAuthorizedOperationsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}