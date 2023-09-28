﻿using CommandLine;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Clients.Consumer;
using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Cli.Cmd
{
    internal static class ConsumerCmd
    {

        public static async ValueTask<int> Parse(
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
                errs => new ValueTask<int>(-1)
            )
        ;

        public static async ValueTask<int> Run(
            ConsumerOpts opts,
            CancellationToken cancellationToken
        )
        {
            var config = CreateConfig(
                opts
            );
            if (!OptionsMapper.SetProperties(config, opts.Properties, Console.Out))
                return -1;

            using var consumer = CreateConsumer(
                opts,
                config,
                StringDeserializer.Instance,
                StringDeserializer.Instance
            );
            try
            {
                var topicNames = opts.Topics.Select(r => new TopicName(r)).ToHashSet();
                if (opts.PartitionAssign.Any())
                    await RunAssignedConsumer(consumer, cancellationToken);
                else
                    await RunApplicationConsumer(consumer, topicNames, opts.Interactive, cancellationToken);
            }
            finally
            {
                await consumer.Close(CancellationToken.None);
            }
            return 0;
        }

        private static async Task RunApplicationConsumer<TKey, TValue>(
            IConsumer<TKey, TValue> consumer,
            IReadOnlySet<TopicName> topicNames,
            bool interactive,
            CancellationToken cancellationToken
        )
        {
            using var streamReader = await consumer.CreateInstance(
                topicNames,
                cancellationToken
            );
            try
            {
                if (interactive)
                    await Interactive(streamReader, topicNames, cancellationToken);
                else
                    await Fetch(streamReader, cancellationToken);
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
                await CloseStream(streamReader, cts.Token);
                await consumer.Close(cts.Token);
            }
        }

        private static async Task Interactive<TKey, TValue>(
            IStreamReaderApplication<TKey, TValue> streamReader,
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
                                    await streamReader.Commit(cancellationToken);
                                    break;
                                case { Length: 1 }:
                                    if(TryParseTopicPartitionOffset(topicNames, args[1], out var topicPartitionOffset))
                                        await streamReader.Commit(topicPartitionOffset, cancellationToken);
                                    break;
                                default:
                                    if (TryParseTopicPartitionOffsets(topicNames, args.Skip(1).ToArray(), out var topicPartitionOffsets))
                                        await streamReader.Commit(topicPartitionOffsets, cancellationToken);
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
                var consumerRecord = await streamReader.Fetch(cancellationToken);
                Console.WriteLine(Formatter.Print(consumerRecord));
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
                    var consumerRecord = await streamReader.Fetch(cts.Token);
                    Console.WriteLine(Formatter.Print(consumerRecord));
                }
            }
            catch (OperationCanceledException)
            {
                if (cancellationToken.IsCancellationRequested)
                    throw;
            }
        }

        private static Task RunAssignedConsumer(
            IConsumer<string, string> consumer,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        private static async Task CloseStream<TKey, TValue>(IStreamReader<TKey, TValue> instance, CancellationToken cancellationToken)
        {
            try
            {
                await instance.Close(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static ConsumerConfig CreateConfig(
            ConsumerOpts verb
        )
        {
            var groupId = verb.GroupId;
            if (string.IsNullOrEmpty(groupId))
                groupId = $"{Guid.NewGuid()}";
            return new ConsumerConfig
            {
                ClientId = "kafka-cli.net",
                BootstrapServers = verb.BootstrapServer,
                GroupId = groupId,
                EnableAutoCommit = !verb.Interactive
            };
        }

        private static IConsumer<TKey, TValue> CreateConsumer<TKey, TValue>(
            ConsumerOpts verb,
            ConsumerConfig config,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        )
        {
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddSimpleConsole()
                    .SetMinimumLevel(verb.LogLevel)

                )
                .CreateLogger<IConsumer<TKey, TValue>>()
            ;
            return ConsumerBuilder
                .New()
                .WithConfig(config)
                .WithKey(keyDeserializer)
                .WithValue(valueDeserializer)
                .WithLogger(logger)
                .Build()
            ;
        }
    }
}
