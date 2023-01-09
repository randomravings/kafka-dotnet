using Kafka.Common.Hashing;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Producer
{
    public class DefaultPartitioner :
        IPartitioner
    {
        private DefaultPartitioner() { }
        public static DefaultPartitioner Instance { get; } = new();
        public async ValueTask<Partition> Select(TopicName topic, int partitionCount, ReadOnlyMemory<byte>? keyBytes, CancellationToken cancellationToken)
        {
            if (keyBytes.HasValue)
            {
                var p = Convert.ToUInt32(partitionCount);
                var selection = Murmur2.Compute(keyBytes.Value.ToArray(), 0u);
                var partition = Convert.ToInt32(selection % p);
                return await ValueTask.FromResult(partition);
            }
            else
            {
                var partition = Random.Shared.Next(0, partitionCount);
                return await ValueTask.FromResult(partition);
            }
        }
    }
}
