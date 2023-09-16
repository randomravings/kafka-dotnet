namespace Kafka.Common.Model
{
    public readonly record struct Api(
        ApiKey Key,
        VersionRange Range
    );
}
