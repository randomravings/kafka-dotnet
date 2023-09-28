using Microsoft.Extensions.Logging;

namespace Kafka.Client.Clients.Admin.Logging
{
    public static partial class AdminLog
    {
        [LoggerMessage(EventId = 1000, Level = LogLevel.Information, Message = "{config}", SkipEnabledCheck = false)]
        public static partial void AdminConfig(this ILogger logger, AdminClientConfig config);
    }
}
