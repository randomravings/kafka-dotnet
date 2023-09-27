using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed class DeleteTopicsOptionsBuilder :
        AdminClientOptionsBuilder<DeleteTopicsOptionsBuilder, DeleteTopicsOptions>
    {
        private readonly List<Guid> _topicIds = new();
        private readonly List<string> _topicNames = new();
        public DeleteTopicsOptionsBuilder(AdminClientConfig adminClientConfig)
            : base(adminClientConfig) { }

        public DeleteTopicsOptionsBuilder Topic(string topic)
        {
            if(Guid.TryParse(topic, out var topicId))
                _topicIds.Add(topicId);
            else if (!string.IsNullOrEmpty(topic))
                _topicNames.Add(topic);
            return this;
        }

        public override DeleteTopicsOptions Build() =>
            new(
                TimeoutMs,
                _topicIds.ToImmutableArray(),
                _topicNames.ToImmutableArray()
            )
        ;
    }
}
