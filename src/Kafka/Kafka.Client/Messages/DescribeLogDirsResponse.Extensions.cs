using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeLogDirsResponseExtensions
    {
        public static void Write(this DescribeLogDirsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.ResultsField, (b, i) =>
            {
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.LogDirField);
                Encoder.WriteArray(buffer, i.TopicsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i.PartitionIndexField);
                        Encoder.WriteInt64(buffer, i.PartitionSizeField);
                        Encoder.WriteInt64(buffer, i.OffsetLagField);
                        Encoder.WriteBoolean(buffer, i.IsFutureKeyField);
                        return 0;
                    });
                    return 0;
                });
                Encoder.WriteInt64(buffer, i.TotalBytesField);
                Encoder.WriteInt64(buffer, i.UsableBytesField);
                return 0;
            });
        }
    }
}
