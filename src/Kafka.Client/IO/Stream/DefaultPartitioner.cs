using Kafka.Common.Hashing;
using Kafka.Common.Model;

namespace Kafka.Client.IO.Stream
{
    public class DefaultPartitioner :
        IPartitioner
    {
        private DefaultPartitioner() { }
        public static DefaultPartitioner Instance { get; } = new();
        public ValueTask<Partition> SelectPartition(TopicName topic, int partitionCount, ReadOnlyMemory<byte>? keyBytes, CancellationToken cancellationToken)
        {
            if (keyBytes.HasValue)
            {
                var p = Convert.ToUInt32(partitionCount);
                var selection = Murmur2.Compute(keyBytes.Value.ToArray(), 0u);
                var partition = Convert.ToInt32(selection % p);
                return ValueTask.FromResult(new Partition(partition));
            }
            else
            {
#pragma warning disable CA5394 // Do not use insecure randomness
                var partition = Random.Shared.Next(0, partitionCount);
#pragma warning restore CA5394 // Do not use insecure randomness
                return ValueTask.FromResult(new Partition(partition));
            }
        }
    }
}
