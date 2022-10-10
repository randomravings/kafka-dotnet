using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateTopicsResponseExtensions
    {
        public static void Write(this CreateTopicsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteUuid(buffer, i.TopicIdField);
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.ErrorMessageField);
                Encoder.WriteInt16(buffer, i.TopicConfigErrorCodeField);
                Encoder.WriteInt32(buffer, i.NumPartitionsField);
                Encoder.WriteInt16(buffer, i.ReplicationFactorField);
                Encoder.WriteArray(buffer, i.ConfigsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteString(buffer, i.ValueField);
                    Encoder.WriteBoolean(buffer, i.ReadOnlyField);
                    Encoder.WriteInt8(buffer, i.ConfigSourceField);
                    Encoder.WriteBoolean(buffer, i.IsSensitiveField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
