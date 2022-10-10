using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class IncrementalAlterConfigsRequestExtensions
    {
        public static void Write(this IncrementalAlterConfigsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.ResourcesField, (b, i) =>
            {
                Encoder.WriteInt8(buffer, i.ResourceTypeField);
                Encoder.WriteString(buffer, i.ResourceNameField);
                Encoder.WriteArray(buffer, i.ConfigsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteInt8(buffer, i.ConfigOperationField);
                    Encoder.WriteString(buffer, i.ValueField);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
        }
    }
}
