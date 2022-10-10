using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaderAndIsrRequestExtensions
    {
        public static void Write(this LeaderAndIsrRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
            Encoder.WriteInt8(buffer, message.TypeField);
            Encoder.WriteArray(buffer, message.UngroupedPartitionStatesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicNameField);
                Encoder.WriteInt32(buffer, i.PartitionIndexField);
                Encoder.WriteInt32(buffer, i.ControllerEpochField);
                Encoder.WriteInt32(buffer, i.LeaderField);
                Encoder.WriteInt32(buffer, i.LeaderEpochField);
                Encoder.WriteArray(buffer, i.IsrField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i);
                    return 0;
                });
                Encoder.WriteInt32(buffer, i.PartitionEpochField);
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
                Encoder.WriteBoolean(buffer, i.IsNewField);
                Encoder.WriteInt8(buffer, i.LeaderRecoveryStateField);
                return 0;
            });
            Encoder.WriteArray(buffer, message.TopicStatesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicNameField);
                Encoder.WriteUuid(buffer, i.TopicIdField);
                Encoder.WriteArray(buffer, i.PartitionStatesField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.TopicNameField);
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt32(buffer, i.ControllerEpochField);
                    Encoder.WriteInt32(buffer, i.LeaderField);
                    Encoder.WriteInt32(buffer, i.LeaderEpochField);
                    Encoder.WriteArray(buffer, i.IsrField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    Encoder.WriteInt32(buffer, i.PartitionEpochField);
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
                    Encoder.WriteBoolean(buffer, i.IsNewField);
                    Encoder.WriteInt8(buffer, i.LeaderRecoveryStateField);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteArray(buffer, message.LiveLeadersField, (b, i) =>
            {
                Encoder.WriteInt32(buffer, i.BrokerIdField);
                Encoder.WriteString(buffer, i.HostNameField);
                Encoder.WriteInt32(buffer, i.PortField);
                return 0;
            });
        }
    }
}
