using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterClientQuotasResponseExtensions
    {
        public static void Write(this AlterClientQuotasResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.EntriesField, (b, i) =>
            {
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.ErrorMessageField);
                Encoder.WriteArray(buffer, i.EntityField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.EntityTypeField);
                    Encoder.WriteString(buffer, i.EntityNameField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
