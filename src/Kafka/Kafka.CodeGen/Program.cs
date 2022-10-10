// See https://aka.ms/new-console-template for more information
using CommandLine;
using Kafka.CodeGen.Cmd;
using System.IO.Abstractions;

var fileSystem = new FileSystem();
await Parser.Default.ParseArguments<FetchVerb, CodeVerb>(args)
    .MapResult(
        (FetchVerb verb) => Exec.Fetch(fileSystem, verb),
        (CodeVerb verb) => Exec.Code(fileSystem, verb),
        errs => new ValueTask<int>(-1)
    );
;
//var t = await DowloadClient.GetRepo("Apache", "Kafka", "/clients/src/main/resources/common/message", false, "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");
