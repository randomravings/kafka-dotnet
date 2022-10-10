using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class WriteTxnMarkersResponseExtensions
    {
        public static void Write(this WriteTxnMarkersResponse message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.MarkersField, (b, i) =>
            {
                Encoder.WriteInt64(buffer, i.ProducerIdField);
                Encoder.WriteArray(buffer, i.TopicsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i.PartitionIndexField);
                        Encoder.WriteInt16(buffer, i.ErrorCodeField);
                        return 0;
                    });
                    return 0;
                });
                return 0;
            });
        }
    }
}
