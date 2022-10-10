using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SnapshotFooterRecordExtensions
    {
        public static void Write(this SnapshotFooterRecord message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.VersionField);
        }
    }
}
