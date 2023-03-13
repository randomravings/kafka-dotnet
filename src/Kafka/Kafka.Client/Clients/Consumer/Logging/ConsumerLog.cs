using Kafka.Common.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Client.Clients.Consumer.Logging
{
    public static partial class ConsumerLog
    {
        [LoggerMessage(EventId = 1000, EventName = nameof(FetchError), Level = LogLevel.Error, Message = "Error during fetch: {error}", SkipEnabledCheck = false)]
        public static partial void FetchError(this ILogger logger, Error error);
    }
}
