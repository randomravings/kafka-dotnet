using KafkaGraphQL.Model;

namespace KafkaGraphQL.Types
{
    public class RecordType :
        ObjectType<Record>
    {
        protected override void Configure(IObjectTypeDescriptor<Record> descriptor)
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
