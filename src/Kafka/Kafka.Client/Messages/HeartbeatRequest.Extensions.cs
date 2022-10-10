using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class HeartbeatRequestExtensions
    {
        public static void Write(this HeartbeatRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteString(buffer, message.GroupInstanceIdField);
        }
    }
}
