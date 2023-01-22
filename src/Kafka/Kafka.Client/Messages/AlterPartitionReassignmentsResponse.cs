using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using ReassignablePartitionResponse = Kafka.Client.Messages.AlterPartitionReassignmentsResponse.ReassignableTopicResponse.ReassignablePartitionResponse;
using ReassignableTopicResponse = Kafka.Client.Messages.AlterPartitionReassignmentsResponse.ReassignableTopicResponse;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The top-level error code, or 0 if there was no error.</param>
    /// <param name="ErrorMessageField">The top-level error message, or null if there was no error.</param>
    /// <param name="ResponsesField">The responses to topics to reassign.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterPartitionReassignmentsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ErrorMessageField,
        ImmutableArray<ReassignableTopicResponse> ResponsesField
    ) : Response(45)
    {
        public static AlterPartitionReassignmentsResponse Empty { get; } = new(
            default(int),
            default(short),
            default(string?),
            ImmutableArray<ReassignableTopicResponse>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name</param>
        /// <param name="PartitionsField">The responses to partitions to reassign</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record ReassignableTopicResponse (
            string NameField,
            ImmutableArray<ReassignablePartitionResponse> PartitionsField
        )
        {
            public static ReassignableTopicResponse Empty { get; } = new(
                "",
                ImmutableArray<ReassignablePartitionResponse>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The error code for this partition, or 0 if there was no error.</param>
            /// <param name="ErrorMessageField">The error message for this partition, or null if there was no error.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record ReassignablePartitionResponse (
                int PartitionIndexField,
                short ErrorCodeField,
                string? ErrorMessageField
            )
            {
                public static ReassignablePartitionResponse Empty { get; } = new(
                    default(int),
                    default(short),
                    default(string?)
                );
            };
        };
    };
}