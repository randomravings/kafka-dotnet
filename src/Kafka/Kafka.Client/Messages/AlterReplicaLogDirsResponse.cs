using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using AlterReplicaLogDirPartitionResult = Kafka.Client.Messages.AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult.AlterReplicaLogDirPartitionResult;
using AlterReplicaLogDirTopicResult = Kafka.Client.Messages.AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResultsField">The results for each topic.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterReplicaLogDirsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<AlterReplicaLogDirTopicResult> ResultsField
    ) : Response(34)
    {
        public static AlterReplicaLogDirsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<AlterReplicaLogDirTopicResult>.Empty
        );
        /// <summary>
        /// <param name="TopicNameField">The name of the topic.</param>
        /// <param name="PartitionsField">The results for each partition.</param>
        /// </summary>
        public sealed record AlterReplicaLogDirTopicResult (
            string TopicNameField,
            ImmutableArray<AlterReplicaLogDirPartitionResult> PartitionsField
        )
        {
            public static AlterReplicaLogDirTopicResult Empty { get; } = new(
                "",
                ImmutableArray<AlterReplicaLogDirPartitionResult>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
            /// </summary>
            public sealed record AlterReplicaLogDirPartitionResult (
                int PartitionIndexField,
                short ErrorCodeField
            )
            {
                public static AlterReplicaLogDirPartitionResult Empty { get; } = new(
                    default(int),
                    default(short)
                );
            };
        };
    };
}