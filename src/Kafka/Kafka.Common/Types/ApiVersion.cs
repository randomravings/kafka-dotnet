namespace Kafka.Common.Types
{
    public readonly record struct ApiVersion(
        Api Api,
        Version Version
    );
}
