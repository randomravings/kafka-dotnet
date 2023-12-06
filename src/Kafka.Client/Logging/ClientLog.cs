using Kafka.Client.Messages;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace Kafka.Client.Logging
{
    internal static partial class ClientLog
    {
        [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "{header}|{error}", SkipEnabledCheck = true)]
        internal static partial void LogApiError(this ILogger logger, in RequestHeaderData header, in ApiError error);
        [LoggerMessage(EventId = 1002, Level = LogLevel.Warning, Message = "No valid bootstrap servers", SkipEnabledCheck = false)]
        internal static partial void EmptyBootstrapServers(this ILogger logger);
        [LoggerMessage(EventId = 1003, Level = LogLevel.Error, Message = "Invalid bootstrap url: {bootstrapUrl}", SkipEnabledCheck = false)]
        internal static partial void InvalidBootstrapUrl(this ILogger logger, in string bootstrapUrl);

        [LoggerMessage(EventId = 2000, Level = LogLevel.Error, Message = "Error during connect", SkipEnabledCheck = false)]
        internal static partial void ConnectError(this ILogger logger, in OpenConnectionException exception);

        [LoggerMessage(EventId = 5101, Level = LogLevel.Warning, Message = "Unexpected correllation id: '{correllationId}'", SkipEnabledCheck = false)]
        public static partial void UnexpectedCorrellationId(this ILogger logger, in int correllationId);
        [LoggerMessage(EventId = 5901, Level = LogLevel.Warning, Message = "Socket exception during send", SkipEnabledCheck = false)]
        public static partial void SndSocketException(this ILogger logger, in SocketException ex);
        [LoggerMessage(EventId = 5902, Level = LogLevel.Warning, Message = "Socket exception during receive", SkipEnabledCheck = false)]
        public static partial void RcvSocketException(this ILogger logger, in SocketException ex);
    }
}
