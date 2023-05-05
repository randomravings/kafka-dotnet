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
            ProducerOpts options,
            CancellationToken cancellationToken
        )
        {
            var commands = new BlockingCollection<ICommand<ProduceResult>>();
            var config = new ProducerConfig
            {
                ClientId = options.ClientId,
                BootstrapServers = options.BootstrapServer,
                TransactionalId = options.TransactionalId,
                LingerMs = options.LingerMs,
                MaxInFlightRequestsPerConnection = options.MaxInFlightRequestsPerConnection,
                MaxRequestSize = options.MaxRequestSize
            };
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddConsole()
                    .SetMinimumLevel(options.LogLevel)
                )
                .CreateLogger<IProducer<string, string>>()
            ;
            var producer = ProducerBuilder
                .New()
                .WithConfig(config)
                .WithKey(Serializers.Utf8)
                .WithValue(Serializers.Utf8)
                .WithLogger(logger)
                .Build()
            ;
            var resultHandler = HandleResults(commands, cancellationToken);

            Console.WriteLine("Empty new line will terminate session.");
            while (!cancellationToken.IsCancellationRequested)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    return 0;
                switch (input)
                {
                    case "/bt":
                        await producer.BeginTransaction(cancellationToken);
                        continue;
                    case "/ct":
                        await producer.CommitTransaction(cancellationToken);
                        continue;
                    case "/rt":
                        await producer.RollbackTransaction(cancellationToken);
                        continue;
                    case "/fl":
                        await producer.Flush(cancellationToken);
                        continue;
                }
                var split = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (split.Length != 2)
                {
                    Console.WriteLine("Format must be 'key,value'");
                    continue;
                }
                var record = new ProduceRecord<string, string>(
                    options.TopicName,
                    split[0],
                    split[1]
                );
                var sendCommand = await producer.Send(
                    record,
                    cancellationToken
                );

            }
            return 0;

        }

        static Task HandleResults(BlockingCollection<ICommand<ProduceResult>> commands, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var command = commands.Take(cancellationToken);
                        var produceResult = await command.Result();
                        if (produceResult.Error.Code != 0)
                        {
                            Console.WriteLine(Formatter.Print(produceResult.Error));
                            Console.WriteLine(Formatter.Print(produceResult.RecordError));
                        }
                        else
                        {
                            Console.WriteLine(Formatter.Print(produceResult.TopicPartitionOffset));
                        }
                    }
                    catch (OperationCanceledException) { }
                }
            }, CancellationToken.None);
        }
    }
}
