using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ProduceRequestExtensions
    {
        public static void Write(this ProduceRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt16(buffer, message.AcksField);
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray(buffer, message.TopicDataField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionDataField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.IndexField);
                    Encoder.WriteRecords(buffer, i.RecordsField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
