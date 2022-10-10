using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaderAndIsrResponseExtensions
    {
        public static void Write(this LeaderAndIsrResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.PartitionErrorsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicNameField);
                Encoder.WriteInt32(buffer, i.PartitionIndexField);
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                return 0;
            });
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteUuid(buffer, i.TopicIdField);
                Encoder.WriteArray(buffer, i.PartitionErrorsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.TopicNameField);
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
