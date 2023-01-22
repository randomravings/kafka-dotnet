using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ScramCredentialDeletion = Kafka.Client.Messages.AlterUserScramCredentialsRequest.ScramCredentialDeletion;
using ScramCredentialUpsertion = Kafka.Client.Messages.AlterUserScramCredentialsRequest.ScramCredentialUpsertion;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterUserScramCredentialsRequestSerde
   {
       private static readonly DecodeDelegate<AlterUserScramCredentialsRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<AlterUserScramCredentialsRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, AlterUserScramCredentialsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterUserScramCredentialsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterUserScramCredentialsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var deletionsField) = Decoder.ReadCompactArray<ScramCredentialDeletion>(buffer, index, ScramCredentialDeletionSerde.ReadV00);
           if (deletionsField == null)
               throw new NullReferenceException("Null not allowed for 'Deletions'");
           (index, var upsertionsField) = Decoder.ReadCompactArray<ScramCredentialUpsertion>(buffer, index, ScramCredentialUpsertionSerde.ReadV00);
           if (upsertionsField == null)
               throw new NullReferenceException("Null not allowed for 'Upsertions'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               deletionsField.Value,
               upsertionsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterUserScramCredentialsRequest message)
       {
           index = Encoder.WriteCompactArray<ScramCredentialDeletion>(buffer, index, message.DeletionsField, ScramCredentialDeletionSerde.WriteV00);
           index = Encoder.WriteCompactArray<ScramCredentialUpsertion>(buffer, index, message.UpsertionsField, ScramCredentialUpsertionSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ScramCredentialDeletionSerde
       {
           public static (int Offset, ScramCredentialDeletion Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var mechanismField) = Decoder.ReadInt8(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   mechanismField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ScramCredentialDeletion message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt8(buffer, index, message.MechanismField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ScramCredentialUpsertionSerde
       {
           public static (int Offset, ScramCredentialUpsertion Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var mechanismField) = Decoder.ReadInt8(buffer, index);
               (index, var iterationsField) = Decoder.ReadInt32(buffer, index);
               (index, var saltField) = Decoder.ReadCompactBytes(buffer, index);
               (index, var saltedPasswordField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   mechanismField,
                   iterationsField,
                   saltField,
                   saltedPasswordField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ScramCredentialUpsertion message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt8(buffer, index, message.MechanismField);
               index = Encoder.WriteInt32(buffer, index, message.IterationsField);
               index = Encoder.WriteCompactBytes(buffer, index, message.SaltField);
               index = Encoder.WriteCompactBytes(buffer, index, message.SaltedPasswordField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}