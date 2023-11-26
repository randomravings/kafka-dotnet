using System.Runtime.Serialization;

namespace Kafka.Common.Exceptions
{
    public class CorruptRecordException : Exception
    {
        public CorruptRecordException()
        {
        }

        public CorruptRecordException(string? message) : base(message)
        {
        }

        public CorruptRecordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
