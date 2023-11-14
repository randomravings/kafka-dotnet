using Kafka.Client;
using Kafka.Client.Model;
using Kafka.Common.Model;

namespace KafkaGraphQL.Queries
{
    public class Query
    {
        [GraphQLDescription("Gets a list of topic and partition descriptions.")]
        public async ValueTask<IQueryable<TopicDescription>> GetTopics(

            [GraphQLType<ListType<StringType>>]
            [GraphQLDescription("List of topics to get, omit for all topics.")]
            TopicName[]? topicNames,


            [GraphQLDescription("Options fetching topics.")] 
            GetTopicsOptions? options,

            [Service]
            IKafkaClient kafkaClient,

            CancellationToken cancellationToken
        )
        {
            var result = await kafkaClient.Topics.Get(
                topicNames ?? Array.Empty<TopicName>(),
                options ?? GetTopicsOptions.Empty,
                cancellationToken
            );
            return result.Topics.AsQueryable();
        }
    }
}
