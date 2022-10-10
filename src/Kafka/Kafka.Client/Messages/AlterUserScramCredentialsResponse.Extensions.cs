using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterUserScramCredentialsResponseExtensions
    {
        public static void Write(this AlterUserScramCredentialsResponse message, MemoryStream buffer)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray(buffer, message.ResultsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.UserField);
                Encoder.WriteInt16(buffer, i.ErrorCodeField);
                Encoder.WriteString(buffer, i.ErrorMessageField);
                return 0;
            });
        }
    }
}
