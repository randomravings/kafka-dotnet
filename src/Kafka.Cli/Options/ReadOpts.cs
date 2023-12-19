using CommandLine;

namespace Kafka.Cli.Options
{
    public sealed class ReadOpts
        : Opts
    {
        [Option("topics", SetName = "group-assign", Required = true, HelpText = "List of topics to subscribe to")]
        public IEnumerable<string> Topics { get; set; } = Array.Empty<string>();
        [Option("group-id", SetName = "group-assign", HelpText = "Consumer group id to use")]
        public string GroupId { get; set; } = "";
        [Option("partition-assign", SetName = "partition-assign", Required = true, HelpText = PARTITION_ASSIGN_HELP)]
        public IEnumerable<string> ToppicPartitionAssign { get; set; } = Array.Empty<string>();
        [Option("interactive", HelpText = "Starts reader in interactive mode")]
        public bool Interactive { get; set; }

        [Option("topic-details", Group = "stdout", Default = TopicDisplayLevel.None, HelpText = "Topic info level to include in output")]
        public TopicDisplayLevel TopicDetails { get; set; } = TopicDisplayLevel.None;

        [Option("show-key", Group = "stdout", HelpText = "Includes the key in output")]
        public bool ShowKey {get;set;} = false;

        [Option("show-timestamp", Group = "stdout", HelpText = "Includes the timestamp in output")]
        public bool ShowTimestamp { get; set; }
        [Option("timestamp-format", Group = "stdout", HelpText = "Starts reader in interactive mode")]
        public string TimeStampFormat{get;set;} = "yyyy-MM-ddTHH:mm:ss.fffZ";

        [Option("as-json", Group = "json", HelpText = "Writes the entire records details as JSON")]
        public bool AsJson{get;set;}

        private const string PARTITION_ASSIGN_HELP = "List of topic partition assignments. Example: <topic0>[0:1,1:1,2:1]";
    }
}
