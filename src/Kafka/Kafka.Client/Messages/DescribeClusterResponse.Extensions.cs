using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClusterResponseExtensions
    {
        public static void Write(this DescribeClusterResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.ErrorMessageField);
            Encoder.WriteString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ControllerIdField);
            Encoder.WriteArray(buffer, message.BrokersField, (b, i) =>
            {
                Encoder.WriteInt32(buffer, i.BrokerIdField);
                Encoder.WriteString(buffer, i.HostField);
                Encoder.WriteInt32(buffer, i.PortField);
                Encoder.WriteString(buffer, i.RackField);
                return 0;
            });
            Encoder.WriteInt32(buffer, message.ClusterAuthorizedOperationsField);
        }
    }
}
