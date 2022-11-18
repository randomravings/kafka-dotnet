using Kafka.Cli.AdminClient.Verbs;
using Kafka.Client.Clients.Admin;
using Kafka.Client.Clients.Admin.Model;

namespace Kafka.Cli.AdminClient.Cmd
{
    internal static class Api
    {
        public static async ValueTask<int> Versions(
            VerbApiVersions verb,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var adminClientConfig = new AdminClientConfig
                {
                    BootstrapServers = verb.BootstrapServer
                };
                using var adminClient = (IAdminClient)new Client.Clients.Admin.AdminClient(adminClientConfig);
                var options = new ApiVersionsOptionsBuilder(adminClientConfig)
                    .Version(verb.ApiVersion)
                    .Build()
                ;
                var result = await adminClient.GetApiVersions(
                    options,
                    cancellationToken
                );

                foreach (var apiVersion in result.ApiVersions)
                    Console.WriteLine(apiVersion);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
    }
}
