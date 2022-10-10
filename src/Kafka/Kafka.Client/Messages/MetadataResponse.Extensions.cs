using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class MetadataResponseExtensions
    {
        public static void Write(this MetadataResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.BrokersField, (b, i) =>
            {
                Encoder.WriteInt32(buffer, i.NodeIdField);
                Encoder.WriteString(buffer, i.HostField);
                Encoder.WriteInt32(buffer, i.PortField);
                Encoder.WriteString(buffer, i.RackField);
                return 0;
            });
            Encoder.WriteString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteUuid(buffer, i.TopicIdField);
                Encoder.WriteBoolean(buffer, i.IsInternalField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt16(buffer, i.ErrorCodeField);
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteInt32(buffer, i.LeaderIdField);
                    Encoder.WriteInt32(buffer, i.LeaderEpochField);
                    Encoder.WriteArray(buffer, i.ReplicaNodesField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    Encoder.WriteArray(buffer, i.IsrNodesField, (b, i) =>
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
                Encoder.WriteInt32(buffer, i.TopicAuthorizedOperationsField);
                return 0;
            });
            Encoder.WriteInt32(buffer, message.ClusterAuthorizedOperationsField);
        }
    }
}
