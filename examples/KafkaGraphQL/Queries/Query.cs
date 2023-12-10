﻿using GreenDonut;
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
        public async ValueTask<IQueryable<Record>> ReadFromTopics(

            [GraphQLType<ListType<StringType>>]
            [GraphQLDescription("List of topics to get, omit for all topics.")]
            TopicName[] topicNames,

            [Service]
            IGroupReader<string, string> streamReader,
            int maxCount,
            int timeoutMs,

            CancellationToken cancellationToken
        )
        {
            var results = new List<Record>();
            if (topicNames.Length == 0)
                return results.AsQueryable();
            if (await streamReader.SetTopics(topicNames))
            {
                var result = await streamReader.Read(
                    cancellationToken
                );
                if (result == null)
                    return results.AsQueryable();
                results.Add(ToRecord(result));
            }
            var timeout = DateTimeOffset.UtcNow.AddMilliseconds(timeoutMs);
            try
            {
                while (results.Count < maxCount)
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
                    results.Add(ToRecord(result));
                }
            }
            catch (OperationCanceledException) { }
            return results.AsQueryable();
        }
        private static Record ToRecord(ReadRecord<string, string> readRecord) =>
            new()
            {
                TopicId = readRecord.TopicPartition.Topic.TopicId,
                TopicName = readRecord.TopicPartition.Topic.TopicName,
                Partition = readRecord.TopicPartition.Partition,
                Offset = readRecord.Offset,
                Key = readRecord.Key,
                Value = readRecord.Value
            }
        ;
    }
}
