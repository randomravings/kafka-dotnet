using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeUserScramCredentialsResponseExtensions
    {
        public static void Write(this DescribeUserScramCredentialsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteString(buffer, message.ErrorMessageField);
            Encoder.WriteArray(buffer, message.ResultsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.UserField);
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.ErrorMessageField);
                Encoder.WriteArray(buffer, i.CredentialInfosField, (b, i) =>
                {
                    Encoder.WriteInt8(buffer, i.MechanismField);
                    Encoder.WriteInt32(buffer, i.IterationsField);
                    return 0;
                });
                return 0;
            });
        }
    }
}
