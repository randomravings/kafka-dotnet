using Kafka.Client.Model;

namespace KafkaGraphQL.Types
{
    public class PartitionType :
        ObjectType<PartitionDescription>
    {
        protected override void Configure(IObjectTypeDescriptor<PartitionDescription> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsExplicitly();
            descriptor
                .Field(t => t.PartitionIndex)
                .Type<IntType>()
            ;
            descriptor
                .Field(t => t.LeaderId)
                .Type<IntType>()
            ;
            descriptor
                .Field(t => t.LeaderEpoch)
                .Type<IntType>()
            ;
            descriptor
                .Field(t => t.ReplicaNodes)
                .Type<ListType<IntType>>()
            ;
            descriptor
                .Field(t => t.IsrNodes)
                .Type<ListType<IntType>>()
            ;
            descriptor
                .Field(t => t.OfflineReplicas)
                .Type<ListType<IntType>>()
            ;
            descriptor
                .Field(t => t.Error)
                .Type<ErrorType>()
            ;
        }
    }
}
