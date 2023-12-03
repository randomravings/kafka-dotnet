using Kafka.Common.Hashing;

namespace Kafka.Common.L0.Test.Hashing
{
    [TestFixture]
    public class Crc32Test
    {
        [TestCase("", 0U)]
        [TestCase("123456789", 3421780262U)]
        [TestCase("abcdefghi", 2376698031U)]
        public void Test(string utf8String, uint expected)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(utf8String);
            var actual = Crc32.Update(bytes);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
