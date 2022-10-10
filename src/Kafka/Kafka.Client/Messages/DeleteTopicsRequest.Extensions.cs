using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteTopicsRequestExtensions
    {
        public static void Write(this DeleteTopicsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteUuid(buffer, i.TopicIdField);
                return 0;
            });
            Encoder.WriteArray(buffer, message.TopicNamesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i);
                return 0;
            });
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
    }
}
