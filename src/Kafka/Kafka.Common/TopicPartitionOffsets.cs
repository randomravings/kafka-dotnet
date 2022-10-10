using System.Collections;

namespace Kafka.Common
{
    public sealed class TopicPartitionOffsets :
        IReadOnlySet<PartitionOffset>
    {
        private readonly SortedSet<PartitionOffset> _partitionOffsets = new();
        public TopicPartitionOffsets(
            string topic,
            params PartitionOffset[] PartitionOffsets
        )
        {
            Topic = topic;
            foreach (var PartitionOffset in PartitionOffsets)
                _partitionOffsets.Add(PartitionOffset)
            ;
        }
        public string Topic { get; private set; }

        public int Count => _partitionOffsets.Count;

        public bool Contains(PartitionOffset item) =>
            _partitionOffsets.Contains(item)
        ;

        public IEnumerator<PartitionOffset> GetEnumerator() =>
            _partitionOffsets.GetEnumerator()
        ;

        public bool IsProperSubsetOf(IEnumerable<PartitionOffset> other) =>
            _partitionOffsets.IsProperSubsetOf(other)
        ;

        public bool IsProperSupersetOf(IEnumerable<PartitionOffset> other) =>
            _partitionOffsets.IsProperSupersetOf(other)
        ;

        public bool IsSubsetOf(IEnumerable<PartitionOffset> other) =>
            _partitionOffsets.IsSubsetOf(other)
        ;

        public bool IsSupersetOf(IEnumerable<PartitionOffset> other) =>
            _partitionOffsets.IsSupersetOf(other)
        ;

        public bool Overlaps(IEnumerable<PartitionOffset> other) =>
            _partitionOffsets.Overlaps(other)
        ;

        public bool SetEquals(IEnumerable<PartitionOffset> other) =>
            _partitionOffsets.SetEquals(other)
        ;

        IEnumerator IEnumerable.GetEnumerator() =>
            _partitionOffsets.GetEnumerator()
        ;
    }
}
