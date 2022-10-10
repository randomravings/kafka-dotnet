using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListPartitionReassignmentsResponseExtensions
    {
        public static void Write(this ListPartitionReassignmentsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.ErrorMessageField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteArray(buffer, i.ReplicasField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    Encoder.WriteArray(buffer, i.AddingReplicasField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    Encoder.WriteArray(buffer, i.RemovingReplicasField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    return 0;
                });
                return 0;
            });
        }
    }
}
