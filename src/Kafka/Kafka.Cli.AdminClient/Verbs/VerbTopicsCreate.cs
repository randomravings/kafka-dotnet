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
    }
}
