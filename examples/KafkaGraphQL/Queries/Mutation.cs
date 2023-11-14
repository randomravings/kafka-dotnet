using Kafka.Client;
using Kafka.Client.IO;
using Kafka.Client.Model;
using Kafka.Common.Model;

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

        [GraphQLDescription("Deletes a topic.")]
        public async ValueTask<DeleteTopicsResult> DeleteTopic(

            [GraphQLType<StringType>]
            [GraphQLDescription("List of topics to get, omit for all topics.")]
            TopicName topicName,

            [Service]
            IKafkaClient kafkaClient,

            CancellationToken cancellationToken
        )
        {
            var result = await kafkaClient.Topics.Delete(
                topicName,
                cancellationToken
            );
            return result;
        }

        [GraphQLDescription("Deletes a topic.")]
        public async ValueTask<ProduceResult> WriteToTopic(
            string key,
            string value,

            [Service]
            IStreamWriter<string, string> streamWriter,

            CancellationToken cancellationToken
        )
        {
            var result = await streamWriter.Write(
                key,
                value,
                cancellationToken
            );
            return result;
        }
    }
}
