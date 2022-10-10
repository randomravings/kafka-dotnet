using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateMetadataRequestExtensions
    {
        public static void Write(this UpdateMetadataRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteInt32(buffer, message.ControllerEpochField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
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
                Encoder.WriteInt32(buffer, i.ZkVersionField);
                Encoder.WriteArray(buffer, i.ReplicasField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i);
                    return 0;
                });
                Encoder.WriteArray(buffer, i.OfflineReplicasField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i);
                    return 0;
                });
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
                    Encoder.WriteInt32(buffer, i.ZkVersionField);
                    Encoder.WriteArray(buffer, i.ReplicasField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    Encoder.WriteArray(buffer, i.OfflineReplicasField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    return 0;
                });
                return 0;
            });
            Encoder.WriteArray(buffer, message.LiveBrokersField, (b, i) =>
            {
                Encoder.WriteInt32(buffer, i.IdField);
                Encoder.WriteString(buffer, i.V0HostField);
                Encoder.WriteInt32(buffer, i.V0PortField);
                Encoder.WriteArray(buffer, i.EndpointsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PortField);
                    Encoder.WriteString(buffer, i.HostField);
                    Encoder.WriteString(buffer, i.ListenerField);
                    Encoder.WriteInt16(buffer, i.SecurityProtocolField);
                    return 0;
                });
                Encoder.WriteString(buffer, i.RackField);
                return 0;
            });
        }
    }
}
