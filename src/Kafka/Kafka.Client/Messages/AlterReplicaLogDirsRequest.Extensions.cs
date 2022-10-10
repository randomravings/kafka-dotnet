using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterReplicaLogDirsRequestExtensions
    {
        public static void Write(this AlterReplicaLogDirsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.DirsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.PathField);
                Encoder.WriteArray(buffer, i.TopicsField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.NameField);
                    Encoder.WriteArray(buffer, i.PartitionsField, (b, i) =>
                    {
                        Encoder.WriteInt32(buffer, i);
                        return 0;
                    });
                    return 0;
                });
                return 0;
            });
        }
    }
}
