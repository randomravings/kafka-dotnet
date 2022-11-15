using Kafka.Cli.AdminClient.Verbs;
using Kafka.Client.Clients.Admin;

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
                using var adminClient = (IAdminClient)new Client.Clients.Admin.AdminClient(new AdminClientConfig
                {
                    BootstrapServers = verb.BootstrapServer
                });
                var result = await adminClient.GetApiVersions(
                    new(
                        5000,
                        "",
                        ""
                    ),
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
