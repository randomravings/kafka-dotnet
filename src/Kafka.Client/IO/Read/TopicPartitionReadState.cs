using Kafka.Common.Model;

namespace Kafka.Client.IO.Read
{
    internal sealed class TopicPartitionReadState(
        Offset offset
    )
    {
        private SpinLock _lock;
        private Offset _offset = offset;

        public Offset GetOffset()
        {
            var lockTaken = false;
            _lock.Enter(ref lockTaken);
            try
            {
                return _offset;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit();
            }
        }

        public void SetOffset(Offset offset)
        {
            var lockTaken = false;
            _lock.Enter(ref lockTaken);
            try
            {
                _offset = offset;
            }
            finally
            {
                if (lockTaken)
                    _lock.Exit();
            }
        }
    }
}
