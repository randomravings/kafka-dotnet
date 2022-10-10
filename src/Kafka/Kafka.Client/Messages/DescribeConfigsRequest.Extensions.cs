using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeConfigsRequestExtensions
    {
        public static void Write(this DescribeConfigsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.ResourcesField, (b, i) =>
            {
                Encoder.WriteInt8(buffer, i.ResourceTypeField);
                Encoder.WriteString(buffer, i.ResourceNameField);
                Encoder.WriteArray(buffer, i.ConfigurationKeysField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteBoolean(buffer, message.IncludeSynonymsField);
            Encoder.WriteBoolean(buffer, message.IncludeDocumentationField);
        }
    }
}
