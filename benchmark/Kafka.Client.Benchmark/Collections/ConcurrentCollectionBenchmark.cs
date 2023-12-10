using BenchmarkDotNet.Attributes;
using Kafka.Client.Collections.Compare;
using Kafka.Client.Collections.Internal;
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
        [Params(8)]
        public int ThreadCount { get; set; }

        [Params(100)]
        public int Topics { get; set; }

        [Params(64)]
        public int PartitionsPerTopic { get; set; }

        [Params(1024 * 1024 * 10)]
        public int TotalOperations { get; set; }

        private readonly List<TopicPartition> _topicsPartitions = [];
        private readonly ConcurrentDictionary<TopicPartition, object> _concurrentDictionary = new(TopicPartitionCompare.Equality);
        private readonly IndexedDictionary<TopicPartition, object> _indexedDictionary =
            new(
                4096 * 2,
                TopicNamePartitionCompare.Instance,
                TopicIdPartitionCompare.Instance
            )
        ;

        private readonly object _object = new();

        [IterationSetup]
        public void Setup()
        {
            _concurrentDictionary.Clear();
            _indexedDictionary.Clear();

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
        public void ConcurrentDictionaryAddOrSet()
        {
            int passes = 0;
            var tasks = Enumerable
                .Range(0, ThreadCount)
                .Select(t => new Task(() => Run(
                    _topicsPartitions,
                    _concurrentDictionary,
                    UpsertConcurrentDictionary,
                    TotalOperations,
                    _object,
                    ref passes
                 )))
                .ToArray()
            ;
            foreach (var task in tasks)
                task.Start();
            Task.WaitAll(tasks);
        }

        [Benchmark]
        public void FunkyDictionaryAddOrSet()
        {
            int passes = 0;
            var tasks = Enumerable
                .Range(0, ThreadCount)
                .Select(t => new Task(() => Run(
                    _topicsPartitions,
                    _indexedDictionary,
                    UpsertFunkyDictionary,
                    TotalOperations,
                    _object,
                    ref passes
                 )))
                .ToArray()
            ;
            foreach (var task in tasks)
                task.Start();
            Task.WaitAll(tasks);
        }

        private static void Run<TCollection, TKey, TValue>(
            in List<TKey> keys,
            in TCollection collection,
            in UpsertDelegate<TCollection, TKey, TValue> upsert,
            in int passes,
            in TValue value,
            ref int counter
        )
        {
            while (true)
            {
                var pass = Interlocked.Increment(ref counter);
                if (pass >= passes)
                    break;
                var index = pass % keys.Count;
                var key = keys[index];
                upsert(collection, key, value);
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

        private static void UpsertFunkyDictionary<TKey, TValue>(
            in IndexedDictionary<TKey, TValue> dictionary,
            in TKey key,
            in TValue value
        ) => dictionary.AddOrSet(key, value);
    }
}
