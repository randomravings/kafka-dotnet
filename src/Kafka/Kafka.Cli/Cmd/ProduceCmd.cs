using Kafka.Cli.Text;
using Kafka.Cli.Verbs;
using Kafka.Client.Clients.Producer;
using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Cli.Cmd
{
    internal static class ProduceCmd
    {
        public static async ValueTask<int> Parse(
            Produce options,
            CancellationToken cancellationToken
        )
        {
            var config = new ProducerConfig
            {
                ClientId = options.ClientId,
                BootstrapServers = options.BootstrapServer,
                TransactionalId = "txnator"
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

            if (options.BatchSize > 1)
                return await RunBatch(options, producer, cancellationToken);
            else
                return await RunSingle(options, producer, cancellationToken);

        }

        public static async ValueTask<int> RunSingle(
            Produce options,
            IProducer<string, string> producer,
            CancellationToken cancellationToken
        )
        {
            Console.WriteLine("Running in single record mode. Empty new line will terminate session.");
            while (!cancellationToken.IsCancellationRequested)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    return 0;
                var split = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (split.Length != 2)
                {
                    Console.WriteLine("Format must be 'key,value'");
                    continue;
                }
                var record = new ProduceRecord<string, string>(
                    options.TopicName,
                    Partition.Unassigned,
                    Timestamp.None,
                    split[0],
                    split[1],
                    ImmutableArray<RecordHeader>.Empty
                );
                var produceResult = await producer.Send(
                    record,
                    cancellationToken
                );
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
            return 0;
        }

        public static async ValueTask<int> RunBatch(
            Produce options,
            IProducer<string, string> producer,
            CancellationToken cancellationToken
        )
        {
            Console.WriteLine($"Running in batch record mode with batch size {options.BatchSize}. Empty new line will terminate session.");
            var records = new List<ProduceRecord<string, string>>(options.BatchSize);
            var running = true;
            var txn = await  producer.BeginTransaction(cancellationToken);
            while (running && !cancellationToken.IsCancellationRequested)
            {
                while (records.Count < options.BatchSize)
                {
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        running = false;
                        break;
                    }
                    var split = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (split.Length != 2)
                    {
                        Console.WriteLine("Format must be 'key,value'");
                        continue;
                    }
                    var record = new ProduceRecord<string, string>(
                        options.TopicName,
                        Partition.Unassigned,
                        Timestamp.None,
                        split[0],
                        split[1],
                        ImmutableArray<RecordHeader>.Empty
                    );
                    records.Add(record);
                }
                if(records.Count > 0)
                    await FlushBatch(
                        records,
                        producer,
                        cancellationToken
                    );
                records.Clear();
            }
            try
            {
                await txn.Commit(cancellationToken);
            }
            catch(Exception)
            {
                var cts = new CancellationTokenSource();
                cts.CancelAfter(5000);
                await txn.Rollback(cts.Token);
            }
            await producer.Close(CancellationToken.None);
            return 0;
        }

        private static async ValueTask<int> FlushBatch(
            IList<ProduceRecord<string, string>> records,
            IProducer<string, string> producer,
            CancellationToken cancellationToken
        )
        {
            var enumerator = producer.Send(
                records,
                records.Count,
                cancellationToken
            );
            await foreach (var produceResults in enumerator)
            {
                foreach (var produceResult in produceResults)
                {
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
            }
            return 0;
        }
    }
}
