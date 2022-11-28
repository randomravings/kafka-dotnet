using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeTransactionsRequestSerde
    {
        private static readonly DecodeDelegate<DescribeTransactionsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<DescribeTransactionsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static DescribeTransactionsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeTransactionsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeTransactionsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdsField = Decoder.ReadCompactArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'TransactionalIds'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                transactionalIdsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeTransactionsRequest message)
        {
            buffer = Encoder.WriteCompactArray<string>(buffer, message.TransactionalIdsField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}