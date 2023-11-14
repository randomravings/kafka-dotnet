using KafkaGraphQL.Model;

namespace KafkaGraphQL.InputTypes
{
    public class ReplicaAssigmentInputType :
        InputObjectType<ReplicaAssignment>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ReplicaAssignment> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsExplicitly();
            descriptor
                .Field(r => r.Partition)
            ;
            descriptor
                .Field(r => r.ReplicaAssigments)
                .DefaultValue(EMPTY_REPLICAS)
            ;
        }
        private static readonly int[] EMPTY_REPLICAS = Array.Empty<int>();
    }
}
