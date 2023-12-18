using CommandLine;
using Microsoft.Extensions.Logging;

namespace Kafka.Cli.Options
{
    public abstract class Opts
    {
        [Option("bootstrap-server", Required = true)]
        public string BootstrapServer { get; set; } = "";

        [Option("log-level", Required = false, Default = LogLevel.Warning)]
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        [Option("properties")]
        public IEnumerable<string> Properties { get; set; } = Array.Empty<string>();

        [Option("verbose", HelpText = "Command line will print out affirmed actions.", Default = false)]
        public bool Verbose { get; set; } = false;
    }
}
