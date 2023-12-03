using Kafka.Common.Hashing;

namespace Kafka.Common.L0.Test.Hashing
{
    [TestFixture]
    public class Murmur3Test
    {
        [TestCase("", 0U)]
        [TestCase("12345678", 2444432334U)]
        [TestCase("123456789", 3036607362U)]
        [TestCase("abcd", 1139631978U)]
        [TestCase("abcdefghij", 2291300241U)]
        public void Test(string utf8String, uint expected)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(utf8String);
            var actual = Murmur3.Compute(bytes, 0u);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
