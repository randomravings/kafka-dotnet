using static Kafka.Client.Messages.DeleteTopicsRequest;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed class DeleteTopicsOptionsBuilder :
        ClientOptionsBuilder<DeleteTopicsOptionsBuilder, DeleteTopicsOptions>
    {
        private readonly List<DeleteTopicState> _topics = new();
        private readonly List<string> _topicNames = new();
        public DeleteTopicsOptionsBuilder(AdminClientConfig adminClientConfig)
            : base(adminClientConfig) { }

        public DeleteTopicsOptionsBuilder Topic(Guid topicId, string? name = null)
        {
            _topics.Add(new(name, topicId));
            return this;
        }

        public DeleteTopicsOptionsBuilder TopicName(string name)
        {
            _topicNames.Add(name);
            return this;
        }

        public override DeleteTopicsOptions Build() =>
            new(
                _timeoutMs,
                _version,
                _clientId,
                _topics.ToImmutableArray(),
                _topicNames.ToImmutableArray()
            )
        ;
    }
}
