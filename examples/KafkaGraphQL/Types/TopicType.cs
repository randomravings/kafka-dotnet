using Kafka.Client.Model;
using Kafka.Common.Model;

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
                .Description("Topic description.")
            ;
            descriptor
                .Field(t => t.TopicId)
                .Type<UuidType>()
                .Description("Topic id as UUID.")
            ;
            descriptor
                .Field(t => t.TopicName)
                .Type<StringType>()
                .Description("Topic name.")
            ;
            descriptor
                .Field(t => t.Internal)
                .Description("True if internal topic, otherwise false.")
            ;
            descriptor
                .Field(t => t.TopicAuthorizedOperations)
                .Description("Authorized operations on the topic.")
                .Type<ListType<EnumType<AclOperation>>>()
                .Resolve(context =>
                {
                    var value = context.Parent<TopicDescription>().TopicAuthorizedOperations;
                    if (value == AclOperation.None)
                        return [];
                    else
                        return Enum.GetValues<AclOperation>().Where(r => r != AclOperation.None && value.HasFlag(r)).ToArray();
                })
            ;
            descriptor
                .Field(t => t.Partitions)
                .Type<ListType<PartitionType>>()
                .Description("List of partitions on the topic.")
            ;
            descriptor
                .Field(t => t.Error)
                .Type<ErrorType>()
                .Description("Error for the topic.")
            ;
        }
    }
}
