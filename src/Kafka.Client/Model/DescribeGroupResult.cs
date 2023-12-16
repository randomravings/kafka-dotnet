using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record DescribeGroupResult(
        ConsumerGroup GroupId,
        string GroupState,
        string ProtocolType,
        string ProtocolData,
        NodeId Coordinator,
        IReadOnlyList<DescribeGroupMemberResult> Members,
        AclOperation AuthorizedOperations,
        ApiError Error
    );
}
