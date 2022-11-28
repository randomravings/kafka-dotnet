using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed class DeleteTopicsOptionsBuilder :
        ClientOptionsBuilder<DeleteTopicsOptionsBuilder, DeleteTopicsOptions>
    {
        private readonly List<Guid> _topicIds = new();
        private readonly List<string> _topicNames = new();
        public DeleteTopicsOptionsBuilder(AdminClientConfig adminClientConfig)
            : base(adminClientConfig) { }

        public DeleteTopicsOptionsBuilder TopicId(Guid topicId)
        {
            if (topicId != Guid.Empty)
                _topicIds.Add(topicId);
            return this;
        }

        public DeleteTopicsOptionsBuilder TopicName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _topicNames.Add(name);
            return this;
        }

        public override DeleteTopicsOptions Build() =>
            new(
                _timeoutMs,
                _version,
                _clientId,
                _topicIds.ToImmutableArray(),
                _topicNames.ToImmutableArray()
            )
        ;
    }
}
