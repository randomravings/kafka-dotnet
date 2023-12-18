using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client;
using Kafka.Client.Config;
using Kafka.Client.IO;
using Kafka.Common.Model;
using Kafka.Common.Serialization.Nullable;
using System.Collections.Immutable;

namespace Kafka.Cli.Cmd
{
    internal static class ReadCmd
    {
        public static async Task<int> Parse(
            IEnumerable<string> args,
            CancellationToken cancellationToken
        ) => await new Parser(with =>
        {
            with.CaseSensitive = true;
            with.HelpWriter = Console.Out;
            with.IgnoreUnknownArguments = false;
            with.CaseInsensitiveEnumValues = true;
            with.AllowMultiInstance = false;
        }).ParseArguments<ReadOpts>(args)
            .MapResult(
                (ReadOpts opts) => Run(opts, cancellationToken),
                errs => Task.FromResult(-1)
            )
        ;

        public static async Task<int> Run(
            ReadOpts opts,
            CancellationToken cancellationToken
        )
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

            try
            {
                if (opts.ToppicPartitionAssign.Any())
                    await RunAssignedReader(client, opts, cancellationToken);
                else
                    await RunGroupReader(client, opts, cancellationToken);
            }
            finally
            {
                using var cts = new CancellationTokenSource();
                cts.CancelAfter(5000);
                await CloseClient(client, cts.Token);
            }
            return 0;
        }

        private static async Task RunGroupReader(
            IKafkaClient client,
            ReadOpts opts,
            CancellationToken cancellationToken
        )
        {
            var topicNames = opts.Topics.Select(r => new TopicName(r)).ToHashSet();
            var stream = client
                .CreateReadStream()
                .AsGroup()
                .Build()
            ;

            var reader = stream
                .CreateReader()
                .WithTopics(topicNames)
                .WithKey(StringSerde.Deserializer)
                .WithValue(StringSerde.Deserializer)
                .Build()
            ;
            try
            {
                if (opts.Interactive)
                    await RunInteractive(stream, reader, topicNames, cancellationToken);
                else
                    await RunContinuously(reader, cancellationToken);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                using var cts = new CancellationTokenSource();
                cts.CancelAfter(5000);
                await CloseReader(reader, cts.Token);
                await CloseStream(stream, cts.Token);
                await CloseClient(client, cts.Token);
            }
        }

