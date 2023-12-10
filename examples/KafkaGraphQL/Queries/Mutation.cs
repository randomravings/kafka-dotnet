using Kafka.Client;
using Kafka.Client.IO;
using Kafka.Client.Model;
using Kafka.Common.Model;
using KafkaGraphQL.InputTypes;
using KafkaGraphQL.Model;
using KafkaGraphQL.Types;

namespace KafkaGraphQL.Queries
{
    public class Mutation
    {
        [GraphQLDescription("Creates one or more topics.")]
        public async ValueTask<CreateTopicsResult> CreateTopic(

            [GraphQLNonNullType]
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
            [GraphQLNonNullType]
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

        [GraphQLDescription("Writes a set of records to a topic.")]
        public async ValueTask<IQueryable<ProduceResult>> WriteToTopic(

            [GraphQLType<StringType>]
            [GraphQLNonNullType]
            TopicName topic,

            [GraphQLType<ListType<RecordInputType>>]
            IEnumerable<Record> records,

            [Service]
            IStreamWriter<string?, string?> streamWriter,

            CancellationToken cancellationToken
        )
        {
            var tasks = records
                .Select(r =>
                    streamWriter.Write(
                        topic,
                        r.Key,
                        r.Value,
                        cancellationToken
                    )
                )
                .ToArray()
            ;
            await Task.Yield();
            var results = await Task.WhenAll(tasks);
            return results.AsQueryable();
        }
    }
}
