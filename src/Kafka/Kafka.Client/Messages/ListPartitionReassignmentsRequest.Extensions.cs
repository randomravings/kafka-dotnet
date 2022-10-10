using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListPartitionReassignmentsRequestExtensions
    {
        public static void Write(this ListPartitionReassignmentsRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionIndexesField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i);
                    return 0;
                });
                return 0;
            });
        }
    }
}
