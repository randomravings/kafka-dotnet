using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterConfigsRequestExtensions
    {
        public static void Write(this AlterConfigsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.ResourcesField, (b, i) =>
            {
                Encoder.WriteInt8(buffer, i.ResourceTypeField);
                Encoder.WriteString(buffer, i.ResourceNameField);
                Encoder.WriteArray(buffer, i.ConfigsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteString(buffer, i.ValueField);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
        }
    }
}
