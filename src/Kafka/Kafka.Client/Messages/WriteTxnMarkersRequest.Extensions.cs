using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class WriteTxnMarkersRequestExtensions
    {
        public static void Write(this WriteTxnMarkersRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.MarkersField, (b, i) =>
            {
                Encoder.WriteInt64(buffer, i.ProducerIdField);
                Encoder.WriteInt16(buffer, i.ProducerEpochField);
                Encoder.WriteBoolean(buffer, i.TransactionResultField);
                Encoder.WriteArray(buffer, i.TopicsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteArray(buffer, i.PartitionIndexesField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    return 0;
                });
                Encoder.WriteInt32(buffer, i.CoordinatorEpochField);
                return 0;
            });
        }
    }
}
