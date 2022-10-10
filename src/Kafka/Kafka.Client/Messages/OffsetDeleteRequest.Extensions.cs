using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetDeleteRequestExtensions
    {
        public static void Write(this OffsetDeleteRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
