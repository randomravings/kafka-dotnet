using Kafka.Client.Config;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace Kafka.Client.Logging
{
    public static partial class ReadStreamLog
    {
        [LoggerMessage(EventId = 1000, Level = LogLevel.Information, Message = "{config}", SkipEnabledCheck = false)]
        public static partial void ReadStreamConfig(this ILogger logger, in ReadStreamConfig config);

        [LoggerMessage(EventId = 1010, Level = LogLevel.Information, Message = "Joined consumer group {groupId} as member: {memberId}, generation: {generationId}, instance: {instanceId}, topicPartitions: {topicPartitions}", SkipEnabledCheck = false)]
        public static partial void ConsumerGroupJoin(this ILogger logger, in string groupId, in string memberId, in int generationId, in string? instanceId, in IEnumerable<string> topicPartitions);

        [LoggerMessage(EventId = 1011, Level = LogLevel.Information, Message = "Left consumer group {groupId}", SkipEnabledCheck = false)]
        public static partial void ConsumerGroupLeave(this ILogger logger, in string groupId);

        [LoggerMessage(EventId = 1012, Level = LogLevel.Warning, Message = "Left consumer group {groupId}, error: {error}", SkipEnabledCheck = false)]
        public static partial void ConsumerGroupLeaveError(this ILogger logger, in string groupId, in ApiError error);

        [LoggerMessage(EventId = 1013, Level = LogLevel.Warning, Message = "Unexpected topic partition during sync {topicPartition}", SkipEnabledCheck = false)]
        public static partial void ConsumerGroupUnexpectedTopicPartition(this ILogger logger, in TopicPartition topicPartition);

        [LoggerMessage(EventId = 2000, Level = LogLevel.Information, Message = "Input stream pre configure.", SkipEnabledCheck = false)]
        public static partial void InputStreamPreConfigure(this ILogger logger);

        [LoggerMessage(EventId = 2001, Level = LogLevel.Information, Message = "Input stream post configure.", SkipEnabledCheck = false)]
        public static partial void InputStreamPostConfigure(this ILogger logger);

        [LoggerMessage(EventId = 2100, Level = LogLevel.Information, Message = "Fetch loop started for node: {nodeId}", SkipEnabledCheck = false)]
        public static partial void FetchLoopStart(this ILogger logger, in NodeId nodeId);
        
        [LoggerMessage(EventId = 2101, Level = LogLevel.Information, Message = "Fetch loop stoppped for node: {nodeId}", SkipEnabledCheck = false)]
        public static partial void FetchLoopStop(this ILogger logger, in NodeId nodeId);


        [LoggerMessage(EventId = 3000, Level = LogLevel.Information, Message = "Heartbeat loop started", SkipEnabledCheck = false)]
        public static partial void HeartbeatLoopStart(this ILogger logger);

        [LoggerMessage(EventId = 3001, Level = LogLevel.Information, Message = "Heartbeat loop stopped", SkipEnabledCheck = false)]
        public static partial void HeartbeatLoopStop(this ILogger logger);
        [LoggerMessage(EventId = 3002, Level = LogLevel.Information, Message = "Heartbeat loop paused for join", SkipEnabledCheck = false)]
        public static partial void HeartbeatLoopPreJoin(this ILogger logger);
        [LoggerMessage(EventId = 3003, Level = LogLevel.Information, Message = "Heartbeat resumed after join", SkipEnabledCheck = false)]
        public static partial void HeartbeatLoopPostJoin(this ILogger logger);

        [LoggerMessage(EventId = 3999, Level = LogLevel.Warning, Message = "Heartbeat loop error: {error}", SkipEnabledCheck = false)]
        public static partial void HeartBeatError(this ILogger logger, in ApiError error);


        [LoggerMessage(EventId = 4000, Level = LogLevel.Information, Message = "Commit loop entered", SkipEnabledCheck = false)]
        public static partial void CommitLoopStart(this ILogger logger);

        [LoggerMessage(EventId = 4001, Level = LogLevel.Information, Message = "Commit loop exit", SkipEnabledCheck = false)]
        public static partial void CommitLoopStop(this ILogger logger);

        [LoggerMessage(EventId = 4003, Level = LogLevel.Warning, Message = "Commit error {topic}:{partition}:{error}", SkipEnabledCheck = false)]
        public static partial void CommitLoopTopicPartitionError(this ILogger logger, string topic, int partition, ApiError error);

        [LoggerMessage(EventId = 4004, Level = LogLevel.Warning, Message = "Commit operation cancelled", SkipEnabledCheck = false)]
        public static partial void CommitLoopInterrupted(this ILogger logger);
    }
}
