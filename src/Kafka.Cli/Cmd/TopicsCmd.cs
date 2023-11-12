using CommandLine;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client;
using Kafka.Client.Clients.Admin;
using Kafka.Client.Config;
using Kafka.Client.Model;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Cli.Cmd
{
    internal static class TopicsCmd
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
            }).ParseArguments<TopicsListOpts, TopicsCreateOpts, TopicsDescribeOpts, TopicsDeleteOpts>(args)
                .MapResult(
                    (TopicsListOpts verb) => List(verb, cancellationToken),
                    (TopicsCreateOpts verb) => Create(verb, cancellationToken),
                    (TopicsDescribeOpts verb) => Describe(verb, cancellationToken),
                    (TopicsDeleteOpts verb) => Delete(verb, cancellationToken),
                    errs => Task.FromResult(-1)
                )
            ;

        public static async Task<int> List(
            TopicsListOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (!TryCreateConfig(opts, out var config))
                    return -1;
                using var client = CreateAdminClient(opts, config);
                var options = new ListTopicsOptions(
                    !opts.ExcludeInternal
                );
                var result = await client.Topics.List(
                    options,
                    cancellationToken
                );
                foreach (var topic in result.Topics.Where(t => options.IncludeInternal || t.IsInternal == false))
                    Console.WriteLine(topic.Name);
                await client.Close(CancellationToken.None);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public static async Task<int> Create(
            TopicsCreateOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (!TryCreateConfig(opts, out var config))
                    return -1;
                using var client = CreateAdminClient(opts, config);
                var replicaAssinment = new Dictionary<int, int[]>();
                var partitionReplicaAssignments = opts.ReplicaAssignment.Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var partitionReplicaAssignment in partitionReplicaAssignments)
                {
                    var kv = partitionReplicaAssignment.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    var key = int.Parse(kv[0]);
                    var value = kv[1].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray();
                    replicaAssinment.Add(key, value);
                }
                var definition = new CreateTopicDefinition(
                    opts.Topic,
                    opts.PartitionCount,
                    opts.ReplicationFactor,
                    ImmutableDictionary<int, IReadOnlyList<int>>.Empty,
                    ImmutableDictionary<string, string?>.Empty
                );
                var result = await client.Topics.Create(
                    definition,
                    CreateTopicOptions.Empty,
                    cancellationToken
                );
                foreach (var topic in result.CreatedTopics)
                    PrintCreateTopic(
                        topic.Id,
                        topic.Name,
                        topic.NumPartitions,
                        topic.ReplicationFactor
                    );

                foreach (var topic in result.ErrorTopics)
                {
                    Console.Write($"  {topic.Name}");
                    Console.WriteLine();
                    Console.WriteLine($"    {Formatter.Print(topic.Error)}");
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

        private static void PrintCreateTopic(
            TopicId topicId,
            TopicName topicName,
            int partitions,
            int replicationFactor
        )
        {
            Console.Write($"  {topicName.Value}");
            if (topicId != TopicId.Empty)
                Console.Write($" ({topicId.Value})");
            Console.WriteLine();
            Console.WriteLine($"    Partitions:         {partitions}");
            Console.WriteLine($"    Replication Factor: {replicationFactor}");
        }

        public static async Task<int> Delete(
            TopicsDeleteOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (!TryCreateConfig(opts, out var config))
                    return -1;
                using var client = CreateAdminClient(opts, config);
                var result = await client.Topics.Delete(
                    opts.Topic,
                    cancellationToken
                );
                foreach (var topic in result.DeletedTopics)
                    Console.WriteLine(topic);
                foreach (var error in result.ErrorTopics)
                    Console.WriteLine(error);
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
            TopicsDescribeOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (!TryCreateConfig(opts, out var config))
                    return -1;
                using var client = CreateAdminClient(opts, config);
                var result = await client.Topics.Describe(
                    opts.Topic,
                    DescribeTopicOptions.Empty,
                    cancellationToken
                );
                foreach (var topic in result.Topics)
                {
                    if(topic.Error.Code != 0)
                    {
                        Console.WriteLine($"Name: {topic.Name}");
                        Console.WriteLine($"Error: {Formatter.Print(topic.Error)}");
                        continue;
                    }
                    Console.WriteLine($"Id: {topic.TopicId}");
                    Console.WriteLine($"Name: {topic.Name}");
                    Console.WriteLine($"Internal: {topic.IsInternal}");
                    Console.WriteLine($"AuthorizedOperations: {topic.TopicAuthorizedOperations}");
                    foreach (var partition in topic.Partitions.OrderBy(r => r.PartitionIndex))
                    {
                        Console.WriteLine($"Partition: {partition.PartitionIndex}");
                        Console.WriteLine($"  LeaderId: {partition.LeaderId}");
                        Console.WriteLine($"  LeaderEpoch: {partition.LeaderEpoch}");
                        Console.WriteLine($"  Error: {Formatter.Print(topic.Error)}");
                        Console.WriteLine($"  ReplicaNodes: [{string.Join(',', partition.ReplicaNodes)}]");
                        Console.WriteLine($"  IsrNodes: [{string.Join(',', partition.IsrNodes)}]");
                        Console.WriteLine($"  OfflineReplicas: [{string.Join(',', partition.OfflineReplicas)}]");
                    }
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

        private static bool TryCreateConfig(
            KafkaCliOpts opts,
            out ClientConfig config
        )
        {
            config = new ClientConfig
            {
                ClientId = "kafka-cli.net",
                BootstrapServers = opts.BootstrapServer
            };
            return OptionsMapper.SetProperties(config, opts.Properties, Console.Out);
        }

        private static IClient CreateAdminClient(
            KafkaCliOpts opts,
            ClientConfig config
        )
        {
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddConsole()
                    .SetMinimumLevel(opts.LogLevel)
                )
                .CreateLogger<IClient>()
            ;
            return ClientBuilder
                .New()
                .WithConfig(config)
                .WithLogger(logger)
                .Build()
            ;
        }
    }
}
