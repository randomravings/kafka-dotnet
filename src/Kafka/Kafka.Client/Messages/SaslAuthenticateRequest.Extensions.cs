using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslAuthenticateRequestExtensions
    {
        public static void Write(this SaslAuthenticateRequest message, MemoryStream buffer)
        {
            Encoder.WriteBytes(buffer, message.AuthBytesField);
        }
    }
}
