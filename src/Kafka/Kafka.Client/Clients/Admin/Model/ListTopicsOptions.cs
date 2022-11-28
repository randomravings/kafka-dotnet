namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ListTopicsOptions(
        int TimeoutMs,
        short? ApiVersion,
        string ClientId,
        bool IncludeInternal
    ) : ClientOptions(TimeoutMs, ApiVersion, ClientId)
    {
        public static ListTopicsOptions Empty { get; } = new(
            -1,
            0,
            "",
            false
        );
    };
}
