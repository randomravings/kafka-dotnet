using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("consumer")]
    public sealed class ConsumerOpts
        : KafkaCliOpts
    {
        [Option("topic", Required = true, Group = "topics")]
        public IEnumerable<string> TopicNames { get; set; } = Array.Empty<string>();
        [Option("topic-id", Required = true, Group = "topics")]
        public IEnumerable<string> TopicIds { get; set; } = Array.Empty<string>();
        [Option("group-id", SetName = "group-assign")]
        public string GroupId { get; set; } = "";
        [Option("partition-assign", SetName = "partition-assign", HelpText = PARTITION_ASSIGN_HELP)]
        public IEnumerable<string> PartitionAssign { get; set; } = Array.Empty<string>();
        [Option("auto-commit", Required = false)]
        public bool EnableAutoCommit { get; set; } = true;
        [Option("interactive", HelpText = "Starts consumer in interactive mode")]
        public bool Interactive { get; set; }


        private const string PARTITION_ASSIGN_HELP = "List of partition assignments. ',' delimits partition offset pairs and ':' delimits partition and offset. Example: 0:0,1:4,2:2 0:-1,1:-2";
    }
}
