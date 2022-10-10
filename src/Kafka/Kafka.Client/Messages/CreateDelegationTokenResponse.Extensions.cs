using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateDelegationTokenResponseExtensions
    {
        public static void Write(this CreateDelegationTokenResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.PrincipalTypeField);
            Encoder.WriteString(buffer, message.PrincipalNameField);
            Encoder.WriteString(buffer, message.TokenRequesterPrincipalTypeField);
            Encoder.WriteString(buffer, message.TokenRequesterPrincipalNameField);
            Encoder.WriteInt64(buffer, message.IssueTimestampMsField);
            Encoder.WriteInt64(buffer, message.ExpiryTimestampMsField);
            Encoder.WriteInt64(buffer, message.MaxTimestampMsField);
            Encoder.WriteString(buffer, message.TokenIdField);
            Encoder.WriteBytes(buffer, message.HmacField);
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
    }
}
