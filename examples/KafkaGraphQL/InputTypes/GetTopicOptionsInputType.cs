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
                .Description("Query options for topics.")
            ;
            descriptor
                .Field(t => t.IncludeInternal)
                .DefaultValue(false)
                .Description("Option to include internal topics.")
            ;
            descriptor
                .Field(t => t.IncludeTopicAuthorizedOperations)
                .DefaultValue(false)
                .Description("Option to include autorized operations on the topic.")
            ;
        }
    }
}
