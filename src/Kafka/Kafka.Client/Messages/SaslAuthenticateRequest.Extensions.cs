using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class SaslAuthenticateRequestSerde
   {
       private static readonly DecodeDelegate<SaslAuthenticateRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<SaslAuthenticateRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, SaslAuthenticateRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, SaslAuthenticateRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, SaslAuthenticateRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var authBytesField) = Decoder.ReadBytes(buffer, index);
           return (index, new(
               authBytesField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, SaslAuthenticateRequest message)
       {
           index = Encoder.WriteBytes(buffer, index, message.AuthBytesField);
           return index;
       }
       private static (int Offset, SaslAuthenticateRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var authBytesField) = Decoder.ReadBytes(buffer, index);
           return (index, new(
               authBytesField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, SaslAuthenticateRequest message)
       {
           index = Encoder.WriteBytes(buffer, index, message.AuthBytesField);
           return index;
       }
       private static (int Offset, SaslAuthenticateRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var authBytesField) = Decoder.ReadCompactBytes(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               authBytesField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, SaslAuthenticateRequest message)
       {
           index = Encoder.WriteCompactBytes(buffer, index, message.AuthBytesField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}