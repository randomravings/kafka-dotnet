using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using Voter = Kafka.Client.Messages.LeaderChangeMessage.Voter;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class LeaderChangeMessageSerde
   {
       private static readonly DecodeDelegate<LeaderChangeMessage>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<LeaderChangeMessage>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, LeaderChangeMessage Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, LeaderChangeMessage message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, LeaderChangeMessage Value) ReadV00(byte[] buffer, int index)
       {
           (index, var versionField) = Decoder.ReadInt16(buffer, index);
           (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
           (index, var votersField) = Decoder.ReadCompactArray<Voter>(buffer, index, VoterSerde.ReadV00);
           if (votersField == null)
               throw new NullReferenceException("Null not allowed for 'Voters'");
           (index, var grantingVotersField) = Decoder.ReadCompactArray<Voter>(buffer, index, VoterSerde.ReadV00);
           if (grantingVotersField == null)
               throw new NullReferenceException("Null not allowed for 'GrantingVoters'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               versionField,
               leaderIdField,
               votersField.Value,
               grantingVotersField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, LeaderChangeMessage message)
       {
           index = Encoder.WriteInt16(buffer, index, message.VersionField);
           index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
           index = Encoder.WriteCompactArray<Voter>(buffer, index, message.VotersField, VoterSerde.WriteV00);
           index = Encoder.WriteCompactArray<Voter>(buffer, index, message.GrantingVotersField, VoterSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class VoterSerde
       {
           public static (int Offset, Voter Value) ReadV00(byte[] buffer, int index)
           {
               (index, var voterIdField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   voterIdField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, Voter message)
           {
               index = Encoder.WriteInt32(buffer, index, message.VoterIdField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}