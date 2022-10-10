using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class StopReplicaResponseExtensions
    {
        public static void Write(this StopReplicaResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.PartitionErrorsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicNameField);
                Encoder.WriteInt32(buffer, i.PartitionIndexField);
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                return 0;
            });
        }
    }
}
