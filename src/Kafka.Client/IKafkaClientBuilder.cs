using Kafka.Client.Config;
using Microsoft.Extensions.Logging;

namespace Kafka.Client
{
    public interface IKafkaClientBuilder
    {
        IKafkaClientBuilder WithConfig(
            KafkaClientConfig config
        );
        IKafkaClientBuilder WithLogger(
            ILogger<IKafkaClient> logger
        );
        IKafkaClient Build();
    }
}
