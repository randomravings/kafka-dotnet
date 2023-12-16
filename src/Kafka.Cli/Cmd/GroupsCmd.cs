using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Config;
using Kafka.Client.Model;
using Kafka.Common.Model;

namespace Kafka.Cli.Cmd
{
    internal static class GroupsCmd
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
            }).ParseArguments<GroupsListOpts, GroupsDeleteOpts>(args)
                .MapResult(
                    (GroupsListOpts opts) => List(opts, cancellationToken),
                    (GroupsDeleteOpts opts) => Delete(opts, cancellationToken),
                    errs => Task.FromResult(-1)
                )
            ;

        public static async Task<int> List(
            GroupsListOpts opts,
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

                var statesList = new List<ConsumerGroupState>();
                if (opts.States.Any())
                    foreach (var state in opts.States)
                        if (Enum.TryParse<ConsumerGroupState>(state, true, out var consumerGroupState))
                            statesList.Add(consumerGroupState);
                        else
                            Console.WriteLine($"Unoknown group state: {state}");
                else
                    statesList.AddRange(Enum.GetValues<ConsumerGroupState>());

                var options = new ListGroupsOptions(
                    statesList
                );

                var result = await client.Groups.List(
                    options,
                    cancellationToken
                );
                foreach (var group in result)
                {
                    Console.WriteLine(group.GroupId);
                    Console.WriteLine($"  Protocol Type:  {group.ProtocolType}");
                    Console.WriteLine($"  Group State:    {group.GroupState}");
                }
                await client.Close(CancellationToken.None);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public static async Task<int> Delete(
            GroupsDeleteOpts opts,
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


                var result = await client.Groups.Delete(
                    opts.Groups.Select(r => new ConsumerGroup(r)),
                    cancellationToken
                );
                foreach (var group in result)
                {
                    Console.WriteLine(group.GroupId);
                    if (group.Error.Code != ApiError.None.Code)
                        Console.WriteLine(Formatter.Print(group.Error));
                }
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
