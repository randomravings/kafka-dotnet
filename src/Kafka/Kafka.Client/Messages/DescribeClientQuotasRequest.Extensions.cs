using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClientQuotasRequestExtensions
    {
        public static void Write(this DescribeClientQuotasRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.ComponentsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.EntityTypeField);
                Encoder.WriteInt8(buffer, i.MatchTypeField);
                Encoder.WriteString(buffer, i.MatchField);
                return 0;
            });
            Encoder.WriteBoolean(buffer, message.StrictField);
        }
    }
}
