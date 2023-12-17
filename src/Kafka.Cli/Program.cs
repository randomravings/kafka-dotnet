using CommandLine;
using Kafka.Cli.Cmd;
using Kafka.Cli.Options;

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) => { e.Cancel = true; cts.Cancel(); };

var result = await new Parser(with =>
    {
        with.CaseSensitive = true;
        with.HelpWriter = Console.Out;
    })
    .ParseArguments<TopicsVerb, GroupsVerb, AclsVerb, ReadVerb, WriteVerb>(args.Length > 0 ? args.Take(1) : [])
    .MapResult(
        (TopicsVerb verb) => TopicsCmd.Parse(args.Skip(1), cts.Token),
        (GroupsVerb verb) => GroupsCmd.Parse(args.Skip(1), cts.Token),
        (AclsVerb verb) => AclsCmd.Parse(args.Skip(1), cts.Token),
        (ReadVerb verb) => ReadCmd.Parse(args.Skip(1), cts.Token),
        (WriteVerb verb) => WriteCmd.Parse(args.Skip(1), cts.Token),
        errs => Task.FromResult(-1)
    );
;
return result;