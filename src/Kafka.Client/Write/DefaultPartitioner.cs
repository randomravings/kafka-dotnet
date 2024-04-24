using Kafka.Client;
using Kafka.Common.Hashing;
using Kafka.Common.Model;
using System.Security.Cryptography;

namespace Kafka.Client.Write
{
    public class DefaultPartitioner :
        IPartitioner
    {
        private DefaultPartitioner() { }
        public static DefaultPartitioner Instance { get; } = new();
        public Partition SelectPartition(
            in int partitionCount,
            in ReadOnlyMemory<byte>? keyBytes
        )
        {
            if (keyBytes.HasValue)
            {
                var p = Convert.ToUInt32(partitionCount);
                var selection = Murmur2.Compute(keyBytes.Value.ToArray(), 0u);
                var partition = Convert.ToInt32(selection % p);
                return partition;
            }
            else
            {
                var partition = RandomNumberGenerator.GetInt32(0, partitionCount - 1);
                return partition;
            }
        }
    }
}
