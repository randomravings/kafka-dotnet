using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SnapshotHeaderRecordExtensions
    {
        public static void Write(this SnapshotHeaderRecord message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.VersionField);
            Encoder.WriteInt64(buffer, message.LastContainedLogTimestampField);
        }
    }
}
