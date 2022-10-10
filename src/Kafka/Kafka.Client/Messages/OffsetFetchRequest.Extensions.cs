using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetFetchRequestExtensions
    {
        public static void Write(this OffsetFetchRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteArray(buffer, message.TopicsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteArray(buffer, i.PartitionIndexesField, (b, i) =>
                {
                    Encoder.WriteInt32(buffer, i);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteArray(buffer, message.GroupsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.groupIdField);
                Encoder.WriteArray(buffer, i.TopicsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteArray(buffer, i.PartitionIndexesField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    return 0;
                });
                return 0;
            });
            Encoder.WriteBoolean(buffer, message.RequireStableField);
        }
    }
}
