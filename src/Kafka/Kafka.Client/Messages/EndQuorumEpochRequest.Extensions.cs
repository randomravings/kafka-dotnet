using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EndQuorumEpochRequestExtensions
    {
        public static void Write(this EndQuorumEpochRequest message, MemoryStream buffer)
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
                    Encoder.WriteArray(buffer, i.PreferredSuccessorsField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    return 0;
                });
                return 0;
            });
        }
    }
}
