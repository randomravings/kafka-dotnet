using CommandLine;

namespace Kafka.Cli.Options
{
    [Flags]
    public enum TopicDisplayLevel
    {
        None = 0,
        Topic = 1,
        Partition = 2,
        Offset = 4,
        TopicPartition = Topic | Partition,
        PartitionOffset = Partition | Offset,
        All = Topic | Partition | Offset
    }
}
