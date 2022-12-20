using CommandLine;
using Kafka.Cli.Options;

namespace Kafka.Cli.Verbs
{
    [Verb("consume")]
    public sealed class VerbConsume
        : OptionsBaseTopic
    {
        [Option("group-id")]
        public string GroupId { get; set; } = "";
    }
}
