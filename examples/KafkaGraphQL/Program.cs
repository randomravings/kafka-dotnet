using Kafka.Client.Extensions.DependencyInjection;
using Kafka.Common.Model;
using KafkaGraphQL.InputTypes;
using KafkaGraphQL.Queries;
using KafkaGraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddKafkaClient(builder.Configuration);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()

    .AddType<TopicType>()
    .AddType<PartitionType>()
    .AddType<ErrorType>()
    .AddType<GetTopicOptionsInputType>()

    .AddTypeConverter<TopicId, Guid>(
        t => t.Value
    )
    .AddTypeConverter<Guid, TopicId>(
        t => new(t)
    )
    .AddTypeConverter<TopicName, string>(
        t => t.Value ?? ""
    )
    .AddTypeConverter<string, TopicName>(
        t => new(t)
    )
    .AddTypeConverter<Partition, int>(
        t => t.Value
    )
    .AddTypeConverter<int, Partition>(
        t => new(t)
    )
    .AddTypeConverter<ClusterNodeId, int>(
        t => t.Value
    )
    .AddTypeConverter<int, ClusterNodeId>(
        t => new(t)
    )
    .AddTypeConverter<Epoch, int>(
        t => t.Value
    )
    .AddTypeConverter<int, Epoch>(
        t => new(t)
    )
;
        


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGraphQL();

app.Run();