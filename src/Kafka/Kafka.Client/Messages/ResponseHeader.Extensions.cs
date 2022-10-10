using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ResponseHeaderExtensions
    {
        public static void Write(this ResponseHeader message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.CorrelationIdField);
        }
    }
}
