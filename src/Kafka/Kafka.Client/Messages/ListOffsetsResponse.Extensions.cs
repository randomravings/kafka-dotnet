using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListOffsetsResponseExtensions
    {
        public static void Write(this ListOffsetsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    Encoder.WriteArray(buffer, i.OldStyleOffsetsField, (b, i) =>
                    {
                        Encoder.WriteInt64(buffer, i);
                        return 0;
                    });
                    Encoder.WriteInt64(buffer, i.TimestampField);
                    Encoder.WriteInt64(buffer, i.OffsetField);
                    Encoder.WriteInt32(buffer, i.LeaderEpochField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
