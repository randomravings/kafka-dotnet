using CommandLine;
using Kafka.Cli.AdminClient.Options;

namespace Kafka.Cli.AdminClient.Verbs
{
    [Verb("create")]
    public sealed class VerbTopicsCreate
        : OptionsBase
    {
        [Option("topic", Required = true)]
        public string Topic { get; set; } = "";
        [Option("partition-count")]
        public int PartitionCount { get; set; } = 1;
        [Option("replica-assignment")]
        public string ReplicaAssignment { get; set; } = "";
    }
}
