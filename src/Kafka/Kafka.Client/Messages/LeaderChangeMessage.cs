using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record LeaderChangeMessage (
        short VersionField,
        int LeaderIdField,
        LeaderChangeMessage.Voter[] VotersField,
        LeaderChangeMessage.Voter[] GrantingVotersField
    )
    {
        public sealed record Voter (
            int VoterIdField
        );
    };
}
