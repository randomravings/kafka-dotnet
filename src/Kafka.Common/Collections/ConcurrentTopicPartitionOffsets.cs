using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Collections.Immutable;

namespace Kafka.Common.Collections
{
    public sealed class ConcurrentTopicPartitionOffsets
    {
        private readonly SortedList<TopicPartition, Offset> _topicPartitionOffsets;
        private SpinLock _lock;

        public ConcurrentTopicPartitionOffsets()
        {
            _topicPartitionOffsets = new(TopicPartitionCompare.Instance);
        }

        public int Count => _topicPartitionOffsets.Count;

        public Offset this[in TopicPartition topicPartition]
        {
            get => GetOffset(topicPartition);
            set => AddOrUpdate(topicPartition, value);
        }

        public bool TryGetValue(in TopicPartition topicPartition, out Offset offset)
        {
            var lockTaken = false;
            try
            {
                _lock.Enter(ref lockTaken);
                return _topicPartitionOffsets.TryGetValue(topicPartition, out offset);

            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        public void AddOrUpdate(in TopicPartition topicPartition, Offset offset)
        {
            var lockTaken = false;
            try
            {
                _lock.Enter(ref lockTaken);
                _topicPartitionOffsets[topicPartition] = offset;

            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        private Offset GetOffset(in TopicPartition topicPartition)
        {
            var lockTaken = false;
            try
            {
                _lock.Enter(ref lockTaken);
                return _topicPartitionOffsets[topicPartition];

            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }

        /// <summary>
        /// Computes the delta with another collection.
        /// It will add keys that are either missing in the other collection or where current offset is greater.
        /// </summary>
        /// <param name="other">Dictionary to compare to.</param>
        /// <returns></returns>
        public ImmutableSortedDictionary<TopicPartition, Offset> OffsetDiff(
            ConcurrentTopicPartitionOffsets other
        )
        {
            var lockTaken = false;
            try
            {
                _lock.Enter(ref lockTaken);
                var builder = ImmutableSortedDictionary.CreateBuilder<TopicPartition, Offset>(TopicPartitionCompare.Instance);
                foreach ((var topicPartition, var offset) in _topicPartitionOffsets)
                    if (!other.TryGetValue(topicPartition, out var otherOffset) || offset > otherOffset)
                        builder.Add(topicPartition, offset);
                return builder.ToImmutable();
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }


        public void Clear()
        {
            var lockTaken = false;
            try
            {
                _lock.Enter(ref lockTaken);
                _topicPartitionOffsets.Clear();
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit(false);
            }
        }
    }
}
