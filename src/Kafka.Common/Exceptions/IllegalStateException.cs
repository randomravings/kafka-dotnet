using System.Runtime.Serialization;

namespace Kafka.Common.Exceptions
{
    internal class IllegalStateException :
        Exception
    {
        public IllegalStateException()
        {
        }

        public IllegalStateException(string? message) : base(message)
        {
        }

        public IllegalStateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IllegalStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
