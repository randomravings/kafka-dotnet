using Kafka.Common.Model;
using Kafka.Common.Network;

namespace Kafka.Common.Protocol
{
    public interface IProtocol
    {
        IConnection Connection { get; }
        ValueTask Close(CancellationToken cancellationToken);
    }
}
