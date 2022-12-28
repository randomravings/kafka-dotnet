using Kafka.Cli.Options;
using Kafka.Cli.Verbs;
using Kafka.Client.Clients.Admin;
using Kafka.Client.Clients.Admin.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Cli.Cmd
{
    internal static class Api
    {
        public static async ValueTask<int> Parse(
            VerbApiVersions verb,
            CancellationToken cancellationToken
        )
        {
            try
            {
                using var adminClient = CreateAdminClient(verb, out var adminClientConfig);
                var options = new ApiVersionsOptionsBuilder(adminClientConfig)
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

        private static IAdminClient CreateAdminClient(
            OptionsBase optionsBase,
            out AdminClientConfig adminClientConfig
        )
        {
            adminClientConfig = new AdminClientConfig
            {
                BootstrapServers = optionsBase.BootstrapServer
            };
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddConsole()
                    .SetMinimumLevel(LogLevel.Warning)
                )
                .CreateLogger<AdminClient>()
            ;
            return new AdminClient(adminClientConfig, logger);
        }
    }
}
