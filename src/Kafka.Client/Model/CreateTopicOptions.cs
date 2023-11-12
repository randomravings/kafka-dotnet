namespace Kafka.Client.Model
{
    public sealed record CreateTopicOptions(
        bool ValidateOnly,
        bool RetryOnQuotaViolation
    )
    {
        public static CreateTopicOptions Empty { get; } = new(
            false,
            true
        );
    };
}
