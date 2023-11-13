using Kafka.Client.Model;

namespace KafkaGraphQL.Types
{

    public class TopicType :
         ObjectType<TopicDescription>
    {
        protected override void Configure(IObjectTypeDescriptor<TopicDescription> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsExplicitly();
            descriptor
                .Field(t => t.TopicId)
                .Type<UuidType>()
            ;
            descriptor
                .Field(t => t.TopicName)
                .Type<StringType>()
            ;
            descriptor
                .Field(t => t.Internal)
            ;
            descriptor
                .Field(t => t.TopicAuthorizedOperations)
            ;
            descriptor
                .Field(t => t.Partitions)
                .Type<ListType<PartitionType>>()
            ;
            descriptor
                .Field(t => t.Error)
                .Type<ErrorType>()
            ;
        }
    }
}
