using Kafka.Common.Model;
using System.Text.Json.Serialization;

namespace Kafka.Client.Model
{
    public sealed record GroupDescription(
        [property: JsonPropertyName("group id")]
        ConsumerGroup GroupId,
        string ProtocolType,
        string GroupState,
        NodeId Coordinator
    );
}
