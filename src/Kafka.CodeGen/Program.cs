// See https://aka.ms/new-console-template for more information
using CommandLine;
using Kafka.CodeGen.Cmd;
using Kafka.CodeGen.Options;
using System.IO.Abstractions;

var fileSystem = new FileSystem();
await Parser.Default.ParseArguments<FetchVerb, CodeVerb>(args)
    .MapResult(
        (FetchVerb verb) => Exec.Fetch(fileSystem, verb),
        (CodeVerb verb) => ValueTask.FromResult(Exec.Code(fileSystem, verb)),
        errs => new ValueTask<int>(-1)
    );
;
