namespace Kafka.Common.Protocol
{
    /// <summary>
    /// An object that can serialize itself.The serialization protocol is versioned.
    /// Messages also implement toString, equals, and hashCode.
    /// </summary>
    public interface IMessage :
        ICloneable
    {
        /// <summary>
        /// Api key of the message.
        /// </summary>
        public ApiKey Key { get; }

        /// <summary>
        /// Returns the lowest supported API key of this message, inclusive.
        /// </summary>
        short LowestSupportedVersion { get; }

        /// <summary>
        /// Returns the highest supported API key of this message, inclusive.
        /// </summary>
        short HighestSupportedVersion { get; }
    }
}
