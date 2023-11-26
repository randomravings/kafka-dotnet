using BenchmarkDotNet.Attributes;
using Kafka.Client.Collections;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Buffers;
using System.Collections.Concurrent;

namespace Kafka.Client.Benchmark.Buffering
{
    [Config(typeof(AntiVirusFriendlyConfig))]
    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    public class ConcurrentCollectionBenchmark
    {
        [Params(1, 4, 8)]
        public int ThreadCount { get; set; }

        [Params(1, 4, 8)]
        public int Topics { get; set; }

        [Params(1, 4, 8)]
        public int PartitionsPerTopic { get; set; }

        [Params(1024, 32767, 1048576)]
        public int TotalOperations { get; set; }

        private readonly List<TopicPartition> _topics = [];
        private readonly SortedList<TopicPartition, object> _sortedList = [];
        private readonly ConcurrentDictionary<TopicPartition, object> _concurrentDictionary = new(TopicPartitionCompare.Equality);
        private readonly TopicPartitionDictionary<object> _spinningDictionary = [];

        private readonly object _object = new();

        [IterationSetup]
        public void Setup()
        {
            _topics.Clear();
            _topics.AddRange(Enumerable
                .Range(0, Topics)
                .SelectMany(t => Enumerable
                    .Range(0, PartitionsPerTopic)
                    .Select(p =>
                        new TopicPartition(
                            new Topic(
                                Guid.Empty,
                                $"topic{t}"
                            ),
                            new(p)
                        )
                    )
                )
            );
        }

        [Benchmark]
        public void SortedList()
        {
            int passes = 0;
            var tasks = Enumerable
                .Range(0, ThreadCount)
                .Select(t => new Task(() => Run(_sortedList, UpsertSortedList, TotalOperations, ref passes)))
                .ToArray()
            ;
            foreach (var task in tasks)
                task.Start();
            Task.WaitAll(tasks);
        }

        [Benchmark]
        public void ConcurrentDictionary()
        {
            int passes = 0;
            var tasks = Enumerable
                .Range(0, ThreadCount)
                .Select(t => new Task(() => Run(_concurrentDictionary, UpsertConcurrentDictionary, TotalOperations, ref passes)))
                .ToArray()
            ;
            foreach (var task in tasks)
                task.Start();
            Task.WaitAll(tasks);
        }

        [Benchmark]
        public void SpinningTopicPartitionDictionary()
        {
            int passes = 0;
            var tasks = Enumerable
                .Range(0, ThreadCount)
                .Select(t => new Task(() => Run(_spinningDictionary, UpsertSpinningTopicPartitionDictionary, TotalOperations, ref passes)))
                .ToArray()
            ;
            foreach (var task in tasks)
                task.Start();
            Task.WaitAll(tasks);
        }

        private void Run<TCollection>(
            in TCollection collection,
            in UpsertDelegate<TCollection, TopicPartition, object> upsert,
            in int passes,
            ref int counter
        )
        {
            while (true)
            {
                var pass = Interlocked.Increment(ref counter);
                if (pass >= passes)
                    break;
                var index = pass % _topics.Count;
                var topicPartition = _topics[index];
                upsert(collection, topicPartition, _object);
            }
        }

        private delegate void UpsertDelegate<TCollection, TKey, TValue>(
            in TCollection collection,
            in TKey key,
            in TValue value
        );

        private static void UpsertSortedList<TKey, TValue>(
            in SortedList<TKey, TValue> sortedList,
            in TKey key,
            in TValue value
        ) where TKey : notnull => sortedList.Add(key, value);

        private static void UpsertConcurrentDictionary<TKey, TValue>(
            in ConcurrentDictionary<TKey, TValue> concurrentDictionary,
            in TKey key,
            in TValue value
        ) where TKey : notnull => concurrentDictionary[key] = value;

        private static void UpsertSpinningTopicPartitionDictionary<TValue>(
            in TopicPartitionDictionary<TValue> spinningTopicPartitionDictionary,
            in TopicPartition key,
            in TValue value
        ) => spinningTopicPartitionDictionary.Upsert(key, value);
    }
}
