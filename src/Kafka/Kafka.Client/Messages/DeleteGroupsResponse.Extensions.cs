using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteGroupsResponseExtensions
    {
        public static void Write(this DeleteGroupsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.ResultsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.GroupIdField);
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                return 0;
            });
        }
    }
}
