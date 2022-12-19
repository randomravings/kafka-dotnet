using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="IncludeClusterAuthorizedOperationsField">Whether to include cluster authorized operations.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeClusterRequest (
        bool IncludeClusterAuthorizedOperationsField
    ) : Request(60)
    {
        public static DescribeClusterRequest Empty { get; } = new(
            default(bool)
        );
        public static short FlexibleVersion { get; } = 0;
    };
}