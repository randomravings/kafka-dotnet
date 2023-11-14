using Kafka.Client.Model;
using KafkaGraphQL.Model;

namespace KafkaGraphQL.InputTypes
{
    public class CreateTopicDefinitionInputType :
        InputObjectType<CreateTopicDefinition>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateTopicDefinition> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsExplicitly();
            descriptor
                .Description("Definition for topic to be created.")
            ;
            descriptor
                .Field(t => t.Name)
                .Description("Name of the topic.")
            ;
            descriptor
                .Field(t => t.NumPartitions)
                .Description("Number of partitions for topic.")
                .DefaultValue(1)
            ;
            descriptor
                .Field(t => t.ReplicationFactor)
                .Description("Peplication factor for partitions.")
                .DefaultValue(1)
            ;
            descriptor
                .Field(t => t.ReplicasAssignments)
                .Description("Peplication factor for partitions.")
                .Type<ListType<ReplicaAssigmentInputType>>()
                .DefaultValue(DEFAULT_REPLICA_ASASSIGNMENTS)
            ;
            descriptor
                .Field(t => t.Configs)
                .Description("Additional configurations for topic.")
                .Type<ListType<ConfigInputType>>()
                .DefaultValue(DEFAULT_CONFIGS)
            ;
        }
        private static readonly List<ReplicaAssignment> DEFAULT_REPLICA_ASASSIGNMENTS = new();
        private static readonly List<ConfigItem> DEFAULT_CONFIGS = new();
    }
}
