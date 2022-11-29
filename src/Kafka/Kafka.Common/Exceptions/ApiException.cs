using Kafka.Common.Types;

namespace Kafka.Common.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(Error error) :
            base(error.Message)
        {
            ErrorCode = error.ErrorCode;
            Retriable = error.Retriable;
        }

        public ErrorCode ErrorCode { get; init; }
        public bool Retriable { get; init; }
    }
}
