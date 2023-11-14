using Kafka.Common.Model;

namespace KafkaGraphQL.Types
{
    public class TopicPartitionType :
        ObjectType<TopicPartition>
    {
        protected override void Configure(IObjectTypeDescriptor<TopicPartition> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsImplicitly();
            descriptor
                .Field(t => t.Topic)
                .Type<StringType>();
            ;
            descriptor
                .Field(t => t.Partition)
                .Type<IntType>()
            ;
        }
    }
}
