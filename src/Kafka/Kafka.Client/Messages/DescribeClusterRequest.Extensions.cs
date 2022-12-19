using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClusterRequestSerde
    {
        private static readonly DecodeDelegate<DescribeClusterRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<DescribeClusterRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static DescribeClusterRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeClusterRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeClusterRequest ReadV00(byte[] buffer, ref int index)
        {
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                includeClusterAuthorizedOperationsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeClusterRequest message)
        {
            index = Encoder.WriteBoolean(buffer, index, message.IncludeClusterAuthorizedOperationsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}