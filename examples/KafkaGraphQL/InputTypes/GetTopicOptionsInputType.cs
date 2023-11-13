using Kafka.Client.Model;

namespace KafkaGraphQL.InputTypes
{
    public class GetTopicOptionsInputType :
        InputObjectType<GetTopicsOptions>
    {
        protected override void Configure(IInputObjectTypeDescriptor<GetTopicsOptions> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsExplicitly();
            descriptor
                .Field(t => t.IncludeInternal)
                .DefaultValue(false)
            ;
            descriptor
                .Field(t => t.IncludeTopicAuthorizedOperations)
                .DefaultValue(false)
            ;
        }
    }
}
