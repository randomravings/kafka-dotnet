using CommandLine;
using Microsoft.Extensions.Logging;

namespace Kafka.Cli.Options
{
    public abstract class Opts
    {
        [Option("bootstrap-server", Required = true, HelpText = "List of nodes to connect to.")]
        public string BootstrapServer { get; set; } = "";

        [Option("log-level", Required = false, Default = LogLevel.Warning, HelpText = "Log level for kafka client implementation")]
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        [Option("properties", HelpText = "List of kafka client configurations as <key>=<value>")]
        public IEnumerable<string> Properties { get; set; } = Array.Empty<string>();

        [Option('q', "quiet", HelpText = "Hides intro messages")]
        public bool Quiet { get; set; }
    }
}
