using Kafka.Common.Hashing;

namespace Kafka.Common.UnitTest.Hashing
{
    [TestFixture]
    public class Crc32cTest
    {
        [TestCase("", 0U)]
        [TestCase("123456789", 3808858755U)]
        [TestCase("abcdefghi", 769432060U)]
        public void Test(string utf8String, uint expected)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(utf8String);
            var actual = Crc32c.Update(bytes);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
