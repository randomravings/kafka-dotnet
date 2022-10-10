using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AllocateProducerIdsResponseExtensions
    {
        public static void Write(this AllocateProducerIdsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.ProducerIdStartField);
            Encoder.WriteInt32(buffer, message.ProducerIdLenField);
        }
    }
}
