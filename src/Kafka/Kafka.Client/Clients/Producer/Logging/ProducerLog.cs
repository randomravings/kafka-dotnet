using Kafka.Client.Clients.Producer.Model.Internal;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Clients.Producer.Logging
{
    internal static partial class ProducerLog
    {
        [LoggerMessage(EventId = 2000, Level = LogLevel.Warning, Message = "Topic: {topic}, Error: {error}", SkipEnabledCheck = true)]
        internal static partial void ProducePartitionError(ILogger logger, string topic, Error error);

        [LoggerMessage(EventId = 9000, Level = LogLevel.Trace, Message = "Collect reason: {reason}, count: {count}")]
        internal static partial void BatchCollected(ILogger logger, BatchCollectReason reason, int count);

        [LoggerMessage(EventId = 9001, Level = LogLevel.Trace, Message = "Record Builder dequeued {recordCount} records")]
        internal static partial void ProduceCommandDequeue(ILogger logger, int recordCount);
    }
}
