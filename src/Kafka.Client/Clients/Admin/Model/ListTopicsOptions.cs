using Kafka.Client.Model;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ListTopicsOptions(
        int TimeoutMs,
        bool IncludeInternal
    ) : ClientOptions(TimeoutMs)
    {
        public static ListTopicsOptions Empty { get; } = new(
            -1,
            false
        );
    };
}
