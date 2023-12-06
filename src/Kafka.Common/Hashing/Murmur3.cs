using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Hashing
{
    public static class Murmur3
    {
        /// <summary>
        /// Note: In this version, all arithmetic is performed with unsigned 32-bit integers.
        //  In the case of overflow, the result is reduced modulo 232.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static uint Compute([NotNull] in byte[] key, uint seed)
        {
            var len = key.Length;
            var len4 = len - len % 4;
            var h = seed;
            var i = 0;
            /* Read in groups of 4. */
            while (i < len4)
            {
                // Here is a source of differing results across endiannesses.
                // A swap here has no effects on hash properties though.
                var k1 = (uint)(key[i++] | key[i++] << 8 | key[i++] << 16 | key[i++] << 24);
                h ^= Murmur32Scramble(k1);
                h = (h << 13) | (h >> 19);
                h = h * 5 + 0xe6546b64;
            }
            /* Read the rest. */
            var k2 = 0u;
            i = len - 1;
            while (i >= len4)
            {
                k2 <<= 8;
                k2 |= key[i--];
            }
            // A swap is *not* necessary here because the preceding loop already
            // places the low bytes in the low places according to whatever endianness
            // we use. Swaps only apply when the memory is copied in a chunk.
            h ^= Murmur32Scramble(k2);
            /* Finalize. */
            h ^= (uint)len;
            h ^= h >> 16;
            h *= 0x85ebca6b;
            h ^= h >> 13;
            h *= 0xc2b2ae35;
            h ^= h >> 16;
            return h;
        }

        static uint Murmur32Scramble(uint k)
        {
            k *= 0xcc9e2d51;
            k = (k << 15) | (k >> 17);
            k *= 0x1b873593;
            return k;
        }
    }
}