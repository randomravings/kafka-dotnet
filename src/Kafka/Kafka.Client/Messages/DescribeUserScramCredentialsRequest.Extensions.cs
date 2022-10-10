using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeUserScramCredentialsRequestExtensions
    {
        public static void Write(this DescribeUserScramCredentialsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.UsersField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                return 0;
            });
        }
    }
}
