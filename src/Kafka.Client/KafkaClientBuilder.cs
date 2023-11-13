using Kafka.Client.Config;
using Kafka.Client.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client
{
    public sealed class KafkaClientBuilder :
            IKafkaClientBuilder
    {
        private KafkaClientConfig _config = new();
        private ILogger<IKafkaClient> _logger = NullLogger<IKafkaClient>.Instance;
        private KafkaClientBuilder() { }
        public static IKafkaClientBuilder New() =>
            new KafkaClientBuilder()
        ;
        IKafkaClientBuilder IKafkaClientBuilder.WithConfig(KafkaClientConfig config)
        {
            _config = config;
            return this;
        }

        IKafkaClientBuilder IKafkaClientBuilder.WithLogger(ILogger<IKafkaClient> logger)
        {
            _logger = logger;
            return this;
        }

        IKafkaClient IKafkaClientBuilder.Build()
        {
            _logger.ClientConfig(_config);
            return new KafkaClient(_config, _logger);
        }
    }
}
