using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("create", HelpText = "Create acls")]
    public sealed class AclsCreateOpts
        : Opts
    {
    }
}
