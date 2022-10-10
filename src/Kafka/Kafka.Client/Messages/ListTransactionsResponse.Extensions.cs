using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListTransactionsResponseExtensions
    {
        public static void Write(this ListTransactionsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.UnknownStateFiltersField, (b, i) =>
            {
                Encoder.WriteString(buffer, i);
                return 0;
            });
            Encoder.WriteArray(buffer, message.TransactionStatesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TransactionalIdField);
                Encoder.WriteInt64(buffer, i.ProducerIdField);
                Encoder.WriteString(buffer, i.TransactionStateField);
                return 0;
            });
        }
    }
}
