using Kafka.CodeGen.CSharp;
using Kafka.CodeGen.GitHub;
using Kafka.CodeGen.Models;
using Newtonsoft.Json;
using System.IO.Abstractions;

namespace Kafka.CodeGen.Cmd
{
    internal class Exec
    {
        public static async ValueTask<int> Fetch(
            IFileSystem fileSystem,
            FetchVerb opts
        )
        {
            var gitDirectory = await GitHubClient.GetRepo(
                opts.GitHubUri,
                opts.Owner,
                opts.Project,
                opts.Directory,
                opts.Recurse,
                opts.Token
            );
            await GitHubClient.SaveLocal(
                fileSystem,
                gitDirectory,
                opts.Local
            );
            return 0;
        }

        public static async ValueTask<int> Code(
            IFileSystem fileSystem,
            CodeVerb opts
        )
        {
            if (!fileSystem.Directory.Exists(opts.Source))
            {
                Console.WriteLine($"Directory does not exist: {opts.Source}");
                return -1;
            }

            if (!fileSystem.Directory.Exists(opts.Output))
                fileSystem.Directory.CreateDirectory(opts.Output);

            foreach (var file in fileSystem.Directory.GetFiles(opts.Source, "*.json"))
            {
                Console.Write(file);
                try
                {
                    var message = JsonConvert.DeserializeObject<MessageDefinition>(File.ReadAllText(file));
                    if (message == null)
                    {
                        Console.WriteLine($" ... Null");
                        continue;
                    }
                    await Generator.Write(
                        fileSystem,
                        opts.Output,
                        message
                    );
                    Console.WriteLine($" ... Done ({message?.GetType()?.Name ?? ""})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" ... {ex}");
                    return -1;
                }
            }
            return 0;
        }
    }
}
