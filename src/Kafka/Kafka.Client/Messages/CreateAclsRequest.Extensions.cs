using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateAclsRequestExtensions
    {
        public static void Write(this CreateAclsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.CreationsField, (b, i) =>
            {
                Encoder.WriteInt8(buffer, i.ResourceTypeField);
                Encoder.WriteString(buffer, i.ResourceNameField);
                Encoder.WriteInt8(buffer, i.ResourcePatternTypeField);
                Encoder.WriteString(buffer, i.PrincipalField);
                Encoder.WriteString(buffer, i.HostField);
                Encoder.WriteInt8(buffer, i.OperationField);
                Encoder.WriteInt8(buffer, i.PermissionTypeField);
                return 0;
            });
        }
    }
}
