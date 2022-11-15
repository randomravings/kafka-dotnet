using Newtonsoft.Json;
using System.IO.Abstractions;
using System.Text;

namespace Kafka.CodeGen.GitHub
{
    public sealed record GitFile(
        string Name,
        string Contents
    );

    public sealed record GitDirectory(
        string Name,
        IList<GitDirectory> SubDirs,
        IList<GitFile> Files
    );

    public static class GitHubClient
    {
        private sealed record GitLinkFields(
            [property: JsonProperty("self")] string Self
        );

        private sealed record GitItem(
            [property: JsonProperty("name")] string Name,
            [property: JsonProperty("type")] string Type,
            [property: JsonProperty("download_url")] string DownloadUrl,
            [property: JsonProperty("_links")] GitLinkFields Links
        );

        public static async ValueTask<GitDirectory> GetRepo(
            string uri,
            string owner,
            string name,
            string path,
            bool recurse,
            string accessToken,
            CancellationToken cancellationToken = default
        )
        {
            var root = new GitDirectory(
                "",
                new List<GitDirectory>(),
                new List<GitFile>()
            );
            using var client = new HttpClient();
            await ReadDirectory(
                root,
                client,
                $"{uri}/repos/{owner}/{name}/contents/{path}",
                recurse,
                accessToken,
                cancellationToken
            );
            return root;
        }

        private static async ValueTask ReadDirectory(
            GitDirectory parentDirectory,
            HttpClient client,
            string uri,
            bool recurse,
            string accessToken,
            CancellationToken cancellationToken
        )
        {
            using var getDirectoryRequest = CreateRequest(uri, accessToken);
            using var getDirectoryResponse = await client.SendAsync(
                getDirectoryRequest,
                cancellationToken
            );
            var getDirectoryJson = await getDirectoryResponse
                .Content
                .ReadAsStringAsync(
                    cancellationToken
                )
            ;
            var gitItems = JsonConvert.DeserializeObject<GitItem[]>(
                getDirectoryJson
            );

            if (gitItems == null ||
                gitItems.Length == 0)
                return;

            foreach (var gitItem in gitItems)
            {
                switch (gitItem.Type, recurse)
                {
                    case ("dir", true):
                        await AddDirectory(
                            parentDirectory,
                            client,
                            gitItem,
                            recurse,
                            accessToken,
                            cancellationToken
                        );
                        break;
                    case ("file", _):
                        await AddFile(
                            parentDirectory,
                            client,
                            gitItem,
                            accessToken
                        );
                        break;
                    default:
                        break;
                }
            }
        }

        public static async ValueTask SaveLocal(
            GitDirectory gitDirectory,
            string localDirectory,
            CancellationToken cancellationToken = default
        ) =>
            await SaveLocal(
                new FileSystem(),
                gitDirectory,
                localDirectory,
                cancellationToken
            )
        ;

        public static async ValueTask SaveLocal(
            IFileSystem fileSystem,
            GitDirectory gitDirectory,
            string localDirectory,
            CancellationToken cancellationToken = default
        )
        {
            if (fileSystem.Directory.Exists(localDirectory))
                fileSystem.Directory.CreateDirectory(localDirectory);
            foreach(var subDirectory in gitDirectory.SubDirs)
                await SaveLocal(
                    fileSystem,
                    subDirectory,
                    fileSystem
                        .Path
                        .Combine(
                            localDirectory,
                            gitDirectory.Name
                        ),
                    cancellationToken
                );
            foreach (var file in gitDirectory.Files)
                await fileSystem.File.WriteAllTextAsync(
                    fileSystem
                        .Path
                        .Combine(
                            localDirectory,
                            file.Name
                        ),
                    file.Contents,
                    cancellationToken
                );
        }

        private static async ValueTask AddDirectory(
            GitDirectory parentDirectory,
            HttpClient client,
            GitItem gitItem,
            bool recurse,
            string accessToken,
            CancellationToken cancellationToken
        )
        {
            var subDirectory = new GitDirectory(
                gitItem.Name,
                new List<GitDirectory>(),
                new List<GitFile>()
            );
            await ReadDirectory(
                subDirectory,
                client,
                gitItem.Links.Self,
                recurse,
                accessToken,
                cancellationToken
            );
            parentDirectory
                .SubDirs
                .Add(
                    subDirectory
                )
            ;
        }

        private static async ValueTask AddFile(
            GitDirectory parentDirectory,
            HttpClient client,
            GitItem gitItem,
            string accessToken
        )
        {
            using var downloadRequest = CreateRequest(
                gitItem.DownloadUrl,
                accessToken
            );
            using var contentResponse = await client.SendAsync(
                downloadRequest
            );
            var content = await contentResponse.Content.ReadAsStringAsync();

            var file = new GitFile(
                gitItem.Name,
                content
            );
            parentDirectory
                .Files
                .Add(
                    file
                )
            ;
        }

        private static HttpRequestMessage CreateRequest(
            string uri,
            string accessToken
        )
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add(
                "Authorization",
                $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{accessToken}:{"x-oauth-basic"}"))}"
            );
            request.Headers.Add(
                "User-Agent",
                "lk-github-client"
            );
            return request;
        }
    }
}