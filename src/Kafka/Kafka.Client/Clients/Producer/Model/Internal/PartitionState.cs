namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal sealed class PartitionState
    {
        public PartitionState(
            int partitionIndex,
            int partitionLeader,
            int baseSequence
        )
        {
            PartitionIndex = partitionIndex;
            PartitionLeader = partitionLeader;
            BaseSequence = baseSequence;
        }
        public int PartitionIndex { get; init; }
        public int PartitionLeader { get; init; }
        public int BaseSequence { get; set; }
    }
}
