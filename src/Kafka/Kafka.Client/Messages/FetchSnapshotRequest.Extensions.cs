using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchSnapshotRequestExtensions
    {
        public static void Write(this FetchSnapshotRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionField);
                    Encoder.WriteInt32(buffer, i.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, i.SnapshotIdField.EndOffsetField);
                    Encoder.WriteInt32(buffer, i.SnapshotIdField.EpochField);
                    Encoder.WriteInt64(buffer, i.PositionField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
