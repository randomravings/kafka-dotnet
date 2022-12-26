using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using PartitionResult = Kafka.Client.Messages.ElectLeadersResponse.ReplicaElectionResult.PartitionResult;
using ReplicaElectionResult = Kafka.Client.Messages.ElectLeadersResponse.ReplicaElectionResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The top level response error code.</param>
    /// <param name="ReplicaElectionResultsField">The election results, or an empty array if the requester did not have permission and the request asks for all partitions.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ElectLeadersResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<ReplicaElectionResult> ReplicaElectionResultsField
    ) : Response(43)
    {
        public static ElectLeadersResponse Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<ReplicaElectionResult>.Empty
        );
        /// <summary>
        /// <param name="TopicField">The topic name</param>
        /// <param name="PartitionResultField">The results for each partition</param>
        /// </summary>
        public sealed record ReplicaElectionResult (
            string TopicField,
            ImmutableArray<PartitionResult> PartitionResultField
        )
        {
            public static ReplicaElectionResult Empty { get; } = new(
                "",
                ImmutableArray<PartitionResult>.Empty
            );
            /// <summary>
            /// <param name="PartitionIdField">The partition id</param>
            /// <param name="ErrorCodeField">The result error, or zero if there was no error.</param>
            /// <param name="ErrorMessageField">The result message, or null if there was no error.</param>
            /// </summary>
            public sealed record PartitionResult (
                int PartitionIdField,
                short ErrorCodeField,
                string? ErrorMessageField
            )
            {
                public static PartitionResult Empty { get; } = new(
                    default(int),
                    default(short),
                    default(string?)
                );
            };
        };
    };
}