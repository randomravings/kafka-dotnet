using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Model;
using System.Collections;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class ProduceBatch :
        IEnumerable<KeyValuePair<TopicName, Dictionary<Partition, List<SendCommand>>>>
    {
        private readonly Dictionary<TopicName, Dictionary<Partition, List<SendCommand>>> _items = new();
        private int _count;

        public ProduceBatch(Attributes localAttributes) =>
            LocalAttributes = localAttributes
        ;

        public SendCommand this[TopicName topic, Partition partition, int sequence] =>
            _items[topic][partition][sequence]
        ;

        public IReadOnlyList<SendCommand> this[TopicName topic, Partition partition] =>
            _items[topic][partition]
        ;

        public void Add(SendCommand item)
        {
            UpsertBatch(_items, item);
            _count++;
        }

        public Attributes LocalAttributes { get; private set; }
        public int Count => _count;

        private static void UpsertBatch(
            Dictionary<TopicName, Dictionary<Partition, List<SendCommand>>> batch,
            SendCommand command
        )
        {
            if (!batch.TryGetValue(command.TopicPartition.Topic.TopicName, out var partitions))
            {
                partitions = new Dictionary<Partition, List<SendCommand>>();
                batch.Add(command.TopicPartition.Topic.TopicName, partitions);
            }
            if (!partitions.TryGetValue(command.TopicPartition.Partition, out var commands))
            {
                commands = new List<SendCommand>();
                partitions.Add(command.TopicPartition.Partition, commands);
            }
            commands.Add(command);
        }

        public IEnumerator<KeyValuePair<TopicName, Dictionary<Partition, List<SendCommand>>>> GetEnumerator() =>
            _items.GetEnumerator()
        ;

        IEnumerator IEnumerable.GetEnumerator() =>
            _items.GetEnumerator()
        ;
    }
}
