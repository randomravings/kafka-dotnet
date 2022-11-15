using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="IncludeClusterAuthorizedOperationsField">Whether to include cluster authorized operations.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeClusterRequest (
        bool IncludeClusterAuthorizedOperationsField
    )
    {
        public static DescribeClusterRequest Empty { get; } = new(
            default(bool)
        );
    };
}