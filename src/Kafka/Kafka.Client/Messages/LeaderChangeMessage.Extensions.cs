using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Voter = Kafka.Client.Messages.LeaderChangeMessage.Voter;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaderChangeMessageSerde
    {
        private static readonly DecodeDelegate<LeaderChangeMessage>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<LeaderChangeMessage>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static LeaderChangeMessage Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, LeaderChangeMessage message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static LeaderChangeMessage ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var versionField = Decoder.ReadInt16(ref buffer);
            var leaderIdField = Decoder.ReadInt32(ref buffer);
            var votersField = Decoder.ReadCompactArray<Voter>(ref buffer, (ref ReadOnlyMemory<byte> b) => VoterSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Voters'");
            var grantingVotersField = Decoder.ReadCompactArray<Voter>(ref buffer, (ref ReadOnlyMemory<byte> b) => VoterSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'GrantingVoters'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                versionField,
                leaderIdField,
                votersField,
                grantingVotersField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, LeaderChangeMessage message)
        {
            buffer = Encoder.WriteInt16(buffer, message.VersionField);
            buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
            buffer = Encoder.WriteCompactArray<Voter>(buffer, message.VotersField, (b, i) => VoterSerde.WriteV00(b, i));
            buffer = Encoder.WriteCompactArray<Voter>(buffer, message.GrantingVotersField, (b, i) => VoterSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class VoterSerde
        {
            public static Voter ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var voterIdField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    voterIdField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, Voter message)
            {
                buffer = Encoder.WriteInt32(buffer, message.VoterIdField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}