using BenchmarkDotNet.Attributes;
using Kafka.Client.Collections.Internal;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Buffers;

namespace Kafka.Client.Benchmark.Buffering
{
    [Config(typeof(AntiVirusFriendlyConfig))]
    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    public class BinarySearchBenchmark
    {
        private TopicPartition[] _topicsPartitions = [];
        private TopicPartition[] _samples = [];

        [IterationSetup]
        public void Setup()
        {
            var topics = Enumerable
                .Range(0, 1024*1024)
                .Select(t =>
                {
                    var id = Guid.NewGuid();
                    return new Topic(
                        id,
                        $"topic{t}"
                    );
                })
            ;

            _topicsPartitions =(
                topics
                .SelectMany(t => Enumerable
                    .Range(0, 6)
                    .Select(p =>
                        new TopicPartition(
                            t,
                            new(p)
                        )
                    )
                )
                .ToArray()
            );

            _samples = Enumerable
                .Range(0, (_topicsPartitions.Length / 10) - 1)
                .Select(t => _topicsPartitions[t * 10])
                .ToArray()
            ;
        }

        [Benchmark]
        public void FrameworkCompareByName()
        {
            foreach (var sample in _samples)
                Array.BinarySearch(_topicsPartitions, sample, TopicPartitionCompare.Instance);
        }

        [Benchmark]
        public void CustomCompareByName()
        {
            foreach (var sample in _samples)
                ArrayOperations.BinaryIndexOf(_topicsPartitions, sample, _topicsPartitions.Length, KeyOperations.TopicPartitionName);
        }
    }
}
