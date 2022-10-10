using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddPartitionsToTxnRequestExtensions
    {
        public static void Write(this AddPartitionsToTxnRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i);
                    return 0;
                });
                return 0;
            });
        }
    }
}
