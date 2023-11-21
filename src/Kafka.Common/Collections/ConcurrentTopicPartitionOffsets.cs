using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Collections;

namespace Kafka.Common.Collections
{
    public sealed class ConcurrentTopicPartitionOffsets :
        IEnumerable<KeyValuePair<TopicPartition, Offset>>
    {
        private readonly IComparer<TopicPartition> _comparer;
        private readonly ReaderWriterLockSlim _lock = new();
        private readonly SortedList<TopicPartition, Offset> _topicPartitionOffsets;

        public ConcurrentTopicPartitionOffsets(
            bool useId
        )
        {
            _comparer = useId ?
                TopicPartitionCompareById.Instance :
                TopicPartitionCompare.Instance
            ;
            _topicPartitionOffsets = new(_comparer);
        }

        public int Count => _topicPartitionOffsets.Count;

        public Offset this[in TopicPartition topicPartition]
        {
            get => GetOffset(topicPartition);
            set => AddOrUpdate(topicPartition, value);
        }

        public bool TryGetValue(in TopicPartition topicPartition, out Offset offset)
        {
            _lock.EnterReadLock();
            try
            {
                return _topicPartitionOffsets.TryGetValue(topicPartition, out offset);

            }
            finally
            {
                if (_lock.IsReadLockHeld)
                    _lock.ExitReadLock();
            }
        }

        public void Update(in TopicPartition topicPartition, in Offset offset)
        {
            _lock.EnterWriteLock();
            try
            {
                var index = _topicPartitionOffsets.IndexOfKey(topicPartition);
                if (index > -1)
                    _topicPartitionOffsets.SetValueAtIndex(index, offset);
            }
            finally
            {
                if (_lock.IsWriteLockHeld)
                    _lock.ExitWriteLock();
            }
        }

        public void AddOrUpdate(in TopicPartition topicPartition, in Offset offset)
        {
            _lock.EnterWriteLock();
            try
            {
                _topicPartitionOffsets[topicPartition] = offset;

            }
            finally
            {
                if (_lock.IsWriteLockHeld)
                    _lock.ExitWriteLock();
            }
        }

        private Offset GetOffset(in TopicPartition topicPartition)
        {
            _lock.EnterReadLock();
            try
            {
                return _topicPartitionOffsets[topicPartition];

            }
            finally
            {
                if (_lock.IsReadLockHeld)
                    _lock.ExitReadLock();
            }
        }

        public void Clear()
        {
            _lock.EnterWriteLock();
            try
            {
                _topicPartitionOffsets.Clear();
            }
            finally
            {
                if (_lock.IsWriteLockHeld)
                    _lock.ExitWriteLock();
            }
        }

        public IEnumerator<KeyValuePair<TopicPartition, Offset>> GetEnumerator()
        {
            _lock.EnterReadLock();
            try
            {
                foreach (var topicPartitionOffset in _topicPartitionOffsets)
                    yield return topicPartitionOffset;
            }
            finally
            {
                if (_lock.IsReadLockHeld)
                    _lock.ExitReadLock();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator()
        ;
    }
}
