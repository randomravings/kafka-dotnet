using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeProducersResponseExtensions
    {
        public static void Write(this DescribeProducersResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    Encoder.WriteString(buffer, i.ErrorMessageField);
                    Encoder.WriteArray(buffer, i.ActiveProducersField, (b, i) =>
                    {
                        Encoder.WriteInt64(buffer, i.ProducerIdField);
                        Encoder.WriteInt32(buffer, i.ProducerEpochField);
                        Encoder.WriteInt32(buffer, i.LastSequenceField);
                        Encoder.WriteInt64(buffer, i.LastTimestampField);
                        Encoder.WriteInt32(buffer, i.CoordinatorEpochField);
                        Encoder.WriteInt64(buffer, i.CurrentTxnStartOffsetField);
                        return 0;
                    });
                    return 0;
                });
                return 0;
            });
        }
    }
}
