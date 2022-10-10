using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class VoteResponseExtensions
    {
        public static void Write(this VoteResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicNameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    Encoder.WriteInt32(buffer, i.LeaderIdField);
                    Encoder.WriteInt32(buffer, i.LeaderEpochField);
                    Encoder.WriteBoolean(buffer, i.VoteGrantedField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
