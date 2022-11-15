using CommandLine;
using Kafka.Cli.AdminClient.Verbs;
using Kafka.Client.Clients.Admin;
using Kafka.Client.Clients.Admin.Model;
using System.Collections.Immutable;

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
                using var adminClient = (IAdminClient)new Client.Clients.Admin.AdminClient(new AdminClientConfig
                {
                    BootstrapServers = verb.BootstrapServer
                });
                var result = await adminClient.ListTopics(
                    new(
                        5000,
                        true
                    ),
                    cancellationToken
                );
                foreach (var topic in result.Topics)
                    Console.WriteLine($"{{topic:{topic.Key.Value},id:{Convert.ToBase64String(topic.Value.TopicId.ToByteArray())},internal:{topic.Value.IsInternal}}}");
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
                using var adminClient = (IAdminClient)new Client.Clients.Admin.AdminClient(new AdminClientConfig
                {
                    BootstrapServers = verb.BootstrapServer
                });
                var result = await adminClient.CreateTopic(
                    new(
                        5000,
                        false,
                        true,
                        new[]
                        {
                            new CreateTopicsOptions.NewTopic(
                                verb.Topic,
                                1,
                                null,
                                ImmutableSortedDictionary<int, ImmutableArray<int>>.Empty,
                                ImmutableSortedDictionary<string, string?>.Empty
                            )
                        }.ToImmutableArray()
                    ),
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
