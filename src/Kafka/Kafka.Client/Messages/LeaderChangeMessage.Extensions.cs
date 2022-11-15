using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Voter = Kafka.Client.Messages.LeaderChangeMessage.Voter;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaderChangeMessageSerde
    {
        private static readonly Func<Stream, LeaderChangeMessage>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, LeaderChangeMessage>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static LeaderChangeMessage Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, LeaderChangeMessage message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static LeaderChangeMessage ReadV00(Stream buffer)
        {
            var versionField = Decoder.ReadInt16(buffer);
            var leaderIdField = Decoder.ReadInt32(buffer);
            var votersField = Decoder.ReadCompactArray<Voter>(buffer, b => VoterSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Voters'");
            var grantingVotersField = Decoder.ReadCompactArray<Voter>(buffer, b => VoterSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'GrantingVoters'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                versionField,
                leaderIdField,
                votersField,
                grantingVotersField
            );
        }
        private static void WriteV00(Stream buffer, LeaderChangeMessage message)
        {
            Encoder.WriteInt16(buffer, message.VersionField);
            Encoder.WriteInt32(buffer, message.LeaderIdField);
            Encoder.WriteCompactArray<Voter>(buffer, message.VotersField, (b, i) => VoterSerde.WriteV00(b, i));
            Encoder.WriteCompactArray<Voter>(buffer, message.GrantingVotersField, (b, i) => VoterSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class VoterSerde
        {
            public static Voter ReadV00(Stream buffer)
            {
                var voterIdField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    voterIdField
                );
            }
            public static void WriteV00(Stream buffer, Voter message)
            {
                Encoder.WriteInt32(buffer, message.VoterIdField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}