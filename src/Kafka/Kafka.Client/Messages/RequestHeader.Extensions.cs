using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class RequestHeaderExtensions
    {
        public static void Write(this RequestHeader message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.RequestApiKeyField);
            Encoder.WriteInt16(buffer, message.RequestApiVersionField);
            Encoder.WriteInt32(buffer, message.CorrelationIdField);
            Encoder.WriteString(buffer, message.ClientIdField);
        }
    }
}
