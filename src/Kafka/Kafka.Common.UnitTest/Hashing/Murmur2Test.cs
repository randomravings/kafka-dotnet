using Kafka.Common.Hashing;

namespace Kafka.Common.UnitTest.Hashing
{
    [TestFixture]
    public class Murmur2Test
    {
        [TestCase("", 0U)]
        [TestCase("12345678", 3528850415U)]
        [TestCase("123456789", 3704291687U)]
        [TestCase("abcd", 646393889U)]
        [TestCase("abcdefghi", 4029782695U)]
        [TestCase("abcdefghij", 1258932500U)]
        [TestCase("abcdefghijk", 1249130918U)]
        public void Test(string utf8String, uint expected)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(utf8String);
            var actual = Murmur2.Compute(bytes, 0u);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
