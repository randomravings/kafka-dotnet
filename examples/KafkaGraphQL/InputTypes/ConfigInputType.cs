using KafkaGraphQL.Model;

namespace KafkaGraphQL.InputTypes
{
    public class ConfigInputType :
        InputObjectType<ConfigItem>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ConfigItem> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsExplicitly();
            descriptor
                .Field(r => r.Key)
            ;
            descriptor
                .Field(r => r.Value)
            ;
        }
    }
}
