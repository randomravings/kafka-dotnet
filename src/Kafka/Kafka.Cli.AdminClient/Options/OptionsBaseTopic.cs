using CommandLine;

namespace Kafka.Cli.AdminClient.Options
{
    public abstract class OptionsBaseTopic
        : OptionsBase
    {
        [Option("topic", SetName = "byName", Required = true)]
        public string TopicName { get; set; } = "";
        [Option("topic-id", SetName = "byId", Required = true)]
        public Guid TopicId { get; set; } = Guid.Empty;
    }
}
