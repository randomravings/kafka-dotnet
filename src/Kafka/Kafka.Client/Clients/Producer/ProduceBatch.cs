using Kafka.Client.Clients.Producer.Model.Internal;
using Kafka.Common.Model;
using Kafka.Common.Records;
using System.Collections;

namespace Kafka.Client.Clients.Producer
{
    internal class ProduceBatch :
        IEnumerable<KeyValuePair<TopicName, Dictionary<Partition, List<ProduceCommand>>>>
    {
        private readonly Dictionary<TopicName, Dictionary<Partition, List<ProduceCommand>>> _items = new();
        private int _count = 0;

        public ProduceBatch(Attributes localAttributes) =>
            LocalAttributes = localAttributes
        ;

        public ProduceCommand this[TopicName topic, Partition partition, int sequence] =>
            _items[topic][partition][sequence]
        ;

        public IReadOnlyList<ProduceCommand> this[TopicName topic, Partition partition] =>
            _items[topic][partition]
        ;

        public void Add(ProduceCommand item)
        {
            UpsertBatch(_items, item);
            _count++;
        }

        public Attributes LocalAttributes { get; private set; }
        public int Count => _count;

        private static void UpsertBatch(
            Dictionary<TopicName, Dictionary<Partition, List<ProduceCommand>>> batch,
            ProduceCommand command
        )
        {
            if (!batch.TryGetValue(command.TopicPartition.Topic, out var partitions))
            {
                partitions = new Dictionary<Partition, List<ProduceCommand>>();
                batch.Add(command.TopicPartition.Topic, partitions);
            }
            if (!partitions.TryGetValue(command.TopicPartition.Partition, out var commands))
            {
                commands = new List<ProduceCommand>();
                partitions.Add(command.TopicPartition.Partition, commands);
            }
            commands.Add(command);
        }

        public IEnumerator<KeyValuePair<TopicName, Dictionary<Partition, List<ProduceCommand>>>> GetEnumerator() =>
            _items.GetEnumerator()
        ;

        IEnumerator IEnumerable.GetEnumerator() =>
            _items.GetEnumerator()
        ;
    }
}
