using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("list", HelpText = "List of acls")]
    public sealed class AclsListOpts
        : Opts
    {
    }
}
