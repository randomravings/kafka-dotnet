﻿using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Clients.Producer;
using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Commands;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Cli.Cmd
{
    internal static class ProducerCmd
    {
        private enum CommandState
        {
            None,
            SingleRecord,
            Batch,
            Transaction
        };
        public static async ValueTask<int> Parse(
            ProducerOpts options,
            CancellationToken cancellationToken
        )
        {
            var config = new ProducerConfig
            {
                ClientId = options.ClientId,
                BootstrapServers = options.BootstrapServer,
                EnableIdempotence = options.EnableItempotence,
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
                .WithKey(StringSerializer.Instance)
                .WithValue(StringSerializer.Instance)
                .WithLogger(logger)
                .Build()
            ;

            var commandState = CommandState.SingleRecord;
            var commands = new List<ICommand<ProduceResult>>();
            Console.WriteLine("Empty new line will terminate session.");
            while (!cancellationToken.IsCancellationRequested)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                switch (commandState, input)
                {
                    case (CommandState.SingleRecord, "/bt"):
                        await producer.BeginTransaction(cancellationToken).ConfigureAwait(false);
                        commandState = CommandState.Transaction;
                        continue;
                    case (CommandState.Transaction, "/ct"):
                        await producer.CommitTransaction(cancellationToken).ConfigureAwait(false);
                        commandState = CommandState.SingleRecord;
                        continue;
                    case (CommandState.Transaction, "/rt"):
                        await producer.RollbackTransaction(cancellationToken).ConfigureAwait(false);
                        commandState = CommandState.SingleRecord;
                        continue;
                    case (_, "/fl"):
                        await producer.Flush(cancellationToken).ConfigureAwait(false);
                        await HandleResults(commands);
                        commands.Clear();
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
                var sendCommand = await producer.Send(record, cancellationToken).ConfigureAwait(false);
                commands.Add(sendCommand);
                await HandleResults(commands);
                commands.Clear();
            }
            await producer.Flush(cancellationToken).ConfigureAwait(false);
            await HandleResults(commands);
            commands.Clear();
            return 0;
        }

        static async ValueTask HandleResults(IReadOnlyList<ICommand< ProduceResult>> commands)
        {
            if (commands.Count == 0)
                return;
            var results = await Task.WhenAll(commands.Select(async r => await r.Result())).ConfigureAwait(false);
            foreach (var result in results)
            {
                if (result.Error.Code != 0)
                {
                    Console.WriteLine(Formatter.Print(result.Error));
                    Console.WriteLine(Formatter.Print(result.RecordError));
                }
                else
                {
                    Console.WriteLine(Formatter.Print(result.TopicPartitionOffset));
                }
            }
        }
    }
}
