using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class EndTxnRequestExtensions
    {
        public static void Write(this EndTxnRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteBoolean(buffer, message.CommittedField);
        }
    }
}
