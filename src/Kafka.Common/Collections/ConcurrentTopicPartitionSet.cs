using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Collections;
using System.Collections.Immutable;

namespace Kafka.Common.Collections
{
    public sealed class ConcurrentTopicPartitionSet :
        IEnumerable<TopicPartition>
    {
        private readonly SortedSet<TopicPartition> _topicPartitions;
        private readonly ReaderWriterLockSlim _lock = new();

        public ConcurrentTopicPartitionSet()
        {
            _topicPartitions = new(TopicPartitionCompare.Instance);
        }

        public int Count
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    return _topicPartitions.Count;
                }
                finally
                {
                    if (_lock.IsReadLockHeld)
                        _lock.ExitReadLock();
                }
            }
        }

        public bool Add(in TopicPartition topicPartition)
        {
            _lock.EnterWriteLock();
            try
            {
                return _topicPartitions.Add(topicPartition);

            }
            finally
            {
                if (_lock.IsWriteLockHeld)
                    _lock.ExitWriteLock();
            }
        }

        public bool Remove(in TopicPartition topicPartition)
        {
            _lock.EnterWriteLock();
            try
            {
                return _topicPartitions.Remove(topicPartition);

            }
            finally
            {
                if (_lock.IsWriteLockHeld)
                    _lock.ExitWriteLock();
            }
        }

        public bool Contains(in TopicPartition topicPartition)
        {
            _lock.EnterReadLock();
            try
            {
                return _topicPartitions.Contains(topicPartition);

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
                _topicPartitions.Clear();

            }
            finally
            {
                if (_lock.IsWriteLockHeld)
                    _lock.ExitWriteLock();
            }
        }

        public IReadOnlySet<TopicPartition> Copy()
        {
            _lock.EnterReadLock();
            try
            {
                return _topicPartitions.ToImmutableSortedSet(TopicPartitionCompare.Instance);

            }
            finally
            {
                if (_lock.IsReadLockHeld)
                    _lock.ExitReadLock();
            }
        }

        public IEnumerator<TopicPartition> GetEnumerator()
        {
            _lock.EnterReadLock();
            try
            {
                foreach (var topicPartition in _topicPartitions)
                    yield return topicPartition;
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
