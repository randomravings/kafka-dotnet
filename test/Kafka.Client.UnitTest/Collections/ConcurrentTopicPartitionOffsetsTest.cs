using Kafka.Client.Collections;
using Kafka.Common.Model;

namespace Kafka.Client.UnitTest.Collections
{
    [TestFixture]
    public class ConcurrentTopicPartitionOffsetsTest
    {
        [Test]
        public void TestAdd()
        {
            var topics = new Topic[]
            {
                new(Guid.Parse("00000000-0000-0000-0000-000000000002"), "a"),
                new(Guid.Parse("00000000-0000-0000-0000-000000000001"), "z"),
                new(Guid.Parse("00000000-0000-0000-0000-000000000003"), "b")
            };

            var topicPartitions = topics
                .SelectMany(t => Enumerable
                    .Range(0, 6)
                    .Select(p => new TopicPartition(t, p))
                )
                .ToArray()
            ;

            var topicPartitionOffsets = new TopicPartitionDictionary<Offset>();

            for (int i = 0; i < topicPartitionOffsets.Count; i++)
            {
                var added = topicPartitionOffsets.Add(topicPartitions[i], 0);
                var count = topicPartitionOffsets.Count;
                Assert.Multiple(() =>
                {
                    Assert.That(added, Is.EqualTo(true));
                    Assert.That(count, Is.EqualTo(i + 1));
                });
            }

            var expectedNameOrder = topicPartitionOffsets
                .OrderBy(r => r.Key.Topic.TopicName.Value)
                .ThenBy(r => r.Key.Partition.Value)
                .ToArray()
            ;
            var itemsByName = topicPartitionOffsets.CopyItems();
            CollectionAssert.AreEqual(expectedNameOrder, itemsByName);

            var expectedIdOrder = topicPartitionOffsets
                .OrderBy(r => r.Key.Topic.TopicId.Value)
                .ThenBy(r => r.Key.Partition.Value)
                .ToArray()
            ;
            var itemsById = topicPartitionOffsets.CopyItems(true);
            CollectionAssert.AreEqual(expectedIdOrder, itemsById);
        }
    }
}
