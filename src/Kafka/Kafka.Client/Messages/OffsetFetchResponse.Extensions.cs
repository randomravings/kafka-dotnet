using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetFetchResponseExtensions
    {
        public static void Write(this OffsetFetchResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt64(buffer, i.CommittedOffsetField);
                    Encoder.WriteInt32(buffer, i.CommittedLeaderEpochField);
                    Encoder.WriteString(buffer, i.MetadataField);
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.GroupsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.groupIdField);
                Encoder.WriteArray(buffer, i.TopicsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i.PartitionIndexField);
                        Encoder.WriteInt64(buffer, i.CommittedOffsetField);
                        Encoder.WriteInt32(buffer, i.CommittedLeaderEpochField);
                        Encoder.WriteString(buffer, i.MetadataField);
                        Encoder.WriteInt16(buffer, i.ErrorCodeField);
                        return 0;
                    });
                    return 0;
                });
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                return 0;
            });
        }
    }
}
