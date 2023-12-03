using Kafka.Client.Config;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.IO.Stream
{
    internal class InputStreamBuilder :
        IInputStreamBuilder,
        IApplicationInputStreamBuilder,
        IManualInputStreamBuilder
    {
        private readonly SortedSet<TopicName> _topics = new(TopicNameCompare.Instance);
        private readonly ICluster<INodeLink> _connections;
        private readonly InputStreamConfig _config;
        private ILogger _logger = NullLogger.Instance;

        public InputStreamBuilder(
            ICluster<INodeLink> connections,
            InputStreamConfig config,
            ILogger logger
        )
        {
            _connections = connections;
            _config = config;
            _logger = logger;
        }

        IApplicationInputStreamBuilder IInputStreamBuilder.AsApplication(IReadOnlySet<TopicName> topics)
        {
            foreach (var topic in topics)
                _topics.Add(topic);
            return this;
        }

        IApplicationInputStreamBuilder IInputStreamBuilder.AsApplication(TopicName topic)
        {
            _topics.Add(topic);
            return this;
        }

        IManualInputStreamBuilder IInputStreamBuilder.AsManual() =>
            this
        ;

        IApplicationInputStreamBuilder IApplicationInputStreamBuilder.WithLogger(
            ILogger<IApplicationInputStream> logger
        )
        {
            _logger = logger;
            return this;
        }

        IApplicationInputStream IApplicationInputStreamBuilder.Build() =>
            new ApplicationInputStream(
                _connections,
                _topics,
                _config,
                _logger
            )
        ;

        IManualInputStreamBuilder IManualInputStreamBuilder.WithLogger(
            ILogger<IManualInputStream> logger
        )
        {
            _logger = logger;
            return this;
        }

        IManualInputStream IManualInputStreamBuilder.Build()
        {
            throw new NotImplementedException();
        }
    }
}
