using Kafka.Cli.Verbs;
using Kafka.Client.Clients.Producer;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
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
            var producer = new Producer<string, string>(config, Serializers.Utf8, Serializers.Utf8);
            var produceResult = await producer.Send(
                new(
                    verb.TopicName,
                    Partition.Unassigned,
                    Timestamp.None,
                    "test key",
                    "test value",
                    ImmutableArray<RecordHeader>.Empty
                ),
                cancellationToken
            );
            Console.WriteLine(produceResult.Error);
            Console.WriteLine(produceResult.recordError);
            return 0;
        }
    }
}
