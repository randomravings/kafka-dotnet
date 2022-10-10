using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ExpireDelegationTokenRequestExtensions
    {
        public static void Write(this ExpireDelegationTokenRequest message, MemoryStream buffer)
        {
            Encoder.WriteBytes(buffer, message.HmacField);
            Encoder.WriteInt64(buffer, message.ExpiryTimePeriodMsField);
        }
    }
}
