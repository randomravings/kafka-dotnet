using Kafka.Client;
using Kafka.Client.IO;
using Kafka.Client.Model;
using Kafka.Common.Model;
using KafkaGraphQL.Model;
using System.Diagnostics;

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
                topicNames ?? [],
                options ?? GetTopicsOptions.Empty,
                cancellationToken
            );
            return result.Topics.AsQueryable();
        }

        [GraphQLDescription("Gets a list of topic and partition descriptions.")]
        public async ValueTask<IQueryable<Record>> ReadFromTopic(
            [Service]
            IApplicationReader<string, string> streamReader,
            int maxCount,
            int timeoutMs,

            CancellationToken cancellationToken
        )
        {
            var results = new List<KeyValuePair<string, string>>();
            var timeout = DateTimeOffset.UtcNow.AddMilliseconds(timeoutMs);
            try
            {
                while (true)
                {
                    var waitTime = timeout - DateTimeOffset.UtcNow;
                    if (waitTime <= TimeSpan.Zero)
                        break;
                    var result = await streamReader.Read(
                        waitTime,
                        cancellationToken
                    );
                    if (result == null)
                        break;
                    results.Add(new(result.Key, result.Value));
                    if (results.Count >= maxCount)
                        break;
                }
            }
            catch (OperationCanceledException) { }
            return results.Select(r => new Record { Key = r.Key, Value = r.Value }).AsQueryable();
        }
    }
}
