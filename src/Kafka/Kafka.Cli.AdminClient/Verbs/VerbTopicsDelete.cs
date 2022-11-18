using CommandLine;
using Kafka.Cli.AdminClient.Options;

namespace Kafka.Cli.AdminClient.Verbs
{
    [Verb("delete")]
    public sealed class VerbTopicsDelete
        : OptionsBase
    {
        [Option("topic", Required = true)]
        public string Topic { get; set; } = "";
    }
}
