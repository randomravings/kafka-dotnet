using Kafka.Common.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.Clients.Consumer.Logging
{
    public static partial class ConsumerLog
    {
        [LoggerMessage(EventId = 1000, Level = LogLevel.Information, Message = "{config}", SkipEnabledCheck = false)]
        public static partial void ConsumerConfig(this ILogger logger, ConsumerConfig config);

        [LoggerMessage(EventId = 1010, Level = LogLevel.Information, Message = "Joined consumer group {groupId} as member: {memberId}, generation: {generationId}, instance: {instanceId}, topicPartitions: {topicPartitions}", SkipEnabledCheck = false)]
        public static partial void ConsumerGroupJoin(this ILogger logger, string groupId, string memberId, int generationId, string? instanceId, IEnumerable<string> topicPartitions);

        [LoggerMessage(EventId = 1011, Level = LogLevel.Information, Message = "Left consumer group {groupId}", SkipEnabledCheck = false)]
        public static partial void ConsumerGroupLeave(this ILogger logger, string groupId);

        [LoggerMessage(EventId = 1012, Level = LogLevel.Warning, Message = "Left consumer group {groupId}, error: {error}", SkipEnabledCheck = false)]
        public static partial void ConsumerGroupLeaveError(this ILogger logger, string groupId, Error error);

        [LoggerMessage(EventId = 2000, Level = LogLevel.Information, Message = "Fetch loop started", SkipEnabledCheck = false)]
        public static partial void FetchLoopStart(this ILogger logger);
        
        [LoggerMessage(EventId = 2001, Level = LogLevel.Information, Message = "Fetch loop stoppped", SkipEnabledCheck = false)]
        public static partial void FetchLoopStop(this ILogger logger);

        [LoggerMessage(EventId = 2002, Level = LogLevel.Warning, Message = "Error during fetch: {error}", SkipEnabledCheck = false)]
        public static partial void FetchError(this ILogger logger, Error error);

        [LoggerMessage(EventId = 2010, Level = LogLevel.Information, Message = "Consumer channel: {nodeId} starting for topic partitions: {assignments}", SkipEnabledCheck = false)]
        public static partial void ConsumerChannelStart(this ILogger logger, int nodeId, IEnumerable<string> assignments);
        [LoggerMessage(EventId = 2011, Level = LogLevel.Information, Message = "Consumer channel: {nodeId} records fetched: {records}", SkipEnabledCheck = false)]
        public static partial void RecordsFetched(this ILogger logger, int nodeId, IEnumerable<string> records);



        [LoggerMessage(EventId = 3000, Level = LogLevel.Information, Message = "Heartbeat loop started", SkipEnabledCheck = false)]
        public static partial void HeartbeatLoopStart(this ILogger logger);

        [LoggerMessage(EventId = 3001, Level = LogLevel.Information, Message = "Heartbeat loop stopped", SkipEnabledCheck = false)]
        public static partial void HeartbeatLoopStop(this ILogger logger);

        [LoggerMessage(EventId = 3002, Level = LogLevel.Warning, Message = "Heartbeat loop error: {error}", SkipEnabledCheck = false)]
        public static partial void HeartBeatError(this ILogger logger, Error error);


        [LoggerMessage(EventId = 4000, Level = LogLevel.Information, Message = "Commit loop entered", SkipEnabledCheck = false)]
        public static partial void CommitLoopStart(this ILogger logger);

        [LoggerMessage(EventId = 4001, Level = LogLevel.Information, Message = "Commit loop exit", SkipEnabledCheck = false)]
        public static partial void CommitLoopStop(this ILogger logger);

        [LoggerMessage(EventId = 4002, Level = LogLevel.Information, Message = "Commit loop error: {error}", SkipEnabledCheck = false)]
        public static partial void CommitLoopError(this ILogger logger, Error error);

        [LoggerMessage(EventId = 4003, Level = LogLevel.Warning, Message = "Commit error {topic}:{partition}:{error}", SkipEnabledCheck = false)]
        public static partial void CommitLoopTopicPartitionError(this ILogger logger, string topic, int partition, Error error);

        [LoggerMessage(EventId = 4004, Level = LogLevel.Warning, Message = "Commit operation cancelled", SkipEnabledCheck = false)]
        public static partial void CommitLoopInterrupted(this ILogger logger);
    }
}
