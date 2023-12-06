using System.Diagnostics.CodeAnalysis;

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
        /// Update CRC from span with a prior value.
        /// </summary>
        /// <param name="bytes">Span to compute from.</param>
        /// <returns></returns>
        public static uint Update([NotNull] byte[] bytes) =>
            Update(0, bytes, 0, bytes.Length)
        ;

        /// <summary>
        /// Update CRC from span with a prior value.
        /// </summary>
        /// <param name="crc">Prior value.</param>
        /// <param name="bytes">Span to compute from.</param>
        /// <returns></returns>
        public static uint Update(uint crc, [NotNull] byte[] bytes) =>
            Update(crc, bytes, 0, bytes.Length)
        ;

        /// <summary>
        /// Update CRC from span with a prior value.
        /// </summary>
        /// <param name="bytes">Span to compute from.</param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static uint Update([NotNull] byte[] bytes, int index, int length) =>
            Update(0U, bytes, index, length)
        ;

        /// <summary>
        /// Update CRC from span with a prior value.
        /// </summary>
        /// <param name="crc">Prior value.</param>
        /// <param name="bytes">Span to compute from.</param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static uint Update(uint crc, [NotNull] byte[] bytes, int index, int length)
        {
            var c = crc ^ 0xffffffffU;
            var l = index + length;
            for (int n = index; n < l; n++)
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
