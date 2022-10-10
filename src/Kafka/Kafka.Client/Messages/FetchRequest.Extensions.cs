using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchRequestExtensions
    {
        public static void Write(this FetchRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteInt32(buffer, message.SessionEpochField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicField);
                Encoder.WriteUuid(buffer, i.TopicIdField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionField);
                    Encoder.WriteInt32(buffer, i.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, i.FetchOffsetField);
                    Encoder.WriteInt32(buffer, i.LastFetchedEpochField);
                    Encoder.WriteInt64(buffer, i.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, i.PartitionMaxBytesField);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteArray(buffer, message.ForgottenTopicsDataField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicField);
                Encoder.WriteUuid(buffer, i.TopicIdField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteString(buffer, message.RackIdField);
        }
    }
}
