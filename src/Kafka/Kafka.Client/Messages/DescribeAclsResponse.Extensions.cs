using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeAclsResponseExtensions
    {
        public static void Write(this DescribeAclsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.ErrorMessageField);
            Encoder.WriteArray(buffer, message.ResourcesField, (b, i) =>
            {
                Encoder.WriteInt8(buffer, i.ResourceTypeField);
                Encoder.WriteString(buffer, i.ResourceNameField);
                Encoder.WriteInt8(buffer, i.PatternTypeField);
                Encoder.WriteArray(buffer, i.AclsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.PrincipalField);
                    Encoder.WriteString(buffer, i.HostField);
                    Encoder.WriteInt8(buffer, i.OperationField);
                    Encoder.WriteInt8(buffer, i.PermissionTypeField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
