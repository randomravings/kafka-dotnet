using Kafka.Cli.Verbs;
using Kafka.Client.Clients.Consumer;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

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
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = await consumer.Poll(cancellationToken);
                Console.WriteLine($"{consumeResult.Record.Key}:{consumeResult.Record.Value}");
            }
            return 0;
        }

        private static IConsumer<TKey, TValue> CreateConsumer<TKey, TValue>(
            VerbConsume verb,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        )
        {
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddNLog()
                    .SetMinimumLevel(LogLevel.Warning)
                )
                .CreateLogger<SubscribedConsumer<TKey, TValue>>()
            ;
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
                valueDeserializer,
                logger
            );
        }
    }
}
