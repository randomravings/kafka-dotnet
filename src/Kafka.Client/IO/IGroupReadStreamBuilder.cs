using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO
{
    public interface IGroupReadStreamBuilder
    {
        IGroupReadStream Build();
    }
}
