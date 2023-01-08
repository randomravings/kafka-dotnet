namespace Kafka.Common.Hashing
{
    public static class Murmur2
    {
        public static uint Compute(byte[] key, uint seed)
        {
            var len = key.Length;
            var rem = len % 4;
            var len4 = len - rem;
            var m = 0x5bd1e995u;
            var r = 24;
            var h = seed ^ (uint)len;
            var i = 0;
            while (i < len4)
            {
                var k = (uint)(key[i++] | key[i++] << 8 | key[i++] << 16 | key[i++] << 24);

                k *= m;
                k ^= k >> r;
                k *= m;

                h *= m;
                h ^= k;
            }

            switch (rem)
            {
                case 3:
                    h ^= (uint)(key[i++] | key[i++] << 8 | key[i] << 16);
                    h *= m;
                    break;
                case 2:
                    h ^= (uint)(key[i++] | key[i] << 8);
                    h *= m;
                    break;
                case 1:
                    h ^= key[i];
                    h *= m;
                    break;
            };

            h ^= h >> 13;
            h *= m;
            h ^= h >> 15;

            return h;
        }

    }
}