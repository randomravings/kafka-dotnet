using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClusterRequestExtensions
    {
        public static void Write(this DescribeClusterRequest message, MemoryStream buffer)
        {
            Encoder.WriteBoolean(buffer, message.IncludeClusterAuthorizedOperationsField);
        }
    }
}
