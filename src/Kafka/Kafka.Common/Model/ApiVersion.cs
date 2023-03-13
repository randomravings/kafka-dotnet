namespace Kafka.Common.Model
{
    public readonly record struct ApiVersion(
        ApiKey Api,
        Version Version
    );
}
