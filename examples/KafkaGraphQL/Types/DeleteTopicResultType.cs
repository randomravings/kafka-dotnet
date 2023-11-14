using Kafka.Client.Model;

namespace KafkaGraphQL.Types
{
    public class DeleteTopicResultType :
        ObjectType<DeleteTopicResult>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteTopicResult> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsExplicitly();
            descriptor
                .Field(r => r.TopicId)
                .Type<UuidType>()
            ;
            descriptor
                .Field(r => r.TopicName)
                .Type<StringType>()
            ;
            descriptor
                .Field(r => r.Error)
            ;
        }
    }
}
