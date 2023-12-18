using CommandLine;

namespace Kafka.Cli.Options
{
    public sealed class ReadOpts
        : Opts
    {
        [Option("topics", SetName = "group-assign", Required = true)]
        public IEnumerable<string> Topics { get; set; } = Array.Empty<string>();
        [Option("group-id", SetName = "group-assign")]
        public string GroupId { get; set; } = "";
        [Option("partition-assign", SetName = "partition-assign", Required = true, HelpText = PARTITION_ASSIGN_HELP)]
        public IEnumerable<string> ToppicPartitionAssign { get; set; } = Array.Empty<string>();
        [Option("interactive", HelpText = "Starts reader in interactive mode")]
        public bool Interactive { get; set; }

        private const string PARTITION_ASSIGN_HELP = "List of topic partition assignments. Example: <topic0>[0:1,1:1,2:1]";
    }
}
