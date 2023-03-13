using Kafka.Client.Messages;
using Kafka.Common.Model;

namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal sealed class TopicState
    {
        public TopicState(
            string topicName,
            long lastRefreshedMs,
            PartitionState[] partitionStates
        )
        {
            TopicName = topicName;
            LastRefreshedMs = lastRefreshedMs;
            PartitionStates = partitionStates;
        }
        public string TopicName { get; init; }
        public long LastRefreshedMs { get; init; }
        public PartitionState[] PartitionStates { get; init; }
    }
}
