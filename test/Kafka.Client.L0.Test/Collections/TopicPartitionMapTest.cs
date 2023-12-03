using Kafka.Client.Collections;
using Kafka.Common.Model;

namespace Kafka.Client.L0.Test.Collections
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

            var obj = new object();
            var topicPartitions = topics
                .SelectMany(t => Enumerable
                    .Range(0, 6)
                    .Select(p => new TopicPartition(t, p))
                )
                .ToArray()
            ;

            var topicPartitionSet = new TopicPartitionMap<object>();
            var expectedNameOrder = topicPartitions
                .OrderBy(r => r.Topic.TopicName.Value)
                .ThenBy(r => r.Partition.Value)
                .Select(r => new KeyValuePair<TopicPartition, object>(r, obj))
                .ToArray()
            ;
            var expectedIdOrder = topicPartitions
                .OrderBy(r => r.Topic.TopicId.Value)
                .ThenBy(r => r.Partition.Value)
                .Select(r => new KeyValuePair<TopicPartition, object>(r, obj))
                .ToArray()
            ;

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

            var itemsByName = topicPartitionSet.CopyItems();
            CollectionAssert.AreEqual(expectedNameOrder, itemsByName);
            var itemsById = topicPartitionSet.CopyItems(true);
            CollectionAssert.AreEqual(expectedIdOrder, itemsById);
        }

        [Test]
        public void TestUpsert()
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

            var obj = new object();
            var expectedNameOrder = topicPartitions
                .OrderBy(r => r.Topic.TopicName.Value)
                .ThenBy(r => r.Partition.Value)
                .Select(r => new KeyValuePair<TopicPartition, object>(r, obj))
                .ToArray()
            ;
            var expectedIdOrder = topicPartitions
                .OrderBy(r => r.Topic.TopicId.Value)
                .ThenBy(r => r.Partition.Value)
                .Select(r => new KeyValuePair<TopicPartition, object>(r, obj))
                .ToArray()
            ;

            var topicPartitionSet = new TopicPartitionMap<object>();
            for (int i = 0; i < topicPartitions.Length; i++)
            {
                topicPartitionSet.Upsert(topicPartitions[i], obj);
                var count = topicPartitionSet.Count;
                Assert.That(count, Is.EqualTo(i + 1));
            }

            var itemsByName = topicPartitionSet.CopyItems();
            CollectionAssert.AreEqual(expectedNameOrder, itemsByName);
            var itemsById = topicPartitionSet.CopyItems(true);
            CollectionAssert.AreEqual(expectedIdOrder, itemsById);

            for (int i = 0; i < topicPartitions.Length; i++)
            {
                topicPartitionSet.Upsert(topicPartitions[i], obj);
                var count = topicPartitionSet.Count;
                Assert.That(count, Is.EqualTo(topicPartitions.Length));
            }

            itemsByName = topicPartitionSet.CopyItems();
            CollectionAssert.AreEqual(expectedNameOrder, itemsByName);
            itemsById = topicPartitionSet.CopyItems(true);
            CollectionAssert.AreEqual(expectedIdOrder, itemsById);
        }

        [Test]
        public async Task RunUpsertParallel()
        {
            var threadCount = 4;
            var topicCount = 4;
            var partitionsCount = 4;
            var passes = 1024;
            var topics = Enumerable
                .Range(0, topicCount)
                .Select(t =>
                {
                    var id = Guid.NewGuid();
                    return new Topic(
                        id,
                        $"topic{t}"
                    );
                })
            ;

            var topicsPartitions =
                topics
                .SelectMany(t => Enumerable
                    .Range(0, partitionsCount)
                    .Select(p =>
                        new TopicPartition(
                            t,
                            new(p)
                        )
                    )
                )
                .ToArray()
            ;

            var topicPartitionMap = new TopicPartitionMap<object>();
            var tasks = Enumerable
                .Range(0, threadCount)
                .Select(t => new Task(() => Run(topicPartitionMap, topicsPartitions, passes)))
                .ToArray()
            ;
            foreach (var task in tasks)
                task.Start();
            await Task.WhenAll(tasks);

            var itemsByName = topicPartitionMap.CopyKeys();
            CollectionAssert.AreEqual(topicsPartitions, itemsByName);
        }

        private static void Run(
            in TopicPartitionMap<object> topicPartitionMap,
            in TopicPartition[] topicPartitionValues,
            in int passes
        )
        {
            var obj = new object();
            var len = topicPartitionValues.Length;
            var index = Random.Shared.Next(len);
            Task.Delay(100).Wait();
            for(int i = 0; i < passes; i++)
            {
                index = (index + 1) % len;
                var topicPartition = topicPartitionValues[index];
                topicPartitionMap.Upsert(topicPartition, obj);
            }
        }
    }
}
