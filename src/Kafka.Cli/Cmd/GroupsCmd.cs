using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Config;
using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Collections.Immutable;

namespace Kafka.Cli.Cmd
{
    internal static class GroupsCmd
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
            var result = parser.ParseArguments<GroupsListOpts, GroupsDescribeOpts, GroupsOffsetOpts, GroupsDeleteOpts>(args);
            return await result.MapResult(
                (GroupsListOpts opts) => List(opts, cancellationToken),
                (GroupsDescribeOpts opts) => Describe(opts, cancellationToken),
                (GroupsOffsetOpts opts) => Offsets(opts, cancellationToken),
                (GroupsDeleteOpts opts) => Delete(opts, cancellationToken),
                err => HelpTextWriter.DisplayHelp(result)
            );
        }

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
                    statesList,
                    opts.Types.ToList()
                );

                var result = await client.ListGroups(
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

        public static async Task<int> Offsets(
            GroupsOffsetOpts opts,
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


                var result = await client.GetOffsetsCommitted(
                    opts.Groups.Select(r => new ConsumerGroup(r)),
                    opts.Topics.Select(r => new TopicName(r)),
                    cancellationToken
                );

                var groupWidth = 5;
                var topicWidth = 5;

                foreach (var (group, topicPartitionOffsets) in result)
                {
                    groupWidth = Math.Max(groupWidth, group.Value.Length);
                    if (topicPartitionOffsets.Count > 0)
                        topicWidth = Math.Max(topicWidth, topicPartitionOffsets.Max(r => r.TopicPartition.Topic.TopicName.Value?.Length ?? 0));
                }
                groupWidth += 2;
                topicWidth += 2;

                Console.Write("GROUP".PadRight(groupWidth));
                Console.Write("TOPIC".PadRight(topicWidth));
                Console.Write("PARTITION  ");
                Console.Write("OFFSET");
                Console.WriteLine();
                foreach (var (group, topicPartitionOffsets) in result.OrderBy(r => r.Key, ConsumerGroupCompare.Instance))
                {
                    foreach (var topicPartitionOffset in topicPartitionOffsets.OrderBy(r => r.TopicPartition, TopicPartitionCompare.Instance))
                    {
                        Console.Write(group.Value.PadRight(groupWidth));
                        Console.Write((topicPartitionOffset.TopicPartition.Topic.TopicName.Value ?? "").PadRight(topicWidth));
                        Console.Write(topicPartitionOffset.TopicPartition.Partition.Value.ToString().PadRight(11));
                        Console.Write(topicPartitionOffset.Offset.Value.ToString().PadRight(11));
                        Console.WriteLine();
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

                var result = await client.DescribeGroups(
                    opts.Groups.Select(r => new ConsumerGroup(r)).ToImmutableArray(),
                    new DescribeGroupOptions(opts.ShowAllowedOperations),
                    cancellationToken
                );

                foreach (var group in result)
                {
                    Console.WriteLine();
                    Console.WriteLine(group.GroupId.Value);
                    Console.WriteLine($"  Coordinator:             {group.Coordinator.Value}");
                    Console.WriteLine($"  Protocol Type:           {group.ProtocolType}");
                    Console.WriteLine($"  Protocol Data:           {group.ProtocolData}");
                    Console.WriteLine($"  Group State:             {group.GroupId.Value}");
                    Console.WriteLine($"  Authorization:           {group.AuthorizedOperations}");
                    Console.WriteLine($"  Error:                   {group.Error.Label}");
                    if (group.Error.Code != ApiError.None.Code)
                    {
                        Console.WriteLine($"    Code:                  {group.Error.Code}");
                        Console.WriteLine($"    Message:               {group.Error.Message}");
                    }
                    Console.Write($"  Members:");
                    if (group.Members.Count > 0)
                    {
                        Console.WriteLine();
                        foreach (var member in group.Members)
                        {
                            Console.WriteLine($"    {member.MemberId}");
                            Console.WriteLine($"      Group Instance Id:   {member.GroupInstanceId}");
                            Console.WriteLine($"      Client Id:           {member.ClientId}");
                            Console.WriteLine($"      Client Host:         {member.ClientHost}");
                            Console.Write($"      Member Metadata: [");
                            if (member.MemberMetadata.Assignments.Count > 0)
                            {
                                Console.WriteLine();
                                foreach (var assignment in member.MemberMetadata.Assignments)
                                    Console.WriteLine($"        {Formatter.Print(assignment)}");
                                Console.Write("      ");
                            }
                            Console.WriteLine("]");
                            Console.Write($"      Member Assingment: [");
                            if (member.MemberAssignment.Count > 0)
                            {
                                Console.WriteLine();
                                foreach (var topicPartition in member.MemberAssignment)
                                    Console.WriteLine($"        {Formatter.Print(topicPartition)}");
                                Console.Write("      ");
                            }
                            Console.WriteLine("]");
                        }
                        Console.Write("  ");
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


                var result = await client.DeleteGroups(
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
