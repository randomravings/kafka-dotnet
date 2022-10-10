using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class VoteRequestExtensions
    {
        public static void Write(this VoteRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.ClusterIdField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicNameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt32(buffer, i.CandidateEpochField);
                    Encoder.WriteInt32(buffer, i.CandidateIdField);
                    Encoder.WriteInt32(buffer, i.LastOffsetEpochField);
                    Encoder.WriteInt64(buffer, i.LastOffsetField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
