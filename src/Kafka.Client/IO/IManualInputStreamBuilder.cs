using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IManualInputStreamBuilder
    {
        IManualInputStreamBuilder WithLogger(ILogger<IManualInputStream> logger);
        IManualInputStream Build();
    }
}
