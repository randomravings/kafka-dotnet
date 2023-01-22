using Kafka.Common.Records;

namespace Kafka.Client.Clients.Consumer.Models
{
    internal sealed record ControlRecord(
        ControlType Type,
        short Version
    );
}
