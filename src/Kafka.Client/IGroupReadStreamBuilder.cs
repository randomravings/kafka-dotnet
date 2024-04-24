using Microsoft.Extensions.Logging;

namespace Kafka.Client
{
    public interface IGroupReadStreamBuilder
    {
        IGroupReadStream Build();
    }
}
