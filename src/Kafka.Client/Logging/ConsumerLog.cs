using Kafka.Client.Config;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace Kafka.Client.Logging
{
    public static partial class ConsumerLog
    {
        [LoggerMessage(EventId = 1000, Level = LogLevel.Information, Message = "{config}", SkipEnabledCheck = false)]
        public static partial void ConsumerConfig(this ILogger logger, ReadStreamConfig config);

        [LoggerMessage(EventId = 1010, Level = LogLevel.Information, Message = "Joined consumer group {groupId} as member: {memberId}, generation: {generationId}, instance: {instanceId}, topicPartitions: {topicPartitions}", SkipEnabledCheck = false)]
        public static partial void ConsumerGroupJoin(this ILogger logger, string groupId, string memberId, int generationId, string? instanceId, IEnumerable<string> topicPartitions);

        [LoggerMessage(EventId = 1011, Level = LogLevel.Information, Message = "Left consumer group {groupId}", SkipEnabledCheck = false)]
        public static partial void ConsumerGroupLeave(this ILogger logger, string groupId);

        [LoggerMessage(EventId = 1012, Level = LogLevel.Warning, Message = "Left consumer group {groupId}, error: {error}", SkipEnabledCheck = false)]
        public static partial void ConsumerGroupLeaveError(this ILogger logger, string groupId, ApiError error);

        [LoggerMessage(EventId = 2000, Level = LogLevel.Information, Message = "Input stream pre configure.", SkipEnabledCheck = false)]
        public static partial void InputStreamPreConfigure(this ILogger logger);

        [LoggerMessage(EventId = 2001, Level = LogLevel.Information, Message = "Input stream post configure.", SkipEnabledCheck = false)]
        public static partial void InputStreamPostConfigure(this ILogger logger);

        [LoggerMessage(EventId = 2100, Level = LogLevel.Information, Message = "Fetch loop started", SkipEnabledCheck = false)]
        public static partial void FetchLoopStart(this ILogger logger);
        
        [LoggerMessage(EventId = 2101, Level = LogLevel.Information, Message = "Fetch loop stoppped", SkipEnabledCheck = false)]
        public static partial void FetchLoopStop(this ILogger logger);

        [LoggerMessage(EventId = 2102, Level = LogLevel.Warning, Message = "Error during fetch: {error}", SkipEnabledCheck = false)]
        public static partial void FetchError(this ILogger logger, ApiError error);

        [LoggerMessage(EventId = 2110, Level = LogLevel.Information, Message = "Consumer channel: {nodeId} starting for topic partitions: {assignments}", SkipEnabledCheck = false)]
        public static partial void ConsumerChannelStart(this ILogger logger, int nodeId, IEnumerable<string> assignments);
        [LoggerMessage(EventId = 2111, Level = LogLevel.Information, Message = "Consumer channel: {nodeId} records fetched: {records}", SkipEnabledCheck = false)]
        public static partial void RecordsFetched(this ILogger logger, int nodeId, IEnumerable<string> records);



        [LoggerMessage(EventId = 3000, Level = LogLevel.Information, Message = "Heartbeat loop started", SkipEnabledCheck = false)]
        public static partial void HeartbeatLoopStart(this ILogger logger);

        [LoggerMessage(EventId = 3001, Level = LogLevel.Information, Message = "Heartbeat loop stopped", SkipEnabledCheck = false)]
        public static partial void HeartbeatLoopStop(this ILogger logger);
        [LoggerMessage(EventId = 3002, Level = LogLevel.Information, Message = "Heartbeat loop paused for join", SkipEnabledCheck = false)]
        public static partial void HeartbeatLoopPreJoin(this ILogger logger);
        [LoggerMessage(EventId = 3003, Level = LogLevel.Information, Message = "Heartbeat resumed after join", SkipEnabledCheck = false)]
        public static partial void HeartbeatLoopPostJoin(this ILogger logger);

        [LoggerMessage(EventId = 3999, Level = LogLevel.Warning, Message = "Heartbeat loop error: {error}", SkipEnabledCheck = false)]
        public static partial void HeartBeatError(this ILogger logger, ApiError error);


        [LoggerMessage(EventId = 3101, Level = LogLevel.Warning, Message = "Topic partition already assigned '{topic}:{partition}'", SkipEnabledCheck = false)]
        public static partial void TopicPartitionNotAssigned(this ILogger logger, string topic, int partition);
        [LoggerMessage(EventId = 3102, Level = LogLevel.Warning, Message = "Topic partition not assigned '{topic}:{partition}'", SkipEnabledCheck = false)]
        public static partial void TopicPartitionNotAdded(this ILogger logger, string topic, int partition);


        [LoggerMessage(EventId = 4000, Level = LogLevel.Information, Message = "Commit loop entered", SkipEnabledCheck = false)]
        public static partial void CommitLoopStart(this ILogger logger);

        [LoggerMessage(EventId = 4001, Level = LogLevel.Information, Message = "Commit loop exit", SkipEnabledCheck = false)]
        public static partial void CommitLoopStop(this ILogger logger);

        [LoggerMessage(EventId = 4002, Level = LogLevel.Information, Message = "Commit loop error: {error}", SkipEnabledCheck = false)]
        public static partial void CommitLoopError(this ILogger logger, ApiError error);

        [LoggerMessage(EventId = 4003, Level = LogLevel.Warning, Message = "Commit error {topic}:{partition}:{error}", SkipEnabledCheck = false)]
        public static partial void CommitLoopTopicPartitionError(this ILogger logger, string topic, int partition, ApiError error);

        [LoggerMessage(EventId = 4004, Level = LogLevel.Warning, Message = "Commit operation cancelled", SkipEnabledCheck = false)]
        public static partial void CommitLoopInterrupted(this ILogger logger);

        [LoggerMessage(EventId = 5101, Level = LogLevel.Warning, Message = "Unexpected correllation id: '{correllationId}'", SkipEnabledCheck = false)]
        public static partial void UnexpectedCorrellationId(this ILogger logger, int correllationId);
        [LoggerMessage(EventId = 5901, Level = LogLevel.Warning, Message = "Socket exception during send", SkipEnabledCheck = false)]
        public static partial void SndSocketException(this ILogger logger, SocketException ex);
        [LoggerMessage(EventId = 5902, Level = LogLevel.Warning, Message = "Socket exception during receive", SkipEnabledCheck = false)]
        public static partial void RcvSocketException(this ILogger logger, SocketException ex);
    }
}
