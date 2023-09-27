using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed class DescribeTopicsOptionsBuilder :
        AdminClientOptionsBuilder<DescribeTopicsOptionsBuilder, DescribeTopicsOptions>
    {
        private readonly List<Guid> _topicIds = new();
        private readonly List<string> _topicNames = new();
        private bool _includeTopicAuthorizedOperations;
        public DescribeTopicsOptionsBuilder(AdminClientConfig adminClientConfig)
            : base(adminClientConfig) { }

        public DescribeTopicsOptionsBuilder Topic(string topic)
        {
            if (Guid.TryParse(topic, out var topicId))
                _topicIds.Add(topicId);
            if (!string.IsNullOrEmpty(topic))
                _topicNames.Add(topic);
            return this;
        }

        public DescribeTopicsOptionsBuilder IncludeTopicAuthorizedOperations(bool includeTopicAuthorizedOperations)
        {
            _includeTopicAuthorizedOperations = includeTopicAuthorizedOperations;
            return this;
        }

        public override DescribeTopicsOptions Build() =>
            new(
                TimeoutMs,
                _topicIds.ToImmutableArray(),
                _topicNames.ToImmutableArray(),
                _includeTopicAuthorizedOperations
            )
        ;
    }
}
