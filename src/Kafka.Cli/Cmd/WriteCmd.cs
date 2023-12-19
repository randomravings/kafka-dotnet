using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Config;
using Kafka.Client.IO;
using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Serialization.Nullable;

namespace Kafka.Cli.Cmd
{
    internal static class WriteCmd
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
            var result = parser.ParseArguments<WriteOpts>(args);
            return await result.MapResult(
                (WriteOpts opts) => Run(opts, cancellationToken),
                err => HelpTextWriter.DisplayHelp(result)
            );
        }

        private static async Task<int> Run(
            WriteOpts opts,
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

            var outputStream = client
                .CreateWriteStream()
                .Build()
            ;

            var writer = outputStream
                .CreateWriter()
                .WithKey(StringSerde.Serializer)
                .WithValue(StringSerde.Serializer)
                .Build()
            ;

            var topic = new TopicName(opts.Topic);

            if (!opts.Quiet)
                Console.WriteLine("Stream Writer: Empty new or Ctrl+C line will terminate session.");
            var transaction = default(ITransaction);
            var batch = new List<KeyValuePair<string, string>>();
            var batching = false;
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                        break;
                    switch (input)
                    {
                        case "/sb":
                            if (!batching)
                                batching = true;
                            continue;
                        case "/eb":
                            if (batching)
                            {
                                await HandleBatch(
                                    topic,
                                    writer,
                                    batch,
                                    opts,
                                    cancellationToken
                                );
                                batching = false;
                            }
                            continue;
                        case "/bt":
                            transaction ??= await outputStream.BeginTransaction(cancellationToken).ConfigureAwait(false);
                            continue;
                        case "/ct":
                            if (transaction != null)
                            {
                                await transaction.Commit(cancellationToken).ConfigureAwait(false);
                                transaction = null;
                            }
                            continue;
                        case "/rt":
                            if (transaction != null)
                            {
                                await transaction.Rollback(cancellationToken).ConfigureAwait(false);
                                transaction = null;
                            }
                            continue;
                        case "/fl":
                            await outputStream.Flush(cancellationToken).ConfigureAwait(false);
                            continue;
                        default:
                            var split = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                            if (split.Length != 2)
                            {
                                Console.WriteLine("format must be 'key,value'");
                            }
                            else if (batching)
                            {
                                batch.Add(new KeyValuePair<string, string>(split[0], split[1]));
                            }
                            else
                            {
                                var result = await writer.Write(topic, split[0], split[1], cancellationToken).ConfigureAwait(false);
                                PrintResult(result, opts);
                            }
                            continue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            using var cts = new CancellationTokenSource();
            cts.CancelAfter(5000);

            if (batch.Count > 0)
                await HandleBatch(
                    topic,
                    writer,
                    batch,
                    opts,
                    cts.Token
                );
            await outputStream.Flush(cts.Token).ConfigureAwait(false);
            await outputStream.Close(cts.Token).ConfigureAwait(false);
            await client.Close(cts.Token).ConfigureAwait(false);

            transaction?.Dispose();
            return 0;
        }

        private static async ValueTask HandleBatch(
            TopicName topic,
            IStreamWriter<string, string> writer,
            List<KeyValuePair<string, string>> batch,
            WriteOpts opts,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var tasks = batch
                    .Select(r =>
                        writer.Write(
                            topic,
                            r.Key,
                            r.Value,
                            cancellationToken
                        )
                    )
                    .ToArray()
                ;
                var results = await Task.WhenAll(tasks);
                foreach (var result in results)
                    PrintResult(result, opts);
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.InnerExceptions)
                    Console.WriteLine(ex.ToString());
            }
            catch (OperationCanceledException)
            {

            }
            batch.Clear();
        }

        private static void PrintResult(
            in WriteResult result,
            in WriteOpts opts
        )
        {
            if (opts.TopicDetails == TopicDisplayLevel.None)
                return;
            if (opts.TopicDetails.HasFlag(TopicDisplayLevel.Topic))
            {
                Console.Write(Formatter.Print(result.TopicPartitionOffset.TopicPartition.Topic.TopicName));
                if (opts.TopicDetails.HasFlag(TopicDisplayLevel.PartitionOffset))
                    Console.Write(':');
            }
            if (opts.TopicDetails.HasFlag(TopicDisplayLevel.Partition))
            {
                Console.Write(Formatter.Print(result.TopicPartitionOffset.TopicPartition.Partition));
                if (opts.TopicDetails.HasFlag(TopicDisplayLevel.Offset))
                    Console.Write(':');
            }
            if (opts.TopicDetails.HasFlag(TopicDisplayLevel.Offset))
                Console.Write(Formatter.Print(result.TopicPartitionOffset.Offset));
            Console.WriteLine();
        }

        private static KafkaClientConfig CreateConfig(
            WriteOpts opts
        )
        {
            var config = new KafkaClientConfig
            {
                Client = new()
                {
                    ClientId = "kafka-cli.net",
                    BootstrapServers = opts.BootstrapServer
                },
                WriteStream = new()
                {
                    LingerMs = opts.LingerMs,
                    MaxInFlightRequestsPerConnection = opts.MaxInFlightRequestsPerConnection,
                    MaxRequestSize = opts.MaxRequestSize
                }
            };
            return config;
        }
    }
}
