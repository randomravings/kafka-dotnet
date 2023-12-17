using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Config;
using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Collections.Immutable;
using System.Text.Json;

namespace Kafka.Cli.Cmd
{
    internal static class AclsCmd
    {
        public static async Task<int> Parse(
                IEnumerable<string> args,
                CancellationToken cancellationToken
            ) =>
                await new Parser(with =>
                {
                    with.CaseSensitive = true;
                    with.HelpWriter = Console.Out;
                    with.IgnoreUnknownArguments = false;
                    with.CaseInsensitiveEnumValues = true;
                    with.AllowMultiInstance = false;
                }).ParseArguments<AclsListOpts>(args)
                    .MapResult(
                        (AclsListOpts opts) => List(opts, cancellationToken),
                        errs => Task.FromResult(-1)
                    )
                ;

        public static async Task<int> List(
            AclsListOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var config = CreateConfig(
                    opts
                );

                if (!ClientUtils.TrySetProperties(config, opts, Console.Out))
                    return -1;

                using var client = ClientUtils.CreateClient(
                    opts,
                    config
                );

                var options = DescribeAclOptions.Empty;

                var result = await client.Security.DescribeAcls(
                    options,
                    cancellationToken
                );
                Console.WriteLine(result);
                await client.Close(CancellationToken.None);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        private static KafkaClientConfig CreateConfig(
            Opts opts
        )
        {
            var config = new KafkaClientConfig
            {
                Client = new()
                {
                    ClientId = "kafka-cli.net",
                    BootstrapServers = opts.BootstrapServer
                },
            };
            return config;
        }
    }
}
