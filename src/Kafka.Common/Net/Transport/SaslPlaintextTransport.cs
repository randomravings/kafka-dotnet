using Microsoft.Extensions.Logging;

namespace Kafka.Common.Net.Transport
{
    public sealed class SaslPlaintextTransport(
        string host,
        int port,
        ILogger logger
    ) :
        TcpTransport(host, port, logger)
    {
    }
}