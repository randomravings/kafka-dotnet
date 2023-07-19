namespace Kafka.Common.Exceptions
{
    public class OpenConnectionException :
        Exception
    {
        public OpenConnectionException()
        {
        }

        public OpenConnectionException(string message) : base(message)
        {
        }

        public OpenConnectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
