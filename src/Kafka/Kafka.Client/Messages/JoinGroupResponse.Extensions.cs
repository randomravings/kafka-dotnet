using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class JoinGroupResponseExtensions
    {
        public static void Write(this JoinGroupResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.ProtocolTypeField);
            Encoder.WriteString(buffer, message.ProtocolNameField);
            Encoder.WriteString(buffer, message.LeaderField);
            Encoder.WriteBoolean(buffer, message.SkipAssignmentField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray(buffer, message.MembersField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.MemberIdField);
                Encoder.WriteString(buffer, i.GroupInstanceIdField);
                Encoder.WriteBytes(buffer, i.MetadataField);
                return 0;
            });
        }
    }
}
