using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteAclsResponseExtensions
    {
        public static void Write(this DeleteAclsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.FilterResultsField, (b, i) =>
            {
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.ErrorMessageField);
                Encoder.WriteArray(buffer, i.MatchingAclsField, (b, i) =>
                {
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    Encoder.WriteString(buffer, i.ErrorMessageField);
                    Encoder.WriteInt8(buffer, i.ResourceTypeField);
                    Encoder.WriteString(buffer, i.ResourceNameField);
                    Encoder.WriteInt8(buffer, i.PatternTypeField);
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
