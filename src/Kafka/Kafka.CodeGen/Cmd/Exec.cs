using Kafka.CodeGen.CSharp;
using Kafka.CodeGen.GitHub;
using Kafka.CodeGen.Models;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.IO.Abstractions;

namespace Kafka.CodeGen.Cmd
{
    internal class Exec
    {
        private static readonly ImmutableSortedSet<ApiKey> API_KEYS = ImmutableSortedSet.Create(
            ApiKeyCompare.Instance,
            ApiKey.Produce,
            ApiKey.Fetch,
            ApiKey.ListOffsets,
            ApiKey.Metadata,
            ApiKey.OffsetCommit,
            ApiKey.OffsetFetch,
            ApiKey.FindCoordinator,
            ApiKey.JoinGroup,
            ApiKey.Heartbeat,
            ApiKey.LeaveGroup,
            ApiKey.SyncGroup,
            ApiKey.ListGroups,
            ApiKey.ApiVersions,
            ApiKey.CreateTopics,
            ApiKey.DeleteTopics,
            ApiKey.DeleteRecords,
            ApiKey.InitProducerId,
            ApiKey.AddPartitionsToTxn,
            ApiKey.EndTxn
        );

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

        private static TextWriter CreateWriter(
            IFileSystem fileSystem,
            string directory,
            string name
        )
        {
            var path = fileSystem.Path.Join(directory, $"{name}.cs");
            return new StreamWriter(
                fileSystem.FileStream.New(
                    fileSystem.Path.Combine(
                        path
                    ),
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.ReadWrite
                )
            );
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

            var baseNamespace = "Kafka.Client";
            var baseMessageNamespace = "Messages";
            var baseMessageSerdeNamespace = "Serdes";

            var messageNamespace = $"{baseNamespace}.{baseMessageNamespace}";
            var messageSerdeNamespace = $"{messageNamespace}.{baseMessageSerdeNamespace}";

            var messageFolder = Path.Combine(opts.Output, baseMessageNamespace);
            var messageSerdeFolder = Path.Combine(messageFolder, baseMessageSerdeNamespace);

            if (!fileSystem.Directory.Exists(messageFolder))
                fileSystem.Directory.CreateDirectory(messageFolder);
            if (!fileSystem.Directory.Exists(messageSerdeFolder))
                fileSystem.Directory.CreateDirectory(messageSerdeFolder);

            foreach (var file in fileSystem.Directory.GetFiles(opts.Source, "*.json"))
            {
                Console.Write(file);
                try
                {
                    var message = JsonConvert.DeserializeObject<MessageDefinition>(File.ReadAllText(file));
                    switch (message)
                    {
                        case null:
                            Console.WriteLine($" ... Null");
                            break;
                        case HeaderMessage:
                        case ApiMessage apiMessage when API_KEYS.Contains(message.ApiKey):
                            await WriteMessage(fileSystem, messageFolder, message, messageNamespace);
                            await WriteSerde(fileSystem, messageSerdeFolder, message, messageNamespace, messageSerdeNamespace);
                            Console.WriteLine($" ... Done ({message?.GetType()?.Name ?? ""})");
                            break;
                        default:
                            Console.WriteLine($" ... Excluded");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" ... {ex}");
                    return -1;
                }
            }
            return 0;
        }

        private static async Task WriteMessage(
            IFileSystem fileSystem,
            string directory,
            MessageDefinition messageDefinition,
            string messageNamespace
        )
        {
            using var modelWriter = CreateWriter(fileSystem, directory, $"{messageDefinition.Name}.cs");
            await Generator.WriteModel(
                modelWriter,
                messageDefinition,
                messageNamespace
            );
        }

        private static async Task WriteSerde(
            IFileSystem fileSystem,
            string directory,
            MessageDefinition messageDefinition,
            string messageNamespace,
            string messageSerdeNamespace
        )
        {
            using var modelWriter = CreateWriter(fileSystem, directory, $"{messageDefinition.Name}Serde.cs");
            await Generator.WriteSerde(
                modelWriter,
                messageDefinition,
                messageNamespace,
                messageSerdeNamespace
            );
        }
    }
}
