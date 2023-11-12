using Kafka.Client.Config;
using Kafka.Client.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.Clients.Admin
{
    public interface IClientBuilder
    {
        IClientBuilder WithConfig(ClientConfig config);
        IClientBuilder WithLogger(ILogger<IClient> logger);
        IClient Build();
    }

    public sealed class ClientBuilder :
        IClientBuilder
    {
        private ClientConfig _config = new();
        private ILogger<IClient> _logger = NullLogger<IClient>.Instance;
        private ClientBuilder() { }
        public static IClientBuilder New() =>
            new ClientBuilder()
        ;
        IClientBuilder IClientBuilder.WithConfig(ClientConfig config)
        {
            _config = config;
            return this;
        }

        IClientBuilder IClientBuilder.WithLogger(ILogger<IClient> logger)
        {
            _logger = logger;
            return this;
        }

        IClient IClientBuilder.Build()
        {
            _logger.ClientConfig(_config);
            return new KafkaClient(_config, _logger);
        }
    }
}
