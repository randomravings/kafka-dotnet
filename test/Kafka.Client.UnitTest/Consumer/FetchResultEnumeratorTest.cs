using Kafka.Client.Clients.Consumer;
using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Model;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using Moq;
using System.Collections.Immutable;

namespace Kafka.Client.UnitTest.Consumer
{
    [TestFixture]
    public class FetchResultEnumeratorTest
    {
        [Test]
        public void TestTaskComplete()
        {
            var taskCompletionSource = new TaskCompletionSource();
            Assert.That(taskCompletionSource.Task.IsCompleted, Is.EqualTo(false));
            var enumerator = new FetchResultEnumerator(
                ImmutableArray<RawConsumerRecord>.Empty,
                r => { },
                taskCompletionSource
            );
            enumerator.Close();
            Assert.That(taskCompletionSource.Task.IsCompleted, Is.EqualTo(true));
        }

        [Test]
        public void TestClose()
        {
            var taskCompletionSource = new TaskCompletionSource();
            var moveNext = FetchEnumeratorState.None;
            var enumerator = new FetchResultEnumerator(
                ImmutableArray<RawConsumerRecord>.Empty,
                r => { },
                new TaskCompletionSource()
            );
            enumerator.Close();
            moveNext = enumerator.MoveNext();
            Assert.That(moveNext, Is.EqualTo(FetchEnumeratorState.Closed));
        }

        [Test]
        public void TestEmpty()
        {
            var taskCompletionSource = new TaskCompletionSource();
            var moveNext = FetchEnumeratorState.None;
            var enumerator = new FetchResultEnumerator(
                ImmutableArray<RawConsumerRecord>.Empty,
                r => { },
                new TaskCompletionSource()
            );
            moveNext = enumerator.MoveNext();
            Assert.That(moveNext, Is.EqualTo(FetchEnumeratorState.End));
            moveNext = enumerator.MoveNext();
            Assert.That(moveNext, Is.EqualTo(FetchEnumeratorState.End));
        }

        [Test]
        public void TestSingleTP()
        {
            var moveNext = FetchEnumeratorState.None;
            var fetchRecords = CreateRecords(
                new TopicPartition("x", 0),
                0,
                3
            ).ToImmutableArray();
            var enumerator = new FetchResultEnumerator(
                fetchRecords,
                r => { },
                new TaskCompletionSource()
            );
            for (int i = 0; i < 2; i++)
            {
                moveNext = enumerator.MoveNext();
                Assert.That(moveNext, Is.EqualTo(FetchEnumeratorState.Active));
            }
            moveNext = enumerator.MoveNext();
            Assert.That(moveNext, Is.EqualTo(FetchEnumeratorState.End));
            moveNext = enumerator.MoveNext();
            Assert.That(moveNext, Is.EqualTo(FetchEnumeratorState.End));

            enumerator.Close();
            moveNext = enumerator.MoveNext();
            Assert.That(moveNext, Is.EqualTo(FetchEnumeratorState.Closed));
        }

        [Test]
        public void TestMultipleTP()
        {
            var moveNext = FetchEnumeratorState.None;
            var fetchRecords =
                CreateRecords(
                    new TopicPartition("x", 0),
                    0,
                    3
                ).Concat(
                CreateRecords(
                    new TopicPartition("x", 2),
                    0,
                    5
                )).Concat(
                CreateRecords(
                    new TopicPartition("x", 4),
                    0,
                    1
                )).ToImmutableArray()
            ;

            var enumerator = new FetchResultEnumerator(
                fetchRecords,
                r => { },
                new TaskCompletionSource()
            );
            for (int i = 0; i < 8; i++)
            {
                moveNext = enumerator.MoveNext();
                Assert.That(moveNext, Is.EqualTo(FetchEnumeratorState.Active));
            }
            moveNext = enumerator.MoveNext();
            Assert.That(moveNext, Is.EqualTo(FetchEnumeratorState.End));
        }

        private static IEnumerable<RawConsumerRecord> CreateRecords(
            TopicPartition topicPartition,
            Offset baseOffset,
            int count
        ) =>
            Enumerable
                .Range(0, count)
                .Select(r => new RawConsumerRecord(
                    topicPartition,
                    baseOffset + r,
                    Timestamp.Created(r),
                    null,
                    null,
                    ImmutableArray<RecordHeader>.Empty,
                    Errors.Known.NONE
                ))
        ;
    }
}
