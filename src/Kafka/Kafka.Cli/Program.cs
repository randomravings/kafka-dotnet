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
    .ParseArguments<VerbApiVersions, VerbTopic, VerbProduce, VerbConsume>(args)
    .MapResult(
        (VerbApiVersions verb) => Api.Parse(verb, cts.Token),
        (VerbTopic verb) => Topics.Parse(args.Skip(1), cts.Token),
        (VerbProduce verb) => Produce.Parse(verb, cts.Token),
        (VerbConsume verb) => Consume.Parse(verb, cts.Token),
        errs => new ValueTask<int>(-1)
    );
;