using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslAuthenticateResponseExtensions
    {
        public static void Write(this SaslAuthenticateResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.ErrorMessageField);
            Encoder.WriteBytes(buffer, message.AuthBytesField);
            Encoder.WriteInt64(buffer, message.SessionLifetimeMsField);
        }
    }
}
