using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;

namespace Kafka.Common.UnitTest.Model.Compare
{
    [TestFixture]
    public class TopicCompareTest
    {
        [TestCase(new object?[] { null, null, null, null }, ExpectedResult = 1)]
        [TestCase(new object?[] { "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null }, ExpectedResult = 1)]
        [TestCase(new object?[] { "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d92", null }, ExpectedResult = 1)]
        [TestCase(new object?[] { "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a" }, ExpectedResult = 1)]
        [TestCase(new object?[] { "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a" }, ExpectedResult = 1)]
        [TestCase(new object?[] { "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", null, "a" }, ExpectedResult = 1)]
        [TestCase(new object?[] { "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", null, "b" }, ExpectedResult = 1)]
        [TestCase(new object?[] { null, "a", null, "a" }, ExpectedResult = 1)]
        public int CompareTest(string? idA, string? nameA, string? idB, string? nameB)
        {
            var topicIdA = (TopicId)idA;
            var topicNameA = (TopicName)nameA;
            var a = new Topic(topicIdA, topicNameA);

            var topicIdB = (TopicId)idB;
            var topicNameB = (TopicName)nameB;
            var b = new Topic(topicIdB, topicNameB);

            return TopicCompare.Instance.Compare(a, b);
        }
    }
}
