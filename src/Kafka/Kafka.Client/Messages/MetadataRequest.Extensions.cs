using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class MetadataRequestExtensions
    {
        public static void Write(this MetadataRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteUuid(buffer, i.TopicIdField);
                Encoder.WriteString(buffer, i.NameField);
                return 0;
            });
            Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            Encoder.WriteBoolean(buffer, message.IncludeClusterAuthorizedOperationsField);
            Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
        }
    }
}
