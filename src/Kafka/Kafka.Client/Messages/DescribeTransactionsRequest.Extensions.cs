using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeTransactionsRequestExtensions
    {
        public static void Write(this DescribeTransactionsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.TransactionalIdsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i);
                return 0;
            });
        }
    }
}
