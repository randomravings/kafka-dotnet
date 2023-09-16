using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public sealed class NullSerializer :
        ISerializer<Null>
    {
        private NullSerializer() { }
        public static NullSerializer Instance { get; } = new();
        ReadOnlyMemory<byte>? ISerializer<Null>.Write(in OptionalValue<Null> value)
        {
            if(value.IsNull)
                return null;
            else
                throw new ArgumentNullException(nameof(value));
        }
    }
}
