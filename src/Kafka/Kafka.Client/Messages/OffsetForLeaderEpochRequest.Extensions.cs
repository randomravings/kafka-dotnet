using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetForLeaderEpochRequestExtensions
    {
        public static void Write(this OffsetForLeaderEpochRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionField);
                    Encoder.WriteInt32(buffer, i.CurrentLeaderEpochField);
                    Encoder.WriteInt32(buffer, i.LeaderEpochField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
