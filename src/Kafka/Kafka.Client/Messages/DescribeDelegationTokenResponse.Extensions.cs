using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeDelegationTokenResponseExtensions
    {
        public static void Write(this DescribeDelegationTokenResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray(buffer, message.TokensField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.PrincipalTypeField);
                Encoder.WriteString(buffer, i.PrincipalNameField);
                Encoder.WriteString(buffer, i.TokenRequesterPrincipalTypeField);
                Encoder.WriteString(buffer, i.TokenRequesterPrincipalNameField);
                Encoder.WriteInt64(buffer, i.IssueTimestampField);
                Encoder.WriteInt64(buffer, i.ExpiryTimestampField);
                Encoder.WriteInt64(buffer, i.MaxTimestampField);
                Encoder.WriteString(buffer, i.TokenIdField);
                Encoder.WriteBytes(buffer, i.HmacField);
                Encoder.WriteArray(buffer, i.RenewersField, (b, i) =>
                {
                    Encoder.WriteString(buffer, i.PrincipalTypeField);
                    Encoder.WriteString(buffer, i.PrincipalNameField);
                    return 0;
                });
                return 0;
            });
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
        }
    }
}
