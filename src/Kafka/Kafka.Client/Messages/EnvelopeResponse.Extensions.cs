using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EnvelopeResponseExtensions
    {
        public static void Write(this EnvelopeResponse message, MemoryStream buffer)
        {
            Encoder.WriteBytes(buffer, message.ResponseDataField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
    }
}
