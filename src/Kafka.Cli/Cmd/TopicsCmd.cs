using CommandLine;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Clients.Admin;
using Kafka.Client.Clients.Admin.Model;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;

namespace Kafka.Cli.Cmd
{
    internal static class TopicsCmd
    {
        public static async ValueTask<int> Parse(
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
                    errs => new ValueTask<int>(-1)
                )
            ;

        public static async ValueTask<int> List(
            TopicsListOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (!TryCreateConfig(opts, out var config))
                    return -1;
                using var adminClient = CreateAdminClient(opts, config);
                var options = new ListTopicsOptionsBuilder(config)
                    .IncludeInternal(!opts.ExcludeInternal)
                    .Build()
                ;
                var result = await adminClient.ListTopics(
                    options,
                    cancellationToken
                );
                foreach (var topic in result.Topics)
                    Console.WriteLine(topic.Name);
                await adminClient.Close(CancellationToken.None);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public static async ValueTask<int> Create(
            TopicsCreateOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (!TryCreateConfig(opts, out var config))
                    return -1;
                using var adminClient = CreateAdminClient(opts, config);
                var replicaAssinment = new Dictionary<int, int[]>();
                var partitionReplicaAssignments = opts.ReplicaAssignment.Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var partitionReplicaAssignment in partitionReplicaAssignments)
                {
                    var kv = partitionReplicaAssignment.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    var key = int.Parse(kv[0]);
                    var value = kv[1].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray();
                    replicaAssinment.Add(key, value);
                }
                var options = new CreateTopicsOptionsBuilder(config)
                    .NewTopic(b => b
                        .Name(opts.Topic)
                        .NumPartitions(opts.PartitionCount)
                        .ReplicationFactor(opts.ReplicationFactor)
                        .ReplicasAssignments(replicaAssinment)
                        .Build()
                    )
                    .Build()
                ;
                var result = await adminClient.CreateTopics(
                    options,
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
                await adminClient.Close(CancellationToken.None);
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

        public static async ValueTask<int> Delete(
            TopicsDeleteOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (!TryCreateConfig(opts, out var config))
                    return -1;
                using var adminClient = CreateAdminClient(opts, config);
                var options = new DeleteTopicsOptionsBuilder(config)
                    .Topic(opts.Topic)
                    .Build()
                ;
                var result = await adminClient.DeleteTopics(
                    options,
                    cancellationToken
                );
                foreach (var topic in result.DeletedTopics)
                    Console.WriteLine(topic);
                foreach (var error in result.ErrorTopics)
                    Console.WriteLine(error);
                await adminClient.Close(CancellationToken.None);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public static async ValueTask<int> Describe(
            TopicsDescribeOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (!TryCreateConfig(opts, out var config))
                    return -1;
                using var adminClient = CreateAdminClient(opts, config);
                var options = new DescribeTopicsOptionsBuilder(config)
                    .Topic(opts.Topic)
                    .Build()
                ;
                var result = await adminClient.DescribeTopics(
                    options,
                    cancellationToken
                );
                foreach (var topic in result.Topics)
                {
                    Console.WriteLine($"Id: {topic.TopicId}");
                    Console.WriteLine($"Name: {topic.Name}");
                    Console.WriteLine($"Internal: {topic.IsInternal}");
                    Console.WriteLine($"AuthorizedOperations: {topic.TopicAuthorizedOperations}");
                    Console.WriteLine($"Error: {Formatter.Print(topic.Error)}");
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
                await adminClient.Close(CancellationToken.None);
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
            out AdminClientConfig config
        )
        {
            config = new AdminClientConfig
            {
                ClientId = "kafka-cli.net",
                BootstrapServers = opts.BootstrapServer
            };
            return OptionsMapper.SetProperties(config, opts.Properties, Console.Out);
        }

        private static IAdminClient CreateAdminClient(
            KafkaCliOpts opts,
            AdminClientConfig config
        )
        {
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddConsole()
                    .SetMinimumLevel(opts.LogLevel)
                )
                .CreateLogger<IAdminClient>()
            ;
            return AdminClientBuilder
                .New()
                .WithConfig(config)
                .WithLogger(logger)
                .Build()
            ;
        }
    }
}
