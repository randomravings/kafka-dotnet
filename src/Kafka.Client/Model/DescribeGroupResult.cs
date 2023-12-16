using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record DescribeGroupResult(
        ConsumerGroup GroupId,
        string GroupStateField,
        string ProtocolTypeField,
        string ProtocolDataField,
        NodeId Coordinator,
        IReadOnlyList<DescribeGroupMemberResult> Members,
        int AuthorizedOperationsField,
        ApiError Error
    );
}
