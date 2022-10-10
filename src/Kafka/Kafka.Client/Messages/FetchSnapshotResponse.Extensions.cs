using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchSnapshotResponseExtensions
    {
        public static void Write(this FetchSnapshotResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.IndexField);
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    Encoder.WriteInt64(buffer, i.SnapshotIdField.EndOffsetField);
                    Encoder.WriteInt32(buffer, i.SnapshotIdField.EpochField);
                    Encoder.WriteInt32(buffer, i.CurrentLeaderField.LeaderIdField);
                    Encoder.WriteInt32(buffer, i.CurrentLeaderField.LeaderEpochField);
                    Encoder.WriteInt64(buffer, i.SizeField);
                    Encoder.WriteInt64(buffer, i.PositionField);
                    Encoder.WriteRecords(buffer, i.UnalignedRecordsField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
