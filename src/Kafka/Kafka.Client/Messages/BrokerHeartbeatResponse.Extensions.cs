using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class BrokerHeartbeatResponseExtensions
    {
        public static void Write(this BrokerHeartbeatResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteBoolean(buffer, message.IsCaughtUpField);
            Encoder.WriteBoolean(buffer, message.IsFencedField);
            Encoder.WriteBoolean(buffer, message.ShouldShutDownField);
        }
    }
}
