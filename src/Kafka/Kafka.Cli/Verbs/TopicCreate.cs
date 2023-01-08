using CommandLine;
using Kafka.Cli.Options;

namespace Kafka.Cli.Verbs
{
    [Verb("create")]
    public sealed class TopicCreate
        : OptionsBase
    {
        [Option("topic", Required = true)]
        public string Topic { get; set; } = "";
        [Option("partition-count")]
        public int PartitionCount { get; set; } = 1;
        [Option("replication-factor")]
        public short ReplicationFactor { get; set; } = 1;
        [Option("replica-assignment")]
        public string ReplicaAssignment { get; set; } = "";
    }
}
