using CommandLine;
using Kafka.Cli.AdminClient.Cmd;
using Kafka.Cli.AdminClient.Verbs;

await new Parser(with =>
    {
        with.CaseSensitive = true;
        with.HelpWriter = Console.Out;
        with.IgnoreUnknownArguments = true;
    })
    .ParseArguments<VerbApiVersions, VerbTopic, VerbProduce>(args)
    .MapResult(
        (VerbApiVersions verb) => Api.Parse(verb, CancellationToken.None),
        (VerbTopic verb) => Topics.Parse(args.Skip(1), CancellationToken.None),
        (VerbProduce verb) => Produce.Parse(verb, CancellationToken.None),
        errs => new ValueTask<int>(-1)
    );
;