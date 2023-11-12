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
    }
}
