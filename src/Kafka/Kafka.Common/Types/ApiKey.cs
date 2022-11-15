namespace Kafka.Common.Types
{
    ///<summary>
    /// The following are the numeric codes that the ApiKey in the request can take for each of the below request types.
    ///<summary>
    public readonly record struct Api(
        short Key
    )
    {
        public static implicit operator Api(short value) => new(value);
        public static implicit operator short(Api value) => value.Key;
        public static bool operator >=(Api a, Api b) => a.Key >= b.Key;
        public static bool operator <=(Api a, Api b) => a.Key <= b.Key;
        public static bool operator >(Api a, Api b) => a.Key > b.Key;
        public static bool operator <(Api a, Api b) => a.Key < b.Key;
        public static Api None { get; } = new(-1);
        public static Api Produce { get; } = new(0);
        public static Api Fetch { get; } = new(1);
        public static Api ListOffsets { get; } = new(2);
        public static Api Metadata { get; } = new(3);
        public static Api LeaderAndIsr { get; } = new(4);
        public static Api StopReplica { get; } = new(5);
        public static Api UpdateMetadata { get; } = new(6);
        public static Api ControlledShutdown { get; } = new(7);
        public static Api OffsetCommit { get; } = new(8);
        public static Api OffsetFetch { get; } = new(9);
        public static Api FindCoordinator { get; } = new(10);
        public static Api JoinGroup { get; } = new(11);
        public static Api Heartbeat { get; } = new(12);
        public static Api LeaveGroup { get; } = new(13);
        public static Api SyncGroup { get; } = new(14);
        public static Api DescribeGroups { get; } = new(15);
        public static Api ListGroups { get; } = new(16);
        public static Api SaslHandshake { get; } = new(17);
        public static Api ApiVersions { get; } = new(18);
        public static Api CreateTopics { get; } = new(19);
        public static Api DeleteTopics { get; } = new(20);
        public static Api DeleteRecords { get; } = new(21);
        public static Api InitProducerId { get; } = new(22);
        public static Api OffsetForLeaderEpoch { get; } = new(23);
        public static Api AddPartitionsToTxn { get; } = new(24);
        public static Api AddOffsetsToTxn { get; } = new(25);
        public static Api EndTxn { get; } = new(26);
        public static Api WriteTxnMarkers { get; } = new(27);
        public static Api TxnOffsetCommit { get; } = new(28);
        public static Api DescribeAcls { get; } = new(29);
        public static Api CreateAcls { get; } = new(30);
        public static Api DeleteAcls { get; } = new(31);
        public static Api DescribeConfigs { get; } = new(32);
        public static Api AlterConfigs { get; } = new(33);
        public static Api AlterReplicaLogDirs { get; } = new(34);
        public static Api DescribeLogDirs { get; } = new(35);
        public static Api SaslAuthenticate { get; } = new(36);
        public static Api CreatePartitions { get; } = new(37);
        public static Api CreateDelegationToken { get; } = new(38);
        public static Api RenewDelegationToken { get; } = new(39);
        public static Api ExpireDelegationToken { get; } = new(40);
        public static Api DescribeDelegationToken { get; } = new(41);
        public static Api DeleteGroups { get; } = new(42);
        public static Api ElectLeaders { get; } = new(43);
        public static Api IncrementalAlterConfigs { get; } = new(44);
        public static Api AlterPartitionReassignments { get; } = new(45);
        public static Api ListPartitionReassignments { get; } = new(46);
        public static Api OffsetDelete { get; } = new(47);
        public static Api DescribeClientQuotas { get; } = new(48);
        public static Api AlterClientQuotas { get; } = new(49);
        public static Api DescribeUserScramCredentials { get; } = new(50);
        public static Api AlterUserScramCredentials { get; } = new(51);
        public static Api AlterPartition { get; } = new(56);
        public static Api UpdateFeatures { get; } = new(57);
        public static Api DescribeCluster { get; } = new(60);
        public static Api DescribeProducers { get; } = new(61);
        public static Api DescribeTransactions { get; } = new(65);
        public static Api ListTransactions { get; } = new(66);
        public static Api AllocateProducerIds { get; } = new(67);
    }
}
