using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeGroupsResponseExtensions
    {
        public static void Write(this DescribeGroupsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.GroupsField, (b, i) =>
            {
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.GroupIdField);
                Encoder.WriteString(buffer, i.GroupStateField);
                Encoder.WriteString(buffer, i.ProtocolTypeField);
                Encoder.WriteString(buffer, i.ProtocolDataField);
                Encoder.WriteArray(buffer, i.MembersField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.MemberIdField);
                    Encoder.WriteString(buffer, i.GroupInstanceIdField);
                    Encoder.WriteString(buffer, i.ClientIdField);
                    Encoder.WriteString(buffer, i.ClientHostField);
                    Encoder.WriteBytes(buffer, i.MemberMetadataField);
                    Encoder.WriteBytes(buffer, i.MemberAssignmentField);
                    return 0;
                });
                Encoder.WriteInt32(buffer, i.AuthorizedOperationsField);
                return 0;
            });
        }
    }
}
