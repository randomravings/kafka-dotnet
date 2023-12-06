using System.Runtime.Serialization;

namespace Kafka.Common.Exceptions
{
    public class UnsupportedOperationException(
        string message
    ) : Exception(message)
    { }
}
