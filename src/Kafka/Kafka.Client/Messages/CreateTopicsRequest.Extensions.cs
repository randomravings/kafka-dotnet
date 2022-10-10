using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateTopicsRequestExtensions
    {
        public static void Write(this CreateTopicsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteInt32(buffer, i.NumPartitionsField);
                Encoder.WriteInt16(buffer, i.ReplicationFactorField);
                Encoder.WriteArray(buffer, i.AssignmentsField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i.PartitionIndexField);
                    Encoder.WriteArray(buffer, i.BrokerIdsField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    return 0;
                });
                Encoder.WriteArray(buffer, i.ConfigsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteString(buffer, i.ValueField);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteInt32(buffer, message.timeoutMsField);
            Encoder.WriteBoolean(buffer, message.validateOnlyField);
        }
    }
}
