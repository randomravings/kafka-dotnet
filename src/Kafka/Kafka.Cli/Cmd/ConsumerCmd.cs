using Kafka.Cli.Options;
using Kafka.Cli.Text;
using Kafka.Client.Clients.Consumer;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
using Microsoft.Extensions.Logging;

namespace Kafka.Cli.Cmd
{
    internal static class ConsumerCmd
    {
        public static async ValueTask<int> Parse(
            ConsumerOpts verb,
            CancellationToken cancellationToken
        )
        {
            var config = CreateConfig(
                verb
            );
            using var consumer = CreateConsumer(
                verb,
                config,
                Deserializers.Utf8,
                Deserializers.Utf8
            );
            var topicNames = verb.TopicNames.ToArray();
            try
            {
                var topicWatermarks = await consumer.GetOffsetsEnd(
                    topicNames,
                    cancellationToken
                );

                foreach (var topicWatermark in topicWatermarks)
                {
                    Console.WriteLine(Formatter.Print(topicWatermark.Key));
                    foreach(var partitionWatermark in topicWatermark.Value)
                        Console.WriteLine($"  {Formatter.Print(partitionWatermark)}");
                }

                var stream = default(IInputStream<string, string>);
                if (verb.PartitionAssign.Any())
                {
                    var topicAssigns = ParseAssignments(verb);
                    stream = await consumer
                        .CreateSeekableStream(topicAssigns.Keys.ToArray(), cancellationToken)
                    ;
                }
                else
                {
                    stream = await consumer
                        .CreateAutoCommitStream(topicNames, cancellationToken)
                    ;
                }

                await foreach (var result in stream.WithCancellation(cancellationToken))
                    Console.WriteLine(Formatter.Print(result));
            }
            catch (OperationCanceledException) { }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await consumer.Close(CancellationToken.None);
            }
            return 0;
        }

        private static SortedList<TopicPartition, Offset> ParseAssignments(ConsumerOpts opts)
        {
            var topicPartitionOffsets = new SortedList<TopicPartition, Offset>(TopicPartitionCompare.Instance);
            var topicArray = opts.TopicNames.ToArray();
            var assignmentArray = opts.PartitionAssign.ToArray();
            if (topicArray.Length != assignmentArray.Length)
                throw new FormatException("number of assignments must match number of topics");
            for(int i = 0; i < topicArray.Length; i++)
            {
                var topic = topicArray[i];
                var partitionAssignment = assignmentArray[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                for(int j = 0; j < partitionAssignment.Length; j++)
                {
                    var partitionOffsetPair = partitionAssignment[j].Split(':', StringSplitOptions.RemoveEmptyEntries);
                    if (partitionOffsetPair.Length != 2)
                        throw new FormatException("partition offset pair must be (int:long)");
                    if (!int.TryParse(partitionOffsetPair[0], out var partition))
                        throw new FormatException("partition must be parsable to int");
                    if (!long.TryParse(partitionOffsetPair[1], out var offset))
                        throw new FormatException("partition must be parsable to long");
                    topicPartitionOffsets[new(topic, partition)] = offset;
                }
            }
            return topicPartitionOffsets;
        }

        private static ConsumerConfig CreateConfig(
            ConsumerOpts verb
        )
        {
            var groupId = verb.GroupId;
            if (string.IsNullOrEmpty(groupId))
                groupId = $"{Guid.NewGuid()}";
            return new ConsumerConfig
            {
                ClientId = verb.ClientId,
                BootstrapServers = verb.BootstrapServer,
                GroupId = groupId
            };
        }

        private static IConsumer<TKey, TValue> CreateConsumer<TKey, TValue>(
            ConsumerOpts verb,
            ConsumerConfig config,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        )
        {
            var logger = LoggerFactory
                .Create(builder => builder
                    .AddSystemdConsole()
                    .SetMinimumLevel(verb.LogLevel)
                )
                .CreateLogger<IConsumer<TKey, TValue>>()
            ;
            return ConsumerBuilder
                .New()
                .WithConfig(config)
                .WithKey(keyDeserializer)
                .WithValue(valueDeserializer)
                .WithLogger(logger)
                .Build()
            ;
        }
    }
}
