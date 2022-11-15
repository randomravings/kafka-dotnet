using System.Collections.Immutable;
using System.Net;

namespace Kafka.Client.Server
{
    public interface ICluster
    {
        ValueTask Refresh(
            IEnumerable<EndPoint> bootstrapServers,
            CancellationToken token
        );
    }
}