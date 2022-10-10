using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateDelegationTokenRequestExtensions
    {
        public static void Write(this CreateDelegationTokenRequest message, MemoryStream buffer)
        {
            Encoder.WriteString(buffer, message.OwnerPrincipalTypeField);
            Encoder.WriteString(buffer, message.OwnerPrincipalNameField);
            Encoder.WriteArray(buffer, message.RenewersField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.PrincipalTypeField);
                Encoder.WriteString(buffer, i.PrincipalNameField);
                return 0;
            });
            Encoder.WriteInt64(buffer, message.MaxLifetimeMsField);
        }
    }
}
