using Kafka.Client.Extensions.DependencyInjection;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Serialization.Nullable;
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
        StringSerde.Serializer,
        StringSerde.Serializer
    )
    .AddKafkaStreamReader(
        StringSerde.Deserializer,
        StringSerde.Deserializer
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
    .AddType<RecordType>()

    .AddType<ReplicaAssigmentInputType>()
    .AddType<ConfigInputType>()
    .AddType<GetTopicOptionsInputType>()
    .AddType<CreateTopicDefinitionInputType>()
    .AddType<RecordInputType>()

    .AddTypeConverter<string, Topic>(
        t => new(Guid.Empty, new TopicName(t))
    )
    .AddTypeConverter<Topic, string>(
        t => t.TopicName.Value ?? ""
    )
    .AddTypeConverter<TopicName, string>(
        t => t.Value ?? ""
    )
    .AddTypeConverter<string, TopicName>(
        t => new(t)
    )
    .AddTypeConverter<TopicId, Guid>(
        t => t.Value
    )
    .AddTypeConverter<Guid, TopicId>(
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
    .AddTypeConverter<NodeId, int>(
        t => t.Value
    )
    .AddTypeConverter<int, NodeId>(
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
    .AddTypeConverter<List<ReplicaAssignment>, IReadOnlyDictionary<Partition, IReadOnlySet<NodeId>>>(
        t => t.ToImmutableSortedDictionary(
            k => new Partition(k.Partition),
            v => (IReadOnlySet<NodeId>)v.ReplicaAssigments
                .Select(r => new NodeId(r))
                .ToImmutableSortedSet(NodeIdCompare.Instance)
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