using Kafka.Client.Config;
using Kafka.Client.Model.Internal;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Logging
{
    internal static partial class WriteStreamLog
    {
        [LoggerMessage(EventId = 2000, Level = LogLevel.Information, Message = "{config}", SkipEnabledCheck = false)]
        public static partial void WriteStreamConfig(this ILogger logger, in WriteStreamConfig config);
        [LoggerMessage(EventId = 2001, Level = LogLevel.Information, Message = "Write Stream instance created with id: {producerId}, epoch: {producerEpoch}, idempotent: {idempotent}, transaction id: {transactionalId}.", SkipEnabledCheck = true)]
        internal static partial void WriteInstance(this ILogger logger, in long producerId, in short producerEpoch, bool idempotent, string? transactionalId);

        [LoggerMessage(EventId = 2010, Level = LogLevel.Information, Message = "Write Channel {nodeId} - Batch Collector started")]
        internal static partial void BatchCollectorStarted(this ILogger logger, in NodeId nodeId);

        [LoggerMessage(EventId = 2011, Level = LogLevel.Information, Message = "Write Channel {nodeId} - Batch Collector stopped")]
        internal static partial void BatchCollectorStopped(this ILogger logger, in NodeId nodeId);

        [LoggerMessage(EventId = 2012, Level = LogLevel.Trace, Message = "Write Channel {nodeId} - Batch Collector batched {count} records ({reason})")]
        internal static partial void BatchCollected(this ILogger logger, in NodeId nodeId, in int count, in BatchCollectReason reason);

        [LoggerMessage(EventId = 2020, Level = LogLevel.Information, Message = "Write Channel {nodeId} - Dispatcher started")]
        internal static partial void DispatcherStarted(this ILogger logger, in NodeId nodeId);

        [LoggerMessage(EventId = 2021, Level = LogLevel.Information, Message = "Write Channel {nodeId} - Dispatcher stopped")]
        internal static partial void DispatcherStopped(this ILogger logger, in NodeId nodeId);
        [LoggerMessage(EventId = 2022, Level = LogLevel.Trace, Message = "Write Channel {nodeId} - Record dispatcher dequeued {recordCount} records")]
        internal static partial void DispatcherDequeue(this ILogger logger, in NodeId nodeId, in int recordCount);

        [LoggerMessage(EventId = 2004, Level = LogLevel.Trace, Message = "Write Channel {nodeId} - Unknown value 'acks={acks}, defaulting to 'acks=all'")]
        internal static partial void DefaultAcks(this ILogger logger, in NodeId nodeId, in string acks);

        [LoggerMessage(EventId = 2100, Level = LogLevel.Information, Message = "Transaction coordinator for write stream is node: {nodeId}", SkipEnabledCheck = true)]
        internal static partial void TransactionCoordinator(this ILogger logger, in NodeId nodeId);
        [LoggerMessage(EventId = 2101, Level = LogLevel.Information, Message = "Transaction begin")]
        internal static partial void TransactionBegin(this ILogger logger);
        [LoggerMessage(EventId = 2102, Level = LogLevel.Information, Message = "Transaction comitted")]
        internal static partial void TransactionCommit(this ILogger logger);
        [LoggerMessage(EventId = 2103, Level = LogLevel.Information, Message = "Transaction rolback")]
        internal static partial void TransactionRollback(this ILogger logger);
        [LoggerMessage(EventId = 2104, Level = LogLevel.Information, Message = "Transaction partition adeed: {topicPartition}")]
        internal static partial void TransactionAdd(this ILogger logger, TopicPartition topicPartition);

        [LoggerMessage(EventId = 2201, Level = LogLevel.Trace, Message = "Partition selected: {partition}")]
        internal static partial void PartitionSelection(this ILogger logger, Partition partition);
    }
}
