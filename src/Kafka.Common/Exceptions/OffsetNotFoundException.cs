using System.Runtime.Serialization;

namespace Kafka.Common.Exceptions
{
    public class OffsetNotFoundException :
        Exception
    {
        public OffsetNotFoundException()
        {
        }

        public OffsetNotFoundException(string? message) : base(message)
        {
        }

        public OffsetNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OffsetNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
