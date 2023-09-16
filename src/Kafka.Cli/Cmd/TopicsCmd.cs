using CommandLine;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Clients.Admin;
using Kafka.Client.Clients.Admin.Model;
using Kafka.Common.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

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
            TopicsListOpts verb,
            CancellationToken cancellationToken
        )
        {
            try
            {
                using var adminClient = CreateAdminClient(verb, out var adminClientConfig);
                var options = new ListTopicsOptionsBuilder(adminClientConfig)
                    .IncludeInternal(!verb.ExcludeInternal)
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
            TopicsCreateOpts verb,
            CancellationToken cancellationToken
        )
        {
            try
            {
                using var adminClient = CreateAdminClient(verb, out var adminClientConfig);
                var replicaAssinment = new Dictionary<int, int[]>();
                var partitionReplicaAssignments = verb.ReplicaAssignment.Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var partitionReplicaAssignment in partitionReplicaAssignments)
                {
                    var kv = partitionReplicaAssignment.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    var key = int.Parse(kv[0]);
                    var value = kv[1].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray();
                    replicaAssinment.Add(key, value);
                }
                var options = new CreateTopicsOptionsBuilder(adminClientConfig)
                    .NewTopic(b => b
                        .Name(verb.Topic)
                        .NumPartitions(verb.PartitionCount)
                        .ReplicationFactor(verb.ReplicationFactor)
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
            TopicsDeleteOpts verb,
            CancellationToken cancellationToken
        )
        {
            try
            {
                using var adminClient = CreateAdminClient(verb, out var adminClientConfig);
                var options = new DeleteTopicsOptionsBuilder(adminClientConfig)
                    .TopicName(verb.Topic)
                    .TopicId(verb.TopicId)
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
            TopicsDescribeOpts verb,
            CancellationToken cancellationToken
        )
        {
            try
            {
                using var adminClient = CreateAdminClient(verb, out var adminClientConfig);
                var options = new DescribeTopicsOptionsBuilder(adminClientConfig)
                    .TopicName(verb.Topic)
                    .TopicId(verb.TopicId)
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

        private static IAdminClient CreateAdminClient(
            KafkaCliOpts options,
            out AdminClientConfig adminClientConfig
        )
        {
            adminClientConfig = new AdminClientConfig
            {
                BootstrapServers = options.BootstrapServer
            };
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddConsole()
                    .SetMinimumLevel(options.LogLevel)
                )
                .CreateLogger<IAdminClient>()
            ;
            return AdminClientBuilder
                .New()
                .WithConfig(adminClientConfig)
                .WithLogger(logger)
                .Build()
            ;
        }
    }
}
