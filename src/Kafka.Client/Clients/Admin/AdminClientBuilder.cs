using Kafka.Client.Clients.Admin.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kafka.Client.Clients.Admin
{
    public interface INewAdminClientBuilder
    {
        IAdminClientBuilder WithConfig(AdminClientConfig consumerConfig);
    }

    public interface IAdminClientBuilder
    {
        IAdminClientBuilder WithLogger(ILogger<IAdminClient> logger);
        IAdminClient Build();
    }

    public sealed class AdminClientBuilder :
        INewAdminClientBuilder,
        IAdminClientBuilder
    {
        private AdminClientConfig _config = new();
        private ILogger<IAdminClient> _logger = NullLogger<IAdminClient>.Instance;
        private AdminClientBuilder() { }
        public static INewAdminClientBuilder New() =>
            new AdminClientBuilder()
        ;
        IAdminClientBuilder INewAdminClientBuilder.WithConfig(AdminClientConfig config)
        {
            _config = config;
            return this;
        }

        IAdminClientBuilder IAdminClientBuilder.WithLogger(ILogger<IAdminClient> logger)
        {
            _logger = logger;
            return this;
        }

        IAdminClient IAdminClientBuilder.Build()
        {
            _logger.AdminConfig(_config);
            return new KafkaAdminClient(_config, _logger);
        }
    }
}
