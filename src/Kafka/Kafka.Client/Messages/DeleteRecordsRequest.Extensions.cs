using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteRecordsRequestExtensions
    {
        public static void Write(this DeleteRecordsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt64(buffer, i.OffsetField);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
    }
}
