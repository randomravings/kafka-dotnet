using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;

namespace Kafka.Common.L0.Test.Model.Compare
{
    [TestFixture]
    public class TopicPartitionCompareTest
    {
        [TestCase([null, null, 0, null, null, 0], ExpectedResult = 0)]

        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0], ExpectedResult = 0)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0], ExpectedResult = 0)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d92", null, 0], ExpectedResult = 0)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0], ExpectedResult = -1)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0], ExpectedResult = 0)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0, null, "a", 0], ExpectedResult = 0)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0, null, "b", 0], ExpectedResult = -1)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "b", 0, null, "a", 0], ExpectedResult = 1)]
        [TestCase([null, "a", 0, null, "a", 0], ExpectedResult = 0)]


        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 1, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0], ExpectedResult = 1)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 1], ExpectedResult = -1)]
        public int CompareTest(string? idA, string? nameA, int partitionA, string? idB, string? nameB, int partitionB)
        {
            var topicIdA = idA == null ? Guid.Empty : Guid.Parse(idA);
            var topicNameA = (TopicName)nameA;
            var a = new TopicPartition((topicIdA, topicNameA), partitionA);

            var topicIdB = idB == null ? Guid.Empty : Guid.Parse(idB);
            var topicNameB = (TopicName)nameB;
            var b = new TopicPartition((topicIdB, topicNameB), partitionB);

            return TopicPartitionCompare.Instance.Compare(a, b);
        }

        [TestCase([null, null, 0, null, null, 0], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d92", null, 0], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0], ExpectedResult = false)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0, null, "a", 0], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0, null, "b", 0], ExpectedResult = false)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "b", 0, null, "a", 0], ExpectedResult = false)]
        [TestCase([null, "a", 0, null, "a", 0], ExpectedResult = true)]

        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 1, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0], ExpectedResult = false)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 1], ExpectedResult = false)]
        public bool EqualityTest(string? idA, string? nameA, int partitionA, string? idB, string? nameB, int partitionB)
        {
            var topicIdA = idA == null ? Guid.Empty : Guid.Parse(idA);
            var topicNameA = (TopicName)nameA;
            var a = new TopicPartition((topicIdA, topicNameA), partitionA);

            var topicIdB = idB == null ? Guid.Empty : Guid.Parse(idB);
            var topicNameB = (TopicName)nameB;
            var b = new TopicPartition((topicIdB, topicNameB), partitionB);

            return TopicPartitionCompare.Equality.Equals(a, b);
        }

        [TestCase([null, null, 0, null, null, 0], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d92", null, 0], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0], ExpectedResult = false)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0, null, "a", 0], ExpectedResult = true)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "a", 0, null, "b", 0], ExpectedResult = false)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", "b", 0, null, "a", 0], ExpectedResult = false)]
        [TestCase([null, "a", 0, null, "a", 0], ExpectedResult = true)]

        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 1, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0], ExpectedResult = false)]
        [TestCase(["de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 0, "de43c2af-4125-4415-8ddd-8eb37ef19d91", null, 1], ExpectedResult = false)]
        public bool HashCodeTest(string? idA, string? nameA, int partitionA, string? idB, string? nameB, int partitionB)
        {
            var topicIdA = idA == null ? Guid.Empty : Guid.Parse(idA);
            var topicNameA = (TopicName)nameA;
            var a = new TopicPartition((topicIdA, topicNameA), partitionA);

            var topicIdB = idB == null ? Guid.Empty : Guid.Parse(idB);
            var topicNameB = (TopicName)nameB;
            var b = new TopicPartition((topicIdB, topicNameB), partitionB);

            return TopicPartitionCompare.Equality.GetHashCode(a) ==
                TopicPartitionCompare.Equality.GetHashCode(b)
            ;
        }
    }
}
