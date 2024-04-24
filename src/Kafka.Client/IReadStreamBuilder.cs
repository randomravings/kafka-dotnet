using Microsoft.Extensions.Logging;

namespace Kafka.Client
{
    public interface IReadStreamBuilder
    {
        IReadStreamBuilder WithLogger(ILogger logger);
        IGroupReadStreamBuilder AsGroup();
        IAssignedReadStreamBuilder AsAssigned();
    }
}
