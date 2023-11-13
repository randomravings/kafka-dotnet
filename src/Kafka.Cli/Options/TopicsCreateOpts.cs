﻿using CommandLine;

namespace Kafka.Cli.Options
{
    [Verb("create")]
    public sealed class TopicsCreateOpts
        : Opts
    {
        [Option("topic", Required = true)]
        public string Topic { get; set; } = "";
        [Option("partition-count")]
        public int PartitionCount { get; set; } = 1;
        [Option("replication-factor")]
        public short ReplicationFactor { get; set; } = 1;
        [Option("replica-assignment")]
        public string ReplicaAssignment { get; set; } = "";
    }
}
