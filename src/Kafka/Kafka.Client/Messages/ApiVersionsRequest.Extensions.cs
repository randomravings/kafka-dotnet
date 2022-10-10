using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ApiVersionsRequestExtensions
    {
        public static void Write(this ApiVersionsRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.ClientSoftwareNameField);
            Encoder.WriteString(buffer, message.ClientSoftwareVersionField);
        }
    }
}
