using Kafka.Client;
using Kafka.Client.Model;
using Kafka.Common.Model;

namespace KafkaGraphQL.Queries
{
    public class Query
    {
        public async ValueTask<IQueryable<TopicDescription>> GetTopics(
            [GraphQLType<ListType<StringType>>] TopicName[]? topicNames,
            [Service] IKafkaClient kafkaClient,
            CancellationToken cancellationToken
        )
        {
            var result = await kafkaClient.Topics.Get(
                topicNames ?? Array.Empty<TopicName>(),
                GetTopicsOptions.Empty,
                cancellationToken
            );
            return result.Topics.AsQueryable();
        }
    }
}
