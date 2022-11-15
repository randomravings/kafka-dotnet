namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ListTopicsOptions(
        int TimeoutMs,
        bool IncludeInternal
    ) : AdminOptions(TimeoutMs)
    {
        public static ListTopicsOptions Empty { get; } = new(
            0,
            false
        );
    };
}
