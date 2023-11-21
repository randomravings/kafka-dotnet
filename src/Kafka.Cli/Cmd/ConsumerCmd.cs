using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client;
using Kafka.Client.Config;
using Kafka.Client.IO;
using Kafka.Common.Model;
using Kafka.Common.Serialization;

namespace Kafka.Cli.Cmd
{
    internal static class ConsumerCmd
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
        }).ParseArguments<ConsumerOpts>(args)
            .MapResult(
                (ConsumerOpts opts) => Run(opts, cancellationToken),
                errs => Task.FromResult(-1)
            )
        ;

        public static async Task<int> Run(
            ConsumerOpts opts,
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
                var topicNames = opts.Topics.Select(r => new TopicName(r)).ToHashSet();
                if (opts.PartitionAssign.Any())
                    await RunAssignedConsumer(client, cancellationToken);
                else
                    await RunApplicationConsumer(client, topicNames, opts.Interactive, cancellationToken);
            }
            finally
            {
                using var cts = new CancellationTokenSource();
                cts.CancelAfter(5000);
                await CloseClient(client, cts.Token);
            }
            return 0;
        }

        private static async Task RunApplicationConsumer(
            IKafkaClient client,
            IReadOnlySet<TopicName> topicNames,
            bool interactive,
            CancellationToken cancellationToken
        )
        {
            using var stream = client
                .CreateInputStream()
                .AsApplication(topicNames)
                .Build()
            ;

            using var reader = stream
                .CreateReader()
                .WithKey(StringDeserializer.Instance)
                .WithValue(StringDeserializer.Instance)
                .Build()
            ;
            try
            {
                if (interactive)
                    await Interactive(stream, reader, topicNames, cancellationToken);
                else
                    await Fetch(reader, cancellationToken);
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

        private static async Task Interactive<TKey, TValue>(
            IApplicationInputStream inputStream,
            IStreamReader<TKey, TValue> streamReader,
            IReadOnlySet<TopicName> topicNames,
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
                            await Fetch(streamReader, recordsToFetch, waitTimeout, cancellationToken);
                            break;
                        case "commit":
                            var commitArgs = args.Skip(1).ToArray();
                            switch (commitArgs)
                            {
                                case { Length: 0 }:
                                    await inputStream.Commit(cancellationToken);
                                    break;
                                case { Length: 1 }:
                                    if(TryParseTopicPartitionOffset(topicNames, args[1], out var topicPartitionOffset))
                                        await inputStream.Commit(topicPartitionOffset, cancellationToken);
                                    break;
                                default:
                                    if (TryParseTopicPartitionOffsets(topicNames, args.Skip(1).ToArray(), out var topicPartitionOffsets))
                                        await inputStream.Commit(topicPartitionOffsets, cancellationToken);
                                    break;
                            }
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

        private static async Task Fetch<TKey, TValue>(
            IStreamReader<TKey, TValue> streamReader,
            CancellationToken cancellationToken
        )
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumerRecord = await streamReader.Read(cancellationToken);
                Console.WriteLine(
                    Formatter.Print(
                        consumerRecord
                    )
                );
            }
        }

        private static async Task Fetch<TKey, TValue>(
            IStreamReader<TKey, TValue> streamReader,
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
                    var consumerRecord = await streamReader.Read(cts.Token);
                    Console.WriteLine(
                        Formatter.Print(
                            consumerRecord
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

        private static Task RunAssignedConsumer(
            IKafkaClient client,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
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
            IInputStream inputStream,
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
            IStreamReader<TKey, TValue> streamReader,
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
            ConsumerOpts opts
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
                Consumer = new()
                {
                    GroupId = groupId,
                    EnableAutoCommit = !opts.Interactive
                }
            };
            return config;
        }
    }
}
