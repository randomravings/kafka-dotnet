using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using TxnOffsetCommitResponsePartition = Kafka.Client.Messages.TxnOffsetCommitResponse.TxnOffsetCommitResponseTopic.TxnOffsetCommitResponsePartition;
using TxnOffsetCommitResponseTopic = Kafka.Client.Messages.TxnOffsetCommitResponse.TxnOffsetCommitResponseTopic;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TopicsField">The responses for each topic.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record TxnOffsetCommitResponse (
        int ThrottleTimeMsField,
        ImmutableArray<TxnOffsetCommitResponseTopic> TopicsField
    ) : Response(28)
    {
        public static TxnOffsetCommitResponse Empty { get; } = new(
            default(int),
            ImmutableArray<TxnOffsetCommitResponseTopic>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">The responses for each partition in the topic.</param>
        /// </summary>
        public sealed record TxnOffsetCommitResponseTopic (
            string NameField,
            ImmutableArray<TxnOffsetCommitResponsePartition> PartitionsField
        )
        {
            public static TxnOffsetCommitResponseTopic Empty { get; } = new(
                "",
                ImmutableArray<TxnOffsetCommitResponsePartition>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
            /// </summary>
            public sealed record TxnOffsetCommitResponsePartition (
                int PartitionIndexField,
                short ErrorCodeField
            )
            {
                public static TxnOffsetCommitResponsePartition Empty { get; } = new(
                    default(int),
                    default(short)
                );
            };
        };
    };
}