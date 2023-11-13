using Kafka.Client.Config;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Logging
{
    public static partial class AdminLog
    {
        [LoggerMessage(EventId = 1000, Level = LogLevel.Information, Message = "{config}", SkipEnabledCheck = false)]
        public static partial void ClientConfig(this ILogger logger, KafkaClientConfig config);
    }
}
