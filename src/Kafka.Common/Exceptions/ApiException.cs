using Kafka.Common.Model;

namespace Kafka.Common.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(Error error) :
            base(error.Message)
        {
            Error = error;
        }

        public Error Error { get; init; }
    }
}
