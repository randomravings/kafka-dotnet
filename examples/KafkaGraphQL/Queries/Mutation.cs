using Kafka.Client;
using Kafka.Client.Model;

namespace KafkaGraphQL.Queries
{
    public class Mutation
    {
        [GraphQLDescription("Creates one or more topics.")]
        public async ValueTask<CreateTopicsResult> CreateTopic(

            [GraphQLDescription("Create topic definitions.")]
            CreateTopicDefinition definition,


            [GraphQLDescription("Options creating topics.")] 
            CreateTopicOptions? options,

            [Service]
            IKafkaClient kafkaClient,

            CancellationToken cancellationToken
        )
        {
            var result = await kafkaClient.Topics.Create(
                definition,
                options ?? CreateTopicOptions.Empty,
                cancellationToken
            );
            return result;
        }
    }
}
