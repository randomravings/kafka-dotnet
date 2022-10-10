using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ControlledShutdownRequestExtensions
    {
        public static void Write(this ControlledShutdownRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.BrokerIdField);
            Encoder.WriteInt64(buffer, message.BrokerEpochField);
        }
    }
}
