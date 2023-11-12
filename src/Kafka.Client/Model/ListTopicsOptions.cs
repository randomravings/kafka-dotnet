namespace Kafka.Client.Model
{
    public sealed record ListTopicsOptions(
        bool IncludeInternal
    )
    {
        public static ListTopicsOptions Empty { get; } = new(
            false
        );
    };
}
