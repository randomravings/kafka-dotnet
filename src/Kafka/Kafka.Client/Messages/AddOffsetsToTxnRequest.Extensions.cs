using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddOffsetsToTxnRequestExtensions
    {
        public static void Write(this AddOffsetsToTxnRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteString(buffer, message.GroupIdField);
        }
    }
}
