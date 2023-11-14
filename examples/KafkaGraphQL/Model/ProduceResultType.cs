using Kafka.Client.Model;
using KafkaGraphQL.Types;

namespace KafkaGraphQL.Model
{
    public class ProduceResultType :
        ObjectType<ProduceResult>
    {
        protected override void Configure(IObjectTypeDescriptor<ProduceResult> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsImplicitly();
            descriptor
                .Field(t => t.TopicPartitionOffset)
                .Type<TopicPartitionOffsetType>()
            ;
            descriptor
                .Field(t => t.Timestamp)
                .Type<DateTimeType>()
            ;
            descriptor
                .Field(t => t.Error)
                .Type<ErrorType>()
            ;
        }
    }
}
