using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FindCoordinatorRequestExtensions
    {
        public static void Write(this FindCoordinatorRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.KeyField);
            Encoder.WriteInt8(buffer, message.KeyTypeField);
            Encoder.WriteArray(buffer, message.CoordinatorKeysField, (b, i) =>
            {
                Encoder.WriteString(buffer, i);
                return 0;
            });
        }
    }
}
