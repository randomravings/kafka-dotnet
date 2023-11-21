using KafkaGraphQL.Model;

namespace KafkaGraphQL.InputTypes
{
    public class RecordInputType :
        InputObjectType<Record>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Record> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsExplicitly();
            descriptor
                .Field(t => t.Key)
            ;
            descriptor
                .Field(t => t.Value)
            ;
        }
    }
}
