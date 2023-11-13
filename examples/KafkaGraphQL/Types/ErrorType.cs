namespace KafkaGraphQL.Types
{
    public class ErrorType :
        ObjectType<Kafka.Common.Model.Error>
    {
        protected override void Configure(IObjectTypeDescriptor<Kafka.Common.Model.Error> descriptor)
        {
            base.Configure(descriptor);
            descriptor.BindFieldsExplicitly();
            descriptor
                .Field(r => r.Code)
            ;
            descriptor
                .Field(r => r.Label)
            ;
            descriptor
                .Field(r => r.Message)
            ;
            descriptor
                .Field(r => r.Retriable)
            ;
        }
    }
}
