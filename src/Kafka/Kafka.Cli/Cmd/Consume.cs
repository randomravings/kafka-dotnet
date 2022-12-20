using Kafka.Cli.Verbs;
using Kafka.Client.Clients.Consumer;
using Kafka.Common.Serialization;

namespace Kafka.Cli.Cmd
{
    internal static class Consume
    {
        public static async ValueTask<int> Parse(
            VerbConsume verb,
            CancellationToken cancellationToken
        )
        {
            var consumer = CreateConsumer(
                verb,
                Deserializers.Utf8,
                Deserializers.Utf8
            );
            await consumer.Subscribe(
                "test",
                cancellationToken
            );
            var x = await consumer.Poll(cancellationToken);
            return 0;
        }

        private static IConsumer<TKey, TValue> CreateConsumer<TKey, TValue>(
            VerbConsume verb,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        )
        {
            var groupId = verb.GroupId;
            if (string.IsNullOrEmpty(groupId))
                groupId = $"{Guid.NewGuid()}";
            var config = new ConsumerConfig
            {
                ClientId = verb.ClientId,
                BootstrapServers = verb.BootstrapServer,
                GroupId = groupId
            };
            return new SubscribedConsumer<TKey, TValue>(
                config,
                keyDeserializer,
                valueDeserializer
            );
        }
    }
}
