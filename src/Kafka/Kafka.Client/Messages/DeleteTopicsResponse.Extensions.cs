using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteTopicsResponseExtensions
    {
        public static void Write(this DeleteTopicsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.ResponsesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteUuid(buffer, i.TopicIdField);
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.ErrorMessageField);
                return 0;
            });
        }
    }
}
