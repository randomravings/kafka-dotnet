using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public sealed class BytesSerializer :
        ISerializer<byte[]>
    {
        private BytesSerializer() { }
        public static ISerializer<byte[]> Instance { get; } = new BytesSerializer();
        ReadOnlyMemory<byte>? ISerializer<byte[]>.Write(in OptionalValue<byte[]> parameter)
        {
            if(parameter.IsNull)
                return null;
            var value = parameter.Value;
            var buffer = new byte[value.Length];
            Array.Copy(value, buffer, value.Length);
            return buffer;
        }
    }
}
