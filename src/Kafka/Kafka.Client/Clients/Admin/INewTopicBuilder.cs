using Kafka.Client.Clients.Admin.Model;

namespace Kafka.Client.Clients.Admin
{
    public interface INewTopicBuilder
    {
        INewTopicBuilder Name(string name);
        INewTopicBuilder NumPartitions(int numPartitions);
        INewTopicBuilder ReplicationFactor(short replicationFactor);
        INewTopicBuilder ReplicasAssignments(int partition, params int[] replicas);
        INewTopicBuilder ReplicasAssignments(IDictionary<int, int[]> assinments);
        INewTopicBuilder Configs(string key, string? value);
        CreateTopicOptions Build();
    }
}
