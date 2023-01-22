using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribeDelegationTokenOwner = Kafka.Client.Messages.DescribeDelegationTokenRequest.DescribeDelegationTokenOwner;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeDelegationTokenRequestSerde
   {
       private static readonly DecodeDelegate<DescribeDelegationTokenRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<DescribeDelegationTokenRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, DescribeDelegationTokenRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeDelegationTokenRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeDelegationTokenRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var ownersField) = Decoder.ReadArray<DescribeDelegationTokenOwner>(buffer, index, DescribeDelegationTokenOwnerSerde.ReadV00);
           return (index, new(
               ownersField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeDelegationTokenRequest message)
       {
           index = Encoder.WriteArray<DescribeDelegationTokenOwner>(buffer, index, message.OwnersField, DescribeDelegationTokenOwnerSerde.WriteV00);
           return index;
       }
       private static (int Offset, DescribeDelegationTokenRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var ownersField) = Decoder.ReadArray<DescribeDelegationTokenOwner>(buffer, index, DescribeDelegationTokenOwnerSerde.ReadV01);
           return (index, new(
               ownersField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeDelegationTokenRequest message)
       {
           index = Encoder.WriteArray<DescribeDelegationTokenOwner>(buffer, index, message.OwnersField, DescribeDelegationTokenOwnerSerde.WriteV01);
           return index;
       }
       private static (int Offset, DescribeDelegationTokenRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var ownersField) = Decoder.ReadCompactArray<DescribeDelegationTokenOwner>(buffer, index, DescribeDelegationTokenOwnerSerde.ReadV02);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               ownersField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DescribeDelegationTokenRequest message)
       {
           index = Encoder.WriteCompactArray<DescribeDelegationTokenOwner>(buffer, index, message.OwnersField, DescribeDelegationTokenOwnerSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DescribeDelegationTokenRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var ownersField) = Decoder.ReadCompactArray<DescribeDelegationTokenOwner>(buffer, index, DescribeDelegationTokenOwnerSerde.ReadV03);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               ownersField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DescribeDelegationTokenRequest message)
       {
           index = Encoder.WriteCompactArray<DescribeDelegationTokenOwner>(buffer, index, message.OwnersField, DescribeDelegationTokenOwnerSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DescribeDelegationTokenOwnerSerde
       {
           public static (int Offset, DescribeDelegationTokenOwner Value) ReadV00(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadString(buffer, index);
               (index, var principalNameField) = Decoder.ReadString(buffer, index);
               return (index, new(
                   principalTypeField,
                   principalNameField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DescribeDelegationTokenOwner message)
           {
               index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
               return index;
           }
           public static (int Offset, DescribeDelegationTokenOwner Value) ReadV01(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadString(buffer, index);
               (index, var principalNameField) = Decoder.ReadString(buffer, index);
               return (index, new(
                   principalTypeField,
                   principalNameField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DescribeDelegationTokenOwner message)
           {
               index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
               return index;
           }
           public static (int Offset, DescribeDelegationTokenOwner Value) ReadV02(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadCompactString(buffer, index);
               (index, var principalNameField) = Decoder.ReadCompactString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   principalTypeField,
                   principalNameField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DescribeDelegationTokenOwner message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DescribeDelegationTokenOwner Value) ReadV03(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadCompactString(buffer, index);
               (index, var principalNameField) = Decoder.ReadCompactString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   principalTypeField,
                   principalNameField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, DescribeDelegationTokenOwner message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}