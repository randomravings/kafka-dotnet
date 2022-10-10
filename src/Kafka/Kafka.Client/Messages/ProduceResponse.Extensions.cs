using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ProduceResponseExtensions
    {
        public static void Write(this ProduceResponse message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.ResponsesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionResponsesField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.IndexField);
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    Encoder.WriteInt64(buffer, i.BaseOffsetField);
                    Encoder.WriteInt64(buffer, i.LogAppendTimeMsField);
                    Encoder.WriteInt64(buffer, i.LogStartOffsetField);
                    Encoder.WriteArray(buffer, i.RecordErrorsField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i.BatchIndexField);
                        Encoder.WriteString(buffer, i.BatchIndexErrorMessageField);
                        return 0;
                    });
                    Encoder.WriteString(buffer, i.ErrorMessageField);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
    }
}
