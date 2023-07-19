namespace Kafka.Client.Clients.Admin.Model
{
    public sealed class ListTopicsOptionsBuilder :
        AdminClientOptionsBuilder<ListTopicsOptionsBuilder, ListTopicsOptions>
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
                TimeoutMs,
                _includeInternal
            )
        ;
    }
}
