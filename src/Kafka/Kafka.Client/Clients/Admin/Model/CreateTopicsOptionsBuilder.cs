using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed class CreateTopicsOptionsBuilder :
        AdminClientOptionsBuilder<CreateTopicsOptionsBuilder, CreateTopicsOptions>
    {
        private bool _validateOnly;
        private bool _retryOnQuotaViolation = true;
        private readonly List<CreateTopicOptions> _topics = new();
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

        public CreateTopicsOptionsBuilder NewTopic(Func<INewTopicBuilder, CreateTopicOptions> topicBuilder)
        {
            if(topicBuilder == null)
                throw new ArgumentNullException(nameof(topicBuilder));
            _topics.Add(topicBuilder(new NewTopicBuilder()));
            return this;
        }

        public override CreateTopicsOptions Build() =>
            new(
                TimeoutMs,
                _validateOnly,
                _retryOnQuotaViolation,
                _topics.ToImmutableArray()
            )
        ;

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

            CreateTopicOptions INewTopicBuilder.Build() =>
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
