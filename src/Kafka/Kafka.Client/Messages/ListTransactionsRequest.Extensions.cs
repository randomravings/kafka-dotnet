using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListTransactionsRequestExtensions
    {
        public static void Write(this ListTransactionsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.StateFiltersField, (b, i) =>
            {
                Encoder.WriteString(buffer, i);
                return 0;
            });
            Encoder.WriteArray(buffer, message.ProducerIdFiltersField, (b, i) =>
            {
                Encoder.WriteInt64(buffer, i);
                return 0;
            });
        }
    }
}
