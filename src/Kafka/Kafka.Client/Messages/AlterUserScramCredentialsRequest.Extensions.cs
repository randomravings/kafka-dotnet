using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterUserScramCredentialsRequestExtensions
    {
        public static void Write(this AlterUserScramCredentialsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.DeletionsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteInt8(buffer, i.MechanismField);
                return 0;
            });
            Encoder.WriteArray(buffer, message.UpsertionsField, (b, i) =>
            {
                Encoder.WriteString(buffer, i.NameField);
                Encoder.WriteInt8(buffer, i.MechanismField);
                Encoder.WriteInt32(buffer, i.IterationsField);
                Encoder.WriteBytes(buffer, i.SaltField);
                Encoder.WriteBytes(buffer, i.SaltedPasswordField);
                return 0;
            });
        }
    }
}
