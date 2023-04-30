using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Clients.Producer;
using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Cli.Cmd
{
    internal static class ProducerCmd
    {
        public static async ValueTask<int> Parse(
            ProducerOpts options,
            CancellationToken cancellationToken
        )
        {
            var config = new ProducerConfig
            {
                ClientId = options.ClientId,
                BootstrapServers = options.BootstrapServer,
                TransactionalId = "txnator",
                LingerMs= options.LingerMs,
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

            if (options.MaxInFlightRequestsPerConnection > 1)
                return await RunBatch(options, producer, cancellationToken);
            else
                return await RunSingle(options, producer, cancellationToken);

        }

        public static async ValueTask<int> RunSingle(
            ProducerOpts options,
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
                    split[0],
                    split[1]
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
            ProducerOpts options,
            IProducer<string, string> producer,
            CancellationToken cancellationToken
        )
        {
            Console.WriteLine($"Running in batch record mode with batch size {options.MaxInFlightRequestsPerConnection}. Empty new line will terminate session.");
            var records = new List<ProduceRecord<string, string>>(options.MaxInFlightRequestsPerConnection);
            var running = true;
            while (running && !cancellationToken.IsCancellationRequested)
            {
                while (records.Count < options.MaxInFlightRequestsPerConnection)
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
                        split[0],
                        split[1]
                    );
                    records.Add(record);
                }
                if (records.Count > 0)
                    await FlushBatch(
                        records,
                        producer,
                        cancellationToken
                    );
                records.Clear();
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
            var tasks = records.Select(r => producer.Send(r, cancellationToken)).ToList();
            try
            {
                await Task.WhenAll(tasks);
                foreach (var task in tasks)
                {
                    if (task.Result.Error.Code != 0)
                    {
                        Console.WriteLine(Formatter.Print(task.Result.Error));
                        Console.WriteLine(Formatter.Print(task.Result.RecordError));
                    }
                    else
                    {
                        Console.WriteLine(Formatter.Print(task.Result.TopicPartitionOffset));
                    }
                }
                return 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }
    }
}
