using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeGroupsRequestExtensions
    {
        public static void Write(this DescribeGroupsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.GroupsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i);
                return 0;
            });
            Encoder.WriteBoolean(buffer, message.IncludeAuthorizedOperationsField);
        }
    }
}
