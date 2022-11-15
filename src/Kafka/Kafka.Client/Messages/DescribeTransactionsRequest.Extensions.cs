using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeTransactionsRequestSerde
    {
        private static readonly Func<Stream, DescribeTransactionsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, DescribeTransactionsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeTransactionsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeTransactionsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeTransactionsRequest ReadV00(Stream buffer)
        {
            var transactionalIdsField = Decoder.ReadCompactArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'TransactionalIds'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                transactionalIdsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeTransactionsRequest message)
        {
            Encoder.WriteCompactArray<string>(buffer, message.TransactionalIdsField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}