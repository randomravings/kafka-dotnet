using Kafka.Cli.Verbs;
using Kafka.Client.Clients.Consumer;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Cli.Cmd
{
    internal static class ConsumeCmd
    {
        public static async ValueTask<int> Parse(
            Consume verb,
            CancellationToken cancellationToken
        )
        {
            using var consumer = CreateConsumer(
                verb,
                Deserializers.Utf8,
                Deserializers.Utf8
            );
            var topic = new Client.Clients.Consumer.Models.TopicList("test");
            try
            {
                var topicWatermarks = await consumer.QueryWatermarks(
                    topic,
                    cancellationToken
                );
                foreach (var topicWatermark in topicWatermarks)
                {
                    Console.WriteLine(topicWatermark.Key.Value);
                    foreach (var partitionWatermark in topicWatermark.Value)
                        Console.WriteLine(partitionWatermark);
                    Console.WriteLine();
                }

                await foreach (var consumeResult in consumer.Read(topic, cancellationToken))
                    Console.WriteLine($"{consumeResult.Record.Key}:{consumeResult.Record.Value}");
            }
            catch (OperationCanceledException) { }
            finally
            {
                await consumer.Close(CancellationToken.None);
            }
            return 0;
        }

        private static IConsumer<TKey, TValue> CreateConsumer<TKey, TValue>(
            Consume verb,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        )
        {
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddConsole()
                    .SetMinimumLevel(verb.LogLevel)
                )
                .CreateLogger<ConsumerClient<TKey, TValue>>()
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
            return new ConsumerClient<TKey, TValue>(
                config,
                keyDeserializer,
                valueDeserializer,
                logger
            );
        }
    }
}
