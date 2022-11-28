namespace Kafka.Client.Clients.Admin.Model
{
    public sealed class ListTopicsOptionsBuilder :
        ClientOptionsBuilder<ListTopicsOptionsBuilder, ListTopicsOptions>
    {
        private bool _includeInternal;
        public ListTopicsOptionsBuilder(AdminClientConfig adminClientConfig)
            : base(adminClientConfig) { }

        public ListTopicsOptionsBuilder IncludeInternal(bool includeInternal)
        {
            _includeInternal = includeInternal;
            return this;
        }

        public override ListTopicsOptions Build() =>
            new(
                _timeoutMs,
                _version,
                _clientId,
                _includeInternal
            )
        ;
    }
}
