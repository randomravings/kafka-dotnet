using Kafka.Client.Collections;
using Kafka.Common.Model;

namespace Kafka.Client.UnitTest.Collections
{
    public class TopicPartitionMapTest
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

            var topicPartitionSet = new TopicPartitionMap<object>();
            var obj = new object();
            for (int i = 0; i < topicPartitions.Length; i++)
            {
                var added = topicPartitionSet.Add(topicPartitions[i], obj);
                var count = topicPartitionSet.Count;
                Assert.Multiple(() =>
                {
                    Assert.That(added, Is.EqualTo(true));
                    Assert.That(count, Is.EqualTo(i + 1));
                });
            }

            var expectedNameOrder = topicPartitionSet
                .OrderBy(r => r.Key.Topic.TopicName.Value)
                .ThenBy(r => r.Key.Partition.Value)
                .ToArray()
            ;
            var itemsByName = topicPartitionSet.CopyItems();
            CollectionAssert.AreEqual(expectedNameOrder, itemsByName);

            var expectedIdOrder = topicPartitionSet
                .OrderBy(r => r.Key.Topic.TopicId.Value)
                .ThenBy(r => r.Key.Partition.Value)
                .ToArray()
            ;
            var itemsById = topicPartitionSet.CopyItems(true);
            CollectionAssert.AreEqual(expectedIdOrder, itemsById);
        }
    }
}
