using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ScramCredentialDeletion = Kafka.Client.Messages.AlterUserScramCredentialsRequest.ScramCredentialDeletion;
using ScramCredentialUpsertion = Kafka.Client.Messages.AlterUserScramCredentialsRequest.ScramCredentialUpsertion;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterUserScramCredentialsRequestSerde
    {
        private static readonly Func<Stream, AlterUserScramCredentialsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, AlterUserScramCredentialsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AlterUserScramCredentialsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterUserScramCredentialsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterUserScramCredentialsRequest ReadV00(Stream buffer)
        {
            var deletionsField = Decoder.ReadCompactArray<ScramCredentialDeletion>(buffer, b => ScramCredentialDeletionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Deletions'");
            var upsertionsField = Decoder.ReadCompactArray<ScramCredentialUpsertion>(buffer, b => ScramCredentialUpsertionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Upsertions'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                deletionsField,
                upsertionsField
            );
        }
        private static void WriteV00(Stream buffer, AlterUserScramCredentialsRequest message)
        {
            Encoder.WriteCompactArray<ScramCredentialDeletion>(buffer, message.DeletionsField, (b, i) => ScramCredentialDeletionSerde.WriteV00(b, i));
            Encoder.WriteCompactArray<ScramCredentialUpsertion>(buffer, message.UpsertionsField, (b, i) => ScramCredentialUpsertionSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ScramCredentialDeletionSerde
        {
            public static ScramCredentialDeletion ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var mechanismField = Decoder.ReadInt8(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    mechanismField
                );
            }
            public static void WriteV00(Stream buffer, ScramCredentialDeletion message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt8(buffer, message.MechanismField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class ScramCredentialUpsertionSerde
        {
            public static ScramCredentialUpsertion ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var mechanismField = Decoder.ReadInt8(buffer);
                var iterationsField = Decoder.ReadInt32(buffer);
                var saltField = Decoder.ReadCompactBytes(buffer);
                var saltedPasswordField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    mechanismField,
                    iterationsField,
                    saltField,
                    saltedPasswordField
                );
            }
            public static void WriteV00(Stream buffer, ScramCredentialUpsertion message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt8(buffer, message.MechanismField);
                Encoder.WriteInt32(buffer, message.IterationsField);
                Encoder.WriteCompactBytes(buffer, message.SaltField);
                Encoder.WriteCompactBytes(buffer, message.SaltedPasswordField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}