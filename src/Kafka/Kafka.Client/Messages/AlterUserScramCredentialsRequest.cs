using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterUserScramCredentialsRequest (
        AlterUserScramCredentialsRequest.ScramCredentialDeletion[] DeletionsField,
        AlterUserScramCredentialsRequest.ScramCredentialUpsertion[] UpsertionsField
    )
    {
        public sealed record ScramCredentialUpsertion (
            string NameField,
            sbyte MechanismField,
            int IterationsField,
            byte[] SaltField,
            byte[] SaltedPasswordField
        );
        public sealed record ScramCredentialDeletion (
            string NameField,
            sbyte MechanismField
        );
    };
}
