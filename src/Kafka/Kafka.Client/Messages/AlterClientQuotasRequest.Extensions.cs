using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterClientQuotasRequestExtensions
    {
        public static void Write(this AlterClientQuotasRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.EntriesField, (b, i) =>
            {
                Encoder.WriteArray(buffer, i.EntityField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.EntityTypeField);
                    Encoder.WriteString(buffer, i.EntityNameField);
                    return 0;
                });
                Encoder.WriteArray(buffer, i.OpsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.KeyField);
                    Encoder.WriteFloat64(buffer, i.ValueField);
                    Encoder.WriteBoolean(buffer, i.RemoveField);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
        }
    }
}
