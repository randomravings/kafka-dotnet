using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Config;
using Kafka.Client.Model;
using Kafka.Common.Model;
using System.Collections.Immutable;
using System.Text.Json;

namespace Kafka.Cli.Cmd
{
    internal static class GroupsCmd
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };
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
                }).ParseArguments<GroupsListOpts, GroupsDescribeOpts, GroupsDeleteOpts>(args)
                    .MapResult(
                        (GroupsListOpts opts) => List(opts, cancellationToken),
                        (GroupsDescribeOpts opts) => Describe(opts, cancellationToken),
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
                var nameWidth = 2;
                var typeWidth = 4;
                var nodeWidth = 11;
                var stateWidth = 5;
                foreach (var group in result)
                {
                    nameWidth = Math.Max(nameWidth, group.GroupId.Value.Length);
                    typeWidth = Math.Max(typeWidth, group.ProtocolType.Length);
                    nodeWidth = Math.Max(nodeWidth, group.Coordinator.Value.ToString().Length);
                    stateWidth = Math.Max(stateWidth, group.GroupState.Length);
                }
                nameWidth += 2;
                typeWidth += 2;
                nodeWidth += 2;
                stateWidth += 2;
                Console.Write("ID".PadRight(nameWidth));
                Console.Write("TYPE".PadRight(typeWidth));
                Console.Write("COORDINATOR".PadRight(nodeWidth));
                Console.WriteLine("STATE".PadRight(stateWidth));

                foreach (var group in result.OrderBy(r => r.GroupId.Value))
                {
                    Console.Write(group.GroupId.Value.PadRight(nameWidth));
                    Console.Write(group.ProtocolType.PadRight(typeWidth));
                    Console.Write(group.Coordinator.Value.ToString().PadRight(nodeWidth));
                    Console.WriteLine(group.GroupState.PadRight(stateWidth));
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

        public static async Task<int> Describe(
            GroupsDescribeOpts opts,
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

                var result = await client.Groups.Describe(
                    opts.Groups.Select(r => new ConsumerGroup(r)).ToImmutableArray(),
                    new DescribeGroupOptions(opts.ShowAllowedOperations),
                    cancellationToken
                );
                var json = JsonSerializer.Serialize(result, _jsonSerializerOptions);
                Console.WriteLine(json);
                Console.WriteLine();
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
                    Console.Write(group.GroupId);
                    if (group.Error.Code != ApiError.None.Code)
                        Console.Write($" - {Formatter.Print(group.Error)}");
                    else
                        Console.Write($" - Deleted");
                    Console.WriteLine(group.Error.Message);
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
