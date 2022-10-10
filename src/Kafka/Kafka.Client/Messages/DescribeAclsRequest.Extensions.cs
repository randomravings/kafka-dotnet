using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeAclsRequestExtensions
    {
        public static void Write(this DescribeAclsRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
            Encoder.WriteString(buffer, message.ResourceNameFilterField);
            Encoder.WriteInt8(buffer, message.PatternTypeFilterField);
            Encoder.WriteString(buffer, message.PrincipalFilterField);
            Encoder.WriteString(buffer, message.HostFilterField);
            Encoder.WriteInt8(buffer, message.OperationField);
            Encoder.WriteInt8(buffer, message.PermissionTypeField);
        }
    }
}
