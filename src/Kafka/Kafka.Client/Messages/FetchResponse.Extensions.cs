using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchResponseExtensions
    {
        public static void Write(this FetchResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteArray(buffer, message.ResponsesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicField);
                Encoder.WriteUuid(buffer, i.TopicIdField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    Encoder.WriteInt64(buffer, i.HighWatermarkField);
                    Encoder.WriteInt64(buffer, i.LastStableOffsetField);
                    Encoder.WriteInt64(buffer, i.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, i.DivergingEpochField.EpochField);
                    Encoder.WriteInt64(buffer, i.DivergingEpochField.EndOffsetField);
                    Encoder.WriteInt32(buffer, i.CurrentLeaderField.LeaderIdField);
                    Encoder.WriteInt32(buffer, i.CurrentLeaderField.LeaderEpochField);
                    Encoder.WriteInt64(buffer, i.SnapshotIdField.EndOffsetField);
                    Encoder.WriteInt32(buffer, i.SnapshotIdField.EpochField);
                    Encoder.WriteArray(buffer, i.AbortedTransactionsField, (b, i) =>
                    {
                        Encoder.WriteInt64(buffer, i.ProducerIdField);
                        Encoder.WriteInt64(buffer, i.FirstOffsetField);
                        return 0;
                    });
                    Encoder.WriteInt32(buffer, i.PreferredReadReplicaField);
                    Encoder.WriteRecords(buffer, i.RecordsField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
