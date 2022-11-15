using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="VersionField">The version of the snapshot footer record</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SnapshotFooterRecord (
        short VersionField
    )
    {
        public static SnapshotFooterRecord Empty { get; } = new(
            default(short)
        );
    };
}