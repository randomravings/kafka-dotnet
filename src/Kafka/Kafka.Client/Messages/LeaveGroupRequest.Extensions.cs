using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaveGroupRequestExtensions
    {
        public static void Write(this LeaveGroupRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray(buffer, message.MembersField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.MemberIdField);
                Encoder.WriteString(buffer, i.GroupInstanceIdField);
                Encoder.WriteString(buffer, i.ReasonField);
                return 0;
            });
        }
    }
}
