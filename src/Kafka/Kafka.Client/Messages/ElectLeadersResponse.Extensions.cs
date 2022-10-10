using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ElectLeadersResponseExtensions
    {
        public static void Write(this ElectLeadersResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.ReplicaElectionResultsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicField);
                Encoder.WriteArray(buffer, i.PartitionResultField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIdField);
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    Encoder.WriteString(buffer, i.ErrorMessageField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
