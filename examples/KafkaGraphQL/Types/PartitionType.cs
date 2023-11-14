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
                .Description("Partition description.")
            ;
            descriptor
                .Field(t => t.PartitionIndex)
                .Type<IntType>()
                .Description("Partition number.")
            ;
            descriptor
                .Field(t => t.LeaderId)
                .Type<IntType>()
                .Description("Current partition leader broker id.")
            ;
            descriptor
                .Field(t => t.LeaderEpoch)
                .Type<IntType>()
                .Description("Current partition leader broker epoch.")
            ;
            descriptor
                .Field(t => t.ReplicaNodes)
                .Type<ListType<IntType>>()
                .Description("Set of brokers hosting a replica for this partition.")
            ;
            descriptor
                .Field(t => t.IsrNodes)
                .Type<ListType<IntType>>()
                .Description("Set of brokers that are in sync with partition leader broker.")
            ;
            descriptor
                .Field(t => t.OfflineReplicas)
                .Type<ListType<IntType>>()
                .Description("Set of offline brokers that are hosting a replica for this partition.")
            ;
            descriptor
                .Field(t => t.Error)
                .Type<ErrorType>()
                .Description("Error for this partition if any.")
            ;
        }
    }
}
