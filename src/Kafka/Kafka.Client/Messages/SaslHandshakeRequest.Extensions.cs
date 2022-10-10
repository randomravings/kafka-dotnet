using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslHandshakeRequestExtensions
    {
        public static void Write(this SaslHandshakeRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.MechanismField);
        }
    }
}
