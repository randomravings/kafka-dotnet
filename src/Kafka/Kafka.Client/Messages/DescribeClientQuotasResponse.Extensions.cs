using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClientQuotasResponseExtensions
    {
        public static void Write(this DescribeClientQuotasResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.ErrorMessageField);
            Encoder.WriteArray(buffer, message.EntriesField, (b, i) =>
            {
                Encoder.WriteArray(buffer, i.EntityField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.EntityTypeField);
                    Encoder.WriteString(buffer, i.EntityNameField);
                    return 0;
                });
                Encoder.WriteArray(buffer, i.ValuesField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.KeyField);
                    Encoder.WriteFloat64(buffer, i.ValueField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
