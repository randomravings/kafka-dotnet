using CommandLine;
using Kafka.Cli.Client;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client;
using Kafka.Client.Config;
using Kafka.Client.IO;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Cli.Cmd
{
    internal static class ProducerCmd
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
        }).ParseArguments<ProducerOpts>(args)
            .MapResult(
                (ProducerOpts opts) => Run(opts, cancellationToken),
                errs => Task.FromResult(-1)
            )
        ;

        private static async Task<int> Run(
            ProducerOpts opts,
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

            using var outputStream = client
                .CreateOuputStream()
                .Build()
            ;

            using var writer = outputStream
                .CreateWriter(opts.Topic)
                .WithKey(StringSerializer.Instance)
                .WithValue(StringSerializer.Instance)
                .Build()
            ;

            Console.WriteLine("Empty new line will terminate session.");
            var transaction = default(ITransaction);
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                        break;
                    switch (input)
                    {
                        case "/bt":
                            if (transaction == null)
                                transaction = await outputStream.BeginTransaction(cancellationToken).ConfigureAwait(false);
                            else
                                Console.WriteLine("Transaction in progress");
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
                    }
                    var split = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (split.Length != 2)
                    {
                        Console.WriteLine("Format must be 'key,value'");
                        continue;
                    }
                    var result = await writer.Write(split[0], split[1], cancellationToken).ConfigureAwait(false);
                    Console.WriteLine(Formatter.Print(result.TopicPartitionOffset));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            using var cts = new CancellationTokenSource();
            cts.CancelAfter(5000);

            await outputStream.Flush(cts.Token).ConfigureAwait(false);
            await outputStream.Close(cts.Token).ConfigureAwait(false);
            await client.Close(cts.Token).ConfigureAwait(false);

            transaction?.Dispose();
            return 0;
        }

        private static KafkaClientConfig CreateConfig(
            ProducerOpts opts
        )
        {
            var config = new KafkaClientConfig
            {
                ClientId = "kafka-cli.net",
                BootstrapServers = opts.BootstrapServer,
                Producer = new OutputStreamConfig
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
