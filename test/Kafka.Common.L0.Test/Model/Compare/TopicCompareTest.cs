using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;

namespace Kafka.Common.L0.Test.Model.Compare
{
    [TestFixture]
    public class TopicCompareTest
    {
        [TestCase([null, null, null, null], ExpectedResult = 0)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null], ExpectedResult = 0)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d92", null], ExpectedResult = 0)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a"], ExpectedResult = -1)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a"], ExpectedResult = 0)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", null, "a"], ExpectedResult = 0)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", null, "b"], ExpectedResult = -1)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "b", null, "a"], ExpectedResult = 1)]
        [TestCase([null, "a", null, "a"], ExpectedResult = 0)]
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

        [TestCase([null, null, null, null], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d92", null], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a"], ExpectedResult = false)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a"], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", null, "a"], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", null, "b"], ExpectedResult = false)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "b", null, "a"], ExpectedResult = false)]
        [TestCase([null, "a", null, "a"], ExpectedResult = true)]
        public bool EqualityTest(string? idA, string? nameA, string? idB, string? nameB)
        {
            var topicIdA = (TopicId)idA;
            var topicNameA = (TopicName)nameA;
            var a = new Topic(topicIdA, topicNameA);

            var topicIdB = (TopicId)idB;
            var topicNameB = (TopicName)nameB;
            var b = new Topic(topicIdB, topicNameB);

            return TopicCompare.Equality.Equals(a, b);
        }

        [TestCase([null, null, null, null], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d92", null], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a"], ExpectedResult = false)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a"], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", null, "a"], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", null, "b"], ExpectedResult = false)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "b", null, "a"], ExpectedResult = false)]
        [TestCase([null, "a", null, "a"], ExpectedResult = true)]
        public bool HashCodeTest(string? idA, string? nameA, string? idB, string? nameB)
        {
            var topicIdA = (TopicId)idA;
            var topicNameA = (TopicName)nameA;
            var a = new Topic(topicIdA, topicNameA);

            var topicIdB = (TopicId)idB;
            var topicNameB = (TopicName)nameB;
            var b = new Topic(topicIdB, topicNameB);

            return TopicCompare.Equality.GetHashCode(a) ==
                TopicCompare.Equality.GetHashCode(b)
            ;
        }
    }
}
