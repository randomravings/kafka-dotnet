namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ApiVersionsOptions(
        int TimeoutMs,
        short? ApiVersion,
        string ClientId,
        string ClientSoftwareNameField,
        string ClientSoftwareVersionField
    ) : ClientOptions(TimeoutMs, ApiVersion, ClientId)
    {
        public static ApiVersionsOptions Empty { get; } = new(
            -1,
            0,
            "",
            "",
            ""
        );
    };
}
