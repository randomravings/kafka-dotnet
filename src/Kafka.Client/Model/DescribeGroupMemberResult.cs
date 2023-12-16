using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record DescribeGroupMemberResult(
        string MemberId,
        string? GroupInstanceId,
        string ClientId,
        string ClientHost,
        ProtocolMetadata MemberMetadata,
        IReadOnlySet<TopicPartition> MemberAssignment
    );
}
