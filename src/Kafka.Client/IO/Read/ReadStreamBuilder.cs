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
        IGroupReadStreamBuilder,
        IAssignedReadStreamBuilder
    {
        private readonly ICluster<INodeLink> _cluster = cluster;
        private readonly ReadStreamConfig _config = config;
        private ILogger _logger = logger;

        IReadStreamBuilder IReadStreamBuilder.WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        public IGroupReadStreamBuilder AsGroup() =>
            this
        ;

        public IAssignedReadStreamBuilder AsAssigned() =>
            this
        ;

        IGroupReadStream IGroupReadStreamBuilder.Build() =>
            new GroupReadStream(
                _cluster,
                _config,
                _logger
            )
        ;

        IAssignedReadStream IAssignedReadStreamBuilder.Build() =>
            new AssignedReadStream(
                _cluster,
                _config,
                _logger
            )
        ;
    }
}
