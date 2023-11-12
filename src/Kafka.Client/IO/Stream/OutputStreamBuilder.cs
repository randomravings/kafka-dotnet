using Kafka.Client.Config;
using Kafka.Client.Net;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.IO.Stream
{
    internal class OutputStreamBuilder :
        IOutputStreamBuilder
    {
        private readonly IConnectionManager<IClientConnection> _connections;
        private readonly OutputStreamConfig _config;
        private ILogger _logger = NullLogger.Instance;

        public OutputStreamBuilder(
            IConnectionManager<IClientConnection> connections,
            OutputStreamConfig config,
            ILogger logger
        )
        {
            _connections = connections;
            _config = config;
            _logger = logger;
        }

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
