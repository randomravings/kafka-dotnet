using CommandLine;
using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Clients.Producer;
using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Commands;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Kafka.Cli.Cmd
{
    internal static class ProducerCmd
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
        }).ParseArguments<ProducerOpts>(args)
            .MapResult(
                (ProducerOpts opts) => Run(opts, cancellationToken),
                errs => new ValueTask<int>(-1)
            )
        ;

        private static async ValueTask<int> Run(
            ProducerOpts opts,
            CancellationToken cancellationToken
        )
        {

            var config = new ProducerConfig
            {
                ClientId = "kafka-cli.net",
                BootstrapServers = opts.BootstrapServer,
                LingerMs = opts.LingerMs,
                MaxInFlightRequestsPerConnection = opts.MaxInFlightRequestsPerConnection,
                MaxRequestSize = opts.MaxRequestSize
            };
            if (!OptionsMapper.SetProperties(config, opts.Properties, Console.Out))
                return -1;

            var logger = LoggerFactory
                .Create(builder => builder
                    .AddConsole()
                    .SetMinimumLevel(opts.LogLevel)
                )
                .CreateLogger<IProducer<string, string>>()
            ;
            var producer = ProducerBuilder
                .New()
                .WithConfig(config)
                .WithKey(StringSerializer.Instance)
                .WithValue(StringSerializer.Instance)
                .WithLogger(logger)
                .Build()
            ;

            Console.WriteLine("Empty new line will terminate session.");
            var id = 0L;
            var commands = new ConcurrentDictionary<long, Task<ProduceResult>>();
            var transaction = default(ITransaction);
            while (!cancellationToken.IsCancellationRequested)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                switch (input)
                {
                    case "/bt":
                        if (transaction == null)
                            transaction = await producer.BeginTransaction(cancellationToken).ConfigureAwait(false);
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
                        await producer.Flush(cancellationToken).ConfigureAwait(false);
                        continue;
                }
                var split = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (split.Length != 2)
                {
                    Console.WriteLine("Format must be 'key,value'");
                    continue;
                }
                var record = new ProduceRecord<string, string>(
                    opts.Topic,
                    split[0],
                    split[1]
                );
                var command = await producer.Send(record, cancellationToken).ConfigureAwait(false);
                id = unchecked(id + 1);
                HandleCommand(command, commands, id);
            }
            await producer.Flush(cancellationToken).ConfigureAwait(false);
            await Task.WhenAll(commands.Values);
            commands.Clear();

            transaction?.Dispose();
            return 0;
        }

        static void HandleCommand(
            ICommand<ProduceResult> command,
            ConcurrentDictionary<long, Task<ProduceResult>> commands,
            long id
        )
        {
            var cb = command.Result();
            commands.TryAdd(id, cb);
            command.Result().ContinueWith(t =>
            {
                commands.Remove(id, out _);
                if (t.IsCompletedSuccessfully)
                {
                    var result = t.Result;
                    Console.WriteLine(Formatter.Print(result.TopicPartitionOffset));
                }

                if (t.IsFaulted)
                {
                    var exception = t.Exception?.ToString() ?? "Faulted without exception";
                    Console.WriteLine(exception);
                    return;
                }
            });
        }
    }
}
