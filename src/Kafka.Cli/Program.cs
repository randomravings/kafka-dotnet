using CommandLine;
using Kafka.Cli.Cmd;
using Kafka.Cli.Options;

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) =>
{
    cts.Cancel();
    e.Cancel = false;
};

var parser = new Parser(with =>
{
    with.CaseSensitive = true;
    with.HelpWriter = null;
    with.IgnoreUnknownArguments = true;
    with.AllowMultiInstance = false;
});
var result = parser.ParseArguments<TopicsVerb, GroupsVerb, AclsVerb, ReadVerb, WriteVerb>(
    args.Length > 0 ? args.Take(1) : []
);

return await result.MapResult(
    (TopicsVerb verb) => TopicsCmd.Parse(args.Skip(1), cts.Token),
    (GroupsVerb verb) => GroupsCmd.Parse(args.Skip(1), cts.Token),
    (AclsVerb verb) => AclsCmd.Parse(args.Skip(1), cts.Token),
    (ReadVerb verb) => ReadCmd.Parse(args.Skip(1), cts.Token),
    (WriteVerb verb) => WriteCmd.Parse(args.Skip(1), cts.Token),
    errs => HelpTextWriter.DisplayHelp(result)
);