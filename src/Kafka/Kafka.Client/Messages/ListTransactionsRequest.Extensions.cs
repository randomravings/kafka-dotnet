using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListTransactionsRequestSerde
    {
        private static readonly DecodeDelegate<ListTransactionsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<ListTransactionsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static ListTransactionsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ListTransactionsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ListTransactionsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var stateFiltersField = Decoder.ReadCompactArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'StateFilters'");
            var producerIdFiltersField = Decoder.ReadCompactArray<long>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt64(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ProducerIdFilters'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                stateFiltersField,
                producerIdFiltersField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ListTransactionsRequest message)
        {
            buffer = Encoder.WriteCompactArray<string>(buffer, message.StateFiltersField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteCompactArray<long>(buffer, message.ProducerIdFiltersField, (b, i) => Encoder.WriteInt64(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}