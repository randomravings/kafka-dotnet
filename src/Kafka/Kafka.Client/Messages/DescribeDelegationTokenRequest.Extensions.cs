using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeDelegationTokenRequestExtensions
    {
        public static void Write(this DescribeDelegationTokenRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.OwnersField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.PrincipalTypeField);
                Encoder.WriteString(buffer, i.PrincipalNameField);
                return 0;
            });
        }
    }
}
