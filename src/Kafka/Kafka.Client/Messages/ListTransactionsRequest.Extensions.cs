using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListTransactionsRequestSerde
    {
        private static readonly Func<Stream, ListTransactionsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, ListTransactionsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static ListTransactionsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ListTransactionsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ListTransactionsRequest ReadV00(Stream buffer)
        {
            var stateFiltersField = Decoder.ReadCompactArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'StateFilters'");
            var producerIdFiltersField = Decoder.ReadCompactArray<long>(buffer, b => Decoder.ReadInt64(b)) ?? throw new NullReferenceException("Null not allowed for 'ProducerIdFilters'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                stateFiltersField,
                producerIdFiltersField
            );
        }
        private static void WriteV00(Stream buffer, ListTransactionsRequest message)
        {
            Encoder.WriteCompactArray<string>(buffer, message.StateFiltersField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteCompactArray<long>(buffer, message.ProducerIdFiltersField, (b, i) => Encoder.WriteInt64(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}