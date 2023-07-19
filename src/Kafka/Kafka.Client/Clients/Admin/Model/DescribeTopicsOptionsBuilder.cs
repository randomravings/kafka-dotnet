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

        public DescribeTopicsOptionsBuilder TopicId(Guid topicId)
        {
            if (topicId != Guid.Empty)
                _topicIds.Add(topicId);
            return this;
        }

        public DescribeTopicsOptionsBuilder TopicName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _topicNames.Add(name);
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
