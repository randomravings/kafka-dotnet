using Kafka.Common.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Clients.Consumer.Logging
{
    public static partial class ConsumerLog
    {
        [LoggerMessage(EventId = 1000, Level = LogLevel.Error, Message = "Error during fetch: {error}", SkipEnabledCheck = false)]
        public static partial void FetchError(this ILogger logger, Error error);

        [LoggerMessage(EventId = 3000, Level = LogLevel.Warning, Message = "Error during heartbeat: {error}", SkipEnabledCheck = false)]
        public static partial void HeartBeatError(this ILogger logger, Error error);

        [LoggerMessage(EventId = 3001, Level = LogLevel.Information, Message = "Heartbeat loop exited", SkipEnabledCheck = true)]
        public static partial void HeartbeatExit(this ILogger logger);
    }
}
