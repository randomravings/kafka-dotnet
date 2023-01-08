using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed class CreateTopicsOptionsBuilder :
        ClientOptionsBuilder<CreateTopicsOptionsBuilder, CreateTopicsOptions>
    {
        private bool _validateOnly = false;
        private bool _retryOnQuotaViolation = true;
        private readonly List<CreateTopicsOptions.NewTopic> _topics = new();
        public CreateTopicsOptionsBuilder(AdminClientConfig adminClientConfig)
            : base(adminClientConfig) { }

        public CreateTopicsOptionsBuilder ValidateOnly(bool validateOnly)
        {
            _validateOnly = validateOnly;
            return this;
        }

        public CreateTopicsOptionsBuilder RetryOnQuotaViolation(bool retryOnQuotaViolation)
        {
            _retryOnQuotaViolation = retryOnQuotaViolation;
            return this;
        }

        public CreateTopicsOptionsBuilder NewTopic(Func<INewTopicBuilder, CreateTopicsOptions.NewTopic> topicBuilder)
        {
            _topics.Add(topicBuilder(new NewTopicBuilder()));
            return this;
        }

        public override CreateTopicsOptions Build() =>
            new(
                _timeoutMs,
                _validateOnly,
                _retryOnQuotaViolation,
                _topics.ToImmutableArray()
            )
        ;

        public interface INewTopicBuilder
        {
            INewTopicBuilder Name(string name);
            INewTopicBuilder NumPartitions(int numPartitions);
            INewTopicBuilder ReplicationFactor(short replicationFactor);
            INewTopicBuilder ReplicasAssignments(int partition, params int[] replicas);
            INewTopicBuilder ReplicasAssignments(IDictionary<int, int[]> assinments);
            INewTopicBuilder Configs(string key, string ? value);
            CreateTopicsOptions.NewTopic Build();
        }

        private sealed class NewTopicBuilder :
            INewTopicBuilder
        {
            private string _name = "";
            private int _numPartitions = -1;
            private short _replicationFactor = -1;
            private readonly Dictionary<int, int[]> _replicasAssignments = new();
            private readonly Dictionary<string, string?> _configs = new();

            INewTopicBuilder INewTopicBuilder.Configs(string key, string? value)
            {
                _configs.Add(key, value);
                return this;
            }

            INewTopicBuilder INewTopicBuilder.Name(string name)
            {
                _name = name;
                return this;
            }

            INewTopicBuilder INewTopicBuilder.NumPartitions(int numPartitions)
            {
                _numPartitions = numPartitions;
                return this;
            }

            INewTopicBuilder INewTopicBuilder.ReplicasAssignments(int partition, params int[] replicas)
            {
                _replicasAssignments.Add(partition, replicas);
                return this;
            }

            INewTopicBuilder INewTopicBuilder.ReplicasAssignments(IDictionary<int, int[]> assignments)
            {
                foreach (var assignment in assignments)
                    _replicasAssignments.Add(assignment.Key, assignment.Value);
                return this;
            }

            INewTopicBuilder INewTopicBuilder.ReplicationFactor(short replicationFactor)
            {
                _replicationFactor = replicationFactor;
                return this;
            }

            CreateTopicsOptions.NewTopic INewTopicBuilder.Build() =>
                new(
                    _name,
                    _numPartitions,
                    _replicationFactor,
                    _replicasAssignments.ToImmutableSortedDictionary(
                        k => k.Key,
                        v => v.Value.ToImmutableArray()
                    ),
                    _configs.ToImmutableSortedDictionary()
                )
            ;
        }
    }
}
