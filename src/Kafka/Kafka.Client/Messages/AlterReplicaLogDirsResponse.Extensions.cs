using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterReplicaLogDirsResponseExtensions
    {
        public static void Write(this AlterReplicaLogDirsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.ResultsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicNameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
