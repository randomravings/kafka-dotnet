using Kafka.Client.Collections.Internal;
using Kafka.Common.Model;

namespace Kafka.Client.L0.Test.Collections
{

    public class CompareTest
    {
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = -1)]
        [TestCase(1, 0, ExpectedResult = 1)]
        public int TopicPartition(int left, int right) =>
            KeyOperations.Partition(left, right)
        ;

        [TestCase("a", "a", ExpectedResult = 0)]
        [TestCase("a", "b", ExpectedResult = -1)]
        [TestCase("b", "a", ExpectedResult = 1)]
        public int TopicName(string left, string right) =>
            KeyOperations.TopicName(left, right)
        ;

        [TestCase("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000", ExpectedResult = 0)]
        [TestCase("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000001", ExpectedResult = -1)]
        [TestCase("00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000000", ExpectedResult = 1)]
        public int TopicID(string left, string right) =>
            KeyOperations.TopicName(left, right)
        ;
    }
}
