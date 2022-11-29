namespace Kafka.Common.Types
{
    ///<summary>
    /// The following are the numeric codes that the ApiKey in the request can take for each of the below request types.
    ///<summary>
    public readonly record struct ApiKey(
        short Value
    )
    {
        public static implicit operator ApiKey(short value) => new(value);
        public static implicit operator short(ApiKey value) => value.Value;
        public static bool operator >=(ApiKey a, ApiKey b) => a.Value >= b.Value;
        public static bool operator <=(ApiKey a, ApiKey b) => a.Value <= b.Value;
        public static bool operator >(ApiKey a, ApiKey b) => a.Value > b.Value;
        public static bool operator <(ApiKey a, ApiKey b) => a.Value < b.Value;
        public static ApiKey None { get; } = new(-1);
        public static ApiKey Produce { get; } = new(0);
        public static ApiKey Fetch { get; } = new(1);
        public static ApiKey ListOffsets { get; } = new(2);
        public static ApiKey Metadata { get; } = new(3);
        public static ApiKey LeaderAndIsr { get; } = new(4);
        public static ApiKey StopReplica { get; } = new(5);
        public static ApiKey UpdateMetadata { get; } = new(6);
        public static ApiKey ControlledShutdown { get; } = new(7);
        public static ApiKey OffsetCommit { get; } = new(8);
        public static ApiKey OffsetFetch { get; } = new(9);
        public static ApiKey FindCoordinator { get; } = new(10);
        public static ApiKey JoinGroup { get; } = new(11);
        public static ApiKey Heartbeat { get; } = new(12);
        public static ApiKey LeaveGroup { get; } = new(13);
        public static ApiKey SyncGroup { get; } = new(14);
        public static ApiKey DescribeGroups { get; } = new(15);
        public static ApiKey ListGroups { get; } = new(16);
        public static ApiKey SaslHandshake { get; } = new(17);
        public static ApiKey ApiVersions { get; } = new(18);
        public static ApiKey CreateTopics { get; } = new(19);
        public static ApiKey DeleteTopics { get; } = new(20);
        public static ApiKey DeleteRecords { get; } = new(21);
        public static ApiKey InitProducerId { get; } = new(22);
        public static ApiKey OffsetForLeaderEpoch { get; } = new(23);
        public static ApiKey AddPartitionsToTxn { get; } = new(24);
        public static ApiKey AddOffsetsToTxn { get; } = new(25);
        public static ApiKey EndTxn { get; } = new(26);
        public static ApiKey WriteTxnMarkers { get; } = new(27);
        public static ApiKey TxnOffsetCommit { get; } = new(28);
        public static ApiKey DescribeAcls { get; } = new(29);
        public static ApiKey CreateAcls { get; } = new(30);
        public static ApiKey DeleteAcls { get; } = new(31);
        public static ApiKey DescribeConfigs { get; } = new(32);
        public static ApiKey AlterConfigs { get; } = new(33);
        public static ApiKey AlterReplicaLogDirs { get; } = new(34);
        public static ApiKey DescribeLogDirs { get; } = new(35);
        public static ApiKey SaslAuthenticate { get; } = new(36);
        public static ApiKey CreatePartitions { get; } = new(37);
        public static ApiKey CreateDelegationToken { get; } = new(38);
        public static ApiKey RenewDelegationToken { get; } = new(39);
        public static ApiKey ExpireDelegationToken { get; } = new(40);
        public static ApiKey DescribeDelegationToken { get; } = new(41);
        public static ApiKey DeleteGroups { get; } = new(42);
        public static ApiKey ElectLeaders { get; } = new(43);
        public static ApiKey IncrementalAlterConfigs { get; } = new(44);
        public static ApiKey AlterPartitionReassignments { get; } = new(45);
        public static ApiKey ListPartitionReassignments { get; } = new(46);
        public static ApiKey OffsetDelete { get; } = new(47);
        public static ApiKey DescribeClientQuotas { get; } = new(48);
        public static ApiKey AlterClientQuotas { get; } = new(49);
        public static ApiKey DescribeUserScramCredentials { get; } = new(50);
        public static ApiKey AlterUserScramCredentials { get; } = new(51);
        public static ApiKey AlterPartition { get; } = new(56);
        public static ApiKey UpdateFeatures { get; } = new(57);
        public static ApiKey DescribeCluster { get; } = new(60);
        public static ApiKey DescribeProducers { get; } = new(61);
        public static ApiKey DescribeTransactions { get; } = new(65);
        public static ApiKey ListTransactions { get; } = new(66);
        public static ApiKey AllocateProducerIds { get; } = new(67);
    }
}
