using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class SaslHandshakeResponseSerde
   {
       private static readonly DecodeDelegate<SaslHandshakeResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<SaslHandshakeResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, SaslHandshakeResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, SaslHandshakeResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, SaslHandshakeResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var mechanismsField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (mechanismsField == null)
               throw new NullReferenceException("Null not allowed for 'Mechanisms'");
           return (index, new(
               errorCodeField,
               mechanismsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, SaslHandshakeResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<string>(buffer, index, message.MechanismsField, Encoder.WriteCompactString);
           return index;
       }
       private static (int Offset, SaslHandshakeResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var mechanismsField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (mechanismsField == null)
               throw new NullReferenceException("Null not allowed for 'Mechanisms'");
           return (index, new(
               errorCodeField,
               mechanismsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, SaslHandshakeResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<string>(buffer, index, message.MechanismsField, Encoder.WriteCompactString);
           return index;
       }
   }
}