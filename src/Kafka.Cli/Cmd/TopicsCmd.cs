using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Config;
using Kafka.Client.Model;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Cli.Cmd
{
    internal static class TopicsCmd
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
            var result = parser.ParseArguments<TopicsListOpts, TopicsCreateOpts, TopicsDescribeOpts, TopicsDeleteOpts>(args);
            return await result.MapResult(
                (TopicsListOpts opts) => List(opts, cancellationToken),
                (TopicsCreateOpts opts) => Create(opts, cancellationToken),
                (TopicsDescribeOpts opts) => Describe(opts, cancellationToken),
                (TopicsDeleteOpts opts) => Delete(opts, cancellationToken),
                err => HelpTextWriter.DisplayHelp(result)
            );
        }

        public static async Task<int> List(
            TopicsListOpts opts,
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

                var options = new ListTopicsOptions(
                    opts.IncludeInternal,
                    opts.ShowAllowedOperations
                );
                var result = await client.ListTopics(
                    options,
                    cancellationToken
                );
                foreach (var topic in result.Where(t => options.IncludeInternal || t.Internal == false))
                    Console.WriteLine(topic.TopicName);
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

                var config = CreateConfig(
                    opts
                );

                if (!ClientUtils.TrySetProperties(config, opts, Console.Out))
                    return -1;

                using var client = ClientUtils.CreateClient(
                    opts,
                    config
                );

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
                    ImmutableDictionary<Partition, IReadOnlySet<NodeId>>.Empty,
                    ImmutableDictionary<string, string?>.Empty
                );
                var result = await client.CreateTopic(
                    definition,
                    CreateTopicOptions.Empty,
                    cancellationToken
                );
                PrintCreateTopic(result);
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
            CreateTopicsResult result
        )
        {
            foreach (var topic in result.Topics)
            {
                if (topic.Error.Code == 0)
                {
                    Console.WriteLine($"  Topic Id:   {topic.TopicId.Value}");
                    Console.WriteLine($"  Topic Name: {topic.TopicName.Value}");
                    Console.WriteLine($"    Partitions:         {topic.NumPartitions}");
                    Console.WriteLine($"    Replication Factor: {topic.ReplicationFactor}");
                }
                else
                {
                    Console.WriteLine($"  Topic Name: {topic.TopicName.Value}");
                    Console.WriteLine($"    {Formatter.Print(topic.Error)}");
                }
            }
        }

        public static async Task<int> Delete(
            TopicsDeleteOpts opts,
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

                var result = await client.DeleteTopic(
                    opts.Topic,
                    cancellationToken
                );
                foreach (var topic in result.Topics)
                {
                    if (topic.Error.Code == 0)
                    {
                        Console.WriteLine($"  Topic Id:   {topic.TopicId.Value}");
                        Console.WriteLine($"  Topic Name: {topic.TopicName.Value}");
                    }
                    else
                    {
                        Console.WriteLine($"  Topic Name: {topic.TopicName.Value}");
                        Console.WriteLine($"    {Formatter.Print(topic.Error)}");
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

        public static async Task<int> Describe(
            TopicsDescribeOpts opts,
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

                var result = await client.ListTopics(
                    opts.Topic,
                    new ListTopicsOptions(true, opts.ShowAllowedOperations),
                    cancellationToken
                );
                foreach (var topic in result)
                {
                    Console.WriteLine();
                    Console.WriteLine(topic.TopicName.Value);
                    Console.WriteLine($"  Id: {topic.TopicId}");
                    Console.WriteLine($"  Error: {Formatter.Print(topic.Error)}");
                    Console.WriteLine($"  Internal: {Formatter.Print(topic.Internal)}");
                    Console.WriteLine($"  AuthorizedOperations: [{topic.TopicAuthorizedOperations}]");
                    Console.WriteLine($"  Partitions: [");
                    foreach (var partition in topic.Partitions.OrderBy(r => r.PartitionIndex.Value))
                    {
                        Console.WriteLine($"    Partition: {partition.PartitionIndex.Value}");
                        Console.WriteLine($"      LeaderId: {partition.LeaderId.Value}");
                        Console.WriteLine($"      LeaderEpoch: {partition.LeaderEpoch.Value}");
                        Console.WriteLine($"      Error: {Formatter.Print(topic.Error)}");
                        Console.WriteLine($"      ReplicaNodes: [{string.Join(',', partition.ReplicaNodes.Select(r => r.Value))}]");
                        Console.WriteLine($"      IsrNodes: [{string.Join(',', partition.IsrNodes.Select(r => r.Value))}]");
                        Console.WriteLine($"      OfflineReplicas: [{string.Join(',', partition.OfflineReplicas.Select(r => r.Value))}]");
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
