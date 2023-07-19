namespace Kafka.Client.Exceptions
{
    public class CorrelationIdException :
        Exception
    {
        public CorrelationIdException()
        {
        }

        public CorrelationIdException(string message) : base(message)
        {
        }

        public CorrelationIdException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CorrelationIdException(int expectedId, int actualId)
        {
            ExpectedId = expectedId;
            ActualId = actualId;
        }

        public int ExpectedId { get; }
        public int ActualId { get; }
    }
}
