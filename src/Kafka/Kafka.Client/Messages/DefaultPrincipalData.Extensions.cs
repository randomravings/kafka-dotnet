using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DefaultPrincipalDataExtensions
    {
        public static void Write(this DefaultPrincipalData message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.TypeField);
            Encoder.WriteString(buffer, message.NameField);
            Encoder.WriteBoolean(buffer, message.TokenAuthenticatedField);
        }
    }
}
