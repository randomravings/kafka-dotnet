using CommandLine;
using Kafka.Cli.Cmd;
using Kafka.Cli.Options;

var empty = Array.Empty<string>();
var cts = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) => { e.Cancel = true; cts.Cancel(); };

await new Parser(with =>
    {
        with.CaseSensitive = true;
        with.HelpWriter = Console.Out;
        with.IgnoreUnknownArguments = true;
        with.CaseInsensitiveEnumValues = true;
        with.GetoptMode = true;
    })
    .ParseArguments<TopicsVerb, ProducerVerb, ConsumerVerb>(args.Any() ? args.Take(1) : empty)
    .MapResult(
        (TopicsVerb verb) => TopicsCmd.Parse(args.Skip(1), cts.Token),
        (ProducerVerb verb) => ProducerCmd.Parse(args.Skip(1), cts.Token),
        (ConsumerVerb verb) => ConsumerCmd.Parse(args.Skip(1), cts.Token),
        errs => new ValueTask<int>(-1)
    );
;