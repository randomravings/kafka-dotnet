using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Client.Config;
using Kafka.Client.Model;

namespace Kafka.Cli.Cmd
{
    internal static class AclsCmd
    {
        public static async Task<int> Parse(
            IEnumerable<string> args,
            CancellationToken cancellationToken
        )
        {
            var parser = new Parser(with =>
            {
                with.CaseSensitive = true;
                with.HelpWriter = null;
                with.IgnoreUnknownArguments = false;
                with.CaseInsensitiveEnumValues = true;
                with.AllowMultiInstance = false;
            });
            var result = parser.ParseArguments<AclsListOpts, AclsCreateOpts>(args);
            return await result.MapResult(
                (AclsListOpts opts) => List(opts, cancellationToken),
                (AclsCreateOpts opts) => Create(opts, cancellationToken),
                err => HelpTextWriter.DisplayHelp(result)
            );
        }

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

                var result = await client.DescribeAcls(
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

        public static Task<int> Create(
            AclsCreateOpts opts,
            CancellationToken cancellationToken
        )
        {
            return Task.FromResult(-1);
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
