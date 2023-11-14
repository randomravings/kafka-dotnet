using Kafka.Client.Extensions.DependencyInjection;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using KafkaGraphQL.InputTypes;
using KafkaGraphQL.Model;
using KafkaGraphQL.Queries;
using KafkaGraphQL.Types;
using System.Collections.Immutable;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddKafkaClient(builder.Configuration);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()

    .AddType<TopicType>()
    .AddType<PartitionType>()
    .AddType<ErrorType>()
    .AddType<CreateTopicResultType>()

    .AddType<ReplicaAssigmentInputType>()
    .AddType<ConfigInputType>()
    .AddType<GetTopicOptionsInputType>()
    .AddType<CreateTopicDefinitionInputType>()

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
    .AddTypeConverter<List<ReplicaAssignment>, IReadOnlyDictionary<Partition, IReadOnlySet<ClusterNodeId>>>(
        t => t.ToImmutableSortedDictionary(
            k => new Partition(k.Partition),
            v => (IReadOnlySet<ClusterNodeId>)v.ReplicaAssigments
                .Select(r => new ClusterNodeId(r))
                .ToImmutableSortedSet(ClusterNodeIdCompare.Instance)
        )
    )
    .AddTypeConverter<List<ConfigItem>, IReadOnlyDictionary<string, string?>>(
        t => t.ToImmutableSortedDictionary(
            k => k.Key ?? "",
            v => v.Value
        )
    );


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGraphQL();

app.Run();