using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ScramCredentialUpsertion = Kafka.Client.Messages.AlterUserScramCredentialsRequest.ScramCredentialUpsertion;
using ScramCredentialDeletion = Kafka.Client.Messages.AlterUserScramCredentialsRequest.ScramCredentialDeletion;

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
        public static AlterUserScramCredentialsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterUserScramCredentialsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterUserScramCredentialsRequest ReadV00(byte[] buffer, ref int index)
        {
            var deletionsField = Decoder.ReadCompactArray<ScramCredentialDeletion>(buffer, ref index, ScramCredentialDeletionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Deletions'");
            var upsertionsField = Decoder.ReadCompactArray<ScramCredentialUpsertion>(buffer, ref index, ScramCredentialUpsertionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Upsertions'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                deletionsField,
                upsertionsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterUserScramCredentialsRequest message)
        {
            index = Encoder.WriteCompactArray<ScramCredentialDeletion>(buffer, index, message.DeletionsField, ScramCredentialDeletionSerde.WriteV00);
            index = Encoder.WriteCompactArray<ScramCredentialUpsertion>(buffer, index, message.UpsertionsField, ScramCredentialUpsertionSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class ScramCredentialUpsertionSerde
        {
            public static ScramCredentialUpsertion ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var mechanismField = Decoder.ReadInt8(buffer, ref index);
                var iterationsField = Decoder.ReadInt32(buffer, ref index);
                var saltField = Decoder.ReadCompactBytes(buffer, ref index);
                var saltedPasswordField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    mechanismField,
                    iterationsField,
                    saltField,
                    saltedPasswordField
                );
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
        private static class ScramCredentialDeletionSerde
        {
            public static ScramCredentialDeletion ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var mechanismField = Decoder.ReadInt8(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    mechanismField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ScramCredentialDeletion message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt8(buffer, index, message.MechanismField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}