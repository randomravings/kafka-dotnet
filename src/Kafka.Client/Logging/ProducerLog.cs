using Kafka.Client.Config;
using Kafka.Client.Model;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Logging
{
    internal static partial class ProducerLog
    {
        [LoggerMessage(EventId = 2000, Level = LogLevel.Information, Message = "{config}", SkipEnabledCheck = false)]
        public static partial void ProducerConfig(this ILogger logger, OutputStreamConfig config);
        [LoggerMessage(EventId = 2001, Level = LogLevel.Warning, Message = "Topic: {topic}, Error: {error}", SkipEnabledCheck = true)]
        internal static partial void ProducePartitionError(this ILogger logger, string topic, Error error);

        [LoggerMessage(EventId = 2002, Level = LogLevel.Trace, Message = "Record collector queued {count} records ({reason})")]
        internal static partial void BatchCollected(this ILogger logger, int count, BatchCollectReason reason);

        [LoggerMessage(EventId = 2003, Level = LogLevel.Trace, Message = "Record dispatcher dequeued {recordCount} records")]
        internal static partial void ProduceCommandDequeue(this ILogger logger, int recordCount);

        [LoggerMessage(EventId = 2004, Level = LogLevel.Trace, Message = "Unknown value 'acks={acks}, defaulting to 'acks=all'")]
        internal static partial void DefaultAcks(this ILogger logger, string acks);

        [LoggerMessage(EventId = 2101, Level = LogLevel.Trace, Message = "Transaction begin")]
        internal static partial void TransactionBegin(this ILogger logger);
        [LoggerMessage(EventId = 2102, Level = LogLevel.Trace, Message = "Transaction comitted")]
        internal static partial void TransactionCommit(this ILogger logger);
        [LoggerMessage(EventId = 2103, Level = LogLevel.Trace, Message = "Transaction rolback")]
        internal static partial void TransactionRollback(this ILogger logger);
        [LoggerMessage(EventId = 2104, Level = LogLevel.Trace, Message = "Transaction partition adeed: {topicPartition}")]
        internal static partial void TransactionAdd(this ILogger logger, TopicPartition topicPartition);
    }
}
