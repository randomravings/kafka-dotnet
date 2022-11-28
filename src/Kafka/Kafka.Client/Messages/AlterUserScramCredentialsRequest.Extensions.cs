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
        private static readonly DecodeDelegate<AlterUserScramCredentialsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<AlterUserScramCredentialsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static AlterUserScramCredentialsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AlterUserScramCredentialsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AlterUserScramCredentialsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var deletionsField = Decoder.ReadCompactArray<ScramCredentialDeletion>(ref buffer, (ref ReadOnlyMemory<byte> b) => ScramCredentialDeletionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Deletions'");
            var upsertionsField = Decoder.ReadCompactArray<ScramCredentialUpsertion>(ref buffer, (ref ReadOnlyMemory<byte> b) => ScramCredentialUpsertionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Upsertions'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                deletionsField,
                upsertionsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AlterUserScramCredentialsRequest message)
        {
            buffer = Encoder.WriteCompactArray<ScramCredentialDeletion>(buffer, message.DeletionsField, (b, i) => ScramCredentialDeletionSerde.WriteV00(b, i));
            buffer = Encoder.WriteCompactArray<ScramCredentialUpsertion>(buffer, message.UpsertionsField, (b, i) => ScramCredentialUpsertionSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ScramCredentialDeletionSerde
        {
            public static ScramCredentialDeletion ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var mechanismField = Decoder.ReadInt8(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    mechanismField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ScramCredentialDeletion message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt8(buffer, message.MechanismField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class ScramCredentialUpsertionSerde
        {
            public static ScramCredentialUpsertion ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var mechanismField = Decoder.ReadInt8(ref buffer);
                var iterationsField = Decoder.ReadInt32(ref buffer);
                var saltField = Decoder.ReadCompactBytes(ref buffer);
                var saltedPasswordField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    mechanismField,
                    iterationsField,
                    saltField,
                    saltedPasswordField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ScramCredentialUpsertion message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt8(buffer, message.MechanismField);
                buffer = Encoder.WriteInt32(buffer, message.IterationsField);
                buffer = Encoder.WriteCompactBytes(buffer, message.SaltField);
                buffer = Encoder.WriteCompactBytes(buffer, message.SaltedPasswordField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}