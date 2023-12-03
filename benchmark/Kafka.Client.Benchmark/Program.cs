using BenchmarkDotNet.Running;
using Kafka.Client.Benchmark.Buffering;

//var summary = BenchmarkRunner.Run<BinarySearchBenchmark>();
var summary = BenchmarkRunner.Run<ConcurrentCollectionBenchmark>();