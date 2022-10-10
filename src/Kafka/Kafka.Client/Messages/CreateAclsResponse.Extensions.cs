using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateAclsResponseExtensions
    {
        public static void Write(this CreateAclsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.ResultsField, (b, i) =>
            {
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.ErrorMessageField);
                return 0;
            });
        }
    }
}
