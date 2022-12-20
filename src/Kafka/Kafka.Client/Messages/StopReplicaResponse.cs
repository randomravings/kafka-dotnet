using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using StopReplicaPartitionError = Kafka.Client.Messages.StopReplicaResponse.StopReplicaPartitionError;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The top-level error code, or 0 if there was no top-level error.</param>
    /// <param name="PartitionErrorsField">The responses for each partition.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record StopReplicaResponse (
        short ErrorCodeField,
        ImmutableArray<StopReplicaPartitionError> PartitionErrorsField
    ) : Response(5)
    {
        public static StopReplicaResponse Empty { get; } = new(
            default(short),
            ImmutableArray<StopReplicaPartitionError>.Empty
        );
        /// <summary>
        /// <param name="TopicNameField">The topic name.</param>
        /// <param name="PartitionIndexField">The partition index.</param>
        /// <param name="ErrorCodeField">The partition error code, or 0 if there was no partition error.</param>
        /// </summary>
        public sealed record StopReplicaPartitionError (
            string TopicNameField,
            int PartitionIndexField,
            short ErrorCodeField
        )
        {
            public static StopReplicaPartitionError Empty { get; } = new(
                "",
                default(int),
                default(short)
            );
        };
    };
}