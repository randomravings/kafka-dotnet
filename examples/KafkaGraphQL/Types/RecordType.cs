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
                .Field(t => t.TopicId)
                .Type<UuidType>()
            ;
            descriptor
                .Field(t => t.TopicName)
            ;
            descriptor
                .Field(t => t.Partition)
            ;
            descriptor
                .Field(t => t.Offset)
            ;
            descriptor
                .Field(t => t.Key)
            ;
            descriptor
                .Field(t => t.Value)
            ;
        }
    }
}
