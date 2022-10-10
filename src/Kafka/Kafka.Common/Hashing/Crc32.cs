using System.Collections.Immutable;

namespace Kafka.Common.Hashing
{
    /// <summary>
    /// CRC implemtation (ISO 3309).
    /// Implementation was inpired from https://www.ietf.org/rfc/rfc1952.txt Appendix 8.
    /// </summary>
    public static class Crc32
    {
        private static readonly uint[] CRC_TABLE = InitCrcTable();

        /// <summary>
        /// Update CRC from array without a prior value.
        /// </summary>
        /// <param name="bytes">Byte Array to compute from.</param>
        /// <returns></returns>
        public static uint Update(byte[] bytes) =>
            Update(bytes.AsSpan())
        ;

        /// <summary>
        /// Update CRC from array without a prior value.
        /// </summary>
        /// <param name="bytes">Byte Array to compute from.</param>
        /// <returns></returns>
        public static uint Update(ImmutableArray<byte> bytes) =>
            Update(bytes.AsSpan())
        ;

        /// <summary>
        /// Update CRC from span without a prior value.
        /// </summary>
        /// <param name="bytes">Span to compute from.</param>
        /// <returns></returns>
        public static uint Update(ReadOnlySpan<byte> bytes) =>
            Update(0U, bytes)
        ;

        /// <summary>
        /// Update CRC from array with a prior value.
        /// </summary>
        /// <param name="crc">Prior value.</param>
        /// <param name="bytes">Byte Array to compute from.</param>
        /// <returns></returns>
        public static uint Update(uint crc, byte[] bytes) =>
            Update(crc, bytes.AsSpan())
        ;

        /// <summary>
        /// Update CRC from array with a prior value.
        /// </summary>
        /// <param name="crc">Prior value.</param>
        /// <param name="bytes">Byte Array to compute from.</param>
        /// <returns></returns>
        public static uint Update(uint crc, ImmutableArray<byte> bytes) =>
            Update(crc, bytes.AsSpan())
        ;

        /// <summary>
        /// Update CRC from span with a prior value.
        /// </summary>
        /// <param name="crc">Prior value.</param>
        /// <param name="bytes">Span to compute from.</param>
        /// <returns></returns>
        public static uint Update(uint crc, ReadOnlySpan<byte> bytes)
        {
            var len = bytes.Length;
            var c = crc ^ 0xffffffffU;
            for (int n = 0; n < len; n++)
                c = CRC_TABLE[(c ^ bytes[n]) & 0xff] ^ (c >> 8);
            return c ^ 0xffffffffU;
        }

        private static uint[] InitCrcTable()
        {
            var crc_table = new uint[256];
            for (int n = 0; n < 256; n++)
            {
                var c = (uint)n;
                for (int k = 0; k < 8; k++)
                    if ((c & 1) == 1)
                        c = 0xedb88320U ^ (c >> 1);
                    else
                        c >>= 1;
                crc_table[n] = c;
            }
            return crc_table;
        }
    }
}
