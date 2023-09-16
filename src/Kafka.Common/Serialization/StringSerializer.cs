using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public sealed class StringSerializer :
        ISerializer<string>
    {
        private StringSerializer() { }
        public static ISerializer<string> Instance { get; } = new StringSerializer();
        ReadOnlyMemory<byte>? ISerializer<string>.Write(in OptionalValue<string> parameter)
        {
            if(parameter.IsNull)
                return null;
            return System.Text.Encoding.UTF8.GetBytes(parameter.Value);
        }
    }
}
