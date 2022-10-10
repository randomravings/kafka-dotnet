using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BeginQuorumEpochRequestExtensions
    {
        public static void Write(this BeginQuorumEpochRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.ClusterIdField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicNameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt32(buffer, i.LeaderIdField);
                    Encoder.WriteInt32(buffer, i.LeaderEpochField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
