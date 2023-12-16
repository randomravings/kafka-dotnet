using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record GroupDescription(
        ConsumerGroup GroupId,
        string ProtocolType,
        string GroupState
    );
}
