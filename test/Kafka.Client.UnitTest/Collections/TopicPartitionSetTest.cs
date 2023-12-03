using Kafka.Client.Collections;
using Kafka.Common.Model;

namespace Kafka.Client.UnitTest.Collections
{
    public class TopicPartitionSetTest
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

            var expectedNameOrder = topicPartitions
                .OrderBy(r => r.Topic.TopicName.Value)
                .ThenBy(r => r.Partition.Value)
                .ToArray()
            ;
            var expectedIdOrder = topicPartitions
                .OrderBy(r => r.Topic.TopicId.Value)
                .ThenBy(r => r.Partition.Value)
                .ToArray()
            ;

            var topicPartitionSet = new TopicPartitionSet();
            for (int i = 0; i < topicPartitions.Length; i++)
            {
                var added = topicPartitionSet.Add(topicPartitions[i]);
                var count = topicPartitionSet.Count;
                Assert.Multiple(() =>
                {
                    Assert.That(added, Is.EqualTo(true));
                    Assert.That(count, Is.EqualTo(i + 1));
                });
            }
            var itemsByName = topicPartitionSet.CopyItems();
            CollectionAssert.AreEqual(expectedNameOrder, itemsByName);
            var itemsById = topicPartitionSet.CopyItems(true);
            CollectionAssert.AreEqual(expectedIdOrder, itemsById);
        }
    }
}
