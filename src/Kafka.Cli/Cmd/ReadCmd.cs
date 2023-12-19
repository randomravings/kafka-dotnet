using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client;
using Kafka.Client.Config;
using Kafka.Client.IO;
using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Serialization.Nullable;
using System.Collections.Immutable;
using System.Text.Json;

namespace Kafka.Cli.Cmd
{
    internal static class ReadCmd
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
            var result = parser.ParseArguments<ReadOpts>(args);
            return await result.MapResult(
                (ReadOpts opts) => Run(opts, cancellationToken),
                err => HelpTextWriter.DisplayHelp(result)
            );
        }
        public static async Task<int> Run(
            ReadOpts opts,
            CancellationToken cancellationToken
        )
        {
            if (opts.ShowTimestamp)
            {
                try
                {
                    DateTimeOffset.UtcNow.ToString(opts.TimeStampFormat);
                }
                catch (FormatException)
                {
                    Console.WriteLine("invalid timestamp format string provided");
                    return -1;
                }
            }
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
                    await RunInteractive(stream, reader, opts, cancellationToken);
                else
                    await RunContinuously(reader, opts, cancellationToken);
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
            ReadOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (!opts.Quiet)
                    Console.WriteLine("Stream Reader Interactive: type help for instructions ...");
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.Write("> ");
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                        continue;
                    var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (args.Length == 0)
                        continue;
                    switch (args[0])
                    {
                        case "read":
                            await ReadInteractive(
                                reader,
                                opts,
                                args[1..],
                                cancellationToken
                            ).ConfigureAwait(false);
                            break;
                        case "commit":
                            await CommitInteractive(
                                stream,
                                args[1..],
                                cancellationToken
                            ).ConfigureAwait(false);
                            break;
                        case "help":
                            PrintHelp(
                                PrintReadHelp,
                                PrintCommitHelp
                            );
                            break;
                        case "exit":
                            return;
                        default:
                            Console.WriteLine($"invalid command {input}");
                            break;
                    }
                }
            }
            catch (OperationCanceledException) { }
        }

        private static async Task RunInteractive<TKey, TValue>(
            IAssignedReadStream stream,
            IAssignedReader<TKey, TValue> reader,
            ReadOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (!opts.Quiet)
                    Console.WriteLine("Stream Reader Interactive: type help for instructions ...");
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.Write("> ");
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                        continue;
                    var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (args.Length == 0)
                        continue;
                    switch (args[0])
                    {
                        case "read":
                            await ReadInteractive(
                                reader,
                                opts,
                                args[1..],
                                cancellationToken
                            ).ConfigureAwait(false);
                            break;
                        case "seek":
                            await SeekInteractive(
                                stream,
                                args[1..],
                                cancellationToken
                            ).ConfigureAwait(false);
                            break;
                        case "help":
                            PrintHelp(
                                PrintReadHelp,
                                PrintSeekHelp
                            );
                            break;
                        case "exit":
                            return;
                        default:
                            Console.WriteLine($"invalid command {input}");
                            break;
                    }
                }
            }
            catch (OperationCanceledException) { }
        }

        private static void PrintHelp(params Action[] items)
        {
            Console.WriteLine();
            Console.WriteLine("Available commands");
            foreach (var item in items)
            {
                Console.WriteLine();
                item();
            }
            Console.WriteLine();
            Console.WriteLine("  exit          Exits the program");
            Console.WriteLine();
            Console.WriteLine("  help          Display help text");
        }

        private static void PrintReadHelp()
        {
            Console.WriteLine("  read n t      Reads up to n records");
            Console.WriteLine("         n      Number of records to read before timeout");
            Console.WriteLine("                Optional");
            Console.WriteLine("                Default 10");
            Console.WriteLine("         t      Timeout in milliseconds");
            Console.WriteLine("                Optional");
            Console.WriteLine("                Default 1000");
        }

        private static void PrintCommitHelp()
        {
            Console.WriteLine("  commit tpo    Commits topic partition offsets");
            Console.WriteLine("         tpo    If omitted all read offsets will be committed");
            Console.WriteLine("                Format per item <topic>:<partition>:<offset> separated by space");
            Console.WriteLine("                Optional");
        }

        private static void PrintSeekHelp()
        {
            Console.WriteLine("  seek tpo      Seeks to a list of topic partition offsets");
            Console.WriteLine("       tpo      List of topic partition offsets.");
            Console.WriteLine("                Optional");
            Console.WriteLine("                Format: <topic>[<partition>:<offset>] separated by space");
        }

        private static async Task RunContinuously<TKey, TValue>(
            IReader<TKey, TValue> reader,
            ReadOpts opts,
            CancellationToken cancellationToken
        )
        {
            if (!opts.Quiet)
                Console.WriteLine("Stream Reader: Ctrl+C will terminate session.");
            while (!cancellationToken.IsCancellationRequested)
            {
                var readRecord = await reader.Read(cancellationToken);
                PrintRecord(readRecord, opts);
            }
        }

        private static async Task ReadInteractive<TKey, TValue>(
            IReader<TKey, TValue> reader,
            ReadOpts opts,
            string[] args,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var count = 10;
                var timeout = 1000;
                if (args.Length > 1 && !int.TryParse(args[1], out count))
                {
                    Console.WriteLine($"invalid count {args[1]}");
                    return;
                }
                if (args.Length > 2 && !int.TryParse(args[2], out timeout))
                {
                    Console.WriteLine($"invalid timeout {args[2]}");
                    return;
                }
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                cts.CancelAfter(timeout);
                for (int i = 0; i < count && !cts.Token.IsCancellationRequested; i++)
                {
                    var readRecord = await reader.Read(cts.Token);
                    PrintRecord(readRecord, opts);
                }
            }
            catch (OperationCanceledException)
            {
                if (cancellationToken.IsCancellationRequested)
                    throw;
            }
        }

        private static async Task CommitInteractive(
            IGroupReadStream stream,
            string[] args,
            CancellationToken cancellationToken
        )
        {
            if (args.Length > 0)
            {
                if (TryParseTopicPartitionOffsets(args, out var topicPartitionOffsets))
                    if (topicPartitionOffsets.Length == 1)
                        await stream.Commit(
                            topicPartitionOffsets[0],
                            cancellationToken
                        ).ConfigureAwait(false);
                    else
                        await stream.Commit(
                            topicPartitionOffsets,
                            cancellationToken
                        ).ConfigureAwait(false);
            }
            else
            {
                await stream.Commit(
                    cancellationToken
                ).ConfigureAwait(false);
            }
        }

        private static async Task SeekInteractive(
            IAssignedReadStream stream,
            string[] args,
            CancellationToken cancellationToken
        )
        {
            if (TryParseTopicPartitionOffsets(args, out var topicPartitionOffsets))
                await stream.Seek(
                    topicPartitionOffsets,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        private static void PrintRecord<TKey, TValue>(
            in ReadRecord<TKey, TValue> record,
            in ReadOpts opts
        )
        {
            if (opts.AsJson)
            {
                PrintJson(
                    record,
                    opts
                );
                return;
            }
            if (opts.TopicDetails.HasFlag(TopicDisplayLevel.Topic))
                Console.Write($"{Formatter.Print(record.TopicPartition.Topic.TopicName)}:");
            if (opts.TopicDetails.HasFlag(TopicDisplayLevel.Partition))
                Console.Write($"{Formatter.Print(record.TopicPartition.Partition)}:");
            if (opts.TopicDetails.HasFlag(TopicDisplayLevel.Offset))
                Console.Write($"{Formatter.Print(record.Offset)}:");
            if (opts.ShowTimestamp)
                Console.Write($"{Formatter.Print(record.Timestamp, opts.TimeStampFormat)}:");
            if (opts.ShowKey)
                Console.Write($"{Formatter.PrintKey(record.Key)}:");
            Console.WriteLine(Formatter.PrintValue(record.Value));
        }

        private static void PrintJson<TKey, TValue>(
            in ReadRecord<TKey, TValue> record,
            in ReadOpts opts
        )
        {
            using var writer = new Utf8JsonWriter(Console.OpenStandardOutput());
            writer.WriteStartObject();
            writer.WriteString("topic", record.TopicPartition.Topic.TopicName.Value);
            writer.WriteNumber("partition", record.TopicPartition.Partition.Value);
            writer.WriteNumber("offset", record.Offset.Value);
            writer.WriteString("timestamp", record.Timestamp.ToDateTimeOffset().ToString(opts.TimeStampFormat));
            writer.WriteStartArray("headers");
            foreach (var header in record.Headers)
            {
                writer.WriteStartObject();
                writer.WriteString("key", header.Key);
                writer.WriteString("value", header.Value.Span);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            if (record.Key == null)
                writer.WriteNull("key");
            else
                writer.WriteString("key", record.Key.ToString());
            if (record.Value == null)
                writer.WriteNull("key");
            else
                writer.WriteString("value", record.Value.ToString());
            writer.WriteEndObject();
            writer.Flush();
            Console.WriteLine();
        }

        private static async Task<int> RunAssignedReader(
            IKafkaClient client,
            ReadOpts opts,
            CancellationToken cancellationToken
        )
        {
            if (!TryParseTopicPartitionOffsets(opts.ToppicPartitionAssign.ToArray(), out var topicParitionOffsets))
                return -1;
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
                if (opts.Interactive)
                    await RunInteractive(stream, reader, opts, cancellationToken);
                else
                    await RunContinuously(reader, opts, cancellationToken);
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

        private static bool TryParseTopicPartitionOffsets(
            string[] topicPartitionAssignments,
            out ImmutableArray<TopicPartitionOffset> result
        )
        {
            if (topicPartitionAssignments.Length == 0)
            {
                Console.WriteLine($"empty list - expected list of '<topic_name>[<partition>:<offset>]'");
            }
            var separator = new char[] { '[', ']' };
            result = [];
            var builder = ImmutableArray.CreateBuilder<TopicPartitionOffset>();
            foreach (var topicAssignment in topicPartitionAssignments)
            {
                var topicAndPartitionOffsets = topicAssignment.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (topicAndPartitionOffsets.Length != 2)
                {
                    Console.WriteLine($"invalid format '{topicAssignment} - expected list of '<topic_name>[<partition>:<offset>]'");
                    return false;
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
                    Console.WriteLine($"invalid topic partition assignment '{topicAssignment} - expected list of 'topic_name[partition_offsets]'");
                    return false;
                }

                foreach (var partitionsAndOffset in partitionsAndOffsets)
                {
                    var partitionOffset = partitionsAndOffset.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    if (partitionOffset.Length < 1 || !int.TryParse(partitionOffset[0], out var partitionValue))
                    {
                        Console.WriteLine($"invalid partition {partitionsAndOffset} in '{topicAssignment}'");
                        return false;
                    }

                    var partition = new Partition(partitionValue);
                    var offset = Offset.Unset;
                    if (partitionOffset.Length == 2)
                    {
                        if (!long.TryParse(partitionOffset[1], out var offsetValue))
                        {
                            Console.WriteLine($"invalid offset {partitionsAndOffset} in '{topicAssignment}'");
                            return false;
                        }
                        offset = offsetValue;
                    }
                    builder.Add(new(new(topic, partition), offset));
                }
            }
            result = builder.ToImmutable();
            return true;
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