        private static async Task RunInteractive<TKey, TValue>(
            IGroupReadStream stream,
            IGroupReader<TKey, TValue> reader,
            IReadOnlySet<TopicName> topics,
            CancellationToken cancellationToken
        )
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.Write("> ");
                var key = Console.ReadLine();
                if (key == null)
                    break;
                try
                {
                    var args = key.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (args.Length == 0)
                        continue;
                    switch (args[0])
                    {
                        case "fetch":
                            var recordsToFetch = int.Parse(args[1]);
                            if (args.Length < 3 || !int.TryParse(args[2], out var waitTimeout))
                                waitTimeout = 1000;
                            await Fetch(reader, recordsToFetch, waitTimeout, cancellationToken);
                            break;
                        case "commit":
                            var commitArgs = args.Skip(1).ToArray();
                            switch (commitArgs)
                            {
                                case { Length: 0 }:
                                    await stream.Commit(cancellationToken);
                                    break;
                                case { Length: 1 }:
                                    if (TryParseTopicPartitionOffset(topics, args[1], out var topicPartitionOffset))
                                        await stream.Commit(topicPartitionOffset, cancellationToken);
                                    break;
                                default:
                                    if (TryParseTopicPartitionOffsets(topics, args.Skip(1).ToArray(), out var topicPartitionOffsets))
                                        await stream.Commit(topicPartitionOffsets, cancellationToken);
                                    break;
                            }
                            break;
                    }
                }
                catch (OperationCanceledException) { }
            }
        }

        private static async Task RunInteractive<TKey, TValue>(
            IAssignedReadStream stream,
            IAssignedReader<TKey, TValue> reader,
            CancellationToken cancellationToken
        )
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.Write("> ");
                var key = Console.ReadLine();
                if (key == null)
                    break;
                try
                {
                    var args = key.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (args.Length == 0)
                        continue;
                    switch (args[0])
                    {
                        case "fetch":
                            var recordsToFetch = int.Parse(args[1]);
                            if (args.Length < 3 || !int.TryParse(args[2], out var waitTimeout))
                                waitTimeout = 1000;
                            await Fetch(reader, recordsToFetch, waitTimeout, cancellationToken);
                            break;
                    }
                }
                catch (OperationCanceledException) { }
            }
        }

        private static bool TryParseTopicPartitionOffsets(IReadOnlySet<TopicName> topicNames, string[] args, out IList<TopicPartitionOffset> topicPartitionOffsets)
        {
            topicPartitionOffsets = new List<TopicPartitionOffset>(args.Length);
            foreach (var arg in args)
                if (TryParseTopicPartitionOffset(topicNames, arg, out var topicPartitionOffset))
                    topicPartitionOffsets.Add(topicPartitionOffset);
                else
                    return false;
            return true;
        }

        private static bool TryParseTopicPartitionOffset(IReadOnlySet<TopicName> topicNames, string args, out TopicPartitionOffset topicPartition)
        {
            topicPartition = TopicPartitionOffset.Empty;
            var components = args.Split(':', StringSplitOptions.RemoveEmptyEntries);
            if (components.Length != 3)
            {
                Console.WriteLine("Commit argument must be <topic>:<partition>:<offset>");
                return false;
            }
            var topicName = components[0];
            if (!topicNames.Contains(topicName))
            {
                Console.WriteLine($"Unknown topic in argument {topicName}");
                return false;
            }
            if (!int.TryParse(components[1], out var partition))
            {
                Console.WriteLine("Partition must be a digit");
                return false;
            }
            if (!long.TryParse(components[2], out var offset))
            {
                Console.WriteLine("Offset must be a digit");
                return false;
            }
            topicPartition = new(new(topicName, partition), offset);
            return true;
        }

        private static async Task RunContinuously<TKey, TValue>(
            IReader<TKey, TValue> reader,
            CancellationToken cancellationToken
        )
        {
            Console.WriteLine("Stream Reader: Ctrl+C will terminate session.");
            while (!cancellationToken.IsCancellationRequested)
            {
                var readRecord = await reader.Read(cancellationToken);
                Console.WriteLine(
                    Formatter.Print(
                        readRecord
                    )
                );
            }
        }

        private static async Task Fetch<TKey, TValue>(
            IReader<TKey, TValue> reader,
            int recordCount,
            int timeoutMs,
            CancellationToken cancellationToken
        )
        {
            try
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                cts.CancelAfter(timeoutMs);
                for (int i = 0; i < recordCount && !cts.Token.IsCancellationRequested; i++)
                {
                    var readRecord = await reader.Read(cts.Token);
                    Console.WriteLine(
                        Formatter.Print(
                            readRecord
                        )
                    );
                }
            }
            catch (OperationCanceledException)
            {
                if (cancellationToken.IsCancellationRequested)
                    throw;
            }
        }

        private static async Task<int> RunAssignedReader(
            IKafkaClient client,
            ReadOpts opts,
            CancellationToken cancellationToken
        )
        {
            var topicParitionOffsets = ParsePartitionAssign(opts.ToppicPartitionAssign);
            var stream = client
                .CreateReadStream()
                .AsAssigned()
                .Build()
            ;

            var reader = stream
                .CreateReader()
                .WithTopicPartitionOffsets(topicParitionOffsets)
                .WithKey(StringSerde.Deserializer)
                .WithValue(StringSerde.Deserializer)
                .Build()
            ;

            try
            {
            if(opts.Interactive)
                await RunInteractive(stream, reader, cancellationToken);
            else
                await RunContinuously(reader, cancellationToken);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                using var cts = new CancellationTokenSource();
                cts.CancelAfter(5000);
                await CloseReader(reader, cts.Token);
                await CloseStream(stream, cts.Token);
                await CloseClient(client, cts.Token);
            }

            return 0;
        }

        internal static readonly char[] separator = ['[', ']'];

        private static ImmutableArray<TopicPartitionOffset> ParsePartitionAssign(IEnumerable<string> topicPartitionAssignments)
        {
            var builder = ImmutableArray.CreateBuilder<TopicPartitionOffset>();
            foreach (var topicAssignment in topicPartitionAssignments)
            {
                var topicAndPartitionOffsets = topicAssignment.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (topicAndPartitionOffsets.Length != 2)
                {
                    Console.WriteLine($"Invalid topic partition assignment '{topicAssignment} - expected 'topic_name[partition_offsets]'");
                    return [];
                }
                var topicNameOrId = topicAndPartitionOffsets[0];
                var topic = Topic.Empty;
                if (Guid.TryParse(topicNameOrId, out var topicIdValue))
                    topic = topicIdValue;
                else
                    topic = topicNameOrId;


                var partitionsAndOffsets = topicAndPartitionOffsets[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (partitionsAndOffsets.Length == 0)
                {
                    Console.WriteLine($"Invalid topic partition assignment '{topicAssignment} - expected 'topic_name[partition_offsets]'");
                    return [];
                }

                foreach (var partitionsAndOffset in partitionsAndOffsets)
                {
                    var partitionOffset = partitionsAndOffset.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    if (partitionOffset.Length < 1 || !int.TryParse(partitionOffset[0], out var partitionValue))
                    {
                        Console.WriteLine($"Invalid partition {partitionsAndOffset} in '{topicAssignment}'");
                        return [];
                    }

                    var partition = new Partition(partitionValue);
                    var offset = Offset.Unset;
                    if (partitionOffset.Length == 2)
                    {
                        if (!long.TryParse(partitionOffset[1], out var offsetValue))
                        {
                            Console.WriteLine($"Invalid offset {partitionsAndOffset} in '{topicAssignment}'");
                            return [];
                        }
                        offset = offsetValue;
                    }
                    builder.Add(new(new(topic, partition), offset));
                }
            }
            return builder.ToImmutable();
        }

        private static async Task CloseClient(
            IKafkaClient client,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await client.Close(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static async Task CloseStream(
            IReadStream inputStream,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await inputStream.Close(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static async Task CloseReader<TKey, TValue>(
            IReader<TKey, TValue> streamReader,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await streamReader.Close(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static KafkaClientConfig CreateConfig(
            ReadOpts opts
        )
        {
            var groupId = opts.GroupId;
            if (string.IsNullOrEmpty(groupId))
                groupId = $"{Guid.NewGuid()}";
            var config = new KafkaClientConfig
            {
                Client = new()
                {
                    ClientId = "kafka-cli.net",
                    BootstrapServers = opts.BootstrapServer
                },
                ReadStream = new()
                {
                    GroupId = groupId,
                    EnableAutoCommit = !opts.Interactive
                }
            };
            return config;
        }
    }
}
