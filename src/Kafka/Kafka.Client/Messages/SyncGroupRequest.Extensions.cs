using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SyncGroupRequestExtensions
    {
        public static void Write(this SyncGroupRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteString(buffer, message.GroupInstanceIdField);
            Encoder.WriteString(buffer, message.ProtocolTypeField);
            Encoder.WriteString(buffer, message.ProtocolNameField);
            Encoder.WriteArray(buffer, message.AssignmentsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.MemberIdField);
                Encoder.WriteBytes(buffer, i.AssignmentField);
                return 0;
            });
        }
    }
}
