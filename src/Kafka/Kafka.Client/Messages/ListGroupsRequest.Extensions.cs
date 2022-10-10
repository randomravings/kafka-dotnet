using Kafka.Common.Encoding;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages.Extensions
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListGroupsRequestExtensions
    {
        public static void Write(this ListGroupsRequest message, MemoryStream buffer)
        {
            Encoder.WriteArray(buffer, message.StatesFilterField, (b, i) =>
            {
                Encoder.WriteString(buffer, i);
                return 0;
            });
        }
    }
}
