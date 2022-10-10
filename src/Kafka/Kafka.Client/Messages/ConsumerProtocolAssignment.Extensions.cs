using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ConsumerProtocolAssignmentExtensions
    {
        public static void Write(this ConsumerProtocolAssignment message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.AssignedPartitionsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteBytes(buffer, message.UserDataField);
        }
    }
}
