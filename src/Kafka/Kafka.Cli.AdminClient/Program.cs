using CommandLine;
using Kafka.Cli.AdminClient.Cmd;
using Kafka.Cli.AdminClient.Verbs;

await new Parser(with =>
    {
        with.CaseSensitive = true;
        with.HelpWriter = Console.Out;
        with.IgnoreUnknownArguments = true;
    })
    .ParseArguments<VerbApiVersions, VerbTopics>(args)
    .MapResult(
        (VerbApiVersions verb) => Api.Versions(verb, CancellationToken.None),
        (VerbTopics verb) => Topics.Parse(args.Skip(1), CancellationToken.None),
        errs => new ValueTask<int>(-1)
    );
;