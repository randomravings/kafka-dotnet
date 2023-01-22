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
       public static (int Offset, ListTransactionsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ListTransactionsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ListTransactionsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var stateFiltersField) = Decoder.ReadCompactArray<string>(buffer, index, Decoder.ReadCompactString);
           if (stateFiltersField == null)
               throw new NullReferenceException("Null not allowed for 'StateFilters'");
           (index, var producerIdFiltersField) = Decoder.ReadCompactArray<long>(buffer, index, Decoder.ReadInt64);
           if (producerIdFiltersField == null)
               throw new NullReferenceException("Null not allowed for 'ProducerIdFilters'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               stateFiltersField.Value,
               producerIdFiltersField.Value
           ));
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