using Kafka.Common.Model;
using Kafka.Common.Network;

namespace Kafka.Common.Protocol
{
    public interface IProtocol
    {
        ITransport Connection { get; }
        ValueTask Close(CancellationToken cancellationToken);
    }
}
