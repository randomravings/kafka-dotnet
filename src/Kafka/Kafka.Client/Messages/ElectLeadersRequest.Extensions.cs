using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ElectLeadersRequestExtensions
    {
        public static void Write(this ElectLeadersRequest message, MemoryStream buffer)
        {
            Encoder.WriteInt8(buffer, message.ElectionTypeField);
            Encoder.WriteArray(buffer, message.TopicPartitionsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.TopicField);
                Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
    }
}
