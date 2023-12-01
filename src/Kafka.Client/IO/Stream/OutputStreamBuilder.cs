using Kafka.Client.Config;
using Kafka.Client.Net;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Stream
{
    internal class OutputStreamBuilder(
        ICluster<IClientConnection> connections,
        OutputStreamConfig config,
        ILogger logger
    ) :
        IOutputStreamBuilder
    {
        private readonly ICluster<IClientConnection> _connections = connections;
        private readonly OutputStreamConfig _config = config;
        private ILogger _logger = logger;

        IOutputStreamBuilder IOutputStreamBuilder.WithLogger(
            ILogger<IOutputStream> logger
        )
        {
            _logger = logger;
            return this;
        }

        IOutputStream IOutputStreamBuilder.Build() =>
            new OutputStream(
                _connections,
                _config,
                _logger
            )
        ;
    }
}
