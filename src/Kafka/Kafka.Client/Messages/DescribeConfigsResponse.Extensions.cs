using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeConfigsResponseExtensions
    {
        public static void Write(this DescribeConfigsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.ResultsField, (b, i) =>
            {
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.ErrorMessageField);
                Encoder.WriteInt8(buffer, i.ResourceTypeField);
                Encoder.WriteString(buffer, i.ResourceNameField);
                Encoder.WriteArray(buffer, i.ConfigsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteString(buffer, i.ValueField);
                    Encoder.WriteBoolean(buffer, i.ReadOnlyField);
                    Encoder.WriteBoolean(buffer, i.IsDefaultField);
                    Encoder.WriteInt8(buffer, i.ConfigSourceField);
                    Encoder.WriteBoolean(buffer, i.IsSensitiveField);
                    Encoder.WriteArray(buffer, i.SynonymsField, (b, i) =>
                    {
                        Encoder.WriteString(buffer, i.NameField);
                        Encoder.WriteString(buffer, i.ValueField);
                        Encoder.WriteInt8(buffer, i.SourceField);
                        return 0;
                    });
                    Encoder.WriteInt8(buffer, i.ConfigTypeField);
                    Encoder.WriteString(buffer, i.DocumentationField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
