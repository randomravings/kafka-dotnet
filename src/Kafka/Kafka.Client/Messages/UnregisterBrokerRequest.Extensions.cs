using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class UnregisterBrokerRequestSerde
   {
       private static readonly DecodeDelegate<UnregisterBrokerRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<UnregisterBrokerRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, UnregisterBrokerRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, UnregisterBrokerRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, UnregisterBrokerRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               brokerIdField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, UnregisterBrokerRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}