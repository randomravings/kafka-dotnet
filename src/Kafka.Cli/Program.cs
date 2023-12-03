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
    .ParseArguments<TopicsVerb, ProducerVerb, ConsumerVerb>(args.Length > 0 ? args.Take(1) : [])
    .MapResult(
        (TopicsVerb verb) => TopicsCmd.Parse(args.Skip(1), cts.Token),
        (ProducerVerb verb) => ProducerCmd.Parse(args.Skip(1), cts.Token),
        (ConsumerVerb verb) => ConsumerCmd.Parse(args.Skip(1), cts.Token),
        errs => Task.FromResult(-1)
    );
;
return result;