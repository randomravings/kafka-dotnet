using Kafka.Cli.Text;
using Kafka.Cli.Verbs;
using Kafka.Client.Clients.Producer;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Cli.Cmd
{
    internal static class Produce
    {
        public static async ValueTask<int> Parse(
            VerbProduce verb,
            CancellationToken cancellationToken
        )
        {
            var config = new ProducerConfig
            {
                ClientId = verb.ClientId,
                BootstrapServers = verb.BootstrapServer
            };
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddConsole()
                    .SetMinimumLevel(LogLevel.Warning)
                )
                .CreateLogger<Producer<string, string>>()
            ;
            var producer = new Producer<string, string>(Serializers.Utf8, Serializers.Utf8, DefaultPartitioner.Instance, config, logger);

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
                var produceResult = await producer.Send(
                    new(
                        verb.TopicName,
                        Partition.Unassigned,
                        Timestamp.None,
                        split[0],
                        split[1],
                        ImmutableArray<RecordHeader>.Empty
                    ),
                    cancellationToken
                );
                if (produceResult.Error.Code != 0)
                {
                    Console.WriteLine(Formatter.Print(produceResult.Error));
                    if (produceResult.RecordErrors.Length > 0)
                        foreach (var recordError in produceResult.RecordErrors)
                            Console.WriteLine(Formatter.Print(recordError));
                }
                else
                {
                    Console.WriteLine(Formatter.Print(produceResult.TopicPartitionOffset));
                }
            }
            return 0;
        }
    }
}
