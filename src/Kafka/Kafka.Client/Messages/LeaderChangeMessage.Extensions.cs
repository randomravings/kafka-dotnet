using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaderChangeMessageExtensions
    {
        public static void Write(this LeaderChangeMessage message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.VersionField);
            Encoder.WriteInt32(buffer, message.LeaderIdField);
            Encoder.WriteArray(buffer, message.VotersField, (b, i) =>
            {
                Encoder.WriteInt32(buffer, i.VoterIdField);
                return 0;
            });
            Encoder.WriteArray(buffer, message.GrantingVotersField, (b, i) =>
            {
                Encoder.WriteInt32(buffer, i.VoterIdField);
                return 0;
            });
        }
    }
}
