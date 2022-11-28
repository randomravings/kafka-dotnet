using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using AlterReplicaLogDir = Kafka.Client.Messages.AlterReplicaLogDirsRequest.AlterReplicaLogDir;
using AlterReplicaLogDirTopic = Kafka.Client.Messages.AlterReplicaLogDirsRequest.AlterReplicaLogDir.AlterReplicaLogDirTopic;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="DirsField">The alterations to make for each directory.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterReplicaLogDirsRequest (
        ImmutableArray<AlterReplicaLogDir> DirsField
    ) : Request(34)
    {
        public static AlterReplicaLogDirsRequest Empty { get; } = new(
            ImmutableArray<AlterReplicaLogDir>.Empty
        );
        /// <summary>
        /// <param name="PathField">The absolute directory path.</param>
        /// <param name="TopicsField">The topics to add to the directory.</param>
        /// </summary>
        public sealed record AlterReplicaLogDir (
            string PathField,
            ImmutableArray<AlterReplicaLogDirTopic> TopicsField
        )
        {
            public static AlterReplicaLogDir Empty { get; } = new(
                "",
                ImmutableArray<AlterReplicaLogDirTopic>.Empty
            );
            /// <summary>
            /// <param name="NameField">The topic name.</param>
            /// <param name="PartitionsField">The partition indexes.</param>
            /// </summary>
            public sealed record AlterReplicaLogDirTopic (
                string NameField,
                ImmutableArray<int> PartitionsField
            )
            {
                public static AlterReplicaLogDirTopic Empty { get; } = new(
                    "",
                    ImmutableArray<int>.Empty
                );
            };
        };
    };
}