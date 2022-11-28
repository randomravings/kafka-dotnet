using Kafka.Cli.AdminClient.Verbs;
using Kafka.Client.Clients.Producer;
using Kafka.Common.Records;
using Kafka.Common.Serialization;
using System.Collections.Immutable;

namespace Kafka.Cli.AdminClient.Cmd
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
                BootstrapServers = verb.BootstrapServer
            };
            var producer = new Producer<string, string>(config, Serializers.Utf8, Serializers.Utf8);
            await producer.Send(
                verb.TopicName,
                new ProducerRecord<string, string>(
                    Common.Types.Timestamp.Created(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()),
                    ImmutableArray<RecordHeader>.Empty,
                    "test key",
                    "test value"
                ),
                cancellationToken
            );
            return 0;
        }
    }
}
