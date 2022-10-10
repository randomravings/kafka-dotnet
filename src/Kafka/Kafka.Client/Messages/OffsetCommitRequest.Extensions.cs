using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetCommitRequestExtensions
    {
        public static void Write(this OffsetCommitRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteString(buffer, message.GroupInstanceIdField);
            Encoder.WriteInt64(buffer, message.RetentionTimeMsField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt64(buffer, i.CommittedOffsetField);
                    Encoder.WriteInt32(buffer, i.CommittedLeaderEpochField);
                    Encoder.WriteInt64(buffer, i.CommitTimestampField);
                    Encoder.WriteString(buffer, i.CommittedMetadataField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
