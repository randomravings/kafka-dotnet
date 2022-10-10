using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaveGroupResponseExtensions
    {
        public static void Write(this LeaveGroupResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.MembersField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.MemberIdField);
                Encoder.WriteString(buffer, i.GroupInstanceIdField);
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                return 0;
            });
        }
    }
}
