using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetForLeaderEpochResponseExtensions
    {
        public static void Write(this OffsetForLeaderEpochResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    Encoder.WriteInt32(buffer, i.PartitionField);
                    Encoder.WriteInt32(buffer, i.LeaderEpochField);
                    Encoder.WriteInt64(buffer, i.EndOffsetField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
