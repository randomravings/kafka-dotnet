namespace Kafka.Client.Clients.Admin.Model
{
    public sealed class ApiVersionsOptionsBuilder :
        ClientOptionsBuilder<ApiVersionsOptionsBuilder, ApiVersionsOptions>
    {
        private string _clientSoftwareName = "";
        private string _clientSoftwareVersion = "";
        public ApiVersionsOptionsBuilder(AdminClientConfig adminClientConfig)
            : base(adminClientConfig) { }

        public ApiVersionsOptionsBuilder WithClientSoftwareName(string clientSoftwareName)
        {
            _clientSoftwareName = clientSoftwareName;
            return this;
        }

        public ApiVersionsOptionsBuilder WithClientSoftwareVersion(string clientSoftwareVersion)
        {
            _clientSoftwareVersion = clientSoftwareVersion;
            return this;
        }

        public override ApiVersionsOptions Build() =>
            new(
                _timeoutMs,
                _clientSoftwareName,
                _clientSoftwareVersion
            )
        ;
    }
}
