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
        [Params(1, 8)]
        public int ThreadCount { get; set; }

        [Params(100)]
        public int Topics { get; set; }

        [Params(64)]
        public int PartitionsPerTopic { get; set; }

        [Params(1024 * 1024 * 10)]
        public int TotalOperations { get; set; }

        private readonly List<TopicPartition> _topicsPartitions = [];
        private readonly ConcurrentDictionary<TopicPartition, object> _concurrentDictionary = new(TopicPartitionCompare.Equality);
        private readonly TopicPartitionMap<object> _topicPartitionMap = [];

        private readonly object _object = new();

        [IterationSetup]
        public void Setup()
        {
            _concurrentDictionary.Clear();
            _topicPartitionMap.Clear();

            _topicsPartitions.Clear();

            var topics = Enumerable
                .Range(0, Topics)
                .Select(t =>
                {
                    var id = Guid.NewGuid();
                    return new Topic(
                        id,
                        $"topic{t}"
                    );
                })
            ;

            _topicsPartitions.AddRange(
                topics
                .SelectMany(t => Enumerable
                    .Range(0, PartitionsPerTopic)
                    .Select(p =>
                        new TopicPartition(
                            t,
                            new(p)
                        )
                    )
                )
            );
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
                .Select(t => new Task(() => Run(_topicPartitionMap, UpsertSpinningTopicPartitionDictionary, TotalOperations, ref passes)))
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
                var index = pass % _topicsPartitions.Count;
                var topicPartition = _topicsPartitions[index];
                upsert(collection, topicPartition, _object);
            }
        }

        private delegate void UpsertDelegate<TCollection, TKey, TValue>(
            in TCollection collection,
            in TKey key,
            in TValue value
        );

        private static void UpsertConcurrentDictionary<TKey, TValue>(
            in ConcurrentDictionary<TKey, TValue> concurrentDictionary,
            in TKey key,
            in TValue value
        ) where TKey : notnull => concurrentDictionary[key] = value;

        private static void UpsertSpinningTopicPartitionDictionary<TValue>(
            in TopicPartitionMap<TValue> spinningTopicPartitionDictionary,
            in TopicPartition key,
            in TValue value
        ) => spinningTopicPartitionDictionary.Upsert(key, value);
    }
}
