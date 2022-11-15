using CommandLine;

namespace Kafka.Cli.AdminClient.Options
{
    public abstract class OptionsBase
    {
        [Option("bootstrap-server", Required = true)]
        public string BootstrapServer { get; set; } = "";

        [Option("apiversion")]
        public short ApiVersion { get; set; } = 0;
    }
}
