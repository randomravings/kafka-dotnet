using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class StopReplicaRequestExtensions
    {
        public static void Write(this StopReplicaRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteBoolean(buffer, message.DeletePartitionsField);
            Encoder.WriteArray(buffer, message.UngroupedPartitionsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicNameField);
                Encoder.WriteInt32(buffer, i.PartitionIndexField);
                return 0;
            });
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
            Encoder.WriteArray(buffer, message.TopicStatesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicNameField);
                Encoder.WriteArray(buffer, i.PartitionStatesField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt32(buffer, i.LeaderEpochField);
                    Encoder.WriteBoolean(buffer, i.DeletePartitionField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
