namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ApiVersionsOptions(
        int TimeoutMs,
        string ClientSoftwareNameField,
        string ClientSoftwareVersionField
    ) : AdminOptions(TimeoutMs)
    {
        public static ApiVersionsOptions Empty { get; } = new(
            0,
            "",
            ""
        );
    };
}
