using Kafka.Client.Config;
using Kafka.Client;
using Kafka.Client.Net;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Write
{
    internal class WriteStreamBuilder(
        ICluster<INodeLink> connections,
        WriteStreamConfig config,
        ILogger logger
    ) :
        IWriteStreamBuilder
    {
        private readonly ICluster<INodeLink> _connections = connections;
        private readonly WriteStreamConfig _config = config;
        private ILogger _logger = logger;

        IWriteStreamBuilder IWriteStreamBuilder.WithLogger(
            ILogger<IWriteStream> logger
        )
        {
            _logger = logger;
            return this;
        }

        IWriteStream IWriteStreamBuilder.Build() =>
            new WriteStream(
                _connections,
                _config,
                _logger
            )
        ;
    }
}
