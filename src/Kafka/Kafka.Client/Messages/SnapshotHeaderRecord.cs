using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="VersionField">The version of the snapshot header record</param>
    /// <param name="LastContainedLogTimestampField">The append time of the last record from the log contained in this snapshot</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SnapshotHeaderRecord (
        short VersionField,
        long LastContainedLogTimestampField
    )
    {
        public static SnapshotHeaderRecord Empty { get; } = new(
            default(short),
            default(long)
        );
    };
}