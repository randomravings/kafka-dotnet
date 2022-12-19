using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListTransactionsRequestSerde
    {
        private static readonly DecodeDelegate<ListTransactionsRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<ListTransactionsRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static ListTransactionsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ListTransactionsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ListTransactionsRequest ReadV00(byte[] buffer, ref int index)
        {
            var stateFiltersField = Decoder.ReadCompactArray<string>(buffer, ref index, Decoder.ReadCompactString) ?? throw new NullReferenceException("Null not allowed for 'StateFilters'");
            var producerIdFiltersField = Decoder.ReadCompactArray<long>(buffer, ref index, Decoder.ReadInt64) ?? throw new NullReferenceException("Null not allowed for 'ProducerIdFilters'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                stateFiltersField,
                producerIdFiltersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ListTransactionsRequest message)
        {
            index = Encoder.WriteCompactArray<string>(buffer, index, message.StateFiltersField, Encoder.WriteCompactString);
            index = Encoder.WriteCompactArray<long>(buffer, index, message.ProducerIdFiltersField, Encoder.WriteInt64);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}