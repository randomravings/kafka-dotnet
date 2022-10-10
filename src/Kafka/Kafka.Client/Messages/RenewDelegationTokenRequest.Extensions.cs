using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class RenewDelegationTokenRequestExtensions
    {
        public static void Write(this RenewDelegationTokenRequest message, MemoryStream buffer)
        {
            Encoder.WriteBytes(buffer, message.HmacField);
            Encoder.WriteInt64(buffer, message.RenewPeriodMsField);
        }
    }
}
