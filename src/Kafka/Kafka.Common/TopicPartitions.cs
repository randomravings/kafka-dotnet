using System.Collections;

namespace Kafka.Common
{
    public sealed class TopicPartitions :
        IReadOnlySet<Partition>
    {
        private readonly SortedSet<Partition> _partitions = new();
        public TopicPartitions(
            string topic,
            params Partition[] partitions
        )
        {
            Topic = topic;
            foreach (var partition in partitions)
                _partitions.Add(partition)
            ;
        }
        public string Topic { get; private set; }

        public int Count => _partitions.Count;

        public bool Contains(Partition item) =>
            _partitions.Contains(item)
        ;

        public IEnumerator<Partition> GetEnumerator() =>
            _partitions.GetEnumerator()
        ;

        public bool IsProperSubsetOf(IEnumerable<Partition> other) =>
            _partitions.IsProperSubsetOf(other)
        ;

        public bool IsProperSupersetOf(IEnumerable<Partition> other) =>
            _partitions.IsProperSupersetOf(other)
        ;

        public bool IsSubsetOf(IEnumerable<Partition> other) =>
            _partitions.IsSubsetOf(other)
        ;

        public bool IsSupersetOf(IEnumerable<Partition> other) =>
            _partitions.IsSupersetOf(other)
        ;

        public bool Overlaps(IEnumerable<Partition> other) =>
            _partitions.Overlaps(other)
        ;

        public bool SetEquals(IEnumerable<Partition> other) =>
            _partitions.SetEquals(other)
        ;

        IEnumerator IEnumerable.GetEnumerator() =>
            _partitions.GetEnumerator()
        ;
    }
}
