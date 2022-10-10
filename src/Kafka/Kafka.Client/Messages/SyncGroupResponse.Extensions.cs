using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SyncGroupResponseExtensions
    {
        public static void Write(this SyncGroupResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.ProtocolTypeField);
            Encoder.WriteString(buffer, message.ProtocolNameField);
            Encoder.WriteBytes(buffer, message.AssignmentField);
        }
    }
}
