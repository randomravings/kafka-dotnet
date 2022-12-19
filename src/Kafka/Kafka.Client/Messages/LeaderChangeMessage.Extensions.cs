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
        public static LeaderChangeMessage Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, LeaderChangeMessage message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static LeaderChangeMessage ReadV00(byte[] buffer, ref int index)
        {
            var versionField = Decoder.ReadInt16(buffer, ref index);
            var leaderIdField = Decoder.ReadInt32(buffer, ref index);
            var votersField = Decoder.ReadCompactArray<Voter>(buffer, ref index, VoterSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Voters'");
            var grantingVotersField = Decoder.ReadCompactArray<Voter>(buffer, ref index, VoterSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'GrantingVoters'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                versionField,
                leaderIdField,
                votersField,
                grantingVotersField
            );
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
        private static class VoterSerde
        {
            public static Voter ReadV00(byte[] buffer, ref int index)
            {
                var voterIdField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    voterIdField
                );
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