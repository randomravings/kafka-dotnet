namespace Kafka.Common.Attributes
{
    /// <summary>
    /// Attribute use to determine how a value is/should be serialized.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class SerializationAttribute : Attribute
    {
        /// <summary>
        /// The wireformat used for the type.
        /// </summary>
        public SerializationType Type { get; private set; }
        /// <summary>
        /// The order of the value on the wire.
        /// </summary>
        public int Order { get; private set; }
        public SerializationAttribute(SerializationType type, int order)
        {
            Type = type;
            Order = order;
        }
    }

    /// <summary>
    /// An array that is serialized as a sequence of items without length prefix.
    /// The items are expected to have a size prefix per element and the end of the buffer is the termination.
    /// </summary>
    internal class SerializationSequenceAttribute : SerializationAttribute
    {
        public SerializationSequenceAttribute(int order)
            : base(SerializationType.Array, order)
        { }
    }

    /// <summary>
    /// Property is not serialized.
    /// Useful for adding informal values on the type.
    /// </summary>
    internal class SerializationIgnoreAttribute : SerializationAttribute
    {
        public SerializationIgnoreAttribute()
            : base(SerializationType.Ignore, int.MaxValue)
        { }
    }
}
