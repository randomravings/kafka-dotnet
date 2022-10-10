using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FindCoordinatorResponseExtensions
    {
        public static void Write(this FindCoordinatorResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.ErrorMessageField);
            Encoder.WriteInt32(buffer, message.NodeIdField);
            Encoder.WriteString(buffer, message.HostField);
            Encoder.WriteInt32(buffer, message.PortField);
            Encoder.WriteArray(buffer, message.CoordinatorsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.KeyField);
                Encoder.WriteInt32(buffer, i.NodeIdField);
                Encoder.WriteString(buffer, i.HostField);
                Encoder.WriteInt32(buffer, i.PortField);
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.ErrorMessageField);
                return 0;
            });
        }
    }
}
