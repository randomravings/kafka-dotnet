using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class InitProducerIdResponseExtensions
    {
        public static void Write(this InitProducerIdResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
        }
    }
}
