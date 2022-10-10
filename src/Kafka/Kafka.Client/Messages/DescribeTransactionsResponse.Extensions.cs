using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeTransactionsResponseExtensions
    {
        public static void Write(this DescribeTransactionsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.TransactionStatesField, (b, i) =>
            {
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.TransactionalIdField);
                Encoder.WriteString(buffer, i.TransactionStateField);
                Encoder.WriteInt32(buffer, i.TransactionTimeoutMsField);
                Encoder.WriteInt64(buffer, i.TransactionStartTimeMsField);
                Encoder.WriteInt64(buffer, i.ProducerIdField);
                Encoder.WriteInt16(buffer, i.ProducerEpochField);
                Encoder.WriteArray(buffer, i.TopicsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.TopicField);
                    Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    return 0;
                });
                return 0;
            });
        }
    }
}
