using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterReplicaLogDirsRequest (
        AlterReplicaLogDirsRequest.AlterReplicaLogDir[] DirsField
    )
    {
        public sealed record AlterReplicaLogDir (
            string PathField,
            AlterReplicaLogDirsRequest.AlterReplicaLogDir.AlterReplicaLogDirTopic[] TopicsField
        )
        {
            public sealed record AlterReplicaLogDirTopic (
                string NameField,
                int[] PartitionsField
            );
        };
    };
}
