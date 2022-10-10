using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListOffsetsRequestExtensions
    {
        public static void Write(this ListOffsetsRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt32(buffer, i.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, i.TimestampField);
                    Encoder.WriteInt32(buffer, i.MaxNumOffsetsField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
