using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record DeleteGroupResult(
        ConsumerGroup GroupId,
        ApiError Error
    );
}
