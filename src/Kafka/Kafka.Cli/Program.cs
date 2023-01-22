using CommandLine;
using Kafka.Cli.Cmd;
using Kafka.Cli.Options;

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) => { e.Cancel = true; cts.Cancel(); };

await new Parser(with =>
    {
        with.CaseSensitive = true;
        with.HelpWriter = Console.Out;
        with.IgnoreUnknownArguments = true;
        with.CaseInsensitiveEnumValues = true;
    })
    .ParseArguments<TopicsOpts, ProducerOpts, ConsumerOpts>(args)
    .MapResult(
        (TopicsOpts verb) => TopicsCmd.Parse(args.Skip(1), cts.Token),
        (ProducerOpts verb) => ProducerCmd.Parse(verb, cts.Token),
        (ConsumerOpts verb) => ConsumerCmd.Parse(verb, cts.Token),
        errs => new ValueTask<int>(-1)
    );
;