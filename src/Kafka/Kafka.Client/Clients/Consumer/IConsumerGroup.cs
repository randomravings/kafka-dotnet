using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal interface IConsumerGroup
    {
        Task<IConsumerGroupInstance> JoinGroup(IReadOnlySet<TopicName> topics, CancellationToken cancellationToken);
    }

    internal interface IConsumerGroupInstance
    {
        IDictionary<TopicPartition, Offset> ReadOffsets { get; }
        CoordinatorState State { get; }
        Task Start(CancellationToken cancellationToken);
        Task Close(CancellationToken cancellationToken);
        ImmutableArray<NodeAssignment> NodeAssignments { get; }
        void AddOffset(TopicPartition topicPartition, Offset offset);
        Task<CommitResult> Commit();
        Task<CommitResult> Commit(TopicPartition topicPartition, Offset offset);
        CancellationToken CancellationToken { get; }
    }
}
