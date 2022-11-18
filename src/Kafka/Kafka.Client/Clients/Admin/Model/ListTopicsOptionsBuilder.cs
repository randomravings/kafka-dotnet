namespace Kafka.Client.Clients.Admin.Model
{
    public sealed class ListTopicsOptionsBuilder :
        ClientOptionsBuilder<ListTopicsOptionsBuilder, ListTopicsOptions>
    {
        private bool _includeInternal;
        private bool _includeClusterAuthorizedOperations;
        private bool _includeTopicAuthorizedOperations;
        public ListTopicsOptionsBuilder(AdminClientConfig adminClientConfig)
            : base(adminClientConfig) { }

        public ListTopicsOptionsBuilder IncludeInternal(bool includeInternal)
        {
            _includeInternal = includeInternal;
            return this;
        }

        public ListTopicsOptionsBuilder IncludeClusterAuthorizedOperations(bool includeClusterAuthorizedOperations)
        {
            _includeClusterAuthorizedOperations = includeClusterAuthorizedOperations;
            return this;
        }

        public ListTopicsOptionsBuilder IncludeTopicAuthorizedOperations(bool includeTopicAuthorizedOperations)
        {
            _includeTopicAuthorizedOperations = includeTopicAuthorizedOperations;
            return this;
        }

        public override ListTopicsOptions Build() =>
            new(
                _timeoutMs,
                _version,
                _clientId,
                _includeInternal,
                _includeClusterAuthorizedOperations,
                _includeTopicAuthorizedOperations
            )
        ;
    }
}
