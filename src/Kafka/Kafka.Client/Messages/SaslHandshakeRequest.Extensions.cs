using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class SaslHandshakeRequestSerde
   {
       private static readonly DecodeDelegate<SaslHandshakeRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<SaslHandshakeRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, SaslHandshakeRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, SaslHandshakeRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, SaslHandshakeRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var mechanismField) = Decoder.ReadString(buffer, index);
           return (index, new(
               mechanismField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, SaslHandshakeRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.MechanismField);
           return index;
       }
       private static (int Offset, SaslHandshakeRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var mechanismField) = Decoder.ReadString(buffer, index);
           return (index, new(
               mechanismField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, SaslHandshakeRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.MechanismField);
           return index;
       }
   }
}