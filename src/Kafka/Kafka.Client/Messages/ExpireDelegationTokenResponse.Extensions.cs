using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ExpireDelegationTokenResponseExtensions
    {
        public static void Write(this ExpireDelegationTokenResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
    }
}
