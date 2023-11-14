﻿using Kafka.Client.Messages;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Logging
{
    internal static partial class ClientLog
    {
        [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "{header}|{error}", SkipEnabledCheck = true)]
        internal static partial void LogApiError(this ILogger logger, RequestHeaderData header, Error error);


        [LoggerMessage(EventId = 2000, Level = LogLevel.Error, Message = "Error during connect", SkipEnabledCheck = false)]
        internal static partial void ConnectError(this ILogger logger, OpenConnectionException exception);

        [LoggerMessage(EventId = 2001, Level = LogLevel.Error, Message = "Correlation Id mismatch", SkipEnabledCheck = false)]
        internal static partial void CorrelationMismatch(this ILogger logger, CorrelationIdException exception);
    }
}