using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Config;
using Kafka.Client.IO;
using Kafka.Common.Model;
using Kafka.Common.Serialization.Nullable;

namespace Kafka.Cli.Cmd
{
    internal static class WriteCmd
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
        }).ParseArguments<WriteOpts>(args)
            .MapResult(
                (WriteOpts opts) => Run(opts, cancellationToken),
                errs => Task.FromResult(-1)
            )
        ;

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

            Console.WriteLine("Empty new line will terminate session.");
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
                            if (batching)
                            {
                                Console.WriteLine("Batching is already in progress");
                            }
                            else
                            {
                                batching = true;
                                Console.WriteLine("Batching started");
                            }
                            continue;
                        case "/eb":
                            if (!batching)
                            {
                                Console.WriteLine("Batching is not in progress");
                            }
                            else
                            {
                                Console.WriteLine("Batching completed");
                                await HandleBatch(
                                    topic,
                                    writer,
                                    batch,
                                    cancellationToken
                                );
                                batching = false;
                            }
                            continue;
                        case "/bt":
                            if (transaction == null)
                            {
                                transaction = await outputStream.BeginTransaction(cancellationToken).ConfigureAwait(false);
                                Console.WriteLine("Transaction in progress");
                            }
                            else
                            {
                                Console.WriteLine("Transaction is already in progress");
                            }
                            continue;
                        case "/ct":
                            if (transaction != null)
                            {
                                await transaction.Commit(cancellationToken).ConfigureAwait(false);
                                transaction = null;
                                Console.WriteLine("Transaction committed");
                            }
                            else
                            {
                                Console.WriteLine("Transaction is not in progress");
                            }
                            continue;
                        case "/rt":
                            if (transaction != null)
                            {
                                await transaction.Rollback(cancellationToken).ConfigureAwait(false);
                                transaction = null;
                                Console.WriteLine("Transaction rolled back");
                            }
                            else
                            {
                                Console.WriteLine("Transaction is not in progress");
                            }
                            continue;
                        case "/fl":
                            await outputStream.Flush(cancellationToken).ConfigureAwait(false);
                            continue;
                        default:
                            var split = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                            if (split.Length != 2)
                            {
                                Console.WriteLine("Format must be 'key,value'");
                            }
                            else if (batching)
                            {
                                batch.Add(new KeyValuePair<string, string>(split[0], split[1]));
                            }
                            else
                            {
                                var result = await writer.Write(topic, split[0], split[1], cancellationToken).ConfigureAwait(false);
                                Console.WriteLine(Formatter.Print(result.TopicPartitionOffset));
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
                    Console.WriteLine(Formatter.Print(result.TopicPartitionOffset));
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
