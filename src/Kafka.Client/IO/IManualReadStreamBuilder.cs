using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IManualReadStreamBuilder
    {
        IManualReadStream Build();
    }
}
