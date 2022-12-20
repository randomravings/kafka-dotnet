namespace Kafka.Common.Protocol
{
    public abstract record Request(
        short Api,
        short MinVersion,
        short MaxVersion,
        short FlexibleVersion
    );
}