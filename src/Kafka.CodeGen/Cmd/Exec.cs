using Kafka.CodeGen.CSharp;
using Kafka.CodeGen.GitHub;
using Kafka.CodeGen.Models;
using Kafka.Common.Model;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.IO.Abstractions;

namespace Kafka.CodeGen.Cmd
{
    internal class Exec
    {
        [Flags]
        private enum Profile
        {
            None = 0,
            Client = 1,
            Server = 2,
            Both = Client | Server
        }

        private static readonly ImmutableSortedSet<ApiKey> CLIENT_API_KEYS = ImmutableSortedSet.Create(
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

        public static int Code(
            IFileSystem fileSystem,
            CodeVerb opts
        )
        {
            var profile = Profile.Client;
            var apiKeys = CLIENT_API_KEYS;

            if (!fileSystem.Directory.Exists(opts.Source))
            {
                Console.WriteLine($"Directory does not exist: {opts.Source}");
                return -1;
            }

            var baseNamespace = "Kafka.Client";
            var baseMessageNamespace = "Messages";
            var baseMessageSerdeNamespace = "Encoding";

            var messageNamespace = $"{baseNamespace}.{baseMessageNamespace}";
            var messageSerdeNamespace = $"{messageNamespace}.{baseMessageSerdeNamespace}";


            var messageDirectoryPath = Path.Combine(opts.Output, baseMessageNamespace);
            var messageDirectory = fileSystem.DirectoryInfo.New(messageDirectoryPath);
            if (!messageDirectory.Exists)
                messageDirectory.Create();
            var messageSerdeDirectoryPath = Path.Combine(messageDirectoryPath, baseMessageSerdeNamespace);
            var messageSerdeDirectory = fileSystem.DirectoryInfo.New(messageSerdeDirectoryPath);
            if (!messageSerdeDirectory.Exists)
                messageSerdeDirectory.Create();

            foreach (var file in fileSystem.Directory.GetFiles(opts.Source, "*.json"))
            {
                Console.Write($"{file} ... ");
                try
                {
                    var messageDefinition = JsonConvert.DeserializeObject<MessageDefinition>(File.ReadAllText(file));
                    if (messageDefinition == null)
                    {
                        Console.WriteLine("<null>");
                        continue;
                    }
                    if (Include(messageDefinition, apiKeys))
                        Generator.WriteModel(
                            messageDirectory,
                            messageDefinition,
                            messageNamespace
                        );
                    if (IncludeEncoder(profile, messageDefinition, apiKeys))
                        Generator.WriteEncoder(
                            messageSerdeDirectory,
                            messageDefinition,
                            messageNamespace,
                            messageSerdeNamespace
                        );
                    if (IncludeDecoder(profile, messageDefinition, apiKeys))
                        Generator.WriteDecoder(
                            messageSerdeDirectory,
                            messageDefinition,
                            messageNamespace,
                            messageSerdeNamespace
                        );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return -1;
                }
                Console.WriteLine("OK");
            }
            return 0;
        }

        public static bool Include(
            MessageDefinition messageDefinition,
            ImmutableSortedSet<ApiKey> apiKeys
        ) =>
            messageDefinition.MessageType switch
            {
                MessageType.Header => true,
                MessageType.Request or MessageType.Response => apiKeys.Contains(messageDefinition.ApiKey),
                _ => false,
            }
        ;

        private static bool IncludeEncoder(
            Profile profile,
            MessageDefinition messageDefinition,
            ImmutableSortedSet<ApiKey> apiKeys
        ) =>
            (messageDefinition.MessageType, profile) switch
            {
                (_, Profile.Both) => true,
                (MessageType.Header, Profile.Server) => messageDefinition.Name.ToLower().StartsWith("response"),
                (MessageType.Header, Profile.Client) => messageDefinition.Name.ToLower().StartsWith("request"),
                (MessageType.Response, Profile.Server) => apiKeys.Contains(messageDefinition.ApiKey),
                (MessageType.Request, Profile.Client) => apiKeys.Contains(messageDefinition.ApiKey),
                _ => false,
            }
        ;

        private static bool IncludeDecoder(
            Profile profile,
            MessageDefinition messageDefinition,
            ImmutableSortedSet<ApiKey> apiKeys
        ) =>
            (messageDefinition.MessageType, profile) switch
            {
                (_, Profile.Both) => true,
                (MessageType.Header, Profile.Client) => messageDefinition.Name.ToLower().StartsWith("response"),
                (MessageType.Header, Profile.Server) => messageDefinition.Name.ToLower().StartsWith("request"),
                (MessageType.Response, Profile.Client) => apiKeys.Contains(messageDefinition.ApiKey),
                (MessageType.Request, Profile.Server) => apiKeys.Contains(messageDefinition.ApiKey),
                _ => false,
            }
        ;
    }
}
