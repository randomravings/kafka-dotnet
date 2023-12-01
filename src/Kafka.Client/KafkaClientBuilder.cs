using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Model.Internal;
using Kafka.Client.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Immutable;
using System.Net;

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
            var bootstrapServers = GetBootstrapServers(
                _config,
                _logger
            );
            return new KafkaClient(
                bootstrapServers,
                _config,
                _logger
            );
        }

        private static ImmutableArray<BootstrapServer> GetBootstrapServers(
            in KafkaClientConfig kafkaClientConfig,
            in ILogger<IKafkaClient> logger
        )
        {
            var bootstrapUrls = kafkaClientConfig
                .Client
                .BootstrapServers
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
            ;
            var bootstrapServersBuilder = ImmutableArray.CreateBuilder<BootstrapServer>();
            foreach(var bootstrapUrl in bootstrapUrls)
            {
                var hostAndPort = bootstrapUrl.Split(':', StringSplitOptions.RemoveEmptyEntries);
                if(hostAndPort.Length != 2)
                {
                    logger.InvalidBootstrapUrl(bootstrapUrl);
                    continue;
                }
                var host = hostAndPort[0].Trim();
                if (host.Length < 1)
                {
                    logger.InvalidBootstrapUrl(bootstrapUrl);
                    continue;
                }
                if (!int.TryParse(hostAndPort[1], out var port))
                {
                    logger.InvalidBootstrapUrl(bootstrapUrl);
                    continue;
                }
                bootstrapServersBuilder.Add((host, port));
            }
            var bootstrapServers = bootstrapServersBuilder.ToImmutable();
            if (bootstrapServers.Length == 0)
                logger.EmptyBootstrapServers();
            return bootstrapServers;
        }
    }
}
