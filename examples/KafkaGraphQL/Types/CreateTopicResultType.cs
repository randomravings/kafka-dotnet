using Kafka.Client.Model;

namespace KafkaGraphQL.Types
{
    public class CreateTopicResultType :
        ObjectType<CreateTopicResult>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateTopicResult> descriptor)
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
                .Field(r => r.NumPartitions)
            ;
            descriptor
                .Field(r => r.ReplicationFactor)
            ;
            descriptor
                .Field(r => r.Config)
            ;
            descriptor
                .Field(r => r.Error)
            ;
        }
    }
}
