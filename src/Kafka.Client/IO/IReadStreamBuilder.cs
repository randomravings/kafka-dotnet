using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IReadStreamBuilder
    {
        IReadStreamBuilder WithLogger(ILogger logger);
        IGroupReadStreamBuilder AsGroup();
        IAssignedReadStreamBuilder AsAssigned();
    }
}
