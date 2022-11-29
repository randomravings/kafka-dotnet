namespace Kafka.Common.Types
{
    public readonly record struct ApiVersion(
        ApiKey Api,
        Version Version
    );
}
