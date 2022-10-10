using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteAclsRequestExtensions
    {
        public static void Write(this DeleteAclsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.FiltersField, (b, i) =>
            {
                Encoder.WriteInt8(buffer, i.ResourceTypeFilterField);
                Encoder.WriteString(buffer, i.ResourceNameFilterField);
                Encoder.WriteInt8(buffer, i.PatternTypeFilterField);
                Encoder.WriteString(buffer, i.PrincipalFilterField);
                Encoder.WriteString(buffer, i.HostFilterField);
                Encoder.WriteInt8(buffer, i.OperationField);
                Encoder.WriteInt8(buffer, i.PermissionTypeField);
                return 0;
            });
        }
    }
}
