using CommandLine;

namespace Kafka.CodeGen.Cmd
{
    [Verb("fetch")]
    internal sealed class FetchVerb
    {
        [Option('u', "uri", Default = "https://api.github.com/")]
        public string GitHubUri { get; set; } = "";
        [Option('o', "owner", Default = "", HelpText = "Owner of the github project/repository eg. 'Apache'")]
        public string Owner { get; set; } = "";
        [Option('p', "project", Default = "", HelpText = "Github project/repository eg. 'Kafka'")]
        public string Project { get; set; } = "";
        [Option('d', "directory", Default = "", HelpText = "Root path in the repository to start from eg. '/clients/src/main/resources/common/message'")]
        public string Directory { get; set; } = "";
        [Option('r', "recurse", Default = false, HelpText = "Option to recursively traverse subfolders")]
        public bool Recurse { get; set; } = false;
        [Option('t', "token", Required = true, HelpText = "Access token for GitHub")]
        public string Token { get; set; } = "";
        [Option('l', "local", Required = true, HelpText = "Local file system to download files to eg. '/tmp/messages'")]
        public string Local { get; set; } = "";
    }
}
