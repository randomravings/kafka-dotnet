namespace Kafka.Common.Exceptions
{
    public class IllegalStateException(
        string message
    ) : Exception(message)
    { }
}
