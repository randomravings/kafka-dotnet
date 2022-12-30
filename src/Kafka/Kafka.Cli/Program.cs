using CommandLine;
using Kafka.Cli.Cmd;
using Kafka.Cli.Verbs;

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) => { e.Cancel = true; cts.Cancel(); };

await new Parser(with =>
    {
        with.CaseSensitive = true;
        with.HelpWriter = Console.Out;
        with.IgnoreUnknownArguments = true;
        with.CaseInsensitiveEnumValues = true;
    })
    .ParseArguments<VerbApiVersions, Topic, Produce, Consume>(args)
    .MapResult(
        (VerbApiVersions verb) => ApiCmd.Parse(verb, cts.Token),
        (Topic verb) => TopicCmd.Parse(args.Skip(1), cts.Token),
        (Produce verb) => ProduceCmd.Parse(verb, cts.Token),
        (Consume verb) => ConsumeCmd.Parse(verb, cts.Token),
        errs => new ValueTask<int>(-1)
    );
;