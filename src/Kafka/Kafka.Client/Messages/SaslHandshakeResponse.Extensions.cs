using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SaslHandshakeResponseExtensions
    {
        public static void Write(this SaslHandshakeResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.MechanismsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i);
                return 0;
            });
        }
    }
}
