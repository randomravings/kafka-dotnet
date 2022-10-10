using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SnapshotHeaderRecord (
        short VersionField,
        long LastContainedLogTimestampField
    );
}
