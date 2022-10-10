using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerRegistrationRequestExtensions
    {
        public static void Write(this BrokerRegistrationRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteString(buffer, message.ClusterIdField);
            Encoder.WriteUuid(buffer, message.IncarnationIdField);
            Encoder.WriteArray(buffer, message.ListenersField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteString(buffer, i.HostField);
                Encoder.WriteUInt16(buffer, i.PortField);
                Encoder.WriteInt16(buffer, i.SecurityProtocolField);
                return 0;
            });
            Encoder.WriteArray(buffer, message.FeaturesField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteInt16(buffer, i.MinSupportedVersionField);
                Encoder.WriteInt16(buffer, i.MaxSupportedVersionField);
                return 0;
            });
            Encoder.WriteString(buffer, message.RackField);
        }
    }
}
