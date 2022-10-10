using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterConfigsResponseExtensions
    {
        public static void Write(this AlterConfigsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.ResponsesField, (b, i) =>
            {
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.ErrorMessageField);
                Encoder.WriteInt8(buffer, i.ResourceTypeField);
                Encoder.WriteString(buffer, i.ResourceNameField);
                return 0;
            });
        }
    }
}
