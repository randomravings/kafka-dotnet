using Kafka.Client.Config;
using Kafka.Client.Net;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Read
{
    internal class ReadStreamBuilder(
        ICluster<INodeLink> cluster,
        ReadStreamConfig config,
        ILogger logger
    ) :
        IReadStreamBuilder,
        IApplicationReadStreamBuilder,
        IManualReadStreamBuilder
    {
        private readonly ICluster<INodeLink> _cluster = cluster;
        private readonly ReadStreamConfig _config = config;
        private ILogger _logger = logger;

        IReadStreamBuilder IReadStreamBuilder.WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        public IApplicationReadStreamBuilder AsApplication() =>
            this
        ;

        public IManualReadStreamBuilder AsManual() =>
            this
        ;

        IApplicationReadStream IApplicationReadStreamBuilder.Build() =>
            new ApplicationReadStream(
                _cluster,
                _config,
                _logger
            )
        ;

        IManualReadStream IManualReadStreamBuilder.Build() =>
            new ManualReadStream(
                _cluster,
                _config,
                _logger
            )
        ;
    }
}
