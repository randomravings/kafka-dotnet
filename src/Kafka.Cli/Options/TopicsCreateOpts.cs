using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("create", HelpText = "Create a topic")]
    public sealed class TopicsCreateOpts
        : Opts
    {
        [Option("topic", Required = true, HelpText = "Name of topics")]
        public string Topic { get; set; } = "";
        [Option("partition-count", Default = 1, HelpText = "Number of partitions for topics")]
        public int PartitionCount { get; set; } = 1;
        [Option("replication-factor", Default = 1, HelpText = "Number of replications per partition")]
        public short ReplicationFactor { get; set; } = 1;
        [Option("replica-assignment", HelpText = "Explicit assigment of replicas (not supported currently)")]
        public string ReplicaAssignment { get; set; } = "";
    }
}
