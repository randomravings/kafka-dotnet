using CommandLine;
using Kafka.Cli.AdminClient.Verbs;
using Kafka.Client.Clients.Admin;
using Kafka.Client.Clients.Admin.Model;

namespace Kafka.Cli.AdminClient.Cmd
{
    internal static class Topics
    {
        public static async ValueTask<int> Parse(
            IEnumerable<string> args,
            CancellationToken cancellationToken
        ) =>
            await Parser.Default.ParseArguments<VerbTopicsList, VerbTopicsCreate>(args)
                .MapResult(
                    (VerbTopicsList verb) => List(verb, cancellationToken),
                    (VerbTopicsCreate verb) => Create(verb, cancellationToken),
                    errs => new ValueTask<int>(-1)
                )
            ;

        public static async ValueTask<int> List(
            VerbTopicsList verb,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var adminClientConfig = new AdminClientConfig
                {
                    BootstrapServers = verb.BootstrapServer
                };
                using var adminClient = (IAdminClient)new Client.Clients.Admin.AdminClient(adminClientConfig);
                var options = new ListTopicsOptionsBuilder(adminClientConfig)
                    .Version(verb.ApiVersion)
                    .IncludeInternal(verb.IncludeInternal)
                    .Build()
                ;
                var result = await adminClient.ListTopics(
                    options,
                    cancellationToken
                );
                foreach (var topic in result.Topics)
                    Console.WriteLine($"{{topic:{topic.Key.Name},id:{Convert.ToBase64String(topic.Key.Id.ToByteArray())},internal:{topic.Value.IsInternal}}}");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public static async ValueTask<int> Create(
            VerbTopicsCreate verb,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var adminClientConfig = new AdminClientConfig
                {
                    BootstrapServers = verb.BootstrapServer
                };
                using var adminClient = (IAdminClient)new Client.Clients.Admin.AdminClient(adminClientConfig);
                var replicaAssinment = new Dictionary<int, int[]>();
                var partitionReplicaAssignments = verb.ReplicaAssignment.Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach(var partitionReplicaAssignment in partitionReplicaAssignments)
                {
                    var kv = partitionReplicaAssignment.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    var key = int.Parse(kv[0]);
                    var value = kv[1].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray();
                    replicaAssinment.Add(key, value);
                }
                var options = new CreateTopicsOptionsBuilder(adminClientConfig)
                    .Version(verb.ApiVersion)
                    .NewTopic(b => b
                        .Name(verb.Topic)
                        .NumPartitions(verb.PartitionCount)
                        .ReplicasAssignments(replicaAssinment)
                        .Build()
                    )
                    .Build()
                ;
                var result = await adminClient.CreateTopics(
                    options,
                    cancellationToken
                );
                foreach (var topic in result.CreatedTopics)
                    Console.WriteLine(topic);
                foreach (var error in result.ErrorTopics)
                    Console.WriteLine(error);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
    }
}
