using CommandLine;

namespace Kafka.Cli.Options
{
    public sealed class WriteOpts
        : Opts
    {
        [Option("topic", Required = true)]
        public string Topic { get; set; } = "";

        [Option("max-in-flight", HelpText = "Maximum number of messages in flight per connection.", Default = 5)]
        public int MaxInFlightRequestsPerConnection { get; set; } = 1;

        [Option("batch-size", HelpText = "Maximum size in bytes in flight per connection.", Default = 1048576)]
        public int MaxRequestSize { get; set; } = 0;

        [Option("linger-ms", HelpText = "Maximum time before sending records.", Default = 50)]
        public int LingerMs { get; set; } = 0;

        [Option("topic-details", Default = TopicDisplayLevel.None, HelpText = "Topic info level to include in output")]
        public TopicDisplayLevel TopicDetails { get; set; } = TopicDisplayLevel.None;
    }
}
