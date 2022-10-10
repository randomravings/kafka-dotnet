using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class JoinGroupRequestExtensions
    {
        public static void Write(this JoinGroupRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteString(buffer, message.GroupInstanceIdField);
            Encoder.WriteString(buffer, message.ProtocolTypeField);
            Encoder.WriteArray(buffer, message.ProtocolsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteBytes(buffer, i.MetadataField);
                return 0;
            });
            Encoder.WriteString(buffer, message.ReasonField);
        }
    }
}
