namespace KafkaGraphQL.Model
{
    public class ReplicaAssignment
    {
        public int Partition { get; set; }
        public int[] ReplicaAssigments { get; set; } = Array.Empty<int>();
    }
}
