using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreatePartitionsRequestExtensions
    {
        public static void Write(this CreatePartitionsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteInt32(buffer, i.CountField);
                Encoder.WriteArray(buffer, i.AssignmentsField, (b, i) =>
                {
                    Encoder.WriteArray(buffer, i.BrokerIdsField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    return 0;
                });
                return 0;
            });
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
        }
    }
}
