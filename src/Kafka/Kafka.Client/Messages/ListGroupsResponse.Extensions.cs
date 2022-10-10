using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListGroupsResponseExtensions
    {
        public static void Write(this ListGroupsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.GroupsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.GroupIdField);
                Encoder.WriteString(buffer, i.ProtocolTypeField);
                Encoder.WriteString(buffer, i.GroupStateField);
                return 0;
            });
        }
    }
}
