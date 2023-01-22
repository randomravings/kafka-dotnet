using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using CreatableRenewers = Kafka.Client.Messages.CreateDelegationTokenRequest.CreatableRenewers;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class CreateDelegationTokenRequestSerde
   {
       private static readonly DecodeDelegate<CreateDelegationTokenRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<CreateDelegationTokenRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, CreateDelegationTokenRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, CreateDelegationTokenRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, CreateDelegationTokenRequest Value) ReadV00(byte[] buffer, int index)
       {
           var ownerPrincipalTypeField = default(string?);
           var ownerPrincipalNameField = default(string?);
           (index, var renewersField) = Decoder.ReadArray<CreatableRenewers>(buffer, index, CreatableRenewersSerde.ReadV00);
           if (renewersField == null)
               throw new NullReferenceException("Null not allowed for 'Renewers'");
           (index, var maxLifetimeMsField) = Decoder.ReadInt64(buffer, index);
           return (index, new(
               ownerPrincipalTypeField,
               ownerPrincipalNameField,
               renewersField.Value,
               maxLifetimeMsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, CreateDelegationTokenRequest message)
       {
           index = Encoder.WriteArray<CreatableRenewers>(buffer, index, message.RenewersField, CreatableRenewersSerde.WriteV00);
           index = Encoder.WriteInt64(buffer, index, message.MaxLifetimeMsField);
           return index;
       }
       private static (int Offset, CreateDelegationTokenRequest Value) ReadV01(byte[] buffer, int index)
       {
           var ownerPrincipalTypeField = default(string?);
           var ownerPrincipalNameField = default(string?);
           (index, var renewersField) = Decoder.ReadArray<CreatableRenewers>(buffer, index, CreatableRenewersSerde.ReadV01);
           if (renewersField == null)
               throw new NullReferenceException("Null not allowed for 'Renewers'");
           (index, var maxLifetimeMsField) = Decoder.ReadInt64(buffer, index);
           return (index, new(
               ownerPrincipalTypeField,
               ownerPrincipalNameField,
               renewersField.Value,
               maxLifetimeMsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, CreateDelegationTokenRequest message)
       {
           index = Encoder.WriteArray<CreatableRenewers>(buffer, index, message.RenewersField, CreatableRenewersSerde.WriteV01);
           index = Encoder.WriteInt64(buffer, index, message.MaxLifetimeMsField);
           return index;
       }
       private static (int Offset, CreateDelegationTokenRequest Value) ReadV02(byte[] buffer, int index)
       {
           var ownerPrincipalTypeField = default(string?);
           var ownerPrincipalNameField = default(string?);
           (index, var renewersField) = Decoder.ReadCompactArray<CreatableRenewers>(buffer, index, CreatableRenewersSerde.ReadV02);
           if (renewersField == null)
               throw new NullReferenceException("Null not allowed for 'Renewers'");
           (index, var maxLifetimeMsField) = Decoder.ReadInt64(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               ownerPrincipalTypeField,
               ownerPrincipalNameField,
               renewersField.Value,
               maxLifetimeMsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, CreateDelegationTokenRequest message)
       {
           index = Encoder.WriteCompactArray<CreatableRenewers>(buffer, index, message.RenewersField, CreatableRenewersSerde.WriteV02);
           index = Encoder.WriteInt64(buffer, index, message.MaxLifetimeMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, CreateDelegationTokenRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var ownerPrincipalTypeField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var ownerPrincipalNameField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var renewersField) = Decoder.ReadCompactArray<CreatableRenewers>(buffer, index, CreatableRenewersSerde.ReadV03);
           if (renewersField == null)
               throw new NullReferenceException("Null not allowed for 'Renewers'");
           (index, var maxLifetimeMsField) = Decoder.ReadInt64(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               ownerPrincipalTypeField,
               ownerPrincipalNameField,
               renewersField.Value,
               maxLifetimeMsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, CreateDelegationTokenRequest message)
       {
           index = Encoder.WriteCompactNullableString(buffer, index, message.OwnerPrincipalTypeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.OwnerPrincipalNameField);
           index = Encoder.WriteCompactArray<CreatableRenewers>(buffer, index, message.RenewersField, CreatableRenewersSerde.WriteV03);
           index = Encoder.WriteInt64(buffer, index, message.MaxLifetimeMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class CreatableRenewersSerde
       {
           public static (int Offset, CreatableRenewers Value) ReadV00(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadString(buffer, index);
               (index, var principalNameField) = Decoder.ReadString(buffer, index);
               return (index, new(
                   principalTypeField,
                   principalNameField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, CreatableRenewers message)
           {
               index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
               return index;
           }
           public static (int Offset, CreatableRenewers Value) ReadV01(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadString(buffer, index);
               (index, var principalNameField) = Decoder.ReadString(buffer, index);
               return (index, new(
                   principalTypeField,
                   principalNameField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, CreatableRenewers message)
           {
               index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
               return index;
           }
           public static (int Offset, CreatableRenewers Value) ReadV02(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadCompactString(buffer, index);
               (index, var principalNameField) = Decoder.ReadCompactString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   principalTypeField,
                   principalNameField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, CreatableRenewers message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, CreatableRenewers Value) ReadV03(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadCompactString(buffer, index);
               (index, var principalNameField) = Decoder.ReadCompactString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   principalTypeField,
                   principalNameField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, CreatableRenewers message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}