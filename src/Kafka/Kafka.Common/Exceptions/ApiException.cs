using Kafka.Common.Types;
using System.Runtime.Serialization;

namespace Kafka.Common.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException()
        {
            ErrorCode = ErrorCode.UNKNOWN_SERVER_ERROR;
        }

        public ApiException(ErrorCode errorCode, string? message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ApiException(ErrorCode errorCode, string? message, Exception? innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ErrorCode ErrorCode { get; init; }
    }
}
