using Kafka.Common.Model;

namespace KafkaGraphQL.Types
{
    public class TopicPartitionOffsetType :
        ObjectType<TopicPartitionOffset>
    {
        protected override void Configure(IObjectTypeDescriptor<TopicPartitionOffset> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsImplicitly();
            descriptor
                .Field(t => t.TopicPartition)
                .Type<TopicPartitionType>()
            ;
            descriptor
                .Field(t => t.Offset)
                .Type<LongType>()
            ;
        }
    }
}
