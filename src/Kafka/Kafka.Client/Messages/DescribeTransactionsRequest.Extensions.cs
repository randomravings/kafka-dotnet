using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeTransactionsRequestSerde
   {
       private static readonly DecodeDelegate<DescribeTransactionsRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<DescribeTransactionsRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, DescribeTransactionsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeTransactionsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeTransactionsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var transactionalIdsField) = Decoder.ReadCompactArray<string>(buffer, index, Decoder.ReadCompactString);
           if (transactionalIdsField == null)
               throw new NullReferenceException("Null not allowed for 'TransactionalIds'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               transactionalIdsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeTransactionsRequest message)
       {
           index = Encoder.WriteCompactArray<string>(buffer, index, message.TransactionalIdsField, Encoder.WriteCompactString);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}