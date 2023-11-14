using Kafka.Client.Extensions.DependencyInjection;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Serialization;
using KafkaGraphQL.InputTypes;
using KafkaGraphQL.Model;
using KafkaGraphQL.Queries;
using KafkaGraphQL.Types;
using System.Collections.Immutable;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddKafkaClient(builder.Configuration)
    .AddKafkaStreamWriter(
        "test",
        StringSerializer.Instance,
        StringSerializer.Instance
    )
    .AddKafkaStreamReader(
        "test",
        StringDeserializer.Instance,
        StringDeserializer.Instance
    )
;

builder.Services
    .AddGraphQLServer()
    .AddInMemorySubscriptions()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()

    .AddType<TopicType>()
    .AddType<PartitionType>()
    .AddType<ErrorType>()
    .AddType<CreateTopicResultType>()
    .AddType<DeleteTopicResultType>()
    .AddType<TopicPartitionOffsetType>()

    .AddType<ReplicaAssigmentInputType>()
    .AddType<ConfigInputType>()
    .AddType<GetTopicOptionsInputType>()
    .AddType<CreateTopicDefinitionInputType>()

    .AddTypeConverter<string, Topic>(
        t => new(Guid.Empty, new TopicName(t))
    )
    .AddTypeConverter<TopicName, string>(
        t => t.Value ?? ""
    )
    .AddTypeConverter<TopicId, Guid>(
        t => t.Value
    )
    .AddTypeConverter<Guid, TopicId>(
        t => new(t)
    )
    .AddTypeConverter<Topic, string>(
        t => t.TopicName.Value ?? ""
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
    .AddTypeConverter<Offset, long>(
        t => t.Value
    )
    .AddTypeConverter<long, Offset>(
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
    .AddTypeConverter<Timestamp, DateTimeOffset>(
        t => t
    )
    .AddTypeConverter<DateTimeOffset, Timestamp>(
        t => Timestamp.Created(t)
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

app.UseRouting();
app.UseWebSockets();
app.MapGraphQL();

app.Run();