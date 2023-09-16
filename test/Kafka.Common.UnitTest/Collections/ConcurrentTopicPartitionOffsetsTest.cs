using Kafka.Common.Collections;
using Kafka.Common.Model;

namespace Kafka.Common.UnitTest.Collections
{
    [TestFixture]
    public class ConcurrentTopicPartitionOffsetsTest
    {
        [Test]
        public void TestAdd()
        {
            var topicPartitionOffsets = new ConcurrentTopicPartitionOffsets();

            var topicPartition = UpdateCollection(
                topicPartitionOffsets,
                Guid.Parse("de43c2af-4125-4415-8ddd-8eb37ef19d91"),
                "a",
                0,
                5
            );

            Assert.That(topicPartitionOffsets, Has.Count.EqualTo(1));
            Assert.That(topicPartitionOffsets[topicPartition], Is.EqualTo(new Offset(5)));

            topicPartition = UpdateCollection(
                topicPartitionOffsets,
                Guid.Parse("de43c2af-4125-4415-8ddd-8eb37ef19d91"),
                "a",
                0,
                6
            );

            Assert.That(topicPartitionOffsets, Has.Count.EqualTo(1));
            Assert.That(topicPartitionOffsets[topicPartition], Is.EqualTo(new Offset(6)));

            topicPartition = UpdateCollection(
                topicPartitionOffsets,
                Guid.Parse("de43c2af-4125-4415-8ddd-8eb37ef19d91"),
                null,
                0,
                7
            );

            Assert.That(topicPartitionOffsets, Has.Count.EqualTo(1));
            Assert.That(topicPartitionOffsets[topicPartition], Is.EqualTo(new Offset(7)));

            topicPartition = UpdateCollection(
                topicPartitionOffsets,
                null,
                "a",
                0,
                8
            );

            Assert.That(topicPartitionOffsets, Has.Count.EqualTo(1));
            Assert.That(topicPartitionOffsets[topicPartition], Is.EqualTo(new Offset(8)));
        }

        [Test]
        public void TestDiff()
        {
            var topic = new Topic(Guid.Parse("de43c2af-4125-4415-8ddd-8eb37ef19d91"), "a");

            var current = CreateCollection(
                new TopicPartitionOffset(new(topic, 0), 10),
                new TopicPartitionOffset(new(topic, 1), 11),
                new TopicPartitionOffset(new(topic, 2), 12),
                new TopicPartitionOffset(new(topic, 3), 13)
            );

            var other = CreateCollection(
                new TopicPartitionOffset(new(topic, 0), 10),
                new TopicPartitionOffset(new(topic, 1), 5),
                new TopicPartitionOffset(new(topic, 2), 6)
            );

            var diff = current.OffsetDiff(other);

            Assert.Multiple(() =>
            {
                Assert.That(diff, Has.Count.EqualTo(3));
                Assert.That(diff[new(topic, 1)].Value, Is.EqualTo(11));
                Assert.That(diff[new(topic, 2)].Value, Is.EqualTo(12));
                Assert.That(diff[new(topic, 3)].Value, Is.EqualTo(13));
            });
        }

        private static TopicPartition UpdateCollection(
            ConcurrentTopicPartitionOffsets collection,
            Guid? uuid,
            string? name,
            int partition,
            long offset
        )
        {
            var topic = new Topic(uuid, name);
            var topicPartition = new TopicPartition(topic, partition);
            collection.AddOrUpdate(topicPartition, offset);
            return topicPartition;
        }

        private static ConcurrentTopicPartitionOffsets CreateCollection(params TopicPartitionOffset[] topicPartitionOffsets)
        {
            var collection = new ConcurrentTopicPartitionOffsets();
            foreach ((var topicPartition, var offset) in topicPartitionOffsets)
                collection.AddOrUpdate(topicPartition, offset);
            return collection;
        }
    }
}
