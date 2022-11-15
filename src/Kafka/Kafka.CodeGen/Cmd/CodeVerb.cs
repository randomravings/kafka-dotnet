using CommandLine;

namespace Kafka.CodeGen.Cmd
{
    [Verb("code")]
    internal sealed class CodeVerb
    {
        [Option('s', "source", Required = true, HelpText = "Source directory for the message definitions eg. '/tmp/messages'")]
        public string Source { get; set; } = "";
        [Option('o', "output", Required = true, HelpText = "Output directory of the generated CSharp files eg. '/tmp/messages/csharp'")]
        public string Output { get; set; } = "";
    }
}
