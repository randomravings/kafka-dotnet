namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ApiVersionsOptions(
        int TimeoutMs,
        string ClientSoftwareNameField,
        string ClientSoftwareVersionField
    ) : ClientOptions(TimeoutMs)
    {
        public static ApiVersionsOptions Empty { get; } = new(
            -1,
            "",
            ""
        );
    };
}
