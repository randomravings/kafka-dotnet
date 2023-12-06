using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IApplicationReadStreamBuilder
    {
        IApplicationReadStream Build();
    }
}
