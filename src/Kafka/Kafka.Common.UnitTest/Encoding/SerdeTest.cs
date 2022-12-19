using Kafka.Common.Encoding;

namespace Kafka.Common.UnitTest.Encoding
{
    [TestFixture]
    public class SerdeTest
    {
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(63)]
        [TestCase(-64)]
        [TestCase(64)]
        [TestCase(-65)]
        [TestCase(8191)]
        [TestCase(-8192)]
        [TestCase(8192)]
        [TestCase(-8193)]
        [TestCase(1048575)]
        [TestCase(-1048576)]
        [TestCase(1048576)]
        [TestCase(-1048577)]
        [TestCase(134217727)]
        [TestCase(-134217728)]
        [TestCase(134217728)]
        [TestCase(-134217729)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void TestVarInt32Serde(int value)
        {
            var index = 0;
            var buffer = new byte[20];
            Encoder.WriteVarInt32(buffer, index, value);
            var actual = Decoder.ReadVarInt32(buffer, ref index);
            Assert.That(actual, Is.EqualTo(value));
        }

        [TestCase(0U)]
        [TestCase(1U)]
        [TestCase(63U)]
        [TestCase(64U)]
        [TestCase(8191U)]
        [TestCase(8192U)]
        [TestCase(1048575U)]
        [TestCase(1048576U)]
        [TestCase(134217727U)]
        [TestCase(134217728U)]
        [TestCase(2147483647U)]
        [TestCase(2147483648U)]
        [TestCase(uint.MaxValue)]
        public void TestVarUInt32Serde(uint value)
        {
            var index = 0;
            var buffer = new byte[20];
            Encoder.WriteVarUInt32(buffer, index, value);
            var actual = Decoder.ReadVarUInt32(buffer, ref index);
            Assert.That(actual, Is.EqualTo(value));
        }

        [TestCase(0L)]
        [TestCase(-1L)]
        [TestCase(1L)]
        [TestCase(63L)]
        [TestCase(-64L)]
        [TestCase(64L)]
        [TestCase(-65L)]
        [TestCase(8191L)]
        [TestCase(-8192L)]
        [TestCase(8192L)]
        [TestCase(-8193L)]
        [TestCase(1048575L)]
        [TestCase(-1048576L)]
        [TestCase(1048576L)]
        [TestCase(-1048577L)]
        [TestCase(134217727L)]
        [TestCase(-134217728L)]
        [TestCase(134217728L)]
        [TestCase(-134217729L)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        [TestCase(17179869183L)]
        [TestCase(-17179869184L)]
        [TestCase(17179869184L)]
        [TestCase(-17179869185L)]
        [TestCase(2199023255551L)]
        [TestCase(-2199023255552L)]
        [TestCase(2199023255552L)]
        [TestCase(-2199023255553L)]
        [TestCase(281474976710655L)]
        [TestCase(-281474976710656L)]
        [TestCase(281474976710656L)]
        [TestCase(-281474976710657L)]
        [TestCase(36028797018963967L)]
        [TestCase(-36028797018963968L)]
        [TestCase(36028797018963968L)]
        [TestCase(-36028797018963969L)]
        [TestCase(4611686018427387903L)]
        [TestCase(-4611686018427387904L)]
        [TestCase(4611686018427387904L)]
        [TestCase(-4611686018427387905L)]
        [TestCase(long.MaxValue)]
        [TestCase(long.MinValue)]
        public void TestVarInt64Serde(long value)
        {
            var index = 0;
            var buffer = new byte[20];
            Encoder.WriteVarInt64(buffer, index, value);
            var actual = Decoder.ReadVarInt64(buffer, ref index);
            Assert.That(actual, Is.EqualTo(value));
        }
    }
}
