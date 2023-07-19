using Kafka.Client.Exceptions;
using Kafka.Client.Messages;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Clients.Producer.Logging
{
    internal static partial class ProducerLog
    {
        [LoggerMessage(EventId = 1000, Level = LogLevel.Error, Message = "{header}|{error}", SkipEnabledCheck = true)]
        internal static partial void LogApiError(ILogger logger, RequestHeader header, Error error);

        [LoggerMessage(EventId = 1001, Level = LogLevel.Warning, Message = "{header}|{error}", SkipEnabledCheck = true)]
        internal static partial void LogErrorAsWaring(ILogger logger, RequestHeader header, Error error);

        [LoggerMessage(EventId = 2000, Level = LogLevel.Error, Message = "Error during connect", SkipEnabledCheck = false)]
        internal static partial void ConnectError(ILogger logger, OpenConnectionException exception);

        [LoggerMessage(EventId = 2001, Level = LogLevel.Error, Message = "Correlation Id mismatch", SkipEnabledCheck = false)]
        internal static partial void CorrelationMismatch(ILogger logger, CorrelationIdException exception);
    }
}
